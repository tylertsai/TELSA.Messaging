using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using TELSA.Messaging.LINE;
using TELSA.Messaging.LINE.Actions;
using TELSA.Messaging.LINE.Messages;
using TELSA.Messaging.LINE.Templates;

namespace TELSA.Messaging.UnitTest
{
    public class LineMessagingApiUnitTest
    {
        private readonly MessagingApiClient _messagingClient;
        private readonly string _to;
        private readonly string _replyToken;
        private readonly string _contentMessageId;
        private readonly string _roomId;
        
        public LineMessagingApiUnitTest()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var lineSection = config.GetSection("LINE");

            _messagingClient = new MessagingApiClient(lineSection["ChannelAccessToken"]);
            _to = lineSection["ToUserId"];
            _replyToken = lineSection["ReplyToken"];
            _contentMessageId = lineSection["ContentMessageId"];
            _roomId = lineSection["RoomId"];
        }

        [SetUp]
        public void Setup()
        {
        }
        
        #region Message

        [Test]
        public async Task TestPushTextMessage()
        {
            var retryKey = Guid.NewGuid();

            await _messagingClient.SendPushMessageAsync(
                new PushMessage(
                    _to,
                    new List<IMessage>
                    {
                        new TextMessage("This are push messages."),
                        new TextMessage("$ LINE emoji $")
                        {
                            Emojis = new List<Emoji>
                            {
                                new Emoji(0, "5ac1bfd5040ab15980c9b435", "001"),
                                new Emoji(13, "5ac1bfd5040ab15980c9b435", "002")
                            }
                        }
                    }
                ),
                retryKey
            );

            Assert.Pass();
        }

        [Test]
        public async Task TestSender()
        {
            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("Change icon and display name.")
                    {
                        Sender = new Sender
                        {
                            Name = "faceoofbook",
                            IconUrl = "https://lh3.googleusercontent.com/rkBi-WHAI-dzkAIYjGBSMUToUoi6SWKoy9Fu7QybFb6KVOJweb51NNzokTtjod__MzA"
                        }
                    }
                }
            ));

            Assert.Pass();
        }

        [Test]
        public async Task TestQuickReply()
        {
            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("Choose one Quick Reply action.")
                    {
                        QuickReply = new QuickReply(new List<QuickReplyButton>
                        {
                            new QuickReplyButton(new PostbackAction("data", "Postback")
                            {
                                DisplayText = "Postback 'data'."
                            }),
                            new QuickReplyButton(new MessageAction("message", "Message"))
                            {
                                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/41/LINE_logo.svg/1200px-LINE_logo.svg.png"
                            },
                            new QuickReplyButton(new DatetimePickerAction("datetime", ActionMode.Datetime, "Datetime")
                            {
                                Min = "2016-09-05t09:00",
                                Max = "2020-09-11t18:00",
                                Initial = "2020-06-30t12:41"
                            }),
                            new QuickReplyButton(new CameraAction("Take a photo")),
                            new QuickReplyButton(new CameraRollAction("Pick a photo")),
                            new QuickReplyButton(new LocationAction("Send GPS location"))
                        })
                    }
                }
            ));

            Assert.Pass();
        }

        [Test]
        public async Task TestReplyMessage()
        {
            await _messagingClient.SendReplyMessageAsync(new ReplyMessage(
                _replyToken,
                new List<IMessage>
                {
                    new TextMessage("This is a reply message.")
                }
            ));

            Assert.Pass();
        }

        [Test]
        public async Task TestMulticastMessage()
        {
            var retryKey = Guid.NewGuid();

            await _messagingClient.SendMulticastMessageAsync(
                new MulticastMessage(
                    new List<string> {_to, _to},
                    new List<IMessage>
                    {
                        new TextMessage("This is a multicast message.")
                    }
                ),
                retryKey
            );

            Assert.Pass();
        }

        [Test]
        public async Task TestBroadcastMessage()
        {
            var retryKey = Guid.NewGuid();

            await _messagingClient.SendBroadcastMessageAsync(
                new BroadcastMessage(
                    new List<IMessage>
                    {
                        new TextMessage("This is a broadcast message.")
                    }
                ),
                retryKey
            );

            Assert.Pass();
        }

        [Test]
        public async Task TestNarrowcastMessage()
        {
            var retryKey = Guid.NewGuid();

            var sendNarrowcastMessageResponse = await _messagingClient.SendNarrowcastMessageAsync(
                new NarrowcastMessage(
                    new List<IMessage>
                    {
                        new TextMessage("This is a narrowcast message.")
                    }
                ),
                retryKey
            );

            var response = await _messagingClient.GetNarrowcastMessageStatusAsync(sendNarrowcastMessageResponse.Headers.RequestId);
            var requestProgress = await response.ReadContentAsync();

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("Get narrowcast message status\n" +
                                    $"Phase: {requestProgress.Phase}\n" +
                                    $"Success Count: {requestProgress.SuccessCount}\n" +
                                    $"Failure Count: {requestProgress.FailureCount}\n" +
                                    $"Target Count: {requestProgress.TargetCount}\n" +
                                    $"Failed Description: {requestProgress.FailedDescription}\n" +
                                    $"Error Code: {requestProgress.ErrorCode}\n")
                }
            ));

            Assert.Pass();
        }

        [Test]
        public async Task TestGetContent()
        {
            var messageId = _contentMessageId;
            var response = await _messagingClient.GetContentAsync(messageId);
            var fileExtension = response.HttpResponseMessage.Content.Headers.ContentType.MediaType.Split('/')[1];

            await using (var fileStream = new FileStream($"{messageId}.{fileExtension}", FileMode.Create))
            {
                await response.HttpResponseMessage.Content.CopyToAsync(fileStream);
            }

            Assert.Pass();
        }

        [Test]
        public async Task TestGetTheTargetLimitForAdditionalMessages()
        {
            var response = await _messagingClient.GetTheTargetLimitForAdditionalMessagesAsync();
            var messageQuota = await response.ReadContentAsync();

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("The target limit for additional messages\n" +
                                    $"Quota type: {messageQuota.Type}\n" +
                                    $"Quota value: {messageQuota.Value}")
                }
            ));
        }

        [Test]
        public async Task TestGetNumberOfMessagesSentThisMonth()
        {
            var response = await _messagingClient.GetNumberOfMessagesSentThisMonthAsync();
            var sentStatistic = await response.ReadContentAsync();
            
            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage($"Number of messages sent this month: {sentStatistic.TotalUsage}")
                }
            ));
            
            Assert.Pass();
        }

        [Test]
        public async Task TestGetNumberOfSentReplyMessages()
        {
            var date = new DateTime(2020, 8, 23);
            var response = await _messagingClient.GetNumberOfSentReplyMessagesAsync(date);
            var sentMessagesInfo = await response.ReadContentAsync();

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("Number of reply messages sent\n" +
                                    $"Date: {date:yyyy-MM-dd}\n" +
                                    $"Status: {sentMessagesInfo.Status}\n" +
                                    $"Success: {sentMessagesInfo.Success}")
                }
            ));
            
            Assert.Pass();
        }

        [Test]
        public async Task TestGetNumberOfSentPushMessages()
        {
            var date = new DateTime(2020, 8, 23);
            var response = await _messagingClient.GetNumberOfSentPushMessagesAsync(date);
            var sentMessagesInfo = await response.ReadContentAsync();

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("Number of push messages sent\n" +
                                    $"Date: {date:yyyy-MM-dd}\n" +
                                    $"Status: {sentMessagesInfo.Status}\n" +
                                    $"Success: {sentMessagesInfo.Success}")
                }
            ));
 
            Assert.Pass();
        }
        [Test]
        public async Task TestGetNumberOfSentMulticastMessages()
        {
            var date = new DateTime(2020, 8, 29);
            var response = await _messagingClient.GetNumberOfSentMulticastMessagesAsync(date);
            var sentMessagesInfo = await response.ReadContentAsync();

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("Number of multicast messages sent\n" +
                                    $"Date: {date:yyyy-MM-dd}\n" +
                                    $"Status: {sentMessagesInfo.Status}\n" +
                                    $"Success: {sentMessagesInfo.Success}")
                }
            ));
            
            Assert.Pass();
        }
        
        [Test]
        public async Task TestGetNumberOfSentBroadcastMessages()
        {
            var date = new DateTime(2020, 8, 29);
            var response = await _messagingClient.GetNumberOfSentBroadcastMessagesAsync(date);
            var sentMessagesInfo = await response.ReadContentAsync();

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("Number of broadcast messages sent\n" +
                                    $"Date: {date:yyyy-MM-dd}\n" +
                                    $"Status: {sentMessagesInfo.Status}\n" +
                                    $"Success: {sentMessagesInfo.Success}")
                }
            ));

            Assert.Pass();
        }
        
        #endregion
        
        #region Users

        [Test]
        public async Task TestGetProfile()
        {
            var response = await _messagingClient.GetProfileAsync(_to);
            var userProfile = await response.ReadContentAsync();

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TemplateMessage(
                        "Your User Profile",
                        new ButtonsTemplate(
                            userProfile.DisplayName,
                            new List<IAction>
                            {
                                new MessageAction(userProfile.Language, "See language")
                            })
                        {
                            Title = "My Profile",
                            ThumbnailImageUrl = userProfile.PictureUrl,
                            Text = $"{userProfile.DisplayName}\n" +
                                   $"{userProfile.StatusMessage}"
                        }
                    )
                })
            );
            
            Assert.Pass();
        }
        
        [Test]
        public async Task TestGetFollowerIds()
        {
            var start = string.Empty;
            var followersCount = 0;

            while (true)
            {
                var response = await _messagingClient.GetFollowerIdsAsync(start);
                var followerIds = await response.ReadContentAsync();
                
                start = followerIds.Next;
                followersCount += followerIds.UserIds.Count();

                if (string.IsNullOrWhiteSpace(followerIds.Next))
                    break;
            }
            
            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage($"Total Followers: {followersCount}")
                })
            );
            
            Assert.Pass();
        }
        
        #endregion
        
        #region Chat Room

        [Test]
        public async Task TestGetNumberOfUsersInARoom()
        {
            var response = await _messagingClient.GetNumberOfUsersInARoomAsync(_roomId);
            var numberOfUsers = await response.ReadContentAsync();

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _roomId,
                new List<IMessage>
                {
                    new TextMessage($"Total {numberOfUsers.Count} user(s) in the room.")
                })
            );

            Assert.Pass();
        }
        
        [Test]
        public async Task TestGetRoomMemberUserIds()
        {
            var start = string.Empty;
            var memberCount = 0;

            while (true)
            {
                var response = await _messagingClient.GetRoomMemberUserIdsAsync(_roomId, start);
                var memberUserIds = await response.ReadContentAsync();
                
                start = memberUserIds.Next;
                memberCount += memberUserIds.MemberIds.Count();

                if (string.IsNullOrWhiteSpace(memberUserIds.Next))
                    break;
            }
            
            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _roomId,
                new List<IMessage>
                {
                    new TextMessage($"Total {memberCount} member(s) in the room.")
                })
            );
            
            Assert.Pass();
        }

        [Test]
        public async Task TestGetRoomMemberProfile()
        {
            var response = await _messagingClient.GetRoomMemberProfileAsync(_roomId, _to);
            var memberProfile = await response.ReadContentAsync();

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _roomId,
                new List<IMessage>
                {
                    new TemplateMessage(
                        "Member Profile",
                        new ButtonsTemplate(
                            memberProfile.DisplayName,
                            new List<IAction>
                            {
                                new PostbackAction("ok", "OK")
                            })
                        {
                            Title = "Member Profile",
                            ThumbnailImageUrl = memberProfile.PictureUrl,
                            Text = $"{memberProfile.DisplayName}"
                        }
                    )
                })
            );
            
            Assert.Pass();
        }
        
        [Test]
        public async Task TestLeaveRoom()
        {
            await _messagingClient.LeaveRoomAsync(_roomId);

            Assert.Pass();
        }
        
        #endregion
    }
}

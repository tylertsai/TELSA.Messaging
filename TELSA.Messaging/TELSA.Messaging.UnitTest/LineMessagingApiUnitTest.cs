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

        public LineMessagingApiUnitTest()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var lineSection = config.GetSection("LINE");

            _messagingClient = new MessagingApiClient(lineSection["ChannelAccessToken"]);
            _to = lineSection["ToUserId"];
            _replyToken = lineSection["ReplyToken"];
            _contentMessageId = lineSection["ContentMessageId"];
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

            await _messagingClient.SendBroadcastMessage(
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

            var status = await _messagingClient.GetNarrowcastMessageStatusAsync(sendNarrowcastMessageResponse.Headers.RequestId);

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("Get narrowcast message status\n" +
                                    $"Phase: {status.Phase}\n" +
                                    $"Success Count: {status.SuccessCount}\n" +
                                    $"Failure Count: {status.FailureCount}\n" +
                                    $"Target Count: {status.TargetCount}\n" +
                                    $"Failed Description: {status.FailedDescription}\n" +
                                    $"Error Code: {status.ErrorCode}\n")
                }
            ));

            Assert.Pass();
        }

        [Test]
        public async Task TestGetContent()
        {
            var messageId = _contentMessageId;
            var response = await _messagingClient.GetContent(messageId);
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
            var response = await _messagingClient.GetTheTargetLimitForAdditionalMessages();

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("The target limit for additional messages\n" +
                                    $"Quota type: {response.Type}\n" +
                                    $"Quota value: {response.Value}")
                }
            ));
        }

        [Test]
        public async Task TestGetNumberOfMessagesSentThisMonth()
        {
            var value = await _messagingClient.GetNumberOfMessagesSentThisMonth();

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage($"Number of messages sent this month: {value}")
                }
            ));
            
            Assert.Pass();
        }

        [Test]
        public async Task TestGetNumberOfSentReplyMessages()
        {
            var date = new DateTime(2020, 8, 23);
            var response = await _messagingClient.GetNumberOfSentReplyMessages(date);

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("Number of reply messages sent\n" +
                                    $"Date: {date:yyyy-MM-dd}\n" +
                                    $"Status: {response.Status}\n" +
                                    $"Success: {response.Success}")
                }
            ));
            
            Assert.Pass();
        }

        [Test]
        public async Task TestGetNumberOfSentPushMessages()
        {
            var date = new DateTime(2020, 8, 23);
            var response = await _messagingClient.GetNumberOfSentPushMessages(date);

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("Number of push messages sent\n" +
                                    $"Date: {date:yyyy-MM-dd}\n" +
                                    $"Status: {response.Status}\n" +
                                    $"Success: {response.Success}")
                }
            ));
 
            Assert.Pass();
        }
        [Test]
        public async Task TestGetNumberOfSentMulticastMessages()
        {
            var date = new DateTime(2020, 8, 29);
            var response = await _messagingClient.GetNumberOfSentMulticastMessages(date);

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("Number of multicast messages sent\n" +
                                    $"Date: {date:yyyy-MM-dd}\n" +
                                    $"Status: {response.Status}\n" +
                                    $"Success: {response.Success}")
                }
            ));
            
            Assert.Pass();
        }
        
        [Test]
        public async Task TestGetNumberOfSentBroadcastMessages()
        {
            var date = new DateTime(2020, 8, 29);
            var response = await _messagingClient.GetNumberOfSentBroadcastMessages(date);

            await _messagingClient.SendPushMessageAsync(new PushMessage(
                _to,
                new List<IMessage>
                {
                    new TextMessage("Number of broadcast messages sent\n" +
                                    $"Date: {date:yyyy-MM-dd}\n" +
                                    $"Status: {response.Status}\n" +
                                    $"Success: {response.Success}")
                }
            ));

            Assert.Pass();
        }
        
        #endregion
        
        #region Users

        [Test]
        public async Task TestGetProfile()
        {
            var userProfile = await _messagingClient.GetProfile(_to);

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
                var followerIds = await _messagingClient.GetFollowerIds(start);

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
    }
}

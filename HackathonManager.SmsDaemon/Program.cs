using HackathonManager.Models;
using HackathonManager.RepositoryPattern;
using HackathonManager.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HackathonManager.SmsDaemon
{
    public class Program
    {
        private static IRepository _repo = DIContext.Context.GetMLabsMongoDbRepo();
        private static SmsRoutingConductor _conductor = new SmsRoutingConductor(_repo);
        public static void Main(string[] args)
        {
            //!SmsRoutingConductor.UnprocessedMentorRequests.IsEmpty
            var smsThread = new Thread(() => {
                while (2 > 1)
                {
                    if (!SmsRoutingConductor.UnprocessedMentorRequests.IsEmpty)
                    {
                        _conductor.ProcessQueues();
                        //bool didDequeue = SmsRoutingConductor
                        //                    .UnprocessedMentorRequests
                        //                    .TryDequeue(out MentorRequest request);
                    }

                    if (!SmsRoutingConductor.InboundMessages.IsEmpty)
                    {
                        var f = 0;
                    }

                    Thread.Sleep(5000);
                }
            });
            smsThread.Start();
            #region Sudo Code
            /*
        in ApplicationStart in your MVC project...

        var smsThread = new Thread(() => {

            while(someCondition)

            {



                ...mySMSClass.ProcessMessages();

                Thread.Sleep(10);

            }

        });

        In a controller class....

        ActionResult ReceivedSMS(someParams)

        {

            mySMSClass.IncomingMessages.Add(someParams.textMessage);

        }

        Meanwhile in mySMSClass....

        public static List<TextMessage> IncomingMessages = new List<TextMessage>();

        public void ProcessMessages()

        {

            for(...)

            {

                DoSomeStuff(IncomingMessages[i]);

            }

        }
             */
            #endregion
        }
    }
}

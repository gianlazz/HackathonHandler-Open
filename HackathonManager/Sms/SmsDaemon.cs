using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonManager.Sms
{
    class SmsDaemon
    {
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
    }
}

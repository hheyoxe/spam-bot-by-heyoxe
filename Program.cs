using System;
using System.Windows.Forms;
using System.Threading;

namespace ExeExeExe
{
    internal class Program
    {
        public static bool textSwitch2 = false;
        public static bool textSwitch = true;
        public static bool isRunning = true;
        public static void Main(string[] args)
        {
            Thread tid1 = new Thread(new ThreadStart(writeLines));
            Thread tid2 = new Thread(new ThreadStart(breakKey));
            tid1.Start();
            tid2.Start();
            breakKey();
        }

        private static void writeLines()
        {
            int Timer = 2524;
            Console.WriteLine("Enter Text.....");
            string message = Console.ReadLine();
            //string message2 = Console.ReadLine();
            //string message3 = Console.ReadLine();

            while (textSwitch)
            {
                if (!isRunning) { break; }
                Thread.Sleep(Timer);
                if (!isRunning) { break; }
                SendKeys.SendWait("{A}");
                SendKeys.SendWait("~");
                SendKeys.SendWait("YourtextHere or message here");
                SendKeys.SendWait("~");
                textSwitch = false;
                while (!textSwitch)
                {
                    if (!isRunning) { break; }
                    Thread.Sleep(Timer);
                    if (!isRunning) { break; }
                    SendKeys.SendWait("{D}");
                    SendKeys.SendWait("~");
                    SendKeys.SendWait("YourTextHere or message2 here");
                    SendKeys.SendWait("~");
                    textSwitch2 = true;
                    while (textSwitch2)
                    {
                        if (!isRunning) { break; }
                        Thread.Sleep(Timer);
                        if (!isRunning) { break; }
                        SendKeys.SendWait("~");
                        SendKeys.SendWait("YourTextHere or message3 here");
                        SendKeys.SendWait("~");
                        textSwitch2 = false;
                    }
                    Thread.Sleep(0);
                    textSwitch = true;
                }
            }


        }

        private static void breakKey()
        {
            while (true)
            {
                if(Console.ReadKey().Key == ConsoleKey.X)
                {
                    Console.WriteLine("BREAK");
                    isRunning = false;
                    
                }
            }

        }
    }
}

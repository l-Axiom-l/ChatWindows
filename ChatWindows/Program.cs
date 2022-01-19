using System;
using System.Net;
using System.Threading;

namespace ChatProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Chat chat = new Chat();
            LOOP:
            Console.WriteLine("What do you want to do?");
            switch (Console.ReadLine())
            {
                default: goto LOOP;

                case "Server":
                    Console.WriteLine("Type the ServerIP");
                    chat.ChangeServerIP(Console.ReadLine());
                    Console.WriteLine("Activating Server");
                    Thread threadServer = new Thread(chat.StartServer);
                    threadServer.Start();
                    goto LOOP;


                case "Client":
                    Console.WriteLine("Type the ClientIP");
                    chat.ChangeClientIP(Console.ReadLine());
                    Console.WriteLine("Activating Client");
                    Thread threadClient = new Thread(chat.StartClient);
                    threadClient.Start();
                    goto LOOP;

                case "Send":
                    Console.WriteLine("Type your Message");
                    chat.SendMessage(Console.ReadLine());
                    goto LOOP;

                case "SetIP":
                    Console.WriteLine("Type the ServerIP");
                    chat.ChangeServerIP(Console.ReadLine());
                    Console.WriteLine("Type the ClientIP");
                    chat.ChangeClientIP(Console.ReadLine());
                    goto LOOP;

                case "GetIP":
                    string hostName = Dns.GetHostName(); // Retrive the Name of HOST
                    string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                    Console.WriteLine(myIP);
                    goto LOOP;

                case "Update":
                    chat.Update();
                    goto LOOP;

                case "Quit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

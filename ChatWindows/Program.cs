using System;
using System.Net;
using System.Threading;

namespace ChatProgram
{
    public class Program
    {

        enum Color { Yellow = 1, Blue = 2, Green = 3 };
        public static void Main(string[] args)
        {
            Chat chat = new Chat();
            WriteConsole("If you use the Program for the first time type \"Help\" for a List of Commands", ConsoleColor.Red);
        LOOP:
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Type your Command");
            Console.ResetColor();
            switch (Console.ReadLine())
            {
                default: goto LOOP;

                case "Server":
                    WriteConsole("Type the ServerIP", ConsoleColor.Blue);
                    chat.ChangeServerIP(Console.ReadLine());
                    WriteConsole("Activating Server", ConsoleColor.DarkBlue);
                    Thread threadServer = new Thread(chat.StartServer);
                    threadServer.Start();
                    goto LOOP;


                case "Client":
                    WriteConsole("Type the ClientIP", ConsoleColor.Blue);
                    chat.ChangeClientIP(Console.ReadLine());
                    WriteConsole("Activating Client", ConsoleColor.DarkBlue); 
                    Thread threadClient = new Thread(chat.StartClient);
                    threadClient.Start();
                    goto LOOP;

                case "Send":
                    WriteConsole("Type your Message", ConsoleColor.Blue);
                    chat.SendMessage(Console.ReadLine());
                    goto LOOP;

                case "SetIP":
                    WriteConsole("Type the ServerIP", ConsoleColor.Blue);
                    chat.ChangeServerIP(Console.ReadLine());
                    WriteConsole("Type the ClientIP", ConsoleColor.Blue);
                    chat.ChangeClientIP(Console.ReadLine());
                    goto LOOP;

                case "GetIP":
                    string hostName = Dns.GetHostName(); // Retrive the Name of HOST
                    string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                    Console.WriteLine(myIP);
                    goto LOOP;

                case "SaveHistory":
                    WriteConsole("Type the SavePath", ConsoleColor.Blue);
                    chat.SaveChatHistory(Console.ReadLine());
                    WriteConsole("Safed", ConsoleColor.DarkBlue);
                    goto LOOP;

                case "LoadHistory":
                    WriteConsole("Type the Path", ConsoleColor.Blue);
                    chat.LoadChatHistory(Console.ReadLine());
                    WriteConsole("Loaded", ConsoleColor.DarkBlue);
                    goto LOOP;

                case "Clear":
                    Console.Clear();
                    goto LOOP;

                case "Update":
                    chat.Update();
                    goto LOOP;

                case "Help":
                    WriteConsole("Server - Use this Command to start a Server", ConsoleColor.DarkCyan);
                    WriteConsole("Client - Use this Command to start a Client", ConsoleColor.DarkCyan);
                    WriteConsole("Send - Use this Command to send a Message", ConsoleColor.DarkCyan);
                    WriteConsole("SetIP (old) - Use this Command to set the Server and CLient IP", ConsoleColor.DarkCyan);
                    WriteConsole("GetIP - Use this Command to get your IP Address", ConsoleColor.DarkCyan);
                    WriteConsole("SaveHistory - Use this Command to save your Chat History", ConsoleColor.DarkCyan);
                    WriteConsole("LoadHistory - Use this Command to load your Chat History", ConsoleColor.DarkCyan);
                    WriteConsole("Clear - Use this Command to clear the Console Window", ConsoleColor.DarkCyan);
                    WriteConsole("Update - Use this Command to reload your Chat", ConsoleColor.DarkCyan);
                    WriteConsole("Quit - Use this Command to exit the Programm", ConsoleColor.DarkCyan);
                    goto LOOP;

                case "Quit":
                    Environment.Exit(0);
                    break;
            }
        }

        static void WriteConsole(string Text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(Text);
            Console.ResetColor();
        }
    }
}

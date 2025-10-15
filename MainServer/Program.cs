using MainServer;
using System;
using System.Threading;

namespace DremNet
{
    class Program
    {
        private static Server server;
        static void Main(string[] args)
        {
            Console.Title = "Server";
            server = new Server(7777,5);

            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();

            //server.Start();
            server.Start();
        }

        static void MainThread()
        {
            Console.WriteLine($"Main THread started. Running {Constants.TICKS_PER_SEC} ticks per second");

            int next_game_tick = Environment.TickCount;
            int sleep_time = 0;
            int loops = 0;

            while(server.IsRunning)
            {
                loops = 0;

                while (Environment.TickCount > next_game_tick && loops < Constants.MAX_FRAMESKIP)
                {
                    Server.ProcessMessages();
                    next_game_tick += Constants.MS_PER_TICK;
                    
                    loops++;
                }

                sleep_time = next_game_tick - Environment.TickCount;
                if(sleep_time >= 0)
                {
                    Thread.Sleep(sleep_time);
                }
                else if(loops >= Constants.MAX_FRAMESKIP)
                {
                    Console.WriteLine("Lagging behind");
                }
                
            }
        }
    }
}
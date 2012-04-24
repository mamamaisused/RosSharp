﻿using System;
using System.Threading;

namespace RosSharp.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            RosManager.MasterUri = new Uri("http://192.168.11.5:11311/");
            RosManager.HostName = "192.168.11.2";


            var node = RosManager.CreateNode("/Listener");

            var subscriber = node.CreateSubscriberAsync<RosSharp.std_msgs.String>("/chatter").Result;

            subscriber.Subscribe(
                x => Console.WriteLine(x.data),
                () => Console.WriteLine("OnCompleted!!"));

            //Console.WriteLine("Press Any Key.");
            //Console.ReadKey();

            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }

            RosManager.Dispose();
        }
    }
}

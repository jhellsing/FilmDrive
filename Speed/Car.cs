using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Speed
{
    internal class Car
    {
        double speed = 0;
        Random random = new Random();
        double AllSpeed = 0;
        double SredSpeed;
        double time = 0;
        double OstSec;
        double MsSpeed;
        double doroga;
        public Car(double road)
        {
            doroga = road;
            Thread myThread = new Thread(Speed);
            myThread.Start();
            Road();
        }
        public void Road()
        {
            for (; doroga > 0; doroga = doroga - MsSpeed)
            {
                speed = speed + random.Next(8);
                if (speed > 90)
                {
                    speed = speed - 3;
                }
                AllSpeed = AllSpeed + speed;
                time++;
                SredSpeed = AllSpeed / time;
                MsSpeed = speed / 3.6;
                Console.Clear();
                Console.WriteLine("текущая скорость: " + speed + " км/ч");
                Console.WriteLine("средняя скорость: " + Math.Round(SredSpeed, 3) + " км/ч");
                Console.WriteLine("осталось ехать: " + Math.Round(doroga, 2) + " м");
                Console.WriteLine("времени до прибытия: " + Math.Round(OstSec, 2) + " c\n");
                try
                {
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine(e);
                }
            }
            Console.WriteLine("вы разбились");
            Console.ReadLine();
        }
        public void Speed()
        {
            for (; doroga > 0; doroga = doroga - MsSpeed)
            {
                MsSpeed = speed / 3.6;
                OstSec =  doroga/ (SredSpeed / 3.6);
                try
                {
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}

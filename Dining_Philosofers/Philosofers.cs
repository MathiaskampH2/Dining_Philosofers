using System;
using System.Threading;

namespace Dining_Philosofers
{
    /// <summary>
    ///  Class Philosofers
    ///  Has the purpose of making an object of a Philosof
    ///  it has 3 properties 2 of then is a fork object a left and a right fork
    ///  it has a method RunPhilosophers which will get the Philosof object to take a left and a right fork and start eating
    /// 
    /// </summary>
    public class Philosofers
    {
        public int identity;
        public Fork left;
        public Fork right;
        Random rand = new Random();

        public Philosofers(int id, Fork left, Fork right)
        {
            this.identity = id;
            this.left = left;
            this.right = right;
        }

        public void RunPhilosophers()
        {
            
            while (true)
            {
                Console.WriteLine("Philosopher " + identity + " is waiting");
                try
                {
                    right.GetFork();
                    left.GetFork();
                    Console.WriteLine("Philosopher " + identity + " is eating");
                    Thread.Sleep(rand.Next(2000));
                }
                finally
                {
                    right.PutDownFork();
                    left.PutDownFork();
                }

            }
        }
    }
}
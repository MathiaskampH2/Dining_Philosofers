using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dining_Philosofers
{
    class Program
    {
        // variables that all my methods in main can use
        private static Thread[] Philosofers;
        static Fork[] Forks;
        private static int NumberOfPhilosofers = 5;

        // this methods purpose is to make a Thread with a Philosof object
        public static Thread MakePhilosoferThreads(int id, Fork leftFork, Fork rightFork)
        {
            Philosofers p = new Philosofers(id, leftFork, rightFork);
            return new Thread(p.RunPhilosophers);
        }

        // this method fills the ForkArray with forks and with autoIncremented id´s
        public static void FillForkArray()
        {
            Forks = new Fork[NumberOfPhilosofers];

            for (int i = 0; i < NumberOfPhilosofers; i++)
            {
                Forks[i] = new Fork(i);
            }
        }

        static void Main(string[] args)
        {
            FillForkArray();
            FillPhilosoferArrayWithForks();

            // starts each thread object in Philosofers array
            foreach (Thread thread in Philosofers)
            {
                thread.Start();
            }
            
        }

        // fills the philosofersArrayWithForks and Philosofers
        public static void FillPhilosoferArrayWithForks()
        {
            Philosofers = new Thread[NumberOfPhilosofers];



            for (int i = 0; i < NumberOfPhilosofers; i++)
            {
                // create 5 Philosof objects with an iD of i and a leftFork index and a right fork index. and add them to Philosofers array.
                Philosofers[i] = MakePhilosoferThreads(i, Forks[(i - 1 + NumberOfPhilosofers) % NumberOfPhilosofers], Forks[i]);
            }
        }
    
    }
}

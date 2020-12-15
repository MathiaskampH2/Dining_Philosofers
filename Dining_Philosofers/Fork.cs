using System;
using System.Threading;

namespace Dining_Philosofers
{
    /// <summary>
    /// Class fork
    /// Has the purpose of beeing an object of fork
    /// It has a constructor with IdNumber which will be set from Main when the forks are created
    /// It has a method GetFork which will make the fork disabled so that no other Philosof can use it
    /// It has a method PutDownFork which will make the fork enable again.
    /// </summary>
    public class Fork
    {
        public bool Taken = false;
        public int IdNumber;

        public Fork(int id)
        {
            IdNumber = id;
        }

        public void GetFork()
        {
            lock (this)
            {
                while (Taken) Monitor.Wait(this);
               
            }
        }

        public void PutDownFork()
        {
            lock (this)
            {
                Taken = false;
                Monitor.Pulse(this);

            }
        }
    }
}
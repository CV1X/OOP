using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_lucru_nr_complexe_
{
    internal class OperatiiFractii
    {
        int numarator;
        int numitor;

        public OperatiiFractii(int numarator=0, int numitor=0)
        {
            if (numitor < 0)
                this.numarator = -numarator;
            else
                this.numarator = numarator;
            if (numitor == 0)
                this.numitor = 1;
            else
                this.numitor=Math.Abs(numitor);
            //this.ireductibil();
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            if (numitor == 1)
                s.AppendFormat("{0}", numarator);
            else
                if(numarator == 0)
                s.AppendFormat("{0}");
            else
                s.AppendFormat("{0} / {1}", numitor, numarator);
            return s.ToString();

            
        }
        
        public static OperatiiFractii operator +(OperatiiFractii a, OperatiiFractii b)
        {
            return new OperatiiFractii(a.numarator*b.numitor + b.numarator*a.numitor, a.numitor*b.numitor);
        }
        public static OperatiiFractii operator -(OperatiiFractii a, OperatiiFractii b)
        {
            return new OperatiiFractii(a.numarator * b.numitor - b.numarator * a.numitor, a.numitor * b.numitor);
        }
        public static OperatiiFractii operator *(OperatiiFractii a, OperatiiFractii b)
        {
            return new OperatiiFractii(a.numarator*b.numarator, a.numitor*b.numitor);
        }
        public static OperatiiFractii operator /(OperatiiFractii a, OperatiiFractii b)
        {
            OperatiiFractii r = new OperatiiFractii(b.numitor, b.numarator);
            return a * r;
        }
        public static OperatiiFractii operator ^(OperatiiFractii a, int k)
        {
            return new OperatiiFractii((int)Math.Pow(a.numarator, k), (int)Math.Pow(a.numitor, k));
        }

        public static bool operator ==(OperatiiFractii a, OperatiiFractii b)
        {
            if(a.numarator * b.numitor== a.numitor*b.numarator) return true;
            return false;
        }
        public static bool operator !=(OperatiiFractii a, OperatiiFractii b)
        {
            if (a == b)
                return false;
            return true;
        }
        public static bool operator <(OperatiiFractii a, OperatiiFractii b)
        {
            if (a.numarator * b.numitor < a.numitor * b.numarator) 
                return true;
            return false;
        }
        public static bool operator <=(OperatiiFractii a, OperatiiFractii b)
        {
            if (a < b || a == b)
                return true;
            return false;
        }
        public static bool operator >(OperatiiFractii a, OperatiiFractii b)
        {
            if (a.numarator * b.numitor > a.numitor * b.numarator)
                return true;
            return false;
        }
        public static bool operator >=(OperatiiFractii a, OperatiiFractii b)
        {
            if (a < b || a == b)
                return true;
            return false;
        }
        static int cmmdc(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return cmmdc(b, a % b);
        }
        public void ireductibil()
        {
            int k=cmmdc(numarator,numitor);
            numarator /= k;
            numitor /= k;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_lucru_nr_complexe_
{

    public class NumarComplex
    {
        int reala;
        int imaginara;
        


        public NumarComplex(int parte_reala = 0, int parte_imaginara = 0)
        {
            this.reala = parte_reala;
            this.imaginara = parte_imaginara;
            
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            if (imaginara > 0)
                s.AppendFormat("{0:0} + {1:0}i", reala, imaginara);
            else
                if (imaginara < 0)
                s.AppendFormat("{0:0} - {1:0}i", reala, Math.Abs(imaginara));
            else
                s.AppendFormat("{0:0.00}", reala);
            return s.ToString();
        }

        public static NumarComplex operator +(NumarComplex a, NumarComplex b)
        {
            NumarComplex rezultat = new NumarComplex();
            rezultat.reala = a.reala + b.reala;
            rezultat.imaginara = a.imaginara + b.imaginara;
            return rezultat;
        }
        public static NumarComplex operator -(NumarComplex a, NumarComplex b)
        {
            NumarComplex rezultat = new NumarComplex();
            rezultat.reala = a.reala - b.reala;
            rezultat.imaginara = a.imaginara - b.imaginara;
            return rezultat;
        }
        public static NumarComplex operator *(NumarComplex a, NumarComplex b)
        {
            NumarComplex rezultat = new NumarComplex();
            rezultat.reala = (a.reala * b.reala) - (a.imaginara * b.imaginara);
            rezultat.imaginara = (a.reala * b.imaginara) + (a.imaginara * b.reala);
            return rezultat;
        }
        public static NumarComplex operator ^(NumarComplex a, int p)
        {
            NumarComplex rezultat = new NumarComplex(1, 1);
            for (int i = 0; i < p; i++)
            {
                rezultat *= a;
            }

            return rezultat;
        }
        public string trigo()
        {
            double r = Math.Sqrt(Math.Pow(reala,2) + Math.Pow(imaginara ,2));
            double fi = Math.Atan(imaginara / reala);
            return string.Format("{0:0.00}", r) + " ( cos " + string.Format("{0:0.00}", fi) + " + i * sin " + string.Format("{0:0.00}", fi + " ) ");
        }
        public float modul()
        {
            return (float)Math.Sqrt(reala * reala + imaginara * imaginara);
        }
        public static bool operator <( NumarComplex a, NumarComplex b)
        {
            if (a.modul() < b.modul())
                return true;
            return false;
            
        }
        
    }
}

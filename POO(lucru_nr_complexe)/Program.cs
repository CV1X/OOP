using POO_lucru_nr_complexe_;
using System;
using System.Text;

namespace P1
{

    public class P1
    {
        static void Main(string[] args)
        {
            NumarComplex a = new NumarComplex(1, -3);
            NumarComplex b = new NumarComplex(-2, -1);

            NumarComplex suma = a + b;
            NumarComplex dif = a - b;
            NumarComplex inm = a * b;
            NumarComplex pow = a ^ 2;

            Console.WriteLine("Primul numar este "+ a);
            Console.WriteLine("Al doilea numar este "+ b);
            Console.WriteLine(" ");
            Console.WriteLine("Suma este " + suma);
            Console.WriteLine("Diferenta este " + dif);
            Console.WriteLine("Inmultirea este " + inm);
            Console.WriteLine("Puterea este " + pow);
            Console.WriteLine("Forma trigo : " + a.trigo());




            //OperatiiFractii a = new OperatiiFractii(2,5);
            //OperatiiFractii b = new OperatiiFractii(3,2);

            //Console.WriteLine("Suma este " + (a+b));
            //Console.WriteLine("Diferenta este " + (a - b));
            //Console.WriteLine("Inmultirea este " + (a * b));
            //Console.WriteLine("Impartirea este " + (a / b));
            //Console.WriteLine("La Putere este " + (a ^ 2));





            //Sa se creeze o clasa pt lucru cu matrici pt operatii de : Adunare , Scadere si Inmultire
            //Ridicarea la putere si determinarea inversei 
            // Se va tine cont daca au acelasi nr de linii si coloane 

            //int n1 = 3, m1 = 3, m2 = 3, n2 = 3;
            //Matrice a= new Matrice(n1,m1);
            //Matrice b = new Matrice(n2,m2);
            //Console.WriteLine("Matrice A\n{0}", a.ToString());
            //Console.WriteLine("Matrice B\n{0}", b.ToString());
            //Console.WriteLine("Matrice A+B\n{0}", a.adunare(b));
            //Console.WriteLine("Matrice A-B\n{0}", a.scadere(b));
            //Console.WriteLine("Matrice A*B\n{0}", a.inmultire(b));
            //Console.WriteLine("Matrice A^3\n{0}", a.putere(2));
            //Console.WriteLine("Matrice inversa\n{0}", a.Inversa());

        }

    }
}
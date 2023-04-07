using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_lucru_nr_complexe_
{
    public class Matrice
    {
        private int n, m;
        private double [,] mat;
        public Matrice(int n = 0, int m=0)
        {
            this.n=n;
            this.m=m;
            mat = new double[this.n,this.m];
            Random r = new Random();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    mat[i, j] = r.Next(5);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            for(int i = 0; i < n; i++)
            {
                for( int j = 0; j < m; j++)
                {
                    s.AppendFormat("{0,5:0}", mat[i, j]);
                }
                s.Append("\n");
            }
            return s.ToString();
        }
        public Matrice adunare(Matrice a)
        {
            if (a.n == this.n && a.m == this.m)
            {
                Matrice rez = new Matrice(n, m);
                for(int i=0; i < n; i++)
                    for(int j=0; j < m;j++)
                        rez.mat[i, j]= mat[i, j] + a.mat[i, j];
                return rez;
            }
            Console.WriteLine("Matricile nu se pot aduna");
            return null;
        }
        public Matrice scadere(Matrice a)
        {
            if (a.n == this.n && a.m == this.m)
            {
                Matrice rez = new Matrice(n, m);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        rez.mat[i, j] = mat[i, j] - a.mat[i, j];
                return rez;
            }
            Console.WriteLine("Matricile nu se pot scadea");
            return null;
        }
        public Matrice inmultire(Matrice a)
        {
            if (this.n == a.m)
            {
                Matrice rez = new Matrice(n, m);
                for (int i = 0; i < this.n; i++)
                    for (int j = 0; j < this.m; j++)
                    {
                        rez.mat[i, j] = 0.0;
                        for(int k=0;k<a.m;k++)
                            rez.mat[i, j] += mat[i, k] * a.mat[k, j];

                    }
                return rez;
            }
            Console.WriteLine("Matricile nu se pot inmulti");
            return null;
        }
        public Matrice putere(int k)
        {
            
            Matrice rez = new Matrice(this.n, this.m);
            for (int i = 0; i < this.n; i++)
                for (int j = 0; j < this.m; j++)
                    if (i == j)
                       rez.mat[i, j] = 1;
                    else
                        rez.mat[i, j] = 0;

            for (int i = 0; i < k; i++)
                rez = rez.inmultire(this);
            return rez;
            
            Console.WriteLine("Matricile nu se pot inmulti");
            return null;
        }
        public double determinant(double[,] a, int n)
        {

            int i, j;
            double d, e, aux;

            if (n == 1)
                return a[0, 0];
            else
            {
                d = 0.0;
                for(j=0; j < n; j++)
                {
                    if(((n-1-j)%2==1) || (j==n-1))
                         e = a[n - 1, j];
                    else
                        e = -a[n-1, j];
                    for(i=0; i < n - 1; i++)
                    {
                        aux= a[i, j];
                        a[i,j] = a[i,n-1];
                        a[i,n-1] = aux;
                    }
                    if (((n - 1 - j) % 2 == 0))
                        d += e * determinant(a, n - 1);
                    else
                        d -= e * determinant(a, n - 1);
                    for (i = 0; i < n - 1; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, n - 1];
                        a[i, n - 1] = aux;
                    }
                }
                return d;
            }
        }

        public Matrice Inversa()
        {
            if (this.n == this.m)
            {
                double d= this.determinant(this.mat,this.n);
                if (d != 0)
                {
                    Matrice rez = new Matrice(this.n);
                    Matrice temp = new Matrice(this.n);
                    //matrice transpusa
                    for(int i=0; i<n; i++)
                        for(int j=0; j<n; j++)
                            temp.mat[i, j] = mat[j,i];
                    double aux;
                    int semn;
                    //matrice adjuncta
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                        {
                            //interschimbam linia i cu ultima linie (n-1)
                            for(int k  = 0; k < n; k++)
                            {
                                aux = temp.mat[i,k];
                                temp.mat[i, k] = temp.mat[n - 1, k];
                                temp.mat[n - 1, k] = aux;
                            }
                            // si coloana j
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[k,j];
                                temp.mat[k,j] = temp.mat[k,n-1];
                                temp.mat[k,n-1] = aux;
                            }
                            //stabilim semnul pt permutari 
                            semn = 1;
                            if (((n - 1 - i) % 2 == 0) && (i != n - 1) )
                                semn *= -1;
                            if (((n - 1 - i) % 2 == 0) && ( j != n - 1) )
                                semn *= -1;
                            if((i+j)%2==1)
                                semn*=-1;
                            rez.mat[i, j] = semn * determinant(temp.mat, n - 1);
                            //refac matricea
                            for(int k = 0; k < n; k++) 
                            {
                                aux = temp.mat[i, k];
                                temp.mat[i, k] = temp.mat[n - 1, k];
                                temp.mat[n - 1, k] = aux;
                            }
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[k, j];
                                temp.mat[k, j] = temp.mat[k, n - 1];
                                temp.mat[k, n - 1] = aux;
                            }
                        }
                    //matricea inversa
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            rez.mat[i, j] /= d;
                    return rez;
                }
                Console.WriteLine("Matricea nu este inersabila");
                return null;
            }
            return null;
        }

    }
}

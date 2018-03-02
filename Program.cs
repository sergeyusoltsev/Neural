using System;
using LAlib;

namespace Neural
{
    class Program
    {
        static void Main(string[] args)
        {
            // tests on addition
            Console.WriteLine("+--- Addition tests ---+");
            Matrix test1, test2, test3;
            test1 = new Matrix(new float[,]{{1,2,3},{4,5,6},{7,8,9}});
            test2 = new Matrix(new float[,]{{3,2,1},{4,5,6},{7,8,9}});
            test1.add(0.35f);
            test2.add(test1);
            test3 = new Matrix(new float[,]{{1,2,3},{3,2,1},{4,5,6},{7,8,9}});
            test2.add(test3);
            // tests on inner product and scalar multiplication
            Console.WriteLine("+--- Inner product and scalar multiplication tests ---+");
            // tests on outer product
            Console.WriteLine("+--- Outer product tests ---+");
            // tests on static inversion (static -1 scalar multiplication)
            Console.WriteLine("+--- Matrix inversion ---+");
            // tests on static transposition
            Console.WriteLine("+--- Matrix transposition ---+");
        }
    }
}

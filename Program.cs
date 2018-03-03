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
            Matrix test1, test2;
            test1 = new Matrix(new float[,]{{1,2},{3,4}});
            test2 = new Matrix(new float[,]{{5,6},{7,8}});
            // tests on inner product and scalar multiplication
            Console.WriteLine("+--- Inner product and scalar multiplication tests ---+");
            test1.mul(test2);
            test1.PrintMatrix();
            // tests on static inversion (static -1 scalar multiplication)
            Console.WriteLine("+--- Matrix inversion ---+");
            LAlib.Matrix.invert(test1).PrintMatrix();
            // tests on static transposition
            Console.WriteLine("+--- Matrix transposition ---+");
        }
    }
}

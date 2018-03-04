using System;
using LAlib;
using Lneural;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork nn = new NeuralNetwork(new int[]{2,2,1});
            nn.NeuralVisualize();
            Matrix exp = new Matrix(new float[,]{{1}});
            nn.NeuralLearn(exp);
        }
    }
}

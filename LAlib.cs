using System;

namespace LAlib { //Stands for Linear Algebra library
    public class Matrix {
        public float[,] MatrixData; // Local version of matrix to manipulate
        public Matrix(float[,] data) {
            MatrixData = data;
            // Constructor class which rolls trough the data in the matrix
            // representing it in nice and comfortable way, calling the method Printme();
            Console.WriteLine("Matrix initialized!");
            PrintMatrix();
        }
        public void PrintMatrix() {
            // Method just to print the matrix in a nice way
           for (int i = 0; i < MatrixData.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < MatrixData.GetLength(1); j++)
                {
                    string OutString = MatrixData[i,j].ToString();
                    Console.Write('\t' + OutString + '\t');
                }
                Console.WriteLine("|");
            } 
        }
        public void add(Matrix operand) {
            // Check dimensions euqivalence!
            if (operand.MatrixData.GetLength(0) == MatrixData.GetLength(0) && operand.MatrixData.GetLength(1) == MatrixData.GetLength(1))
            {
                // Elementwise addition of the matricies
                for (int i = 0; i < MatrixData.GetLength(0); i++)
                {
                    for (int j = 0; j < MatrixData.GetLength(1); j++)
                    {
                        MatrixData[i,j] += operand.MatrixData[i,j];
                    }
                }
                Console.WriteLine("Addition result:");
                PrintMatrix();
            }
            else
            {
                // Handler for inconsistent operands dimensions
                Console.WriteLine("Addition failed due to matrix dimensions mismatch");
            }
        }
        public void add(float operand) {
            // Method add being overloaded with elementwise float addition
            for (int i = 0; i < MatrixData.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixData.GetLength(1); j++)
                {
                    MatrixData[i,j] += operand;
                }
            }
            Console.WriteLine("Addition result:");
            PrintMatrix();
        }

    }
}


using System;

namespace LAlib { //Stands for Linear Algebra library
    public class Matrix {
        public float[,] MatrixData; // Local version of matrix to manipulate
        public Matrix(float[,] data) {
            MatrixData = data;
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
        }
        public void mul(Matrix operand) {
            // Check opposite dimensions euqivalence!
            if (MatrixData.GetLength(1) == operand.MatrixData.GetLength(0))
            {
                // Multiplication of the matricies
                int ni = MatrixData.GetLength(1);                    // number of rows in the caller
                int nj = operand.MatrixData.GetLength(0);            // number of columns in operand
                Matrix resmatr = new Matrix(new float[ni,nj]);
                for (int i = 0; i < ni; i++)
                {
                    for (int j = 0; j < nj; j++)
                    {
                        for (int k = 0; k < ni; k++)
                        {
                            resmatr.MatrixData[i,j] += MatrixData[i,k] * operand.MatrixData[k,j];
                        }
                    }
                }
                MatrixData = resmatr.MatrixData;
            }
            else
            {
                // Handler for inconsistent operands dimensions
                Console.WriteLine("Multiplication failed due to matrix opposite dimensions mismatch, maybe order is mixed?");
            }
        }
        public void mul(float operand) {
            // Method mul being overloaded with elementwise float multiplication
            for (int i = 0; i < MatrixData.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixData.GetLength(1); j++)
                {
                    MatrixData[i,j] *= operand;
                }
            }
        }
        public static Matrix invert(Matrix operand) {
            // static method returning -1 multiplied matrix
            operand.mul(-1f);
            return operand;
        }
        public static Matrix transpose(Matrix operand) {
            Matrix transposed = new Matrix(new float[operand.MatrixData.GetLength(1), operand.MatrixData.GetLength(0)]);
            // Method add being overloaded with elementwise float addition
            for (int i = 0; i < transposed.MatrixData.GetLength(0); i++)
            {
                for (int j = 0; j < transposed.MatrixData.GetLength(1); j++)
                {
                    transposed.MatrixData[i,j] = operand.MatrixData[j,i];
                }
            }
            return transposed;
        }
    }
}


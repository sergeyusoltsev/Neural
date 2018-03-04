using System;

namespace LAlib { //Stands for Linear Algebra library
    public class Matrix {
        //TODO - static version of mul and add
        public float[,] MatrixData; // Local version of matrix to manipulate
        public Matrix(float[,] data) {
            MatrixData = data;
            for (int i = 0; i < MatrixData.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixData.GetLength(1); j++)
                {
                    MatrixData[i,j] = 0; //initialize matrix with zero values
                }
            }
        }
        public void Randomize() {
            for (int i = 0; i < MatrixData.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixData.GetLength(1); j++)
                {
                    Random gen = new Random();
                    MatrixData[i,j] = (float)gen.NextDouble();
                }
            }
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
        public static Matrix add(Matrix operand1, Matrix operand2) {
            // Check dimensions euqivalence!
            if (operand2.MatrixData.GetLength(0) == operand1.MatrixData.GetLength(0) 
                && operand2.MatrixData.GetLength(1) == operand1.MatrixData.GetLength(1))
            {
                // Elementwise addition of the matricies
                for (int i = 0; i < operand1.MatrixData.GetLength(0); i++)
                {
                    for (int j = 0; j < operand1.MatrixData.GetLength(1); j++)
                    {
                        operand1.MatrixData[i,j] += operand2.MatrixData[i,j];
                    }
                }
                return operand1;
            }
            else
            {
                // Handler for inconsistent operands dimensions
                Console.WriteLine("Addition failed due to matrix dimensions mismatch");
                return null;
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
        public static Matrix mul(Matrix operand1, Matrix operand2) {
            // Check opposite dimensions euqivalence!
            if (operand1.MatrixData.GetLength(1) == operand2.MatrixData.GetLength(0))
            {
                // Multiplication of the matricies
                int ni = operand1.MatrixData.GetLength(0);                    // number of rows in the caller
                int nj = operand2.MatrixData.GetLength(1);            // number of columns in operand
                Matrix resmatr = new Matrix(new float[ni,nj]);
                for (int i = 0; i < ni; i++)
                {
                    for (int j = 0; j < nj; j++)
                    {
                        for (int k = 0; k < operand1.MatrixData.GetLength(1); k++)
                        {
                            resmatr.MatrixData[i,j] += operand1.MatrixData[i,k] * operand2.MatrixData[k,j];
                        }
                    }
                }
                return resmatr;
            }
            else
            {
                // Handler for inconsistent operands dimensions
                Console.WriteLine("Multiplication failed due to matrix opposite dimensions mismatch, maybe order is mixed?");
                return null;
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
        // TODO - error handler for jacobian
        public static Matrix jacobian(Matrix basex1, Matrix basex2, Matrix deltay, int refx){
            //this produces a matrix of analytical partial derivatives of deltay without concerning the step
            //(step is probably defined by the changes involved in x -> deltax y -> deltay transition)
            //derivarives are taken by a specified row in dx values matrix.
            Matrix jacobian = new Matrix(new float[basex1.MatrixData.GetLength(0),basex1.MatrixData.GetLength(1)]);
            for (int i = 0; i < basex1.MatrixData.GetLength(0); i++)
            {
                for (int j = 0; j < basex1.MatrixData.GetLength(1); j++)
                {
                    jacobian.MatrixData[i,j] = deltay.MatrixData[i,0] / Matrix.add(basex1, Matrix.invert(basex2)).MatrixData[refx,j];
                }
            }
            return jacobian;
        }
        public static Matrix gradient(Matrix basex, Matrix deltax, Matrix deltay, int refx){
            Matrix gradient = Matrix.transpose(Matrix.jacobian(basex, deltax, deltay, refx));
            return gradient;
        }
    }
}


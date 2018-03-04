using System;
using LAlib;

namespace Lneural {
    class NeuralNetwork {
        Matrix[] NeuralValueStack, NeuralWeightStack, NeuralErrorStack;
        int nl;
        public NeuralNetwork(int[] layers){
            nl = layers.GetLength(0);
            NeuralValueStack = new Matrix[nl];
            for (int i = 0; i < nl; i++)
            {
                NeuralValueStack[i] = new Matrix(new float[layers[i],1]);
            }
            NeuralWeightStack = new Matrix[nl - 1];
            for (int i = 0; i < nl - 1; i++)
            {
                NeuralWeightStack[i] = new Matrix(new float[layers[i+1],layers[i]]);
            }
            NeuralErrorStack = new Matrix[nl];
            for (int i = 0; i < nl; i++)
            {
                NeuralErrorStack[i] = new Matrix(new float[layers[i],1]);
            }
            NeuralRandomWeights();
        }
        public void NeuralRandomWeights() {
            for (int i = 0; i < NeuralWeightStack.GetLength(0); i++)
            {
                NeuralWeightStack[i].Randomize();
            }
        }
        public void NeuralVisualize() {
            Console.WriteLine("Neural network instance contains " + NeuralValueStack.Length.ToString() + " layers:");
            Console.WriteLine("-----");
            for (int i = 0; i < NeuralValueStack.GetLength(0); i++) {
                Console.Write("Layer " + i.ToString() + " - ");
                Console.WriteLine(NeuralValueStack[i].MatrixData.GetLength(0).ToString() + " nodes");
            }
        }
        public static float SigmoidActivation(float operand) {
            float result = 1 / 1 + (float)System.Math.Exp(-1f * operand);
            return result;
        }
        public void NeuralForward() {
            for (int i = 0; i < nl - 1; i++)
            {
                NeuralValueStack[i + 1] = Matrix.mul(NeuralWeightStack[i], NeuralValueStack[i]);
                // Next layer values becoming product of current layer weight matrix and current layer values
                for (int j = 0; j < NeuralValueStack[i + 1].MatrixData.GetLength(0); j++)
                {
                    // produced values are normalized using sigmoid
                    NeuralValueStack[i + 1].MatrixData[j,0] = SigmoidActivation(NeuralValueStack[i+1].MatrixData[j,0]);
                }
            }
        }
        public void NeuralBackwards(Matrix expectedResult) {
            // --- initial guess ---
            // TODO add error handling for expected result
            Matrix lastVal = NeuralValueStack[NeuralValueStack.GetLength(0) - 1];
            NeuralErrorStack[NeuralErrorStack.GetLength(0) - 1] = Matrix.add(expectedResult, Matrix.invert(lastVal));
            // last errors evaluated
            // errors backpropagation - multiply E(0) by T(W(-1)) to get E(-1)
            for (int i = NeuralErrorStack.GetLength(0) - 1; i > 0 ; i--)
            {
                NeuralErrorStack[i-1] = Matrix.mul(Matrix.transpose(NeuralWeightStack[i-1]), NeuralErrorStack[i]);
                Console.WriteLine(i.ToString());
            }

        }
        public void NeuralLearn(Matrix expectedResult){
            NeuralForward();
            NeuralBackwards(expectedResult);
            Console.WriteLine("errors are");
            NeuralErrorStack[NeuralErrorStack.GetLength(0) - 1].PrintMatrix();
            NeuralErrorStack[1].PrintMatrix();
            NeuralErrorStack[0].PrintMatrix();
        }
    }
}
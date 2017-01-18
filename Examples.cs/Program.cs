using MachineLearningLib;
using ru.aryumin.MachineLearningLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.cs
{
    class Program
    {
        static double[] xVals = { 1.0, 2.0, 3.0, 4.0, 5.0 };
        static double[] yVals = { 1.0, 2.0, 2.8, 3.75, 4.95 };

        static void Main(string[] args)
        {
            double[,] a = new double[3,2];
            a[0, 0] = 2;
            a[0, 1] = 6;
            a[1, 0] = 7;
            a[1, 1] = 3;
            a[2, 0] = 5;
            a[2, 1] = 2;

            double[,] b = new double[2, 3];
            b[0, 0] = 1;
            b[0, 1] = 7;
            b[0, 2] = 3;
            b[1, 0] = 2;
            b[1, 1] = 5;
            b[1, 2] = 6;            


            Matrix matrixA = new Matrix(a);
            Matrix matrixB = new Matrix(b);

            //Transporate matrix
            Console.WriteLine(matrixA);
            Console.WriteLine("\n");
            matrixA = matrixA.TransporateMatrix();
            Console.WriteLine(matrixA);

            //Multipling to scalar
            Console.WriteLine(matrixA);
            matrixA = matrixA.MultiplyToScalar(10);
            Console.WriteLine(matrixA);

            Matrix matrixC = Matrix.MultiplyMatrices(matrixA, matrixB);
            Console.WriteLine("Multiply marix\n\n{0}\n\nto matrix\n\n{1}\n\nIt gives:\n\n{2}\n\n"
                , matrixA, matrixB, matrixC);



            //Calculate simple linear regression
            SimpleLinearRegression slr = new SimpleLinearRegression(xVals, yVals);
            double yPredicted = slr.PredictY(4);
            Console.WriteLine(yPredicted);

            Console.ReadLine();
        }
    }
}

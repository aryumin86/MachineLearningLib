using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningLib
{
    /// <summary>
    /// Matrix.
    /// </summary>
    public class Matrix
    {
        private double[,] matrixBase;

        public Matrix(double[,] matrixBase)
        {
            this.matrixBase = matrixBase;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < this.matrixBase.GetLength(0); i++)
            {
                for(int j = 0; j < this.matrixBase.GetLength(1); j++)
                {
                    sb.Append(this.matrixBase[i, j]);
                    sb.Append("\t");
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Adding matrixes
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixb"></param>
        /// <returns></returns>
        public static Matrix SumMatrices(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.matrixBase.GetLength(0) != matrixB.matrixBase.GetLength(0) || matrixA.matrixBase.GetLength(1) != matrixB.matrixBase.GetLength(1))
                throw new FormatException("Matrixes have different number of rows or different number of columns");

            Matrix matrixC = new Matrix(new double[matrixA.matrixBase.GetLength(0), matrixB.matrixBase.GetLength(1)]);
            for(int row = 0; row < matrixA.matrixBase.GetLength(0); row++)
            {
                for(int column = 0; column < matrixA.matrixBase.GetLength(1); column++)
                {
                    matrixC.matrixBase[row, column] = matrixA.matrixBase[row, column] + matrixB.matrixBase[row, column];
                }
            }

            return matrixC;
        }

        /// <summary>
        /// Substracting matrixes.
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixb"></param>
        /// <returns></returns>
        public static Matrix SubstractMatrices(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.matrixBase.GetLength(0) != matrixB.matrixBase.GetLength(0) || matrixA.matrixBase.GetLength(1) != matrixB.matrixBase.GetLength(1))
                throw new FormatException("Matrixes have different number of rows or different number of columns");

            Matrix matrixC = new Matrix(new double[matrixA.matrixBase.GetLength(0), matrixB.matrixBase.GetLength(1)]);
            for (int row = 0; row < matrixA.matrixBase.GetLength(0); row++)
            {
                for (int column = 0; column < matrixA.matrixBase.GetLength(1); column++)
                {
                    matrixC.matrixBase[row, column] = matrixA.matrixBase[row, column] - matrixB.matrixBase[row, column];
                }
            }

            return matrixC;
        }

        /// <summary>
        /// Multiplying matrices.
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixb"></param>
        /// <returns></returns>
        public static Matrix MultiplyMatrices(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.matrixBase.GetLength(0) != matrixB.matrixBase.GetLength(1))
                throw new FormatException("matrixA's dimensions number is diffrent from matrixB dimensions[0] length");

            Matrix matrixC = new Matrix(new double[matrixA.matrixBase.GetLength(0), matrixB.matrixBase.GetLength(1)]);
            for(int i = 0; i < matrixB.matrixBase.GetLength(1); i++)
            {
                for(int j = 0; j < matrixA.matrixBase.GetLength(0); j++)
                {
                    double result = 0;
                    for(int k = 0; k < matrixA.matrixBase.GetLength(1); k++)
                    {
                        result += matrixA.matrixBase[j, k] * matrixB.matrixBase[k, i];
                    }
                    matrixC.matrixBase[j, i] = result;
                }
            }

            return matrixC;
        }

        /// <summary>
        /// Multiply to scalar
        /// </summary>
        /// <param name="scalar"></param>
        /// <returns>Returns NEW matrix</returns>
        public Matrix MultiplyToScalar(int scalar)
        {
            Matrix m = new Matrix(this.matrixBase);
            for (int i = 0; i < this.matrixBase.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrixBase.GetLength(1); j++)
                {
                    m.matrixBase[i, j] = m.matrixBase[i, j] * scalar;
                }
            }

            return m;
        }


        /// <summary>
        /// Transporate matrix.
        /// </summary>
        /// <param name="matrixA"></param>
        public Matrix TransporateMatrix()
        {
            Matrix newMatrix = new Matrix(new double[this.matrixBase.GetLength(1), this.matrixBase.GetLength(0)]);

            for (int i = 0; i < this.matrixBase.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrixBase.GetLength(1); j++)
                {
                    newMatrix.matrixBase[j, i] = this.matrixBase[i, j];
                }
            }

            return newMatrix;

        }

        /// <summary>
        /// Get matrix determinant
        /// </summary>
        /// <returns></returns>
        public double GetDeterminant()
        {
            if (this.matrixBase.GetLength(0) != this.matrixBase.GetLength(1))
                throw new FormatException("Matrices should be squared");


            return 0.0;
        }


        /// <summary>
        /// Invert matrix.
        /// </summary>
        /// <param name="matrixA"></param>
        /// <returns></returns>
        public Matrix InvertMatrix(Matrix matrixA)
        {


            return null;
        }

    }
}

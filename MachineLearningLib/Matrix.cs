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
                throw new InvalidOperationException("Matrices should be squared");
            
            //if it is 2x2 matrix
            if(this.matrixBase.GetLength(0) == 2)
            {
                return this.matrixBase[0, 0] * this.matrixBase[1, 1]
                    - this.matrixBase[0, 1] * this.matrixBase[1, 0];
            }



            //new matrix with new columns (we need the same number of columns - 1) for the same values 
            //from beginning of matrix
            double[,] extendedMatrixBase = new double[this.matrixBase.GetLength(0), 
                this.matrixBase.GetLength(1) + this.matrixBase.GetLength(1) - 1];

            //filling part of new matrix with the same values as in this object matrix
            for(int i = 0; i < this.matrixBase.GetLength(0); i++)
            {
                for(int j = 0; j < this.matrixBase.GetLength(1); j++)
                {
                    extendedMatrixBase[i, j] = this.matrixBase[i, j];
                }
            }

            //filling new columns with values the same as at beginning of matrix
            for(int i = 0; i < this.matrixBase.GetLength(0); i++)
            {
                for(int j = this.matrixBase.GetLength(1); j < extendedMatrixBase.GetLength(1); j++)
                {
                    extendedMatrixBase[i, j] = this.matrixBase[i, j - this.matrixBase.GetLength(0)];
                }
            }

            Matrix extendedMatrix = new Matrix(extendedMatrixBase);

            //calculating determinant
            double determinant = 0.0;

            //summing
            double sumsResult = 0.0;
            for(int i = 0; i < this.matrixBase.GetLength(0); i++)
            {
                int row = 0;
                int column = i;

                double diagonalResult = 1.0;
                for (int j = 0; j < this.matrixBase.GetLength(0); j++, row++, column++)
                {
                    diagonalResult *= extendedMatrix.matrixBase[row,column];
                }
                sumsResult += diagonalResult;
            }

            //substracting
            double substractionsResult = 0.0;
            for (int i = 0; i < this.matrixBase.GetLength(0); i++)
            {
                int row = 0;
                int column = extendedMatrix.matrixBase.GetLength(1) - 1 - i;

                double diagonalResult = 1.0;
                for(int j = 0; j < this.matrixBase.GetLength(0); j++, row++, column--)
                {
                    diagonalResult *= extendedMatrix.matrixBase[row, column];
                }
                substractionsResult += diagonalResult;
            }

            determinant = sumsResult - substractionsResult;

            return determinant;
        }

        /// <summary>
        /// Is matrix invertable?
        /// </summary>
        /// <returns></returns>
        public bool isInvertable()
        {
            if (this.GetDeterminant() != 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Invert matrix.
        /// </summary>
        /// <param name="matrixA"></param>
        /// <returns>new inverted matrix</returns>
        public Matrix Invert()
        {
            Matrix invertedMatrix;

            if (this.isInvertable())
            {
                //Getting matrix of minors
                Matrix matrixOfMinors = new Matrix(new double[matrixBase.GetLength(0), matrixBase.GetLength(1)]);

                for (int row = 0; row < matrixBase.GetLength(0); row++)
                {
                    for(int column= 0; column < matrixBase.GetLength(1); column++)
                    {
                        double[,] subMArrBase = new double[matrixBase.GetLength(0)-1,matrixBase.GetLength(1)-1];
                        Matrix subMatrix = new Matrix(subMArrBase);

                        int subMRow = 0;
                        for(int r = 0; r < matrixBase.GetLength(0); r++)
                        {
                            if (row == r)
                                continue;
                            int subMColumn = 0;
                            for (int c = 0; c < matrixBase.GetLength(1); c++)
                            {
                                if (column == c)
                                    continue;

                                subMArrBase[subMRow, subMColumn] = this.matrixBase[r, c];
                                subMColumn++;
                            }
                            subMRow++;
                        }

                        matrixOfMinors.matrixBase[row, column] = subMatrix.GetDeterminant();
                    }
                }


            }
            else
                throw new InvalidOperationException("Matrix is not invertable");

            return null;
        }

    }
}

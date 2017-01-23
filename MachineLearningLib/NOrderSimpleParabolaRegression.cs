using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningLib
{
    /// <summary>
    /// Parabola simple (paired) regression of n-order
    /// </summary>
    public class NOrderSimpleParabolaRegression
    {
        /// <summary>
        /// Getting linear regression (multyple linear) coefficients (b's)
        /// </summary>
        /// <param name="m"></param>
        /// <param name="nOrders"></param>
        /// <returns></returns>
        public Matrix GetRegressionCoefficients(Matrix m, int nOrders)
        {
            Matrix X = m.GetMatrixPart(Enumerable.Range(0, m.matrixBase.GetLength(0)).Select(z => z).ToArray(), new int[] { 0 });
            Matrix Y = m.GetMatrixPart(Enumerable.Range(0, m.matrixBase.GetLength(0)).Select(z => z).ToArray(), new int[] { 1 });

            Matrix multLinM = new Matrix(new double[m.matrixBase.GetLength(0), nOrders + 1]);
            for(int i = 0; i < m.matrixBase.GetLength(0); i++)
            {
                for(int order = 0; order < nOrders + 1; order++)
                {
                    if (order == 0)
                        multLinM.matrixBase[i, 0] = 1;
                    else
                        multLinM.matrixBase[i, order] = Math.Pow(X.matrixBase[i, 0], order);
                }
            }

            var mlr = new MultipleLinearRegression();
            Matrix coefs = mlr.GetBCoefficientsForMatrix(multLinM, Y);
            return coefs;
        }

        /// <summary>
        /// Get y for x's
        /// </summary>
        /// <returns></returns>
        public double GetYForVectorX(Matrix coeffsVector, double x)
        {
            double result = 0.0;
            double[,] xsBase = new double[coeffsVector.matrixBase.GetLength(0) - 1, 1];
            for(int i = 1; i < xsBase.GetLength(0) + 1; i++)
            {
                xsBase[i - 1, 0] = Math.Pow(x, i);
            }

            Matrix xs = new Matrix(xsBase);

            for(int i = 0; i < coeffsVector.matrixBase.GetLength(0); i++)
            {
                if (i == 0)
                    result += coeffsVector.matrixBase[0, 0];
                else
                {
                    result += coeffsVector.matrixBase[i, 0] * xs.matrixBase[i - 1, 0];
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ru.aryumin.MachineLearningLib
{
    /// <summary>
    /// Simple linear regression
    /// </summary>
    public class SimpleLinearRegression
    {
        public double[] xVals, yVals;
        public double standardDevX, standardDevY, correlation, slope, interception;

        /// <summary>
        /// Calculates regression line
        /// </summary>
        /// <param name="xVals"></param>
        /// <param name="yVals"></param>
        public SimpleLinearRegression(double[] xVals, double[] yVals)
        {
            this.xVals = xVals;
            this.yVals = yVals;
            standardDevX = GetStandardDeviation(xVals);
            standardDevY = GetStandardDeviation(yVals);
            correlation = GetCorrelation(xVals, yVals);
            slope = correlation * standardDevY / standardDevX;
            interception = GetArrMean(yVals) - slope * GetArrMean(xVals);
        }

        /// <summary>
        /// Predict y by x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double PredictY(double x)
        {
            return interception + slope * x;
        }

        /// <summary>
        /// Get mean of array
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static double GetArrMean(double[] arr)
        {
            return arr.Sum() / arr.Length;
        }

        /// <summary>
        /// Get standard deviation
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static double GetStandardDeviation(double[] arr)
        {
            double mean = GetArrMean(arr);
            double[] devs = new double[arr.Length]; //отклонения от среднего
            for (int i = 0; i < arr.Length; i++)
            {
                devs[i] = Math.Pow(arr[i] - mean, 2);
            }
            return Math.Sqrt(devs.Sum() / (devs.Length - 1));
        }

        /// <summary>
        /// Get correlation.
        /// </summary>
        /// <returns></returns>
        private static double GetCorrelation(double[] X, double[] Y)
        {
            double XMean = X.Sum() / X.Length;
            double YMean = Y.Sum() / Y.Length;
            double[] x = new double[X.Length];
            double[] y = new double[Y.Length];

            for (int i = 0; i < X.Length; i++)
            {
                x[i] = X[i] - XMean;
                y[i] = Y[i] - YMean;
            }

            double[] xy = new double[X.Length];
            for (int i = 0; i < X.Length; i++)
            {
                xy[i] = x[i] * y[i];
            }

            double[] xPowed = new double[X.Length];
            double[] yPowed = new double[Y.Length];

            for (int i = 0; i < X.Length; i++)
            {
                xPowed[i] = Math.Pow(x[i], 2);
                yPowed[i] = Math.Pow(y[i], 2);
            }

            return xy.Sum() / Math.Sqrt(xPowed.Sum() * yPowed.Sum());
        }
    }
}

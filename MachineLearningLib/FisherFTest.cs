using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningLib
{
    /// <summary>
    /// Fisher F-Test for calculating regression model correctness
    /// </summary>
    public class FisherFTest
    {
        /// <summary>
        /// Get F-counted
        /// </summary>
        /// <param name="rawY">array of raw Y-s</param>
        /// <param name="predictedYs">array of predicted Y-s</param>
        /// <param name="m">number of predictors</param>
        /// <returns></returns>
        public double GetFScore(double[] rawYs, double[] predictedYs, int m)
        {
            double averageYPredicted = predictedYs.Sum() / predictedYs.Length;

            double[] yPredictedDeltas = new double[predictedYs.Length];
            for (int i = 0; i < predictedYs.Length; i++)
                yPredictedDeltas[i] = Math.Pow((predictedYs[i] - averageYPredicted), 2);
            double a = yPredictedDeltas.Sum();

            double[] yDeltas = new double[predictedYs.Length];
            for (int i = 0; i < predictedYs.Length; i++)
                yDeltas[i] = Math.Pow((rawYs[i] - predictedYs[i]), 2);
            double b = yDeltas.Sum();

            return (a / m) * (rawYs.Length - m - 1) / b;
        }
    }
}

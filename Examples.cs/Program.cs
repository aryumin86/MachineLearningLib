using MachineLearningLib;
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
            //Calculate simple linear regression
            SimpleLinearRegression slr = new SimpleLinearRegression(xVals, yVals);
            double yPredicted = slr.PredictY(4);
            Console.WriteLine(yPredicted);

            Console.ReadLine();
        }
    }
}

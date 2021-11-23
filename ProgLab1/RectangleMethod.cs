using System;
using MathNet.Symbolics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLab1
{
    class RectangleMethod
    {
        public static int OptimalSplits(double aBord, double bBord, double esp, Expression func)
        {
            double smallerSquare = 1;
            double largerSquare = 0;
            int splits = 1;

            while (Math.Abs(largerSquare - smallerSquare) > esp)
            {
                double splitStep = (bBord - aBord) / splits;
                double x1 = aBord;
                double x2 = aBord;
                double smallerSum = 0;
                double largerSum = 0;

                for (int counter = 0; counter < splits; ++counter)
                {
                    smallerSum += Form1.FuncValue((2 * x1 + splitStep) / 2, func);
                    x1 += splitStep;
                }

                for (int counter = 0; counter < splits * 2; ++counter)
                {
                    largerSum += Form1.FuncValue((2 * x2 + splitStep / 2) / 2, func);
                    x2 += splitStep / 2;
                }
                smallerSquare = splitStep * smallerSum;
                largerSquare = (splitStep / 2) * largerSum;
                splits *= 2;
            }
            return splits;
        }

        public static double Calculation(double aBord, double bBord, int splits, Expression func)
        {
            double square;
            double sum = 0;
            double splitStep = (bBord - aBord) / splits;
            double x = aBord;

            for (int counter = 0; counter < splits; ++counter)
            {
                sum += Form1.FuncValue((2 * x + splitStep) / 2, func);
                x += splitStep;
            }

            square = splitStep * sum;
            return square;
        }
    }
}

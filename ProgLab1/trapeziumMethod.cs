using System;
using MathNet.Symbolics;
using ZedGraph;

namespace ProgLab1
{
    
    static public class TrapeziumMethod
    {
        public static int OptimalSplits(double aBord, double bBord, double esp, Expression func)
        {
            double smallerSquare = 1;
            double largerSquare = 0;
            int splits = 4;

            while (Math.Abs(largerSquare - smallerSquare) > esp)
            {
                double splitStep = (bBord - aBord) / splits;
                double x1 = aBord;
                double x2 = aBord;
                double smallerSum = 0;
                double largerSum = 0;

                for (int counter = 1; counter < splits; ++counter)
                {
                    x1 += splitStep;
                    smallerSum += Form1.FuncValue(x1, func);
                }

                for (int counter = 1; counter < splits * 2; ++counter)
                {
                    x2 += splitStep / 2;
                    largerSum += Form1.FuncValue(x2, func);
                }

                smallerSquare = splitStep * ((Form1.FuncValue(aBord, func) + Form1.FuncValue(bBord, func)) / 2 + smallerSum);
                largerSquare = (splitStep / 2) * ((Form1.FuncValue(aBord, func) + Form1.FuncValue(bBord, func)) / 2 + largerSum);
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

            for (int counter = 1; counter < splits; ++counter)
            {
                x += splitStep;
                sum += Form1.FuncValue(x, func);
            }

            square = splitStep * ((Form1.FuncValue(aBord, func) + Form1.FuncValue(bBord, func)) / 2 + sum);
            return square;
        }

    }
}

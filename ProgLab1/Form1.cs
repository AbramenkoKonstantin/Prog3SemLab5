using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using MathNet.Symbolics;

namespace ProgLab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        async public void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GraphPane pane = zedGraph.GraphPane;
                pane.CurveList.Clear();
                double.TryParse(textBoxA.Text, out double aBord);
                double.TryParse(textBoxB.Text, out double bBord);
                double.TryParse(textBoxE.Text, out double esp);
                Expression func = Infix.ParseOrThrow(textBoxF.Text);

                if (esp < 0)
                {
                    throw new Exception();
                }
                await Task.Run(() => LineDraw(aBord, bBord, esp, func));

                int round = 0;
                double espValue = esp;
                while (espValue < 1)
                {
                    round += 1;
                    espValue *= 10;
                }

                int splits = trapeziumMethod.OptimalSplits(aBord, bBord, esp, func);
                double square = trapeziumMethod.Calculation(aBord, bBord, splits, func);

                textBoxAnswer.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();

                /*Оптимальное количество разбиений методом прямоугольников*/
                //double sAOS = 1;
                //double sDAOS = 0;
                //double amountOfSteps = 2;
                //double doubleAmountOfSteps = 4;

                //while (Math.Abs(sDAOS - sAOS) > esp)
                //{
                //    double h = (bBord - aBord) / amountOfSteps;
                //    double hHalf = h / 2;
                //    double x1 = aBord;
                //    double x2 = aBord;
                //    double sumAOS = 0;
                //    double sumDAOS = 0;

                //    for (int counter = 0; counter < amountOfSteps; ++counter)
                //    {
                //        sumAOS += FuncValue((2 * x1 + h) / 2, func);
                //        x1 += h;
                //    }

                //    for (int counter = 0; counter < doubleAmountOfSteps; ++counter)
                //    {
                //        sumDAOS += FuncValue((2 * x2 + hHalf) / 2, func);
                //        x2 += hHalf;
                //    }
                //    sAOS = h * sumAOS;
                //    sDAOS = hHalf * sumDAOS;
                //    amountOfSteps *= 2;
                //    doubleAmountOfSteps *= 2;
                //}
                //textBoxAnswer.Text = Math.Round(sDAOS, round).ToString() + "; " + amountOfSteps.ToString();


                /*Оптимальное количество разбиений методом Симпсона*/
                //double sAOS = 1;
                //double sDAOS = 0;
                //double amountOfSteps = 2;
                //double doubleAmountOfSteps = 4;

                //while (Math.Abs(sDAOS - sAOS) > esp)
                //{
                //    double h = (bBord - aBord) / (amountOfSteps);
                //    double hHalf = h / 2;
                //    double x1 = aBord;
                //    double x2 = aBord;
                //    double sumEvenAOS = 0;
                //    double sumEvenDAOS = 0;
                //    double sumOddAOS = 0;
                //    double sumOddDAOS = 0;

                //    for (int counter = 1; counter < amountOfSteps; ++counter)
                //    {
                //        if (counter % 2 == 1)
                //        {
                //            x1 += h;
                //            sumOddAOS += FuncValue(x1, func);
                //        }

                //        else
                //        {
                //            x1 += h;
                //            sumEvenAOS += FuncValue(x1, func);
                //        }
                //    }

                //    for (int counter = 1; counter < doubleAmountOfSteps; ++counter)
                //    {
                //        if (counter % 2 == 1)
                //        {
                //            x2 += hHalf;
                //            sumOddDAOS += FuncValue(x2, func);
                //        }

                //        else
                //        {
                //            x2 += hHalf;
                //            sumEvenDAOS += FuncValue(x2, func);
                //        }
                //    }
                //    sAOS = (h / 3) * (FuncValue(aBord, func) + 4 * sumOddAOS + 2 * sumEvenAOS + FuncValue(bBord, func));
                //    sDAOS = (hHalf / 3) * (FuncValue(aBord, func) + 4 * sumOddDAOS + 2 * sumEvenDAOS + FuncValue(bBord, func));
                //    amountOfSteps *= 2;
                //    doubleAmountOfSteps *= 2;
                //}
                //textBoxAnswer.Text = Math.Round(sDAOS, round).ToString() + "; " + amountOfSteps.ToString();

            }

            catch
            {
                if (textBoxA.Text == "" || textBoxB.Text == "" || textBoxE.Text == "" || textBoxF.Text == "")
                {
                    MessageBox.Show("Пустые поля недопустимы");
                }
                else if (double.Parse(textBoxE.Text) < 0)
                {
                    MessageBox.Show("Точность не может быть меньше 0");
                }
                else if (double.Parse(textBoxA.Text) >= double.Parse(textBoxB.Text))
                {
                    MessageBox.Show("Параметр a должен быть меньше параметра b");
                }
                else
                {
                    MessageBox.Show("Некорректно задана вычисляемая функция");
                }
            }
        }

        private void LineDraw(double aBord, double bBord, double h, Expression func)
        {

            GraphPane pane = zedGraph.GraphPane;
            pane.CurveList.Clear();

            double hValue = h;
            int counter = 0;
            while (hValue < 1)
            {
                hValue *= 10;
                counter += 1;
            }

            if ((bBord - aBord) / 50000 > h)
            {
                h = (bBord - aBord) / 50000;
            }

            PointPairList list = new PointPairList();

            for (double x = aBord; x <= bBord; x += h)
            {
                double funcValue = Math.Round(FuncValue(x, func), counter);
                list.Add(x, funcValue);
            }

            pane.AddCurve("Sinc", list, Color.Blue, SymbolType.None);
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }
        static public double FuncValue(double point, Expression func)
        {
            Dictionary<string, FloatingPoint> x = new Dictionary<string, FloatingPoint>()
            {
                { "x", point }
            };
            return Evaluate.Evaluate(x, func).RealValue;
        }

        private void Params_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == ',' && textBox.Text.Contains(",") == false) || (e.KeyChar == '-' && textBox.Text == "") || (e.KeyChar == (char)Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

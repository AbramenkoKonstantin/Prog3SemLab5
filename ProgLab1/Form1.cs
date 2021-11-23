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

                foreach (Control control in this.Controls)
                {
                    if (control is TextBox && !control.Enabled)
                    {
                        control.Text = "";
                    }
                }

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

                int round = Round(esp);

                if (checkBoxTrapezium.Checked)
                {
                    int splits = TrapeziumMethod.OptimalSplits(aBord, bBord, esp, func);
                    double square = TrapeziumMethod.Calculation(aBord, bBord, splits, func);
                    trapeziumAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                }

                if (checkBoxRectangle.Checked)
                {
                    int splits = RectangleMethod.OptimalSplits(aBord, bBord, esp, func);
                    double square = RectangleMethod.Calculation(aBord, bBord, splits, func);
                    rectangleAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                }

                if (checkBoxSimpson.Checked)
                {
                    int splits = SimpsonMethod.OptimalSplits(aBord, bBord, esp, func);
                    double square = SimpsonMethod.Calculation(aBord, bBord, splits, func);
                    simpsonAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                }
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

        private int Round(double esp)
        {
            int round = 0;
            double espValue = esp;
            while (espValue < 1)
            {
                round += 1;
                espValue *= 10;
            }
            return round;
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

        private void backBtn_Click(object sender, EventArgs e)
        {
            double.TryParse(textBoxA.Text, out double aBord);
            double.TryParse(textBoxB.Text, out double bBord);
            double.TryParse(textBoxE.Text, out double esp);
            Expression func = Infix.ParseOrThrow(textBoxF.Text);
            int round = Round(esp);


            if (trapeziumAnswerBox.Text != "")
            {
                int splits = int.Parse(trapeziumAnswerBox.Text.Substring(trapeziumAnswerBox.Text.IndexOf("; ") + 1));
                double square;
                if (splits / 2 > 0)
                {
                    splits /= 2;
                    square = TrapeziumMethod.Calculation(aBord, bBord, splits, func);
                    trapeziumAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                }
            }

            if (rectangleAnswerBox.Text != "")
            {
                int splits = int.Parse(rectangleAnswerBox.Text.Substring(rectangleAnswerBox.Text.IndexOf("; ") + 1));
                double square;
                if (splits / 2 > 0)
                {
                    splits /= 2;
                    square = RectangleMethod.Calculation(aBord, bBord, splits, func);
                    rectangleAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                }
            }

            if (simpsonAnswerBox.Text != "")
            {
                int splits = int.Parse(simpsonAnswerBox.Text.Substring(simpsonAnswerBox.Text.IndexOf("; ") + 1));
                double square;
                if (splits / 2 > 0)
                {
                    splits /= 2;
                    square = SimpsonMethod.Calculation(aBord, bBord, splits, func);
                    simpsonAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                }
            }
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            double.TryParse(textBoxA.Text, out double aBord);
            double.TryParse(textBoxB.Text, out double bBord);
            double.TryParse(textBoxE.Text, out double esp);
            Expression func = Infix.ParseOrThrow(textBoxF.Text);
            int round = Round(esp);

            if (trapeziumAnswerBox.Text != "")
            {
                int splitsTrapezium = int.Parse(trapeziumAnswerBox.Text.Substring(trapeziumAnswerBox.Text.IndexOf("; ") + 1));
                double squareTrapezium;
                if (splitsTrapezium * 2 < 100000)
                {
                    splitsTrapezium *= 2;
                    squareTrapezium = TrapeziumMethod.Calculation(aBord, bBord, splitsTrapezium, func);
                    trapeziumAnswerBox.Text = Math.Round(squareTrapezium, round).ToString() + "; " + splitsTrapezium.ToString();
                }
            }

            if (rectangleAnswerBox.Text != "")
            {
                int splitsRectangle = int.Parse(rectangleAnswerBox.Text.Substring(rectangleAnswerBox.Text.IndexOf("; ") + 1));
                double squareRectangle;
                if (splitsRectangle * 2 < 100000)
                {
                    splitsRectangle *= 2;
                    squareRectangle = RectangleMethod.Calculation(aBord, bBord, splitsRectangle, func);
                    rectangleAnswerBox.Text = Math.Round(squareRectangle, round).ToString() + "; " + splitsRectangle.ToString();
                }
            }

            if (simpsonAnswerBox.Text != "")
            {
                int splitsSimpson = int.Parse(simpsonAnswerBox.Text.Substring(simpsonAnswerBox.Text.IndexOf("; ") + 1));
                double squareSimpson;
                if (splitsSimpson * 2 < 100000)
                {
                    splitsSimpson *= 2;
                    squareSimpson = SimpsonMethod.Calculation(aBord, bBord, splitsSimpson, func);
                    simpsonAnswerBox.Text = Math.Round(squareSimpson, round).ToString() + "; " + splitsSimpson.ToString();
                }
            }
        }
    }
}

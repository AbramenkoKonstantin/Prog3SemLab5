using System;
using System.Collections.Generic;
using System.Drawing;
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

                GraphPane pane = graphTrapezium.GraphPane;
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
                    int splits = await Task.Run(() => TrapeziumMethod.OptimalSplits(aBord, bBord, esp, func));
                    double square = await Task.Run(() => TrapeziumMethod.Calculation(aBord, bBord, splits, func));
                    trapeziumAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                    await Task.Run(() => TrapeziumSplits(aBord, bBord, splits, func));
                }

                if (checkBoxRectangle.Checked)
                {
                    int splits = await Task.Run(() => RectangleMethod.OptimalSplits(aBord, bBord, esp, func));
                    double square = await Task.Run(() => RectangleMethod.Calculation(aBord, bBord, splits, func));
                    rectangleAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                    await Task.Run(() => RectangleSplits(aBord, bBord, splits, func));
                }

                if (checkBoxSimpson.Checked)
                {
                    int splits = await Task.Run(() => SimpsonMethod.OptimalSplits(aBord, bBord, esp, func));
                    double square = await Task.Run(() => SimpsonMethod.Calculation(aBord, bBord, splits, func));
                    simpsonAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                    await Task.Run(() => SimpsonSplits(aBord, bBord, splits, func));
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

        async public void TrapeziumSplits(double aBord, double bBord, int splits, Expression func)
        {
            GraphPane pane = graphTrapezium.GraphPane;

            if (pane.CurveList.Count > 1)
            {
                pane.CurveList.RemoveAt(1);
            }

            double splitStep = (bBord - aBord) / splits;
            double x = aBord;

            PointPairList trapeziumList = new PointPairList();

            for (int counter = 0; counter < splits - 1; ++counter)
            {
                x += splitStep;
                trapeziumList.Add(x, 0);
                trapeziumList.Add(x, FuncValue(x, func));
                trapeziumList.Add(x + splitStep, FuncValue(x + splitStep, func));
                trapeziumList.Add(x + splitStep, 0);
                graphTrapezium.AxisChange();
                graphTrapezium.Invalidate();
            }
            await Task.Run(() => pane.AddCurve("", trapeziumList, Color.Red, SymbolType.None));
            pane.XAxis.Scale.MinAuto = true;
            pane.XAxis.Scale.MaxAuto = true;
            pane.YAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;

            graphTrapezium.AxisChange();
            graphTrapezium.Invalidate();
        }

        async public void RectangleSplits(double aBord, double bBord, int splits, Expression func)
        {
            GraphPane pane = graphRectangle.GraphPane;

            if (pane.CurveList.Count > 1)
            {
                pane.CurveList.RemoveAt(1);
            }

            double splitStep = (bBord - aBord) / splits;
            double x = aBord;

            double[] xValues = new double[splits];
            double[] yValues = new double[splits];

            for (int counter = 0; counter < splits - 1; ++counter)
            {
                x += splitStep;
                xValues[counter] = x + splitStep / 2;
                yValues[counter] = FuncValue(x + splitStep, func);
            }

            await Task.Run(() => pane.AddBar("", xValues, yValues, Color.White));

            pane.BarSettings.MinClusterGap = 0.0f;
            pane.XAxis.Scale.MinAuto = true;
            pane.XAxis.Scale.MaxAuto = true;
            pane.YAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;
            graphRectangle.AxisChange();
            graphRectangle.Invalidate();
        }

        async public void SimpsonSplits(double aBord, double bBord, int splits, Expression func)
        {
            GraphPane pane = graphSimpson.GraphPane;

            if (pane.CurveList.Count > 1)
            {
                pane.CurveList.RemoveAt(1);
            }

            double splitStep = (bBord - aBord) / splits;
            double x = aBord;
            PointPairList list = new PointPairList();

            for (int counter = 1; counter <= splits; ++counter)
            {
                x += splitStep;
                list.Add(x, FuncValue(x, func));
            }

            LineItem myCurve = await Task.Run(() => pane.AddCurve("", list, Color.Red));
            myCurve.Line.IsVisible = false;
            myCurve.Symbol.Fill.Color = Color.Red;
            myCurve.Symbol.Fill.Type = FillType.Solid;
            myCurve.Symbol.Size = 5;
            pane.XAxis.Scale.MinAuto = true;
            pane.XAxis.Scale.MaxAuto = true;
            pane.YAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;

            graphSimpson.AxisChange();
            graphSimpson.Invalidate();
        }


        async private void LineDraw(double aBord, double bBord, double esp, Expression func)
        {
            PointPairList list = new PointPairList();
            GraphPane trapeziumMethod = graphTrapezium.GraphPane;
            GraphPane rectangleMethod = graphRectangle.GraphPane;
            GraphPane simpsonMethod = graphSimpson.GraphPane;

            if (checkBoxTrapezium.Checked)
            {
                trapeziumMethod.CurveList.Clear();
                trapeziumMethod.Title.Text = "Trapezium Method";
                await Task.Run(() => trapeziumMethod.AddCurve("", list, Color.Blue, SymbolType.None));
                graphTrapezium.AxisChange();
                graphTrapezium.Invalidate();
                trapeziumMethod.XAxis.Scale.MinAuto = true;
                trapeziumMethod.XAxis.Scale.MaxAuto = true;
                trapeziumMethod.YAxis.Scale.MinAuto = true;
                trapeziumMethod.YAxis.Scale.MaxAuto = true;
            }

            else
            {
                trapeziumMethod.CurveList.Clear();
                graphTrapezium.AxisChange();
                graphTrapezium.Invalidate();
            }


            if (checkBoxRectangle.Checked)
            {
                rectangleMethod.CurveList.Clear();
                rectangleMethod.Title.Text = "Rectangle Method";
                await Task.Run(() => rectangleMethod.AddCurve("", list, Color.Blue, SymbolType.None));
                graphRectangle.AxisChange();
                graphRectangle.Invalidate();
                rectangleMethod.XAxis.Scale.MinAuto = true;
                rectangleMethod.XAxis.Scale.MaxAuto = true;
                rectangleMethod.YAxis.Scale.MinAuto = true;
                rectangleMethod.YAxis.Scale.MaxAuto = true;
            }

            else
            {
                rectangleMethod.CurveList.Clear();
                graphRectangle.AxisChange();
                graphRectangle.Invalidate();
            }


            if (checkBoxSimpson.Checked)
            {
                
                simpsonMethod.CurveList.Clear();
                simpsonMethod.Title.Text = "Simpson Method";
                await Task.Run(() => simpsonMethod.AddCurve("", list, Color.Blue, SymbolType.None));
                graphSimpson.AxisChange();
                graphSimpson.Invalidate();
                simpsonMethod.XAxis.Scale.MinAuto = true;
                simpsonMethod.XAxis.Scale.MaxAuto = true;
                simpsonMethod.YAxis.Scale.MinAuto = true;
                simpsonMethod.YAxis.Scale.MaxAuto = true;
            }

            else
            {
                simpsonMethod.CurveList.Clear();
                graphSimpson.AxisChange();
                graphSimpson.Invalidate();
            }

            double espValue = esp;
            int counter = 0;
            while (espValue < 1)
            {
                espValue *= 10;
                counter += 1;
            }

            if ((bBord - aBord) / 50000 > esp)
            {
                esp = (bBord - aBord) / 50000;
            }

            for (double x = aBord; x <= bBord; x += esp)
            {
                double funcValue = Math.Round(FuncValue(x, func), counter);
                list.Add(x, funcValue);
            }
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

        async private void backBtn_Click(object sender, EventArgs e)
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
                if (splits / 2 > 3)
                {
                    splits /= 2;
                    square = await Task.Run(() => TrapeziumMethod.Calculation(aBord, bBord, splits, func));
                    trapeziumAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                    await Task.Run(() => TrapeziumSplits(aBord, bBord, splits, func));
                }
            }

            if (rectangleAnswerBox.Text != "")
            {
                int splits = int.Parse(rectangleAnswerBox.Text.Substring(rectangleAnswerBox.Text.IndexOf("; ") + 1));
                double square;
                if (splits / 2 > 3)
                {
                    splits /= 2;
                    square = await Task.Run(() =>  RectangleMethod.Calculation(aBord, bBord, splits, func));
                    rectangleAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                    await Task.Run(() => RectangleSplits(aBord, bBord, splits, func));
                }
            }

            if (simpsonAnswerBox.Text != "")
            {
                int splits = int.Parse(simpsonAnswerBox.Text.Substring(simpsonAnswerBox.Text.IndexOf("; ") + 1));
                double square;
                if (splits / 2 > 3)
                {
                    splits /= 2;
                    square = await Task.Run(() => SimpsonMethod.Calculation(aBord, bBord, splits, func));
                    simpsonAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                    await Task.Run(() => SimpsonSplits(aBord, bBord, splits, func));
                }
            }
        }

        async private void forwardBtn_Click(object sender, EventArgs e)
        {
            double.TryParse(textBoxA.Text, out double aBord);
            double.TryParse(textBoxB.Text, out double bBord);
            double.TryParse(textBoxE.Text, out double esp);
            Expression func = Infix.ParseOrThrow(textBoxF.Text);
            int round = Round(esp);

            if (trapeziumAnswerBox.Text != "")
            {
                int optimalSplits = await Task.Run(() => TrapeziumMethod.OptimalSplits(aBord, bBord, esp, func));
                int splits = int.Parse(trapeziumAnswerBox.Text.Substring(trapeziumAnswerBox.Text.IndexOf("; ") + 1));
                double square;
                if (splits * 2 <= optimalSplits)
                {
                    splits *= 2;
                    square = await Task.Run(() => TrapeziumMethod.Calculation(aBord, bBord, splits, func));
                    trapeziumAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                    await Task.Run(() => TrapeziumSplits(aBord, bBord, splits, func));
                }
            }

            if (rectangleAnswerBox.Text != "")
            {
                int optimalSplits = await Task.Run(() => RectangleMethod.OptimalSplits(aBord, bBord, esp, func));
                int splits = int.Parse(rectangleAnswerBox.Text.Substring(rectangleAnswerBox.Text.IndexOf("; ") + 1));
                double square;
                if (splits * 2 <= optimalSplits)
                {
                    splits *= 2;
                    square = await Task.Run(() => RectangleMethod.Calculation(aBord, bBord, splits, func));
                    rectangleAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                    await Task.Run(() => RectangleSplits(aBord, bBord, splits, func));
                }
            }

            if (simpsonAnswerBox.Text != "")
            {
                int optimalSplits = await Task.Run(() => SimpsonMethod.OptimalSplits(aBord, bBord, esp, func));
                int splits = int.Parse(simpsonAnswerBox.Text.Substring(simpsonAnswerBox.Text.IndexOf("; ") + 1));
                double square;
                if (splits * 2 <= optimalSplits)
                {
                    splits *= 2;
                    square = await Task.Run(() => SimpsonMethod.Calculation(aBord, bBord, splits, func));
                    simpsonAnswerBox.Text = Math.Round(square, round).ToString() + "; " + splits.ToString();
                    await Task.Run(() => SimpsonSplits(aBord, bBord, splits, func));
                }
            }
        }
    }
}

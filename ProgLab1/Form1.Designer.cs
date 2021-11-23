
namespace ProgLab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxF = new System.Windows.Forms.TextBox();
            this.trapeziumAnswerBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxE = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.graphTrapezium = new ZedGraph.ZedGraphControl();
            this.rectangleAnswerBox = new System.Windows.Forms.TextBox();
            this.simpsonAnswerBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxTrapezium = new System.Windows.Forms.CheckBox();
            this.checkBoxRectangle = new System.Windows.Forms.CheckBox();
            this.checkBoxSimpson = new System.Windows.Forms.CheckBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.graphSimpson = new ZedGraph.ZedGraphControl();
            this.graphRectangle = new ZedGraph.ZedGraphControl();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(74, 56);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(127, 20);
            this.textBoxA.TabIndex = 0;
            this.textBoxA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Params_KeyPress);
            // 
            // textBoxF
            // 
            this.textBoxF.Location = new System.Drawing.Point(74, 185);
            this.textBoxF.Name = "textBoxF";
            this.textBoxF.Size = new System.Drawing.Size(127, 20);
            this.textBoxF.TabIndex = 3;
            // 
            // trapeziumAnswerBox
            // 
            this.trapeziumAnswerBox.Enabled = false;
            this.trapeziumAnswerBox.Location = new System.Drawing.Point(355, 84);
            this.trapeziumAnswerBox.Name = "trapeziumAnswerBox";
            this.trapeziumAnswerBox.Size = new System.Drawing.Size(127, 20);
            this.trapeziumAnswerBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Функция";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "a";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem,
            this.exit});
            this.menuStrip1.Location = new System.Drawing.Point(9, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(142, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "Рассчитать";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.ToolStripMenuItem.Text = "Рассчитать";
            this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(54, 20);
            this.exit.Text = "Выход";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "b";
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(74, 95);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(127, 20);
            this.textBoxB.TabIndex = 1;
            this.textBoxB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Params_KeyPress);
            // 
            // textBoxE
            // 
            this.textBoxE.Location = new System.Drawing.Point(74, 134);
            this.textBoxE.Name = "textBoxE";
            this.textBoxE.Size = new System.Drawing.Size(127, 20);
            this.textBoxE.TabIndex = 2;
            this.textBoxE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Params_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "e";
            // 
            // graphTrapezium
            // 
            this.graphTrapezium.Location = new System.Drawing.Point(565, 9);
            this.graphTrapezium.Name = "graphTrapezium";
            this.graphTrapezium.ScrollGrace = 0D;
            this.graphTrapezium.ScrollMaxX = 0D;
            this.graphTrapezium.ScrollMaxY = 0D;
            this.graphTrapezium.ScrollMaxY2 = 0D;
            this.graphTrapezium.ScrollMinX = 0D;
            this.graphTrapezium.ScrollMinY = 0D;
            this.graphTrapezium.ScrollMinY2 = 0D;
            this.graphTrapezium.Size = new System.Drawing.Size(499, 273);
            this.graphTrapezium.TabIndex = 13;
            this.graphTrapezium.UseExtendedPrintDialog = true;
            // 
            // rectangleAnswerBox
            // 
            this.rectangleAnswerBox.Enabled = false;
            this.rectangleAnswerBox.Location = new System.Drawing.Point(354, 123);
            this.rectangleAnswerBox.Name = "rectangleAnswerBox";
            this.rectangleAnswerBox.Size = new System.Drawing.Size(127, 20);
            this.rectangleAnswerBox.TabIndex = 14;
            // 
            // simpsonAnswerBox
            // 
            this.simpsonAnswerBox.Enabled = false;
            this.simpsonAnswerBox.Location = new System.Drawing.Point(354, 162);
            this.simpsonAnswerBox.Name = "simpsonAnswerBox";
            this.simpsonAnswerBox.Size = new System.Drawing.Size(127, 20);
            this.simpsonAnswerBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Метод трапеций";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(352, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Метод прямоугольников";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(352, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Метод Симпсона";
            // 
            // checkBoxTrapezium
            // 
            this.checkBoxTrapezium.AutoSize = true;
            this.checkBoxTrapezium.Location = new System.Drawing.Point(334, 87);
            this.checkBoxTrapezium.Name = "checkBoxTrapezium";
            this.checkBoxTrapezium.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTrapezium.TabIndex = 19;
            this.checkBoxTrapezium.UseVisualStyleBackColor = true;
            // 
            // checkBoxRectangle
            // 
            this.checkBoxRectangle.AutoSize = true;
            this.checkBoxRectangle.Location = new System.Drawing.Point(333, 126);
            this.checkBoxRectangle.Name = "checkBoxRectangle";
            this.checkBoxRectangle.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRectangle.TabIndex = 20;
            this.checkBoxRectangle.UseVisualStyleBackColor = true;
            // 
            // checkBoxSimpson
            // 
            this.checkBoxSimpson.AutoSize = true;
            this.checkBoxSimpson.Location = new System.Drawing.Point(333, 165);
            this.checkBoxSimpson.Name = "checkBoxSimpson";
            this.checkBoxSimpson.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSimpson.TabIndex = 21;
            this.checkBoxSimpson.UseVisualStyleBackColor = true;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(24, 236);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(228, 46);
            this.backBtn.TabIndex = 22;
            this.backBtn.Text = "Назад";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // graphSimpson
            // 
            this.graphSimpson.Location = new System.Drawing.Point(565, 303);
            this.graphSimpson.Name = "graphSimpson";
            this.graphSimpson.ScrollGrace = 0D;
            this.graphSimpson.ScrollMaxX = 0D;
            this.graphSimpson.ScrollMaxY = 0D;
            this.graphSimpson.ScrollMaxY2 = 0D;
            this.graphSimpson.ScrollMinX = 0D;
            this.graphSimpson.ScrollMinY = 0D;
            this.graphSimpson.ScrollMinY2 = 0D;
            this.graphSimpson.Size = new System.Drawing.Size(499, 273);
            this.graphSimpson.TabIndex = 24;
            this.graphSimpson.UseExtendedPrintDialog = true;
            // 
            // graphRectangle
            // 
            this.graphRectangle.Location = new System.Drawing.Point(24, 303);
            this.graphRectangle.Name = "graphRectangle";
            this.graphRectangle.ScrollGrace = 0D;
            this.graphRectangle.ScrollMaxX = 0D;
            this.graphRectangle.ScrollMaxY = 0D;
            this.graphRectangle.ScrollMaxY2 = 0D;
            this.graphRectangle.ScrollMinX = 0D;
            this.graphRectangle.ScrollMinY = 0D;
            this.graphRectangle.ScrollMinY2 = 0D;
            this.graphRectangle.Size = new System.Drawing.Size(499, 273);
            this.graphRectangle.TabIndex = 25;
            this.graphRectangle.UseExtendedPrintDialog = true;
            // 
            // forwardBtn
            // 
            this.forwardBtn.Location = new System.Drawing.Point(295, 236);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(228, 46);
            this.forwardBtn.TabIndex = 23;
            this.forwardBtn.Text = "Вперед";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.forwardBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 606);
            this.Controls.Add(this.graphRectangle);
            this.Controls.Add(this.graphSimpson);
            this.Controls.Add(this.forwardBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.checkBoxSimpson);
            this.Controls.Add(this.checkBoxRectangle);
            this.Controls.Add(this.checkBoxTrapezium);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.simpsonAnswerBox);
            this.Controls.Add(this.rectangleAnswerBox);
            this.Controls.Add(this.graphTrapezium);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trapeziumAnswerBox);
            this.Controls.Add(this.textBoxF);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxF;
        private System.Windows.Forms.TextBox trapeziumAnswerBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxE;
        private System.Windows.Forms.Label label4;
        private ZedGraph.ZedGraphControl graphTrapezium;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.TextBox rectangleAnswerBox;
        private System.Windows.Forms.TextBox simpsonAnswerBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxTrapezium;
        private System.Windows.Forms.CheckBox checkBoxRectangle;
        private System.Windows.Forms.CheckBox checkBoxSimpson;
        private System.Windows.Forms.Button backBtn;
        private ZedGraph.ZedGraphControl graphSimpson;
        private ZedGraph.ZedGraphControl graphRectangle;
        private System.Windows.Forms.Button forwardBtn;
    }
}


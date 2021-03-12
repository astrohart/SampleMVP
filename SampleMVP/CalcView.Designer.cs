
namespace SampleMVP
{
    partial class CalcView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addButton = new System.Windows.Forms.Button();
            this.firstValueTextBox = new System.Windows.Forms.TextBox();
            this.thirdValueTextBox = new System.Windows.Forms.TextBox();
            this.totalValueTextBox = new System.Windows.Forms.TextBox();
            this.secondValueTextBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.runningTotalLabel = new System.Windows.Forms.Label();
            this.runningTotalTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(20, 179);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(91, 40);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "ADD";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.OnClickAddButton);
            // 
            // firstValueTextBox
            // 
            this.firstValueTextBox.Location = new System.Drawing.Point(20, 21);
            this.firstValueTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.firstValueTextBox.Name = "firstValueTextBox";
            this.firstValueTextBox.Size = new System.Drawing.Size(232, 20);
            this.firstValueTextBox.TabIndex = 0;
            // 
            // thirdValueTextBox
            // 
            this.thirdValueTextBox.Location = new System.Drawing.Point(20, 86);
            this.thirdValueTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.thirdValueTextBox.Name = "thirdValueTextBox";
            this.thirdValueTextBox.Size = new System.Drawing.Size(232, 20);
            this.thirdValueTextBox.TabIndex = 2;
            // 
            // totalValueTextBox
            // 
            this.totalValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalValueTextBox.Location = new System.Drawing.Point(20, 119);
            this.totalValueTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.totalValueTextBox.Name = "totalValueTextBox";
            this.totalValueTextBox.ReadOnly = true;
            this.totalValueTextBox.Size = new System.Drawing.Size(232, 28);
            this.totalValueTextBox.TabIndex = 3;
            // 
            // secondValueTextBox
            // 
            this.secondValueTextBox.Location = new System.Drawing.Point(20, 52);
            this.secondValueTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.secondValueTextBox.Name = "secondValueTextBox";
            this.secondValueTextBox.Size = new System.Drawing.Size(232, 20);
            this.secondValueTextBox.TabIndex = 1;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(160, 179);
            this.resetButton.Margin = new System.Windows.Forms.Padding(2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(91, 40);
            this.resetButton.TabIndex = 5;
            this.resetButton.Text = "RESET";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.OnClickResetButton);
            // 
            // runningTotalLabel
            // 
            this.runningTotalLabel.AutoSize = true;
            this.runningTotalLabel.Location = new System.Drawing.Point(301, 55);
            this.runningTotalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.runningTotalLabel.Name = "runningTotalLabel";
            this.runningTotalLabel.Size = new System.Drawing.Size(77, 13);
            this.runningTotalLabel.TabIndex = 6;
            this.runningTotalLabel.Text = "Running Total:";
            // 
            // runningTotalTextBox
            // 
            this.runningTotalTextBox.Location = new System.Drawing.Point(302, 79);
            this.runningTotalTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.runningTotalTextBox.Name = "runningTotalTextBox";
            this.runningTotalTextBox.ReadOnly = true;
            this.runningTotalTextBox.Size = new System.Drawing.Size(187, 20);
            this.runningTotalTextBox.TabIndex = 7;
            // 
            // CalcForm
            // 
            this.AcceptButton = this.addButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 241);
            this.Controls.Add(this.runningTotalTextBox);
            this.Controls.Add(this.runningTotalLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.secondValueTextBox);
            this.Controls.Add(this.totalValueTextBox);
            this.Controls.Add(this.thirdValueTextBox);
            this.Controls.Add(this.firstValueTextBox);
            this.Controls.Add(this.addButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "CalcView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator v0.01a";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox firstValueTextBox;
        private System.Windows.Forms.TextBox thirdValueTextBox;
        private System.Windows.Forms.TextBox totalValueTextBox;
        private System.Windows.Forms.TextBox secondValueTextBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label runningTotalLabel;
        private System.Windows.Forms.TextBox runningTotalTextBox;
    }}


namespace FinalProject
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.InputFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SymbolTableFile = new System.Windows.Forms.TextBox();
            this.OutputFile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.OPFile = new System.Windows.Forms.TextBox();
            this.ASCFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.programName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F);
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "SIC/XE Program File Name :";
            // 
            // InputFile
            // 
            this.InputFile.Font = new System.Drawing.Font("新細明體", 10F);
            this.InputFile.Location = new System.Drawing.Point(256, 37);
            this.InputFile.Name = "InputFile";
            this.InputFile.Size = new System.Drawing.Size(150, 23);
            this.InputFile.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F);
            this.label2.Location = new System.Drawing.Point(12, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Symbol Table Output File Name (Option) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F);
            this.label3.Location = new System.Drawing.Point(12, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Object Program Output File Name :";
            // 
            // SymbolTableFile
            // 
            this.SymbolTableFile.Font = new System.Drawing.Font("新細明體", 10F);
            this.SymbolTableFile.Location = new System.Drawing.Point(255, 124);
            this.SymbolTableFile.Name = "SymbolTableFile";
            this.SymbolTableFile.Size = new System.Drawing.Size(150, 23);
            this.SymbolTableFile.TabIndex = 5;
            // 
            // OutputFile
            // 
            this.OutputFile.Font = new System.Drawing.Font("新細明體", 10F);
            this.OutputFile.Location = new System.Drawing.Point(255, 153);
            this.OutputFile.Name = "OutputFile";
            this.OutputFile.Size = new System.Drawing.Size(150, 23);
            this.OutputFile.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(176, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 7;
            this.button1.Text = "GO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F);
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Operators Input File Name  (Option) :";
            // 
            // OPFile
            // 
            this.OPFile.Font = new System.Drawing.Font("新細明體", 10F);
            this.OPFile.Location = new System.Drawing.Point(255, 66);
            this.OPFile.Name = "OPFile";
            this.OPFile.Size = new System.Drawing.Size(150, 23);
            this.OPFile.TabIndex = 3;
            // 
            // ASCFile
            // 
            this.ASCFile.Font = new System.Drawing.Font("新細明體", 10F);
            this.ASCFile.Location = new System.Drawing.Point(255, 95);
            this.ASCFile.Name = "ASCFile";
            this.ASCFile.Size = new System.Drawing.Size(150, 23);
            this.ASCFile.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F);
            this.label5.Location = new System.Drawing.Point(11, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "ASCII Input File Name  (Option) :";
            // 
            // programName
            // 
            this.programName.Font = new System.Drawing.Font("新細明體", 10F);
            this.programName.Location = new System.Drawing.Point(255, 8);
            this.programName.Name = "programName";
            this.programName.Size = new System.Drawing.Size(150, 23);
            this.programName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10F);
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "SIC/XE Program Name :";
            // 
            // MainForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 222);
            this.Controls.Add(this.programName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ASCFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OPFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OutputFile);
            this.Controls.Add(this.SymbolTableFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InputFile);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIC/XE Assembly";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SymbolTableFile;
        private System.Windows.Forms.TextBox OutputFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox OPFile;
        private System.Windows.Forms.TextBox ASCFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox programName;
        private System.Windows.Forms.Label label6;
    }
}


namespace FinalProject
{
    partial class CompileForm
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
            this.CompileProgress = new System.Windows.Forms.Label();
            this.CompileBar = new System.Windows.Forms.ProgressBar();
            this.CompileDetails = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CompileProgress
            // 
            this.CompileProgress.AutoSize = true;
            this.CompileProgress.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompileProgress.Location = new System.Drawing.Point(13, 13);
            this.CompileProgress.Name = "CompileProgress";
            this.CompileProgress.Size = new System.Drawing.Size(58, 15);
            this.CompileProgress.TabIndex = 0;
            this.CompileProgress.Text = "Progress:";
            // 
            // CompileBar
            // 
            this.CompileBar.Location = new System.Drawing.Point(12, 31);
            this.CompileBar.Name = "CompileBar";
            this.CompileBar.Size = new System.Drawing.Size(439, 23);
            this.CompileBar.TabIndex = 1;
            // 
            // CompileDetails
            // 
            this.CompileDetails.Location = new System.Drawing.Point(12, 75);
            this.CompileDetails.Name = "CompileDetails";
            this.CompileDetails.ReadOnly = true;
            this.CompileDetails.Size = new System.Drawing.Size(439, 195);
            this.CompileDetails.TabIndex = 2;
            this.CompileDetails.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Details:";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(376, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CompileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(463, 307);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CompileDetails);
            this.Controls.Add(this.CompileBar);
            this.Controls.Add(this.CompileProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CompileForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIC/XE Assembly";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompileForm_FormClosed);
            this.Load += new System.EventHandler(this.CompileForm_Load);
            this.Shown += new System.EventHandler(this.CompileForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CompileProgress;
        private System.Windows.Forms.ProgressBar CompileBar;
        private System.Windows.Forms.RichTextBox CompileDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}
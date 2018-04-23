namespace WindowsApplication1
{
    partial class Form1
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
            this.myVGridControl1 = new WindowsApplication1.MyVGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.myVGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // myVGridControl1
            // 
            this.myVGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myVGridControl1.Location = new System.Drawing.Point(0, 0);
            this.myVGridControl1.Name = "myVGridControl1";
            this.myVGridControl1.Size = new System.Drawing.Size(888, 508);
            this.myVGridControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 508);
            this.Controls.Add(this.myVGridControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.myVGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyVGridControl myVGridControl1;

    }
}


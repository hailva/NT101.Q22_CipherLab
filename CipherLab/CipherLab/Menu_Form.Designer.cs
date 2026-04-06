namespace CipherLab
{
    partial class Menu_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_Title = new Label();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label_Title
            // 
            label_Title.AutoSize = true;
            label_Title.Font = new Font("Calibri", 20.2909088F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Title.Location = new Point(83, 9);
            label_Title.Name = "label_Title";
            label_Title.Size = new Size(444, 38);
            label_Title.TabIndex = 0;
            label_Title.Text = "NT101.Q21 - NETWORK SECURITY";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 28.1454544F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(204, 51);
            label1.Name = "label1";
            label1.Size = new Size(202, 53);
            label1.TabIndex = 1;
            label1.Text = "CipherLab";
            // 
            // button1
            // 
            button1.Font = new Font("Calibri", 15.7090912F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(121, 126);
            button1.Name = "button1";
            button1.Size = new Size(135, 46);
            button1.TabIndex = 2;
            button1.Text = "RSA";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Calibri", 15.7090912F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(349, 126);
            button2.Name = "button2";
            button2.Size = new Size(135, 46);
            button2.TabIndex = 3;
            button2.Text = "Playfair";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 187);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label_Title);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Title;
        private Label label1;
        private Button button1;
        private Button button2;
    }
}

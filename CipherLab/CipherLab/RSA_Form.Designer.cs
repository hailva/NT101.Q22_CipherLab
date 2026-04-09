namespace CipherLab
{
    partial class RSA_Form
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
            groupBox2 = new GroupBox();
            tb_numP = new TextBox();
            tb_numQ = new TextBox();
            tb_phiN = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btn_calculate = new Button();
            btn_generate = new Button();
            groupBox3 = new GroupBox();
            label4 = new Label();
            tb_numE = new TextBox();
            label5 = new Label();
            tb_numN = new TextBox();
            groupBox4 = new GroupBox();
            tb_numD = new TextBox();
            label6 = new Label();
            groupBox6 = new GroupBox();
            tb_inputText = new TextBox();
            label7 = new Label();
            tb_outputText = new TextBox();
            label8 = new Label();
            btn_decrypt = new Button();
            btn_encrypt = new Button();
            btn_import = new Button();
            btn_clear = new Button();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_generate);
            groupBox2.Controls.Add(btn_calculate);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(tb_phiN);
            groupBox2.Controls.Add(tb_numQ);
            groupBox2.Controls.Add(tb_numP);
            groupBox2.Font = new Font("Calibri", 11.7818184F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(303, 174);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Key Parameter";
            // 
            // tb_numP
            // 
            tb_numP.Location = new Point(55, 25);
            tb_numP.Name = "tb_numP";
            tb_numP.Size = new Size(239, 29);
            tb_numP.TabIndex = 0;
            // 
            // tb_numQ
            // 
            tb_numQ.Location = new Point(55, 60);
            tb_numQ.Name = "tb_numQ";
            tb_numQ.Size = new Size(239, 29);
            tb_numQ.TabIndex = 1;
            // 
            // tb_phiN
            // 
            tb_phiN.Location = new Point(55, 95);
            tb_phiN.Name = "tb_phiN";
            tb_phiN.Size = new Size(239, 29);
            tb_phiN.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 15.7090912F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(25, 29);
            label1.TabIndex = 3;
            label1.Text = "P";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 15.7090912F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 60);
            label2.Name = "label2";
            label2.Size = new Size(29, 29);
            label2.TabIndex = 4;
            label2.Text = "Q";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 15.7090912F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(2, 95);
            label3.Name = "label3";
            label3.Size = new Size(47, 29);
            label3.TabIndex = 5;
            label3.Text = "ΦN";
            // 
            // btn_calculate
            // 
            btn_calculate.Font = new Font("Calibri", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_calculate.Location = new Point(201, 133);
            btn_calculate.Name = "btn_calculate";
            btn_calculate.Size = new Size(93, 32);
            btn_calculate.TabIndex = 6;
            btn_calculate.Text = "Calculate";
            btn_calculate.UseVisualStyleBackColor = true;
            // 
            // btn_generate
            // 
            btn_generate.Font = new Font("Calibri", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_generate.Location = new Point(102, 133);
            btn_generate.Name = "btn_generate";
            btn_generate.Size = new Size(93, 32);
            btn_generate.TabIndex = 7;
            btn_generate.Text = "Generate";
            btn_generate.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tb_numN);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(tb_numE);
            groupBox3.Controls.Add(label4);
            groupBox3.Font = new Font("Calibri", 11.7818184F, FontStyle.Bold);
            groupBox3.Location = new Point(321, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(303, 103);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Public Key";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 15.7090912F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 25);
            label4.Name = "label4";
            label4.Size = new Size(29, 29);
            label4.TabIndex = 6;
            label4.Text = "N";
            // 
            // tb_numE
            // 
            tb_numE.Location = new Point(55, 60);
            tb_numE.Name = "tb_numE";
            tb_numE.ReadOnly = true;
            tb_numE.Size = new Size(239, 29);
            tb_numE.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 15.7090912F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(22, 57);
            label5.Name = "label5";
            label5.Size = new Size(25, 29);
            label5.TabIndex = 8;
            label5.Text = "E";
            // 
            // tb_numN
            // 
            tb_numN.Location = new Point(55, 25);
            tb_numN.Name = "tb_numN";
            tb_numN.ReadOnly = true;
            tb_numN.Size = new Size(239, 29);
            tb_numN.TabIndex = 9;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(tb_numD);
            groupBox4.Font = new Font("Calibri", 11.7818184F, FontStyle.Bold);
            groupBox4.Location = new Point(321, 121);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(303, 65);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Private Key";
            // 
            // tb_numD
            // 
            tb_numD.Location = new Point(58, 28);
            tb_numD.Name = "tb_numD";
            tb_numD.ReadOnly = true;
            tb_numD.Size = new Size(239, 29);
            tb_numD.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 15.7090912F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(22, 28);
            label6.Name = "label6";
            label6.Size = new Size(28, 29);
            label6.TabIndex = 9;
            label6.Text = "D";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btn_clear);
            groupBox6.Controls.Add(btn_import);
            groupBox6.Controls.Add(btn_encrypt);
            groupBox6.Controls.Add(btn_decrypt);
            groupBox6.Controls.Add(label8);
            groupBox6.Controls.Add(tb_outputText);
            groupBox6.Controls.Add(label7);
            groupBox6.Controls.Add(tb_inputText);
            groupBox6.Font = new Font("Calibri", 11.7818184F, FontStyle.Bold);
            groupBox6.Location = new Point(12, 192);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(616, 288);
            groupBox6.TabIndex = 3;
            groupBox6.TabStop = false;
            groupBox6.Text = "Encryption";
            // 
            // tb_inputText
            // 
            tb_inputText.Location = new Point(9, 45);
            tb_inputText.Multiline = true;
            tb_inputText.Name = "tb_inputText";
            tb_inputText.ScrollBars = ScrollBars.Vertical;
            tb_inputText.Size = new Size(598, 82);
            tb_inputText.TabIndex = 10;
            tb_inputText.TextChanged += textBox1_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calibri", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(6, 20);
            label7.Name = "label7";
            label7.Size = new Size(53, 22);
            label7.TabIndex = 11;
            label7.Text = "Input:";
            // 
            // tb_outputText
            // 
            tb_outputText.Location = new Point(9, 159);
            tb_outputText.Multiline = true;
            tb_outputText.Name = "tb_outputText";
            tb_outputText.ReadOnly = true;
            tb_outputText.ScrollBars = ScrollBars.Vertical;
            tb_outputText.Size = new Size(598, 82);
            tb_outputText.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Calibri", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(10, 134);
            label8.Name = "label8";
            label8.Size = new Size(66, 22);
            label8.TabIndex = 13;
            label8.Text = "Output:";
            // 
            // btn_decrypt
            // 
            btn_decrypt.Font = new Font("Calibri", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_decrypt.Location = new Point(514, 247);
            btn_decrypt.Name = "btn_decrypt";
            btn_decrypt.Size = new Size(93, 32);
            btn_decrypt.TabIndex = 8;
            btn_decrypt.Text = "Decrypt";
            btn_decrypt.UseVisualStyleBackColor = true;
            // 
            // btn_encrypt
            // 
            btn_encrypt.Font = new Font("Calibri", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_encrypt.Location = new Point(415, 247);
            btn_encrypt.Name = "btn_encrypt";
            btn_encrypt.Size = new Size(93, 32);
            btn_encrypt.TabIndex = 14;
            btn_encrypt.Text = "Encrypt";
            btn_encrypt.UseVisualStyleBackColor = true;
            // 
            // btn_import
            // 
            btn_import.Font = new Font("Calibri", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_import.Location = new Point(108, 247);
            btn_import.Name = "btn_import";
            btn_import.Size = new Size(93, 32);
            btn_import.TabIndex = 15;
            btn_import.Text = "Import";
            btn_import.UseVisualStyleBackColor = true;
            // 
            // btn_clear
            // 
            btn_clear.Font = new Font("Calibri", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_clear.Location = new Point(9, 247);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(93, 32);
            btn_clear.TabIndex = 16;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = true;
            // 
            // RSA_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 494);
            Controls.Add(groupBox3);
            Controls.Add(groupBox4);
            Controls.Add(groupBox6);
            Controls.Add(groupBox2);
            Name = "RSA_Form";
            Text = "RSA_Form";
            Load += RSA_Form_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ToolTip toolTip1;
        private GroupBox groupBox2;
        private Button btn_generate;
        private Button btn_calculate;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tb_phiN;
        private TextBox tb_numQ;
        private TextBox tb_numP;
        private GroupBox groupBox3;
        private TextBox tb_numN;
        private Label label5;
        private TextBox tb_numE;
        private Label label4;
        private GroupBox groupBox4;
        private Label label6;
        private TextBox tb_numD;
        private GroupBox groupBox6;
        private Button btn_clear;
        private Button btn_import;
        private Button btn_encrypt;
        private Button btn_decrypt;
        private Label label8;
        private TextBox tb_outputText;
        private Label label7;
        private TextBox tb_inputText;
    }
}
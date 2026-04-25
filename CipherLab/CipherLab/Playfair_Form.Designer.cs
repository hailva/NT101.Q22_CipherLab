namespace CipherLab
{
    partial class Playfair_Form
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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            label1 = new Label();
            tb_key = new TextBox();
            dgv_matrix = new DataGridView();
            groupBox2 = new GroupBox();
            btn_createMatrix = new Button();
            rd_6x6 = new RadioButton();
            label2 = new Label();
            rd_5x5 = new RadioButton();
            groupBox3 = new GroupBox();
            btn_clear = new Button();
            btn_import = new Button();
            btn_decrypt = new Button();
            btn_encrypt = new Button();
            tb_output = new TextBox();
            label4 = new Label();
            tb_input = new TextBox();
            label3 = new Label();
            toolTip1 = new ToolTip(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_matrix).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tb_key);
            groupBox1.Font = new Font("Calibri", 11.7818184F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(275, 77);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Key Parameters";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 33);
            label1.Name = "label1";
            label1.Size = new Size(39, 24);
            label1.TabIndex = 2;
            label1.Text = "Key";
            // 
            // tb_key
            // 
            tb_key.Font = new Font("Calibri", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_key.Location = new Point(48, 29);
            tb_key.Name = "tb_key";
            tb_key.ScrollBars = ScrollBars.Both;
            tb_key.Size = new Size(217, 31);
            tb_key.TabIndex = 1;
            toolTip1.SetToolTip(tb_key, "A keyword or a phrase.");
            tb_key.TextChanged += tb_key_TextChanged;
            // 
            // dgv_matrix
            // 
            dgv_matrix.BackgroundColor = SystemColors.ButtonFace;
            dgv_matrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_matrix.Location = new Point(13, 29);
            dgv_matrix.Name = "dgv_matrix";
            dgv_matrix.RowHeadersWidth = 47;
            dgv_matrix.Size = new Size(250, 263);
            dgv_matrix.TabIndex = 3;
            toolTip1.SetToolTip(dgv_matrix, "Shows the generated $5 \\times 5$ or $6 \\times 6$ grid based on your key.");
            dgv_matrix.CellContentClick += dgv_matrix_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_createMatrix);
            groupBox2.Controls.Add(rd_6x6);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(rd_5x5);
            groupBox2.Controls.Add(dgv_matrix);
            groupBox2.Font = new Font("Calibri", 11.7818184F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(12, 96);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(275, 381);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Matrix Generation";
            // 
            // btn_createMatrix
            // 
            btn_createMatrix.Font = new Font("Calibri", 11.7818184F);
            btn_createMatrix.Location = new Point(129, 335);
            btn_createMatrix.Name = "btn_createMatrix";
            btn_createMatrix.Size = new Size(140, 40);
            btn_createMatrix.TabIndex = 6;
            btn_createMatrix.Text = "Create Matrix";
            btn_createMatrix.UseVisualStyleBackColor = true;
            btn_createMatrix.Click += btn_createMatrix_Click;
            // 
            // rd_6x6
            // 
            rd_6x6.AutoSize = true;
            rd_6x6.Font = new Font("Calibri", 11.7818184F);
            rd_6x6.Location = new Point(13, 351);
            rd_6x6.Name = "rd_6x6";
            rd_6x6.Size = new Size(60, 28);
            rd_6x6.TabIndex = 5;
            rd_6x6.TabStop = true;
            rd_6x6.Text = "6x6";
            toolTip1.SetToolTip(rd_6x6, "Use an extended 36-character grid (includes A-Z and 0-9).");
            rd_6x6.UseVisualStyleBackColor = true;
            rd_6x6.CheckedChanged += rd_6x6_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 11.7818184F);
            label2.Location = new Point(6, 296);
            label2.Name = "label2";
            label2.Size = new Size(173, 24);
            label2.TabIndex = 3;
            label2.Text = "Choose Matrix size:";
            // 
            // rd_5x5
            // 
            rd_5x5.AutoSize = true;
            rd_5x5.Font = new Font("Calibri", 11.7818184F);
            rd_5x5.Location = new Point(13, 322);
            rd_5x5.Name = "rd_5x5";
            rd_5x5.Size = new Size(60, 28);
            rd_5x5.TabIndex = 4;
            rd_5x5.TabStop = true;
            rd_5x5.Text = "5x5";
            toolTip1.SetToolTip(rd_5x5, "Use a standard 25-letter alphabet (usually combines I/J).");
            rd_5x5.UseVisualStyleBackColor = true;
            rd_5x5.CheckedChanged += rd_5x5_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btn_clear);
            groupBox3.Controls.Add(btn_import);
            groupBox3.Controls.Add(btn_decrypt);
            groupBox3.Controls.Add(btn_encrypt);
            groupBox3.Controls.Add(tb_output);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(tb_input);
            groupBox3.Controls.Add(label3);
            groupBox3.Font = new Font("Calibri", 11.7818184F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(293, 13);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(403, 464);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Encryption";
            // 
            // btn_clear
            // 
            btn_clear.Font = new Font("Calibri", 11.7818184F);
            btn_clear.Location = new Point(6, 424);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(93, 34);
            btn_clear.TabIndex = 10;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_import
            // 
            btn_import.Font = new Font("Calibri", 11.7818184F);
            btn_import.Location = new Point(105, 424);
            btn_import.Name = "btn_import";
            btn_import.Size = new Size(93, 34);
            btn_import.TabIndex = 9;
            btn_import.Text = "Import";
            btn_import.UseVisualStyleBackColor = true;
            btn_import.Click += btn_import_Click;
            // 
            // btn_decrypt
            // 
            btn_decrypt.Font = new Font("Calibri", 11.7818184F);
            btn_decrypt.Location = new Point(303, 424);
            btn_decrypt.Name = "btn_decrypt";
            btn_decrypt.Size = new Size(93, 34);
            btn_decrypt.TabIndex = 8;
            btn_decrypt.Text = "Decrypt";
            btn_decrypt.UseVisualStyleBackColor = true;
            btn_decrypt.Click += btn_decrypt_Click;
            // 
            // btn_encrypt
            // 
            btn_encrypt.Font = new Font("Calibri", 11.7818184F);
            btn_encrypt.Location = new Point(204, 424);
            btn_encrypt.Name = "btn_encrypt";
            btn_encrypt.Size = new Size(93, 34);
            btn_encrypt.TabIndex = 7;
            btn_encrypt.Text = "Encrypt";
            btn_encrypt.UseVisualStyleBackColor = true;
            btn_encrypt.Click += btn_encrypt_Click;
            // 
            // tb_output
            // 
            tb_output.Font = new Font("Calibri", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_output.Location = new Point(7, 254);
            tb_output.Multiline = true;
            tb_output.Name = "tb_output";
            tb_output.ReadOnly = true;
            tb_output.ScrollBars = ScrollBars.Both;
            tb_output.Size = new Size(390, 164);
            tb_output.TabIndex = 5;
            tb_output.TextChanged += tb_output_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 11.7818184F);
            label4.Location = new Point(6, 227);
            label4.Name = "label4";
            label4.Size = new Size(113, 24);
            label4.TabIndex = 4;
            label4.Text = "Output text:";
            // 
            // tb_input
            // 
            tb_input.Font = new Font("Calibri", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_input.Location = new Point(6, 59);
            tb_input.Multiline = true;
            tb_input.Name = "tb_input";
            tb_input.ScrollBars = ScrollBars.Both;
            tb_input.Size = new Size(390, 165);
            tb_input.TabIndex = 3;
            tb_input.TextChanged += tb_input_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 11.7818184F);
            label3.Location = new Point(6, 29);
            label3.Name = "label3";
            label3.Size = new Size(98, 24);
            label3.TabIndex = 3;
            label3.Text = "Input text:";
            // 
            // toolTip1
            // 
            toolTip1.ShowAlways = true;
            // 
            // Playfair_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 487);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Playfair_Form";
            Text = "Playfair_Form";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_matrix).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tb_key;
        private Label label1;
        private DataGridView dgv_matrix;
        private GroupBox groupBox2;
        private Button btn_createMatrix;
        private RadioButton rd_6x6;
        private Label label2;
        private RadioButton rd_5x5;
        private GroupBox groupBox3;
        private Label label4;
        private TextBox tb_input;
        private Label label3;
        private Button btn_encrypt;
        private TextBox tb_output;
        private Button btn_clear;
        private Button btn_import;
        private Button btn_decrypt;
        private ToolTip toolTip1;
    }
}
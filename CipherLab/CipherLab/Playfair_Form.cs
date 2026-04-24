using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CipherLab
{
    public partial class Playfair_Form : Form
    {
        private PlayfairCipher _cipher = null;
        private bool _formattingOutput = false;   // guard against recursive TextChanged

        // Returns the size chosen by the user on the UI (default 5)
        private int SelectedSize => rd_6x6.Checked ? 6 : 5;

        public Playfair_Form()
        {
            InitializeComponent();
        }

        // ─────────────────────────────────────────────
        //  Button handlers
        // ─────────────────────────────────────────────

        private void btn_createMatrix_Click(object sender, EventArgs e)
        {
            string key = tb_key.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Please enter a key.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _cipher = new PlayfairCipher(key);
                DisplayMatrix(_cipher.Matrix, _cipher.Size);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error building matrix: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            if (!EnsureCipher()) return;
            try
            {
                tb_output.Text = _cipher.Encrypt(tb_input.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encryption error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            if (!EnsureCipher()) return;
            try
            {
                tb_output.Text = _cipher.Decrypt(tb_input.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Decryption error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_key.Clear();
            tb_input.Clear();
            tb_output.Clear();
            dgv_matrix.Rows.Clear();
            dgv_matrix.Columns.Clear();
            _cipher = null;
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        tb_input.Text = System.IO.File.ReadAllText(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not read file: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ─────────────────────────────────────────────
        //  Radio-button handlers — rebuild matrix when
        //  the user switches size and a key exists
        // ─────────────────────────────────────────────

        private void rd_5x5_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_5x5.Checked && !string.IsNullOrWhiteSpace(tb_key.Text))
                btn_createMatrix_Click(sender, e);
        }

        private void rd_6x6_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_6x6.Checked && !string.IsNullOrWhiteSpace(tb_key.Text))
                btn_createMatrix_Click(sender, e);
        }

        // ─────────────────────────────────────────────
        //  TextChanged stubs (kept to satisfy designer)
        // ─────────────────────────────────────────────

        private void tb_key_TextChanged(object sender, EventArgs e) { }
        private void tb_input_TextChanged(object sender, EventArgs e) { }

        // Format output as pairs separated by spaces: ABCDEF → AB CD EF
        private void tb_output_TextChanged(object sender, EventArgs e)
        {
            if (_formattingOutput) return;          // prevent infinite loop
            _formattingOutput = true;

            string raw = tb_output.Text.Replace(" ", "");
            if (raw.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < raw.Length; i += 2)
                {
                    if (i > 0) sb.Append(' ');
                    sb.Append(raw[i]);
                    if (i + 1 < raw.Length) sb.Append(raw[i + 1]);
                }
                tb_output.Text = sb.ToString();
                tb_output.SelectionStart = tb_output.Text.Length; // keep cursor at end
            }

            _formattingOutput = false;
        }

        private void dgv_matrix_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // ─────────────────────────────────────────────
        //  Helpers
        // ─────────────────────────────────────────────

        private bool EnsureCipher()
        {
            if (_cipher != null) return true;

            string key = tb_key.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Please enter a key and click 'Create Matrix' first.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                _cipher = new PlayfairCipher(key);
                DisplayMatrix(_cipher.Matrix, _cipher.Size);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error building matrix: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void DisplayMatrix(char[,] matrix, int size)
        {
            dgv_matrix.Rows.Clear();
            dgv_matrix.Columns.Clear();

            // MUST be false BEFORE setting RowCount —
            // otherwise WinForms counts the phantom "new row"
            // inside RowCount, leaving only (size-1) real rows.
            dgv_matrix.AllowUserToAddRows = false;
            dgv_matrix.RowHeadersVisible = false;
            dgv_matrix.ColumnHeadersVisible = false;

            dgv_matrix.ColumnCount = size;
            dgv_matrix.RowCount = size;

            int cellSize = (size == 5) ? 36 : 30;
            foreach (DataGridViewColumn col in dgv_matrix.Columns)
            {
                col.Width = cellSize;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            foreach (DataGridViewRow row in dgv_matrix.Rows)
                row.Height = cellSize;

            for (int r = 0; r < size; r++)
                for (int c = 0; c < size; c++)
                    dgv_matrix.Rows[r].Cells[c].Value = matrix[r, c].ToString();
        }
    }

    // =================================================================
    //  PlayfairCipher — core logic
    // =================================================================

    public class PlayfairCipher
    {
        public char[,] Matrix { get; private set; }
        public int Size { get; private set; }

        // Lookup: character → (row, col)
        private Dictionary<char, (int row, int col)> _pos =
            new Dictionary<char, (int, int)>();

        public PlayfairCipher(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be empty.");

            bool hasDigit = false;
            foreach (char c in key)
                if (char.IsDigit(c)) { hasDigit = true; break; }

            Size = hasDigit ? 6 : 5;
            BuildMatrix(key.ToUpper(), Size);
        }

        // ─────────────────────────────────────────────
        //  Matrix construction
        // ─────────────────────────────────────────────

        private void BuildMatrix(string key, int size)
        {
            // Build the ordered alphabet for this matrix
            string alphabet = (size == 5)
                ? "ABCDEFGHIKLMNOPQRSTUVWXYZ"   // I and J merged; no J
                : "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // 36 chars

            List<char> sequence = new List<char>();
            HashSet<char> seen = new HashSet<char>();

            // Add key characters first (normalised)
            foreach (char raw in key)
            {
                char c = Normalize(raw, size);
                if (c == '\0') continue;
                if (seen.Add(c)) sequence.Add(c);
            }

            // Fill remaining alphabet characters
            foreach (char c in alphabet)
                if (seen.Add(c)) sequence.Add(c);

            // Populate matrix
            Matrix = new char[size, size];
            for (int i = 0; i < size * size; i++)
            {
                int r = i / size, col = i % size;
                Matrix[r, col] = sequence[i];
                _pos[sequence[i]] = (r, col);
            }
        }

        // ─────────────────────────────────────────────
        //  Text preprocessing
        // ─────────────────────────────────────────────

        private char Normalize(char c, int size)
        {
            c = char.ToUpper(c);
            if (size == 5)
            {
                if (c == 'J') return 'I';
                if (c >= 'A' && c <= 'Z') return c;
                return '\0';
            }
            else // 6x6
            {
                if ((c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')) return c;
                return '\0';
            }
        }

        private List<(char, char)> MakePairs(string text)
        {
            // 1. Normalise input
            StringBuilder sb = new StringBuilder();
            foreach (char c in text.ToUpper())
            {
                char n = Normalize(c, Size);
                if (n != '\0') sb.Append(n);
            }
            string clean = sb.ToString();

            // 2. Split into digraphs, inserting 'X' between repeated chars
            List<char> chars = new List<char>();
            int idx = 0;
            while (idx < clean.Length)
            {
                char first = clean[idx++];
                chars.Add(first);

                if (idx < clean.Length)
                {
                    char second = clean[idx];
                    if (second == first)
                    {
                        // Insert filler
                        char filler = (first == 'X') ? 'Q' : 'X';
                        chars.Add(filler);
                        // do NOT advance idx — second char will form next pair
                    }
                    else
                    {
                        chars.Add(second);
                        idx++;
                    }
                }
            }

            // 3. Pad to even length
            if (chars.Count % 2 != 0)
            {
                char last = chars[chars.Count - 1];
                chars.Add((last == 'X') ? 'Q' : 'X');
            }

            // 4. Return as pairs
            List<(char, char)> pairs = new List<(char, char)>();
            for (int i = 0; i < chars.Count; i += 2)
                pairs.Add((chars[i], chars[i + 1]));

            return pairs;
        }

        // ─────────────────────────────────────────────
        //  Core cipher rules
        // ─────────────────────────────────────────────

        private (char, char) EncryptPair(char a, char b)
        {
            var (r1, c1) = _pos[a];
            var (r2, c2) = _pos[b];

            if (r1 == r2) // same row → shift right
                return (Matrix[r1, (c1 + 1) % Size], Matrix[r2, (c2 + 1) % Size]);

            if (c1 == c2) // same col → shift down
                return (Matrix[(r1 + 1) % Size, c1], Matrix[(r2 + 1) % Size, c2]);

            // rectangle → swap columns
            return (Matrix[r1, c2], Matrix[r2, c1]);
        }

        private (char, char) DecryptPair(char a, char b)
        {
            var (r1, c1) = _pos[a];
            var (r2, c2) = _pos[b];

            if (r1 == r2) // same row → shift left
                return (Matrix[r1, (c1 + Size - 1) % Size], Matrix[r2, (c2 + Size - 1) % Size]);

            if (c1 == c2) // same col → shift up
                return (Matrix[(r1 + Size - 1) % Size, c1], Matrix[(r2 + Size - 1) % Size, c2]);

            // rectangle → swap columns
            return (Matrix[r1, c2], Matrix[r2, c1]);
        }

        // ─────────────────────────────────────────────
        //  Public API
        // ─────────────────────────────────────────────

        public string Encrypt(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext))
                return string.Empty;

            var pairs = MakePairs(plaintext);
            StringBuilder result = new StringBuilder();
            foreach (var (a, b) in pairs)
            {
                var (ea, eb) = EncryptPair(a, b);
                result.Append(ea).Append(eb);
            }
            return result.ToString();
        }

        public string Decrypt(string ciphertext)
        {
            if (string.IsNullOrEmpty(ciphertext))
                return string.Empty;

            // Ciphertext should already be clean pairs; still normalise
            StringBuilder sb = new StringBuilder();
            foreach (char c in ciphertext.ToUpper())
            {
                char n = Normalize(c, Size);
                if (n != '\0') sb.Append(n);
            }
            string clean = sb.ToString();

            if (clean.Length % 2 != 0)
                throw new ArgumentException(
                    "Ciphertext has an odd number of valid characters.");

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < clean.Length; i += 2)
            {
                var (da, db) = DecryptPair(clean[i], clean[i + 1]);
                result.Append(da).Append(db);
            }
            return result.ToString();
        }
    }
}
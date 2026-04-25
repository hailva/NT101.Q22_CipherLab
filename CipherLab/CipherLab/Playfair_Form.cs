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
        private bool _formattingOutput = false; // guard: prevent recursive TextChanged

        // Read radio button → size (5 or 6)
        private int SelectedSize => rd_6x6.Checked ? 6 : 5;

        public Playfair_Form()
        {
            InitializeComponent();
        }


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
                // Pass SelectedSize so radio button is always respected
                _cipher = new PlayfairCipher(key, SelectedSize);
                DisplayMatrix(_cipher.Matrix, _cipher.Size);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error building matrix: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Encryption error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Decryption error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Could not read file: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ──────────────────────────────────────────────────────────
        //  Radio-button handlers
        //  CheckedChanged fires AFTER the new state is committed, so
        //  SelectedSize already returns the correct value here.
        // ──────────────────────────────────────────────────────────

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

        private void tb_key_TextChanged(object sender, EventArgs e) { }
        private void tb_input_TextChanged(object sender, EventArgs e) { }

        // Format output as pairs separated by a space: ABCDEF → AB CD EF
        private void tb_output_TextChanged(object sender, EventArgs e)
        {
            if (_formattingOutput) return;
            _formattingOutput = true;

            string raw = tb_output.Text.Replace(" ", "");
            if (raw.Length > 0)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < raw.Length; i += 2)
                {
                    if (i > 0) sb.Append(' ');
                    sb.Append(raw[i]);
                    if (i + 1 < raw.Length) sb.Append(raw[i + 1]);
                }
                tb_output.Text = sb.ToString();
                tb_output.SelectionStart = tb_output.Text.Length;
            }

            _formattingOutput = false;
        }

        private void dgv_matrix_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

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
                // Pass SelectedSize here too
                _cipher = new PlayfairCipher(key, SelectedSize);
                DisplayMatrix(_cipher.Matrix, _cipher.Size);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error building matrix: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void DisplayMatrix(char[,] matrix, int size)
        {
            dgv_matrix.Rows.Clear();
            dgv_matrix.Columns.Clear();

            dgv_matrix.AllowUserToAddRows = false;
            dgv_matrix.RowHeadersVisible = false;
            dgv_matrix.ColumnHeadersVisible = false;

            dgv_matrix.ColumnCount = size;
            dgv_matrix.RowCount = size;

            int cellSize = (size == 5) ? 36 : 30;
            foreach (DataGridViewColumn col in dgv_matrix.Columns)
            {
                col.Width = cellSize;
                col.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
            foreach (DataGridViewRow row in dgv_matrix.Rows)
                row.Height = cellSize;

            for (int r = 0; r < size; r++)
                for (int c = 0; c < size; c++)
                    dgv_matrix.Rows[r].Cells[c].Value = matrix[r, c].ToString();
        }
    }

    //  PlayfairCipher — core logic

    public class PlayfairCipher
    {
        public char[,] Matrix { get; private set; }
        public int Size { get; private set; }

        private readonly Dictionary<char, (int row, int col)> _pos =
            new Dictionary<char, (int, int)>();

        //  forcedSize = 5  → force 5×5  (letters only, I=J)
        //  forcedSize = 6  → force 6×6  (A-Z + 0-9, no merge)
        //  forcedSize = 0  → auto-detect (digit in key → 6, else 5)
        public PlayfairCipher(string key, int forcedSize = 0)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be empty.");

            if (forcedSize == 5 || forcedSize == 6)
            {
                Size = forcedSize;
            }
            else
            {
                bool hasDigit = false;
                foreach (char c in key)
                    if (char.IsDigit(c)) { hasDigit = true; break; }
                Size = hasDigit ? 6 : 5;
            }

            BuildMatrix(key.ToUpper(), Size);
        }

        private void BuildMatrix(string key, int size)
        {
            string alphabet = (size == 5)
                ? "ABCDEFGHIKLMNOPQRSTUVWXYZ"            // 25 chars, I=J
                : "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // 36 chars

            var sequence = new List<char>();
            var seen = new HashSet<char>();

            // 1. Key chars first (normalised, deduped)
            foreach (char raw in key)
            {
                char c = Normalize(raw, size);
                if (c == '\0') continue;
                if (seen.Add(c)) sequence.Add(c);
            }

            // 2. Remaining alphabet
            foreach (char c in alphabet)
                if (seen.Add(c)) sequence.Add(c);

            // 3. Fill matrix and build lookup
            Matrix = new char[size, size];
            for (int i = 0; i < size * size; i++)
            {
                int r = i / size, col = i % size;
                Matrix[r, col] = sequence[i];
                _pos[sequence[i]] = (r, col);
            }
        }

        private char Normalize(char c, int size)
        {
            c = char.ToUpper(c);
            if (size == 5)
            {
                if (c == 'J') return 'I';           // merge J into I
                if (c >= 'A' && c <= 'Z') return c;
                return '\0';
            }
            else // 6×6
            {
                if ((c >= 'A' && c <= 'Z') ||
                    (c >= '0' && c <= '9')) return c;
                return '\0';
            }
        }

        //  Plaintext → list of digraph pairs
  
        private List<(char, char)> MakePairs(string text)
        {
            // 1. Strip invalid characters
            var sb = new StringBuilder();
            foreach (char c in text.ToUpper())
            {
                char n = Normalize(c, Size);
                if (n != '\0') sb.Append(n);
            }
            string clean = sb.ToString();

            // 2. Build char list, inserting filler 'X' (or 'Q') between
            //    two identical characters that would form a pair
            var chars = new List<char>();
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
                        chars.Add(first == 'X' ? 'Q' : 'X');
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
                chars.Add(last == 'X' ? 'Q' : 'X');
            }

            // 4. Return as (char, char) pairs
            var pairs = new List<(char, char)>();
            for (int i = 0; i < chars.Count; i += 2)
                pairs.Add((chars[i], chars[i + 1]));

            return pairs;
        }

        //  Encrypt / Decrypt a single digraph pair
        private (char, char) EncryptPair(char a, char b)
        {
            var (r1, c1) = _pos[a];
            var (r2, c2) = _pos[b];

            if (r1 == r2)   // same row → shift right (wrap)
                return (Matrix[r1, (c1 + 1) % Size],
                        Matrix[r2, (c2 + 1) % Size]);

            if (c1 == c2)   // same col → shift down (wrap)
                return (Matrix[(r1 + 1) % Size, c1],
                        Matrix[(r2 + 1) % Size, c2]);

            return (Matrix[r1, c2], Matrix[r2, c1]); // rectangle
        }

        private (char, char) DecryptPair(char a, char b)
        {
            var (r1, c1) = _pos[a];
            var (r2, c2) = _pos[b];

            if (r1 == r2)   // same row → shift left (wrap)
                return (Matrix[r1, (c1 + Size - 1) % Size],
                        Matrix[r2, (c2 + Size - 1) % Size]);

            if (c1 == c2)   // same col → shift up (wrap)
                return (Matrix[(r1 + Size - 1) % Size, c1],
                        Matrix[(r2 + Size - 1) % Size, c2]);

            return (Matrix[r1, c2], Matrix[r2, c1]); // rectangle (same as encrypt)
        }

        //  Public API
        public string Encrypt(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext)) return string.Empty;

            var pairs = MakePairs(plaintext);
            var result = new StringBuilder();
            foreach (var (a, b) in pairs)
            {
                var (ea, eb) = EncryptPair(a, b);
                result.Append(ea).Append(eb);
            }
            return result.ToString();
        }

        public string Decrypt(string ciphertext)
        {
            if (string.IsNullOrEmpty(ciphertext)) return string.Empty;

            // Strip spaces and invalid chars from ciphertext
            var sb = new StringBuilder();
            foreach (char c in ciphertext.ToUpper())
            {
                char n = Normalize(c, Size);
                if (n != '\0') sb.Append(n);
            }
            string clean = sb.ToString();

            if (clean.Length % 2 != 0)
                throw new ArgumentException(
                    "Ciphertext has an odd number of valid characters.");

            var result = new StringBuilder();
            for (int i = 0; i < clean.Length; i += 2)
            {
                var (da, db) = DecryptPair(clean[i], clean[i + 1]);
                result.Append(da).Append(db);
            }
            return result.ToString();
        }
    }
}

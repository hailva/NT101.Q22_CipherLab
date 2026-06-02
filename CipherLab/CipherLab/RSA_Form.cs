using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Numerics;

namespace CipherLab
{
    public partial class RSA_Form : Form
    {
        public RSA_Form()
        {
            InitializeComponent();
        }

        private void RSA_Form_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void reset()
        {
            tb_numP.Text = "";
            tb_numQ.Text = "";
            tb_numN.Text = "";
            tb_phiN.Text = "";
            tb_numE.Text = "";
            tb_numD.Text = "";
        }

        private bool IsPrime(BigInteger number)
        {
            if (number <= 1) return false;
            if (number == 2 || number == 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;

            int i = 5;
            int w = 2;

            while (i * i <= number)
            {
                if (number % i == 0) return false;

                i += w;
                w = 6 - w; // i tăng lần lượt: 5, 7, 11, 13, ...
            }

            return true;
        }

        // Hàm tạo một số nguyên tố ngẫu nhiên

        private BigInteger ChooseRandomNumber()
        {
            Random rd = new Random();
            return rd.Next(11, 101);
        }

        private void generateKey()
        {
            try
            {
                BigInteger p = BigInteger.Parse(tb_numP.Text);
                BigInteger q = BigInteger.Parse(tb_numQ.Text);

                // 1. Tính n = p * q
                BigInteger n = p * q;
                tb_numN.Text = n.ToString();

                // 2. Tính Phi(n) = (p-1)*(q-1)
                BigInteger phi = (p - 1) * (q - 1);
                tb_phiN.Text = phi.ToString();

                // 3. Chọn E (thường chọn 65537 nếu phi đủ lớn, hoặc tìm số nhỏ hơn)
                BigInteger e = 65537;
                if (e >= phi || GCD(e, phi) != 1)
                {
                    e = 3;
                    while (e < phi && GCD(e, phi) != 1)
                    {
                        e += 2;
                    }
                }
                tb_numE.Text = e.ToString();

                // 4. Tính D (Nghịch đảo modulo của E mod Phi)
                BigInteger d = ModInverse(e, phi);
                tb_numD.Text = d.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo khóa: " + ex.Message);
            }
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            reset();
            BigInteger P;
            BigInteger Q;

            do
            {
                P = ChooseRandomNumber();
                Q = ChooseRandomNumber();
            }
            while (P == Q || !IsPrime(P) || !IsPrime(Q));

            tb_numP.Text = P.ToString();
            tb_numQ.Text = Q.ToString();

            generateKey();  // --> gọi hàm tạo khóa chính

            btn_decrypt.Enabled = true;
            btn_encrypt.Enabled = true;

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            reset();
            tb_numE.Text = "";
        }

        // hàm tính nghịch đảo modulo sử dụng thuật toán Euclid mở rộng
        private BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            // khai báo biến t, q dùng trong thuật toán
            BigInteger t, q;
            BigInteger m0 = m;
            BigInteger x0 = 0;
            BigInteger x1 = 1;

            // Nếu m là 1, nghịch đảo không tồn tại
            if (m == 1)
                return 0;

            // Thuật toán Euclid mở rộng

            while (a > 1)
            {
                q = a / m;
                t = m;
                m = a % m;
                a = t;

                t = x0;
                x0 = x1 - q * x0;
                x1 = t;
            }


            // Đảm bảo x1 là số dương
            if (x1 < 0)
                x1 = x1 + m0;

            return x1;
        }

        // hàm kiểm tra số nguyên tố 
        private bool checkprime(BigInteger n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            // kiểm tra nhập p, q'=
            if (string.IsNullOrWhiteSpace(tb_numP.Text) || string.IsNullOrWhiteSpace(tb_numQ.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ giá trị cho P và Q.", "Lỗi");
                return;
            }

            if (!BigInteger.TryParse(tb_numP.Text, out BigInteger p))
            {
                MessageBox.Show("Giá trị P phải là số nguyên, không được chứa chữ hay ký tự đặc biệt!", "Lỗi");
                return;
            }

            if (!BigInteger.TryParse(tb_numQ.Text, out BigInteger q))
            {
                MessageBox.Show("Giá trị Q phải là số nguyên, không được chứa chữ hay ký tự đặc biệt!", "Lỗi");
                return;
            }

            // lấy giá trị p và q từ textbox
            //        BigInteger p = BigInteger.Parse(tb_numP.Text);
            //        BigInteger q = BigInteger.Parse(tb_numQ.Text);



            // kiểm tra p và q có phải là số nguyên dương và là số nguyên tố hay không
            if (checkprime(p) == false || checkprime(q) == false)
            {
                MessageBox.Show("P và Q phải là số nguyên dương và là số nguyên tố.");
                return;
            }

            // kiểm tra p và q có phải là hai số nguyên tố khác nhau
            if (p == q)
            {
                MessageBox.Show("P và Q phải là hai số nguyên tố khác nhau để đảm bảo tính bảo mật và chính xác!", "Lỗi RSA");
                return;
            }

            // tính n = p * q
            BigInteger n = p * q;
            tb_numN.Text = n.ToString();


            // tinhs phi = (p-1)*(q-1);
            BigInteger phi = (p - 1) * (q - 1);
            tb_phiN.Text = phi.ToString();

            // kiểm tra E có phải là số nguyên dương và nhỏ hơn phi hay không
            BigInteger E;
            if (string.IsNullOrWhiteSpace(tb_numE.Text))
            {
                // Nếu E trống thì tự điền E mặc định
                E = 65537;
                tb_numE.Text = E.ToString();
            }
            else
            {
                if (!BigInteger.TryParse(tb_numE.Text, out E))
                {
                    MessageBox.Show("Giá trị E phải là số nguyên, không được chứa chữ hay ký tự đặc biệt!", "Lỗi");
                    return;
                }

                // Kiểm tra điều kiện của E
                if (E <= 1 || E >= phi)
                {
                    MessageBox.Show($"E phải thỏa mãn điều kiện 1 < E < {phi}", "Lỗi RSA");
                    return;
                }

                // Kiểm tra E và phi có nguyên tố cùng nhau hay không
                if (GCD(E, phi) != 1)
                {
                    MessageBox.Show("E và Phi(N) phải nguyên tố cùng nhau (ƯCLN = 1).", "Lỗi RSA");
                    return;
                }
            }

            // tính D = nghịch đảo modulo của E mod phi
            BigInteger D = ModInverse(E, phi); // hàm tính nghịch đảo modulo
            if (D == -1)
            {
                MessageBox.Show("Không tìm thấy nghịch đảo modulo. Kiểm tra lại E.", "Lỗi");
                return;
            }
            tb_numD.Text = D.ToString();
            MessageBox.Show("Đã tính xong các thông số khóa!", "Thành công");

            //Cho phép mã hóa và giải mã sau khi tính khóa thành công
            btn_encrypt.Enabled = true;
            btn_decrypt.Enabled = true;
        }

        // hàm tính ƯCLN
        private BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_numN.Text) || string.IsNullOrEmpty(tb_numE.Text))
            {
                MessageBox.Show("Vui lòng tạo khóa (Generate) hoặc tính toán (Calculate) trước khi mã hóa!", "Thông báo");
                return;
            }

            if (string.IsNullOrEmpty(tb_inputText.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung cần mã hóa vào ô Input!", "Thông báo");
                return;
            }

            try
            {
                // 2. Lấy giá trị N và E từ TextBox
                BigInteger n = BigInteger.Parse(tb_numN.Text);
                BigInteger eKey = BigInteger.Parse(tb_numE.Text);

                // 3. Lấy chuỗi văn bản từ ô Input
                string input = tb_inputText.Text;
                List<string> encryptedValues = new List<string>();

                // 4. Duyệt qua từng ký tự trong chuỗi
                foreach (char c in input)
                {
                    // Chuyển ký tự thành s
                    BigInteger m = new BigInteger((int)c);

                    // Kiểm tra nếu m >= n thì không mã hóa được vì n nhở   
                    if (m >= n)
                    {
                        MessageBox.Show($"Ký tự '{c}' có mã ASCII là {m} lớn hơn N ({n}). Hãy chọn P, Q lớn hơn!", "Lỗi bảo mật");
                        return;
                    }

                    // Thực hiện tính toán: c_val = (m ^ eKey) % n
                    // Sử dụng ModPow để tính lũy thừa lớn hiệu quả
                    BigInteger c_val = BigInteger.ModPow(m, eKey, n);

                    // Lưu giá trị số sau khi mã hóa vào danh sách
                    encryptedValues.Add(c_val.ToString());
                }

                // 5. Hiển thị kết quả ra ô Output (các số cách nhau bởi dấu cách)
                tb_outputText.Text = string.Join(" ", encryptedValues);

                MessageBox.Show("Mã hóa thành công!", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_numN.Text))
            {
                MessageBox.Show("Thiếu thông số public N để giải mã!", "Lỗi");
                return;
            }
            else if (string.IsNullOrEmpty(tb_numD.Text))
            {
                MessageBox.Show("Thiếu thông số private D để giải mã!", "Lỗi");
                return;
            }

            // lấy dữ liệu để giải mã
            string input = tb_inputText.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Không có dữ liệu số để giải mã!", "Thông báo");
                return;
            }

            try
            {
                // 1. Lấy giá trị N và D từ TextBox
                BigInteger n = BigInteger.Parse(tb_numN.Text);
                BigInteger dKey = BigInteger.Parse(tb_numD.Text);

                // 2. Tách chuỗi số thành mảng dựa trên dấu cách
                string[] encryptedParts = input.Trim().Split(' ');
                StringBuilder decryptedText = new StringBuilder();

                foreach (string part in encryptedParts)
                {
                    if (string.IsNullOrWhiteSpace(part)) continue;

                    // Chuyển chuỗi số thành BigInteger
                    BigInteger c = BigInteger.Parse(part);

                    // 3. Thực hiện tính toán: m = (c ^ dKey) % n
                    BigInteger m = BigInteger.ModPow(c, dKey, n);

                    // 4. Chuyển con số m ngược lại thành ký tự Char
                    char character = (char)((int)m);
                    decryptedText.Append(character);
                }

                // 5. Hiển thị kết quả văn bản gốc
                tb_outputText.Text = decryptedText.ToString();

                MessageBox.Show("Giải mã thành công!", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi giải mã: Dữ liệu đầu vào không đúng định dạng số.\n" + ex.Message);
            }
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
                        tb_inputText.Text = System.IO.File.ReadAllText(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not read file: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

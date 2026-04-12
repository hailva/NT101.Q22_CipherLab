namespace CipherLab
{
    public partial class Menu_Form : Form
    {
        public Menu_Form()
        {
            InitializeComponent();
        }

        private void btn_openRSA_Click(object sender, EventArgs e)
        {
            RSA_Form rsa = new RSA_Form();
            rsa.ShowDialog();
        }

        private void btn_openPlayfair_Click(object sender, EventArgs e)
        {
            Playfair_Form playfair = new Playfair_Form();
            playfair.ShowDialog();
        }
    }
}

using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double gelir = 0;

        public Form1()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Gül növü (gül adı)";
            dataGridView1.Columns[1].Name = "Satış sayı";
            dataGridView1.Columns[2].Name = "Qiyməti";
            dataGridView1.Columns[3].Name = "Yekun qiyməti";

            label1.Text = "Toplam gəlir: 0.00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Bütün xanaları doldurun!");
                return;
            }

            int count;
            double price;

            if (!int.TryParse(textBox2.Text, out count) ||
                !double.TryParse(textBox3.Text.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out price))
            {
                MessageBox.Show("Say və qiyməti düzgün daxil edin!");
                return;
            }

            if (count <= 0 || price <= 0)
            {
                MessageBox.Show("Say və qiymət sıfırdan böyük olmalıdır!");
                return;
            }

            double result = count * price;

            dataGridView1.Rows.Add(
                textBox1.Text,
                count.ToString(),
                price.ToString("F2"),
                result.ToString("F2")
            );

            gelir += result;
            label1.Text = "Toplam gəlir: " +
                gelir.ToString("F2",
                System.Globalization.CultureInfo.InvariantCulture);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cavab = MessageBox.Show(
                "Çıxış edilsinmi?",
                "Təsdiq",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (cavab == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
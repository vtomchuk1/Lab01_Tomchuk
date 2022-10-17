using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Lab01_Tomchuk
{
    public partial class Lab01_Tomchuk : Form
    {
        string login, password;

        public Lab01_Tomchuk()
        {
            login = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";
            password = "69371091eb0f9aec7e61b7421cf3044529167e979cd975201909eb8ae33887ba";
            InitializeComponent();
            //Console.WriteLine(HashSHA256("0000"));
        }

        private static string HashSHA256(string s)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                sb.Append(bytes[i].ToString("x2"));
            return sb.ToString();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            // для кращого результату треба все хешувати
            // хеш пароля зроблений з солями, для підвищення захисту взлому

            if (HashSHA256(textBox_login.Text) == login && HashSHA256(textBox_password.Text + textBox_login.Text) == password)
            {
                status_color.BackColor = Color.Green;
                MessageBox.Show("авторизовано");
            }
            else
            {
                status_color.BackColor = Color.Red;
                MessageBox.Show("помилка");
            }
        }

        
    }
}

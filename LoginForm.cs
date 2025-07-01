using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KullaniciYonetimi.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {

            InitializeComponent();
        }
        private List<Kullanici> kullaniciListesi = new List<Kullanici>
        {
            new Kullanici { KullaniciAdi = "admin", Sifre = "1234", Rol = "Admin" },
            new Kullanici { KullaniciAdi = "kullanici", Sifre = "5678", Rol = "User" }
        };
        private void Yonlendir(string rol)
        {
            this.Hide();

            Form hedefForm = rol switch
            {
                "Admin" => new AdminForm(),
                "User" => new UserForm(),
                _ => null
            };

            if (hedefForm != null)
            {
                hedefForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Geçersiz rol: " + rol);
            }

            this.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtUsername.Text.Trim();
            string sifre = txtPassword.Text;

            // Kullanıcıyı listede ara
            Kullanici girisYapan = kullaniciListesi
                .FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre);

            if (girisYapan != null)
            {
                Yonlendir(girisYapan.Rol);
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}

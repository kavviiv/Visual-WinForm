using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Albumshop
{
    public partial class FP : Form
    {
        public FP()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (username.Text.Trim() == "" && password.Text.Trim() == "")
            {
                MessageBox.Show("Error!!!");
            }
            else
            {
                string query = "SELECT * FROM member WHERE Username = @user AND Password = @pass";
                SQLiteConnection con = new SQLiteConnection("Data Source = D:/BlueShopWA/BlueShopWA/Userdb.db");
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@user", username.Text);
                cmd.Parameters.AddWithValue("@pass", password.Text);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                Form3 form = new Form3();

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Success.");
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error!!!");
                }
            }

        }

        private void register_Click(object sender, EventArgs e)
        {
            this.Hide();
            Regis rg = new Regis();
            rg.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

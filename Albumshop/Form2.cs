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
    public partial class Regis : Form
    {
        public Regis()
        {
            InitializeComponent();
        }

        private void rb_Click(object sender, EventArgs e)
        {
            if (userregist.Text == "" && name.Text == "" && pass.Text == "")
            {
                MessageBox.Show("Error!!!");
            }
            SQLiteConnection con = new SQLiteConnection("Data Source = D:/BlueShopWA/BlueShopWA/Userdb.db");
            string query = "INSERT INTO member(Username, Name, Password) VALUES('" + userregist.Text + "', '" + name.Text + "', '" + pass.Text + "')";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Register Success.");
            FP fp = new FP();
            fp.Show();
            this.Hide();
        }

        private void back2_Click(object sender, EventArgs e)
        {
            FP fp = new FP();
            fp.Show();
            this.Hide();
        }

        private void RP_Load(object sender, EventArgs e)
        {

        }
    }
}

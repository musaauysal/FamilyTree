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

namespace family_tree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxAD.Text == "" || textBoxsoyad.Text == "" || textBoxbabaad.Text == "" || textBoxbbsoyad.Text == "" || textBoxannead.Text == "" || textBoxannesoyad.Text == "") {
                MessageBox.Show("Lütfen bilgileri eksiksiz girin...");
            }
            else
            {
                string yol = "Data source=dbapps.db";
                SQLiteConnection con = new SQLiteConnection(yol);
                con.Open();
                string sql = "insert into Person(Ad,Soyad,Babaad,Babasoyad,Annead,Annesoyad) values(@Ad,@Soyad,@Babaad,@Babasoyad,@annead,@Annesoyad)";
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ad", textBoxAD.Text);
                cmd.Parameters.AddWithValue("@Soyad", textBoxsoyad.Text);
                cmd.Parameters.AddWithValue("@Babaad", textBoxbabaad.Text);
                cmd.Parameters.AddWithValue("@Babasoyad", textBoxbbsoyad.Text);
                cmd.Parameters.AddWithValue("@Annead", textBoxannead.Text);
                cmd.Parameters.AddWithValue("@Annesoyad", textBoxannesoyad.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Veriler Kaydedildi...");
            }



            
        }
    }
}

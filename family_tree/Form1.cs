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
            if (txtAdSoyad.Text == "" || txtBabaAdSoyad.Text == "" || txtAnneAdSoyad.Text == "") {
                MessageBox.Show("Lütfen bilgileri eksiksiz girin...");
            }
            else
            {
                string yol = "Data source=dbapps.db";
                SQLiteConnection con = new SQLiteConnection(yol);
                con.Open();
                string sql = "insert into Person(AdSoyad,BabaadSoyad,AnneadSoyad) values(@AdSoyad,@BabaadSoyad,@AnneadSoyad)";
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
                cmd.Parameters.AddWithValue("@BabaadSoyad", txtBabaAdSoyad.Text);
                cmd.Parameters.AddWithValue("@AnneadSoyad", txtAnneAdSoyad.Text);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Veriler Kaydedildi...");
                con.Close();

                SQLiteCommand cmt = new SQLiteCommand();
                cmt.CommandText = "select * from Person";
                cmt.Connection = con;
                cmt.CommandType = CommandType.Text;
                SQLiteDataReader dr;
                con.Open();
                dr = cmt.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["BabaadSoyad"]);
                   

                }
                con.Close();
            }

           
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string yol = "Data source=dbapps.db";
            SQLiteConnection con = new SQLiteConnection(yol);
            SQLiteCommand cmt = new SQLiteCommand();
            cmt.CommandText = "select * from Person";
            cmt.Connection = con;
            cmt.CommandType = CommandType.Text;
            SQLiteDataReader dr;
            con.Open();
            dr = cmt.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["BabaadSoyad"]);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IZIManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string server = "mysql.hostinger.vn";
            string database = "u592289871_izidb";
            string uid = "u592289871_admin";
            string password = "123456";
            string connectionString;
            connectionString = "SERVER=" + server + ";"  + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = "INSERT INTO `guests`(`id`, `name`, `email`, `phone`, `address`) VALUES (1,2,null,null,null)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}

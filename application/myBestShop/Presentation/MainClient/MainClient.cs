using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myBestShop
{
    public partial class MainClient : Form
    {
        DataTable dataTable;
        MySqlDataAdapter myAdapter;


        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DATA.mySqlConnection.Close();
        }

        public MainClient()
        {
            DATA.mySqlConnection.Open();
            InitializeComponent();
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT FIO FROM client WHERE id_client = @id", DATA.mySqlConnection);
                mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = DATA.id;
                MySqlDataReader myReader = mySqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    Console.WriteLine(myReader.GetString(0));
                    labelName.Text += myReader.GetString(0).Replace(" _", "");
                }
                else
                {
                    Console.WriteLine("NdfdfgfsgfgssdfgfagafaO");
                }
                myReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void tables_box_TextChanged(object sender, EventArgs e)
        {
            dataTable = new DataTable();

            if (tables_box.Text == "order" || tables_box.Text == "discount") {
                try
                {
                    myAdapter = new MySqlDataAdapter("SELECT * FROM " + tables_box.Text + " WHERE id_client = " + DATA.id + ";", DATA.mySqlConnection);
                    myAdapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                try
                {
                    myAdapter = new MySqlDataAdapter("SELECT * FROM " + tables_box.Text + ";", DATA.mySqlConnection);
                    myAdapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}

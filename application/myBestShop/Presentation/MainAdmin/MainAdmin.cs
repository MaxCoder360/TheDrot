using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace myBestShop
{
    public partial class MainAdmin : Form
    {
        string currentTable;
        DataTable dataTable;
        MySqlDataAdapter myAdapter;


        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DATA.mySqlConnection.Close();
        }


        public MainAdmin()
        {
            DATA.mySqlConnection.Open();
            InitializeComponent();
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT FIO FROM employee where id_employee = @id", DATA.mySqlConnection);
                mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = DATA.id;
                MySqlDataReader myReader = mySqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    labelName.Text += myReader.GetString(0).Replace(" _", "");
                }
                else
                {
                    Console.WriteLine("NO");
                }
                myReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void deliveryInWork_Click(object sender, EventArgs e)
        {
            currentTable = "delivery";
            dataTable = new DataTable();
            try
            {   
                myAdapter = new MySqlDataAdapter("SELECT * FROM delivery where id_employee = " + DATA.id + " AND status != 'Доставлен';", DATA.mySqlConnection);
                MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(myAdapter);
                myAdapter.UpdateCommand = mySqlCommandBuilder.GetUpdateCommand();
                myAdapter.DeleteCommand = mySqlCommandBuilder.GetDeleteCommand();
                myAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();
                myAdapter.Fill(dataTable);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView.DataSource = bindingSource;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myAdapter.Update(dataTable);
        }

        private void deliveryClosed_Click(object sender, EventArgs e)
        {
            currentTable = "delivery";
            dataTable = new DataTable();
            try
            {
                myAdapter = new MySqlDataAdapter("SELECT * FROM delivery where id_employee = " + DATA.id + " AND status = 'Доставлен';", DATA.mySqlConnection);
                MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(myAdapter);
                myAdapter.UpdateCommand = mySqlCommandBuilder.GetUpdateCommand();
                myAdapter.DeleteCommand = mySqlCommandBuilder.GetDeleteCommand();
                myAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();
                myAdapter.Fill(dataTable);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView.DataSource = bindingSource;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void tables_box_TextChanged(object sender, EventArgs e)
        {
            dataTable = new DataTable();
            try
            {
                myAdapter = new MySqlDataAdapter("SELECT * FROM "+ tables_box.Text +";", DATA.mySqlConnection);
                MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(myAdapter);
                myAdapter.UpdateCommand = mySqlCommandBuilder.GetUpdateCommand();
                myAdapter.DeleteCommand = mySqlCommandBuilder.GetDeleteCommand();
                myAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();
                myAdapter.Fill(dataTable);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView.DataSource = bindingSource;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

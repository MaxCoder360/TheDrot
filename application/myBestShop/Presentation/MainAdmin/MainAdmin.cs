using myBestShop.Domain.Repository;
using static myBestShop.Utils.AppConfig;
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
using myBestShop.Utils;

namespace myBestShop
{
    public partial class MainAdmin : Form
    {
        private AdminRepository repository;
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public MainAdmin()
        {
            var repositoryConfig = DependencyBuilders.DomainModule.createRepositoryConfig(BUILD_CONFIG, UserTypeExt.UserType.ADMIN);
            repository = (AdminRepository)DependencyBuilders.DomainModule.createRepository(repositoryConfig);
            
        }

        private void initComputerStatusGrid()
        {

        }

        private void deliveryInWork_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void deliveryClosed_Click(object sender, EventArgs e)
        {
        }

        private void tables_box_TextChanged(object sender, EventArgs e)
        {
        }

        private void MainAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}

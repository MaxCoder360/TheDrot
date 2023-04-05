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
using myBestShop.Presentation.Common;

namespace myBestShop
{
    public partial class MainAdmin : Form
    {
        private AdminRepository repository;
        private TableViewHolder tableView;

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public MainAdmin()
        {
            InitializeComponent();
            var repositoryConfig = DependencyBuilders.DomainModule.createRepositoryConfig(BUILD_CONFIG, UserTypeExt.UserType.ADMIN);
            repository = (AdminRepository)DependencyBuilders.DomainModule.createRepository(repositoryConfig);
            repository.addObserver(new ComputerStatusObserver(onComputerStatusUpdate), AdminRepository.userStatusTag);

            tableView = new TableViewHolder(727, 533, 117, 8);

            updateComputerStatusGrid();
        }

        private void updateComputerStatusGrid()
        {
            repository.fetchUserStatuses();
        }

        private object onComputerStatusUpdate(List<ComputerWrapper> computers)
        {
            var count = computers.Count();

            foreach (Control item in this.Controls.OfType<Control>())
            {
                foreach (var label in tableView.getReducedCells())
                {
                    if (item.Name.Equals(label.Name))
                    {
                        this.Controls.Remove(item);
                        item.Dispose();
                    }
                }
            }


            /*computerStatusGrid.ColumnCount = 3;
            computerStatusGrid.RowCount = (count + 2) / count;

            for (int i = 0; i < count; i++)
            {
                int rowInd = i / 3;
                int columnInd = i % 3;
                var computer = computers[i];
                var style = computer.convertStatusToDataGridStyle();

                computerStatusGrid.Rows[rowInd].Cells[columnInd].Style = style;
            }
            computerStatusGrid.Refresh();*/
            return null;
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

        private void computerStatusGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public class ComputerStatusObserver : Observer
        {
            Func<List<ComputerWrapper>, object> onComputerStatusUpdate;
            public ComputerStatusObserver(Func<List<ComputerWrapper>, object> onComputerStatusUpdate)
            {
                this.onComputerStatusUpdate = onComputerStatusUpdate;
            }

            public void handleResult<ResultT>(Result<ResultT> result) where ResultT : class
            {
                if (result == null)
                {
                    Logger.println("Admin screen: main observable caught null result from repository");
                    return;
                }

                if (result.isLoading)
                {
                    // Init progress bar or circle
                    Logger.println("Admin screen: waiting for computer status");
                    return;
                }

                if (result.isError)
                {
                    Logger.println("Admin screen: error caught: " + result.exception.ToString());
                    return;
                }

                if (result.data != null)
                {
                    Logger.println("Admin screen: result is ok");
                    var computerStatuses = (List<ComputerWrapper>)Convert.ChangeType(result.data, typeof(List<ComputerWrapper>));
                    onComputerStatusUpdate(computerStatuses);
                }
                else
                {
                    Logger.println("Admin screen: invalid result state from admin main repository");
                }
            }
        }
    }
}

using myBestShop.Domain.Repository;
using static myBestShop.Utils.AppConfig;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using myBestShop.Utils;
using myBestShop.Presentation.Common;
using myBestShop.Domain.Entities;
using System.Drawing;
using static myBestShop.Utils.Utils;
using myBestShop.Presentation.MainAdmin;
using System.Windows.Media.Animation;
using myBestShop.Domain.Database.Delegates;
using System.Threading.Tasks;

namespace myBestShop
{
    public partial class MainAdmin : Form
    {
        private AdminRepository repository;
        private TableViewHolder tableView;

        private Form parent;

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public MainAdmin(Form parent, ReturnAUF auf)
        {
            InitializeComponent();
            this.parent = parent;

            var repositoryConfig = DependencyBuilders.DomainModule.createRepositoryConfig(BUILD_CONFIG, UserTypeExt.UserType.ADMIN);
            repository = (AdminRepository)DependencyBuilders.DomainModule.createRepository(repositoryConfig);
            repository.observable.addObserver(new ComputerStatusObserver(onComputerStatusUpdate), AdminRepository.userStatusTag);

            tableView = new TableViewHolder(727, 533, 117, 8);

            Task.Run(async () => {
                await (repository.dbManager.IPadmin.SetIPAdmin(auf.id));
                Logger.println(await repository.dbManager.IPadmin.GetIPAdmin(auf.id));
            });


            updateComputerStatusGrid();
        }

        private async void updateComputerStatusGrid()
        {
            List<Computer> computers = await repository.dbManager.Main.getAllComputers();
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

            List<ComputerWrapper> cw = new List<ComputerWrapper>();
            for (int i = 0; i < computers.Count; i++)
            {
                cw.Add(new ComputerWrapper (computers[i].id, ComputerStatus.UNKNOWN));
            }


            var cells = tableView.clear().appendCellsWithStatuses(cw).getCells();
            foreach (var cell in cells)
            {
                this.Controls.Add(cell);
            }
            await repository.fetchUserStatuses(computers);
        }

        private object onComputerStatusUpdate(ComputerWrapper computer)
        {
            Pair<Color, string> cc = computer.convertStatusToTableViewFormat();
            foreach (Label control in this.Controls.OfType<Label>())
            {
                if (control.Name == "Computer id(" + computer.computerId + ")")
                {
                    this.Invoke(new Action<object>((obj) => { control.BackColor = cc.first; }), new object[] { null });
                }

                if (control.Name == "Computer id(" + computer.computerId + ")1") {
                    this.Invoke(new Action<object>((obj) => { control.Text = cc.second; }), new object[] { null });
                }
            }
            return null;
        }

        private void deliveryInWork_Click(object sender, EventArgs e)
        {
            updateComputerStatusGrid();
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
            Func<ComputerWrapper, object> onComputerStatusUpdate;
            public ComputerStatusObserver(Func<ComputerWrapper, object> onComputerStatusUpdate)
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
                    var computerStatus = (ComputerWrapper)Convert.ChangeType(result.data, typeof(ComputerWrapper));
                    onComputerStatusUpdate(computerStatus);
                }
                else
                {
                    Logger.println("Admin screen: invalid result state from admin main repository");
                }
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            parent.Show();
            Program.isLogined = false;
        }

        private void add_User_Click(object sender, EventArgs e)
        {
            using (Form forms = new CreateUser())
            {
                forms.ShowDialog();
            }
        }

        private void add_comp_Click(object sender, EventArgs e)
        {
            using (Form forms = new CreateComp())
            {
                forms.ShowDialog();
            }
        }
    }
}

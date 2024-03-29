﻿using myBestShop.Domain.Repository;
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
using System.Diagnostics;
using System.IO;
using System.Text;

namespace myBestShop
{
    public partial class MainAdmin : Form
    {
        private AdminRepository repository;
        private TableViewHolder tableView;

        private ReturnAUF auf;
        private Form parent;

        public MainAdmin(Form parent, ReturnAUF auf)
        {
            InitializeComponent();
            this.parent = parent;
            this.auf = auf;

            var repositoryConfig = DependencyBuilders.DomainModule.createRepositoryConfig(BUILD_CONFIG, UserTypeExt.UserType.ADMIN);
            repository = (AdminRepository)DependencyBuilders.DomainModule.createRepository(repositoryConfig);
            repository.observable.addObserver(new ComputerStatusObserver(onComputerStatusUpdate), AdminRepository.userStatusTag);

            tableView = new TableViewHolder(727, 533, 117, 8);

            Task.Run(async () => {
                await (repository.dbManager.IPadmin.SetIPAdmin(auf.id));
            });
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

        private async void updateComputerStatusGrid()
        {
            List<Computer> computers = await repository.dbManager.Main.getAllComputers();
            string prefix = TableViewHolder.controlItemNamePrefix;
            bool isTableViewHolderInitialized = false;

            foreach (Control item in this.Controls.OfType<Control>())
            {
                if (item.Name.Length < prefix.Length)
                {
                    continue;
                }
                if (item.Name.Substring(0, prefix.Length).Equals(prefix))
                {
                    isTableViewHolderInitialized = true;
                    break;
                }
            }

            List<ComputerWrapper> cw = new List<ComputerWrapper>();
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            for (int i = 0; i < computers.Count; i++)
            {
                //говно которого тут не должно быть
                cmd.Start();
                cmd.StandardInput.WriteLine("ping " + computers[i].ip_adress + " -n 1 -w 500");
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                string str = cmd.StandardOutput.ReadToEnd();
                //Logger.println(ass);
                if (str.LastIndexOf("(0%") != -1)
                {
                    cw.Add(new ComputerWrapper(computers[i].id, ComputerStatus.IN_DANGER));
                }
                else
                {
                    cw.Add(new ComputerWrapper(computers[i].id, ComputerStatus.UNKNOWN));
                }
                
            }
            
            this.Invoke(new Action<object>((o) => {
                if (isTableViewHolderInitialized)
                {
                    for (int i = 0; i < cw.Count; i++)
                    {
                        onComputerStatusUpdate(cw[i]);
                    }
                }
                else
                {
                    var cells = tableView.clear().addOnCloseCallbacks(add_session_Click).appendCellsWithStatuses(cw).getCells();

                    foreach (var cell in cells)
                    {
                        this.Controls.Add(cell);
                    }
                }
            }), new object[] { new object() });
            await repository.fetchUserStatuses(computers);
        }

        private object onComputerStatusUpdate(ComputerWrapper computer)
        {
            Pair<Color, string> cc = computer.convertStatusToTableViewFormat();
            var statusPrefix = TableViewHolder.statusItemNamePrefix;
            var hintPrefix = TableViewHolder.hintItemNamePrefix;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                Control item = Controls[i];
                var computerName = "Computer id(" + computer.computerId + ")";
                Logger.println(item.Name);
                Action<object> firstAction = null;
                Action<object> secondAction = null;
                if (item.Name.Length >= statusPrefix.Length && item.Name.Substring(0, statusPrefix.Length).Equals(statusPrefix))
                {
                    if (item.Name.Length <= statusPrefix.Length || item.Name.Length < statusPrefix.Length + computerName.Length)
                    {
                        // pass
                    } else if (item.Name.Substring(statusPrefix.Length, computerName.Length) == computerName)
                    {
                        firstAction = new Action<object>((obj) => { item.BackColor = cc.first; });
                        Logger.println("--------------------------------------------------------");
                    }
                }

                if (item.Name.Length >= hintPrefix.Length && item.Name.Substring(0, hintPrefix.Length).Equals(hintPrefix))
                {
                    var nameIndex = item.Name.IndexOf(computerName);
                    if (nameIndex == -1)
                    {
                        continue;
                    }
                    secondAction = new Action<object>((obj) => { item.Text = cc.second; });

                    Logger.println("oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
                }

                this.Invoke(new Action<object>((o) => {
                    if (firstAction != null)
                    {
                        firstAction(o);
                    }
                    if (secondAction != null)
                    {
                        secondAction(o);
                    }
                }), new object[] { new object() });
            }
            return null;
        }

        private void MainAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
            Program.isLogined = false;
        }

        private void deliveryInWork_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                updateComputerStatusGrid();
            });
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

        private async void add_session_Click(object sender, EventArgs e)
        {
            List<User> users = await repository.dbManager.Main.getAllUsers();
            var name = ((Control)sender).Name;
            var stringId = name.Substring(name.IndexOf("(")+1, name.IndexOf(")") - name.IndexOf("(") - 1);
            int computerId = Convert.ToInt32(stringId);
            using (CreateSession forms = new CreateSession(users, computerId))
            {
                forms.ShowDialog();
                Session resultSeesion = forms.MyReturnValue;
                if (resultSeesion != null)
                {
                    resultSeesion.id_admin = auf.id;
                    await repository.dbManager.Main.addSessionInDB(resultSeesion);
                }
            }
        }
    }
}

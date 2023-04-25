using myBestShop.Domain.Database;
using myBestShop.Domain.Entities;
using myBestShop.Domain.Repository;
using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebSocketSharp;

namespace myBestShop.Domain.WebService
{
    public class AdminWebService : IAdminWebService
    {
        private List<Pair<Computer, WebSocket>> wsPool;
        private DatabaseManager dbManager;
        public Observable<object> observable;

        public static AdminWebService Instance;

        public static AdminWebService getInstance(DatabaseManager dbManager)
        {
            if (Instance == null)
            {
                Instance = new AdminWebService(dbManager);
            }

            return Instance;
        }

        private AdminWebService(DatabaseManager dbManager)
        {
            wsPool = new List<Pair<Computer, WebSocket>>();
            this.dbManager = dbManager;
        }

        public void initialize()
        {
            Task.Run(() => getAllAvailableComputers());
        }

        public void fetchUserStatus(Computer computer)
        {
            for (int i = 0; i < wsPool.Count; i++)
            {
                Pair<Computer, WebSocket> ws = wsPool[i];
                if (ws.first.id == computer.id)
                {
                    WsJsonTemplate template = new WsJsonTemplate(computer.id.ToString(), WsJsonDataTypes.FetchUserStatus);
                    try
                    {
                        ws.second.SendAsync(JsonSerializer.Serialize(template), (isSuccessful) =>
                        {
                            Utils.Logger.println(computer.id.ToString() + " " + isSuccessful.ToString());
                        });
                    } catch (Exception ex)
                    {
                        Utils.Logger.println("Cannot update status of " + ws.first.ip_adress);
                    }
                }
            }
        }

        public void fetchUserProcesses(Computer computer)
        {
            throw new NotImplementedException();
        }

        public void blockRemoteComputer(Computer computer)
        {
            throw new NotImplementedException();
        }

        private void initializeWebSockets(List<Computer> availableComputers)
        {
            wsPool.Clear();
            for (int i = 0; i < availableComputers.Count; i++)
            {
                Computer computer = availableComputers[i];
                if (computer != null)
                {
                    Utils.Logger.println(computer.ip_adress);
                    WebSocket socket = new WebSocket("ws://" + computer.ip_adress + ":5050" + "/ToClient");

                    socket.OnMessage += onMessageWS;
                    socket.OnError += onErrorWS;

                    try
                    {
                        socket.ConnectAsync();
                    } catch (Exception ex)
                    {
                        Utils.Logger.println("WebSocket not working (" + computer.ip_adress + "): " + ex.Message);
                    }
                    wsPool.Add(new Pair<Computer, WebSocket>(computer, socket));
                }
            }
        }

        public void updateWebSockets()
        {
            for (int i = 0; i < wsPool.Count; i++)
            {
                Pair<Computer, WebSocket> ws = wsPool[i];
                if (ws.second.IsAlive)
                {
                    continue;
                }
                Utils.Logger.println("Trying to connect to " + ws.first.ip_adress);
                try
                {
                    ws.second.ConnectAsync();
                } catch (Exception ex)
                {
                    Utils.Logger.println("WebSocket not working (" + ws.first.ip_adress + "): " + ex.Message);
                }
            }
        }

        private async void getAllAvailableComputers()
        {
            var computers = await dbManager.Main.getAllComputers();
            initializeWebSockets(computers);
        }

        private void onMessageWS(Object sender, MessageEventArgs e)
        {
            var template = JsonSerializer.Deserialize<WsJsonTemplate>(e.Data);
            if (template.type == WsJsonDataTypes.FetchUserStatus)
            {
                var cw = JsonSerializer.Deserialize<ComputerWrapper>(template.data);
                observable.notify(
                    new Result<object> { data = cw, exception = null, isLoading = false },
                        AdminRepository.userStatusTag
                );
            }
        }

        private void onErrorWS(Object sender, ErrorEventArgs e)
        {
            Utils.Logger.println(e.Message);
        }
    }
}
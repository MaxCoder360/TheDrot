using myBestShop.Domain.Database;
using myBestShop.Domain.Entities;
using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using static myBestShop.Utils.Utils;

namespace myBestShop.Domain.WebService
{
    public class AdminWebService : IAdminWebService
    {
        private List<Pair<Computer, WebSocket>> wsPool;
        private DatabaseManager dbManager;

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
            
            Task.Run(() => getAllAvailableComputers());
        }

        public void fetchUserStatus(Computer computer)
        {
            foreach (Pair<Computer, WebSocket> ws in wsPool)
            {
                if (ws.first.id == computer.id)
                {
                    WsJsonTemplate template = new WsJsonTemplate("", WsJsonTemplate.WsJsonDataTypes.FetchUserStatus);
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
            foreach (Computer computer in availableComputers)
            {
                if (computer != null)
                {
                    Utils.Logger.println(computer.ip_adress);
                    WebSocket socket = new WebSocket("ws://" + computer.ip_adress + ":5050" + "/ToClient");

                    socket.OnMessage += onMessageWS;
                    socket.OnError += onErrorWS;

                    try
                    {
                        socket.Connect();
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
            foreach (Pair<Computer, WebSocket> ws in wsPool)
            {
                Utils.Logger.println("Trying to connect to " + ws.first.ip_adress);
                try
                {
                    ws.second.Connect();
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
            Utils.Logger.println(e.Data);
        }

        private void onErrorWS(Object sender, ErrorEventArgs e)
        {
            Utils.Logger.println(e.Message);
        }
    }
}
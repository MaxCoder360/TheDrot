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

namespace myBestShop.Domain.WebService
{
    public class AdminServerSocketBehaviour : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var data = JsonSerializer.Deserialize<WsJsonTemplate>(e.Data);

            if (data.type == WsJsonTemplate.WsJsonDataTypes.RequestAdmin)
            {
                Utils.Logger.println(data.data);
            }
        }
    }

    public class AdminWebService: IAdminWebService
    {
        private List<Pair<Computer, WebSocket>> wsPool;
        private DatabaseManager dbManager;

        public AdminWebService(DatabaseManager dbManager)
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
                    ws.second.SendAsync(JsonSerializer.Serialize(template), (isSuccessful) => {
                        Utils.Logger.println(computer.id.ToString() + " " + isSuccessful.ToString());
                    });
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

                    WebSocket socket = new WebSocket("ws://" + computer.ip_adress + "5050" + "/ToClient");

                    socket.OnMessage += onMessageWS;
                    socket.OnError += onErrorWS;

                    socket.Connect();
                    wsPool.Add(new Pair<Computer, WebSocket>(computer, socket));
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
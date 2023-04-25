using myBestShop.Domain.Database;
using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using static myBestShop.Utils.Utils;

namespace myBestShop
{
    internal static class Program
    {
        public static WebSocketServer wsServer;

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

        public class UserServerWebSocketBehavior : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                var data = JsonSerializer.Deserialize<WsJsonTemplate>(e.Data);

                if (data.type == WsJsonTemplate.WsJsonDataTypes.FetchUserStatus)
                {
                    var status = JsonSerializer.Serialize<ComputerStatus>(ComputerStatus.IS_USED);
                    var template = JsonSerializer.Serialize(new WsJsonTemplate(status, WsJsonTemplate.WsJsonDataTypes.FetchUserStatus));
                    Send(template);
                }
            }
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // initialize observable storage to keep info about observables
            ObservableStorage.initialize();
            DatabaseManager.createInstance();
            wsServer = new WebSocketServer("ws://" + GetLocalIPAddress() + ":5050");
            Program.wsServer.AddWebSocketService<UserServerWebSocketBehavior>("/ToClient");
            wsServer.AddWebSocketService<AdminServerSocketBehaviour>("/ToAdmin");
            wsServer.Start();

            try
            {
                //new Form1()
                Application.Run(new LoginScreen());
            }
            catch
            {
                Application.Exit();
            }
        }
    }
}

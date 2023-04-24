using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static myBestShop.Utils.AppConfig;
using WebSocketSharp;
using myBestShop.Domain.Repository;
using System.Text.Json;
using WebSocketSharp.Server;
using System.Net;
using System.Net.Sockets;

namespace myBestShop.Domain.WebService
{
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

    public class UserWebService : IUserWebService
    {
        private WebSocket webSocketConnection;
        private Observable<object> _observable;
        private WebSocketServer wsServer;


        /*async Task IUserWebService.fetchSessionKey(LoginHolder holder)
        {
            webSocketConnection.OnMessage += onMessageSessionKey;
            webSocketConnection.OnError += onErrorSessionKey;

            webSocketConnection.Connect();
            webSocketConnection.Send(
                JsonSerializer.Serialize(holder)
            );

            _observable.notify(new Result<object> { data = default, exception = null, isLoading = true }, UserRepository.loginTag);
        }
*/
        /*async Task IUserWebService.fetchServerTime(int userSessionKey)
        {
            webSocketConnection.OnMessage += onMessageServerTime;
            webSocketConnection.OnError += onErrorServerTime;

            webSocketConnection.Connect();
            webSocketConnection.Send(
                JsonSerializer.Serialize(userSessionKey)
            );

            _observable.notify(new Result<object> { data=default, exception=null, isLoading=true }, UserRepository.getServerTimeTag);
        }*/
/*
        Task IUserWebService.fetchTestData()
        {
            throw new NotImplementedException();
        }*/

        public UserWebService(WebServiceConfig config)
        {
            wsServer = new WebSocketServer("ws://" + UserWebService.GetLocalIPAddress() + ":5050");

            wsServer.AddWebSocketService<UserServerWebSocketBehavior>("/ToClient");
            wsServer.Start();
        }

        void IUserWebService.addObservable(Observable<object> observable)
        {
            this._observable = observable;
        }

        private void onWsMessage(Object sender, MessageEventArgs e)
        {
            var data = JsonSerializer.Deserialize<WsJsonTemplate>(e.Data);
        }

        private void onMessageSessionKey(Object sender, MessageEventArgs e)
        {
            Utils.Logger.println("Obtained session key successfully");
            // var data = JsonSerializer.Deserialize(e.Data);
            _observable.notify(new Result<object> { data = e.Data, exception = null, isLoading = false }, UserRepository.loginTag);
            webSocketConnection.OnMessage -= onMessageSessionKey;
            webSocketConnection.OnError -= onErrorSessionKey;
        }

        private void onErrorSessionKey(Object sender, ErrorEventArgs e) {
        
            Utils.Logger.println("Failed fetch session key. Exception occured:" + e.Message);
            _observable.notify(new Result<object> { data = default, exception = e.Exception, isLoading = false }, UserRepository.loginTag);
            webSocketConnection.OnMessage -= onMessageSessionKey;
            webSocketConnection.OnError -= onErrorSessionKey;
        }

        private void onMessageServerTime(Object sender, MessageEventArgs e)
        {
            Utils.Logger.println("Obtained left time successfully");
            _observable.notify(new Result<object> { data = DateTime.Parse(e.Data), exception = null, isLoading = false }, UserRepository.loginTag);
            webSocketConnection.OnMessage -= onMessageServerTime;
            webSocketConnection.OnError -= onErrorServerTime;
        }

        private void onErrorServerTime(Object sender, ErrorEventArgs e)
        {
            Utils.Logger.println("Failed fetch left time from server. Exception occured: " + e.Message);
            _observable.notify(new Result<object> {
                data = default,
                exception = new Exception("Server side exception: " + e.Message),
                isLoading = false
            }, UserRepository.getServerTimeTag);
            webSocketConnection.OnMessage -= onMessageServerTime;
            webSocketConnection.OnError -= onErrorServerTime;
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}

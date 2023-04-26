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
using myBestShop.Domain.Entities;

namespace myBestShop.Domain.WebService
{
    public class UserWebService
    {
        private Observable<object> _observable;
        private WebSocket ws;
        public static UserWebService instance;


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

        public static UserWebService getInstance(WebServiceConfig config)
        {
            if (instance == null)
            {
                instance = new UserWebService(config);

            }

            return instance;
        }

        private UserWebService(WebServiceConfig config)
        {
        }

        public void addObservable(Observable<object> observable)
        {
            this._observable = observable;
        }

        public void sendMessageToAdmin(string message, string computerIpAddress)
        {
            if (ws == null)
            {
                ws = new WebSocket("ws://" + computerIpAddress+ ":5050" + "/ToAdmin");
            }

            if (!ws.IsAlive)
            {
                try
                {
                    ws.ConnectAsync();
                } catch (Exception ex)
                {
                    Utils.Logger.println("UserWebService Cannot connect to websocket of " + computerIpAddress+ " ip: " + ex.Message);
                    _observable.notify(new Result<object> { data = default, exception = ex, isLoading = false }, UserRepository.sendMessageToAdminTag);
                    return;
                }
            }

            var template = new WsJsonTemplate(message, WsJsonDataTypes.RequestAdmin);
            ws.SendAsync(JsonSerializer.Serialize(template), (isSuccessful) => { });
        }

        private void onWsMessage(Object sender, MessageEventArgs e)
        {
            var data = JsonSerializer.Deserialize<WsJsonTemplate>(e.Data);
        }

        /*private void onMessageSessionKey(Object sender, MessageEventArgs e)
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
        }*/
    }
}

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

namespace myBestShop.Domain.WebService
{
    public class UserWebService : IUserWebService
    {
        public string baseUrl;
        private WebSocket webSocketConnection;
        private Observable<object> _observable;

        async Task IUserWebService.fetchSessionKey(LoginHolder holder)
        {
            webSocketConnection.OnMessage += onMessageSessionKey;
            webSocketConnection.OnError += onErrorSessionKey;

            webSocketConnection.Connect();
            webSocketConnection.Send(
                JsonSerializer.Serialize(holder)
            );

            _observable.notify(new Result<object> { data = default, exception = null, isLoading = true }, UserRepository.obtainSessionKeyTag);
        }

        async Task IUserWebService.fetchServerTime(int userSessionKey)
        {
            webSocketConnection.OnMessage += onMessageServerTime;
            webSocketConnection.OnError += onErrorServerTime;

            webSocketConnection.Connect();
            webSocketConnection.Send(
                JsonSerializer.Serialize(userSessionKey)
            );

            _observable.notify(new Result<object> { data=default, exception=null, isLoading=true }, UserRepository.getServerTimeTag);
        }

        Task IUserWebService.fetchTestData()
        {
            throw new NotImplementedException();
        }

        public UserWebService(WebServiceConfig config)
        {
            baseUrl = config.baseUrl;
            webSocketConnection = new WebSocket(baseUrl);
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
            _observable.notify(new Result<object> { data = e.Data, exception = null, isLoading = false }, UserRepository.obtainSessionKeyTag);
            webSocketConnection.OnMessage -= onMessageSessionKey;
            webSocketConnection.OnError -= onErrorSessionKey;
        }

        private void onErrorSessionKey(Object sender, ErrorEventArgs e) {
        
            Utils.Logger.println("Failed fetch session key. Exception occured:" + e.Message);
            _observable.notify(new Result<object> { data = default, exception = e.Exception, isLoading = false }, UserRepository.obtainSessionKeyTag);
            webSocketConnection.OnMessage -= onMessageSessionKey;
            webSocketConnection.OnError -= onErrorSessionKey;
        }

        private void onMessageServerTime(Object sender, MessageEventArgs e)
        {
            Utils.Logger.println("Obtained left time successfully");
            _observable.notify(new Result<object> { data = DateTime.Parse(e.Data), exception = null, isLoading = false }, UserRepository.getServerTimeTag);
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
    }
}

using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static myBestShop.Utils.AppConfig;
using WebSocketSharp;

namespace myBestShop.Domain.WebService
{
    public class UserWebService : IUserWebService
    {
        public string baseUrl;
        private WebSocket webSocketConnection;

        async Task IUserWebService.fetchSessionKey(LoginHolder holder)
        {
            webSocketConnection.OnMessage += (sender, e) =>
            {
                Utils.Logger.println("Obtained session key successfully");
            };

            webSocketConnection.OnError += (sender, e) =>
            {
                Utils.Logger.println("Failed fetch session key. Exception occured:" + e.Message);
            };

            webSocketConnection.Connect();
        }

        async Task IUserWebService.fetchServerTime(int userSessionKey)
        {
            throw new NotImplementedException();
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
    }
}

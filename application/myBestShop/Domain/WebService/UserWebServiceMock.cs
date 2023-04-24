using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static myBestShop.Utils.AppConfig;
using WebSocketSharp;
using System.Text.Json;

namespace myBestShop.Domain.WebService
{
    public class UserWebServiceMock : IUserWebService
    {
        public string baseUrl;
        private WebSocket webSocketConnection;

        async Task IUserWebService.fetchSessionKey(LoginHolder holder)
        {
            int result = -1;
            if (holder.userName == "")
            {
                await Task.Run(() => result = 0);
            } else if (holder.userName == "MaxCode360")
            {
                await Task.Run(() => result = 1);
            }
            else
            {
                await Task.Run(() => result = 2);
            }
            // return result;
        }

        Task IUserWebService.fetchServerTime(int userSessionKey)
        {
            return new Task<string>(() => DateTime.Now.ToString());
        }

        public UserWebServiceMock(WebServiceConfig config)
        {
            baseUrl = config.baseUrl;
            webSocketConnection = new WebSocket(baseUrl);
        }

        Task IUserWebService.fetchTestData()
        {
            var ws = new WebSocket("wss://ws.finnhub.io?token=c12ht2f48v6oi252p5ag");
            ws.OnMessage += (sender, e) => {
                Console.WriteLine("Laputa says: " + e.Data);
                ws.Close();
            };

            ws.OnError += (sender, e) => Utils.Logger.println(e.Message);
            var obj = new TestWebSocketObject("subscribe", "AAPL");

            ws.Connect();
            var jsonRequest = JsonSerializer.Serialize(obj);
            ws.Send(jsonRequest);
            
            return new Task(() => { });
        }

        public void addObservable(Observable<object> observable)
        {

        }
    }
}

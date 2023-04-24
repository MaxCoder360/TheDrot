using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Presentation.MainClient.Observers
{
    public class SessionKeyObserver : Observer
    {
        Func<int, object> onSessionKeyObtained;
        public SessionKeyObserver(Func<int, object> onSessionKeyObtained)
        {
            this.onSessionKeyObtained = onSessionKeyObtained;
        }

        public void handleResult<ResultT>(Result<ResultT> result) where ResultT : class
        {
            if (result == null)
            {
                Logger.println("Session key: an error occured while obtaining session key");
                return;
            }

            if (result.isLoading)
            {
                // Init progress bar or circle
                Logger.println("Session key: loading");
                return;
            }

            if (result.isError)
            {
                Logger.println("Session key: exception occured: " + result.exception.ToString());
                return;
            }

            if (result.data != null)
            {
                Logger.println("Session key: successfully obtained session key");
                var sessionKey = (int)Convert.ChangeType(result.data, typeof(int));
                onSessionKeyObtained(sessionKey);
            }
            else
            {
                Logger.println("Session key: invalid result state");
            }
        }
    }
}

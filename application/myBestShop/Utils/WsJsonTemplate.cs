namespace myBestShop.Utils
{
    public enum WsJsonDataTypes
    {
        FetchUserStatus,
        RequestAdmin,
        ExtendAvailableTimeForClient,
        UpdateUserStatus
    };

    public class WsJsonTemplate
    {
        public string data { get; set; }
        public WsJsonDataTypes type { get; set; }

        public WsJsonTemplate(string data, WsJsonDataTypes type)
        {
            this.data = data;
            this.type = type;
        }
    }
}

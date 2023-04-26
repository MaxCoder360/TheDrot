using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Domain.Entities
{
    public class ClientMessageDTO
    {
        public int computerId { get; set; }
        public string message { get; set; }

        public ClientMessageDTO(int computerId, string message)
        {
            this.message = message;
            this.computerId = computerId;
        }
    }
}

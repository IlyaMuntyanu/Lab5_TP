using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MicroserviceUser.Models
{

    public class User
    {

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("eMail")]
        public string EMail { get; set; }

        [JsonPropertyName("phone")]
        public int Phone { get; set; }

        [JsonPropertyName("account")]
        public int Account { get; set; }

        [JsonPropertyName("balance")]
        public int Balance { get; set; }

        [JsonPropertyName("ticketID")]
        public int TicketID { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceUser.Models
{

    public class User
    {

        public long Id { get; set; }

        public string Username { get; set; }

        public string EMail { get; set; }

        public int Phone { get; set; }

        public int Account { get; set; }

        public int Balance { get; set; }

        public int TicketID { get; set; }

    }
}

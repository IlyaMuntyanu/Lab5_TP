using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceTicket.Models
{

    public class Ticket
    {

        public long Id { get; set; }

        public string DeparturePoint { get; set; }

        public string TransferPoint { get; set; }

        public string ArrivalPoint { get; set; }

        public string DepartureDate { get; set; }

        public string BackwardDate { get; set; }

        public int Price { get; set; }

        public string Flight { get; set; }

        public string TravelTime { get; set; }


    }
}

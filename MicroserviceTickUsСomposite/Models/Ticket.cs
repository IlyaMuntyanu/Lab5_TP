using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MicroserviceTicket.Models
{

    public class Ticket
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("departurePoint")]
        public string DeparturePoint { get; set; }

        [JsonPropertyName("transferPoint")]
        public string TransferPoint { get; set; }

        [JsonPropertyName("arrivalPoint")]
        public string ArrivalPoint { get; set; }

        [JsonPropertyName("departureDate")]
        public string DepartureDate { get; set; }

        [JsonPropertyName("backwardDate")]
        public string BackwardDate { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("flight")]
        public string Flight { get; set; }

        [JsonPropertyName("travelTime")]
        public string TravelTime { get; set; }


    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MicroserviceTicket.Models;
using MicroserviceUser.Models;
using MicroserviceСompositeSC.Models;
using MyLib;

namespace MicroserviceСompositeSC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompositeTickUsController : ControllerBase
    {
        private readonly string _userServiceAddress = "https://localhost:44320/api/users";
        private readonly string _ticketServiceAddress = "https://localhost:44376/api/tickets";


        [HttpGet]
        public string Start()
        {
            return "Composite is run!";
        }

        [HttpGet("tickets/{price}")]
        public async Task<List<Ticket>> GetTicketsByPriceAsync(int price)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback =
            (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = await
                client.GetAsync($"{_ticketServiceAddress}");
                if (response.IsSuccessStatusCode)
                {
                    List<Ticket> tickets = await JsonSerializer.DeserializeAsync<List<Ticket>>(await response.Content.ReadAsStreamAsync());
                    return tickets.Where(ticket => ticket.Price < price).ToList();
                }
            }
            return null;
        }

        

        [HttpGet("ticketsum/{ticketid}")]
        public async Task<TicketSum> GetAverageGroupRatingAsync(int ticketid)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback =
            (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response1 = await client.GetAsync($"{_userServiceAddress}");
                HttpResponseMessage response2 = await client.GetAsync($"{_ticketServiceAddress}");

                if (response1.IsSuccessStatusCode && response2.IsSuccessStatusCode)
                {
                List<User> users = await JsonSerializer.DeserializeAsync<List<User>>(await response1.Content.ReadAsStreamAsync());
                List<Ticket> tickets = await JsonSerializer.DeserializeAsync<List<Ticket>>(await response2.Content.ReadAsStreamAsync());
                    var collection = users.Where(user => user.TicketID == ticketid).ToList();
                    var ticket = tickets.Where(ticket => ticket.Id == ticketid).First();
                    int peopleCount = 0;
                    int sum = 0;
                    foreach (var i in collection)
                        peopleCount += 1;

                    sum = peopleCount * ticket.Price;
                    return new TicketSum() { TicketId = ticketid, Sum = sum };
                }
            }
            return null;
        }

        [HttpGet("timeuntildeparture/{ticketid}")]
        public async Task<string> GetTimeUntilDepartureAsync(int ticketid)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback =
            (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = await
                client.GetAsync($"{_ticketServiceAddress}");
                if (response.IsSuccessStatusCode)
                {
                    List<Ticket> tickets = await JsonSerializer.DeserializeAsync<List<Ticket>>(await response.Content.ReadAsStreamAsync());
                    var ticket = tickets.Where(ticket => ticket.Id == ticketid).First();


                    return Class1.TimeToDeparture(ticket.DepartureDate);
                }
            }
            return null;
        }







    }
}
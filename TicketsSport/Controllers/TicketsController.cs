using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsSport.Models;
using TicketsSport.Repository;

namespace TicketsSport.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        ITicketRepository TicketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            TicketRepository = ticketRepository;
        }

        [HttpGet(Name = "GetAllTickets")]
        public IEnumerable<Ticket> Get()
        {
            return TicketRepository.Get();
        }

        [HttpGet("{id}", Name = "GetTicket")]
        public IActionResult Get(int Id)
        {
            Ticket ticket = TicketRepository.Get(Id);

            if (ticket == null)
            {
                return NotFound();
            }

            return new ObjectResult(ticket);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Ticket ticket)
        {
            if (ticket == null)
            {
                return BadRequest();
            }
            TicketRepository.Create(ticket);
            return CreatedAtRoute("GetTicket", new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int Id, [FromBody] Ticket updatedTicket)
        {
            if (updatedTicket == null || updatedTicket.Id != Id)
            {
                return BadRequest();
            }

            var ticket = TicketRepository.Get(Id);
            if (ticket == null)
            {
                return NotFound();
            }

            TicketRepository.Update(updatedTicket);
            return RedirectToRoute("GetAllTickets");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var deletedTicket = TicketRepository.Delete(Id);

            if (deletedTicket == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedTicket);
        }

        [HttpPost("createTickets/{count}", Name = "CreateTickets")]
        public IActionResult Create([FromBody] Ticket ticket, int count)
        {
            if (ticket == null)
            {
                return BadRequest();
            }
            for (int i = 0; i < count; i++)
            {
                Ticket newTicket = new Ticket();
                newTicket.Status = "free";
                newTicket.EventId = ticket.EventId;
                newTicket.Price = ticket.Price;
                newTicket.Place = i + 1;
                TicketRepository.Create(newTicket);
            }
            return RedirectToRoute("GetAllTickets");
        }

        [HttpGet("event/{eventId}", Name = "GetTicketsByEvent")]
        public IEnumerable<Ticket> GetByEventId(int eventId)
        {
            return TicketRepository.GetByEventId(eventId);
        }

        [HttpDelete("event/{eventId}", Name = "DeleteTicketsByEvent")]
        public IActionResult DeleteByEventId(int eventId)
        {
            TicketRepository.DeleteByEventId(eventId);
            return RedirectToRoute("GetAllTickets");
        }

    }
}

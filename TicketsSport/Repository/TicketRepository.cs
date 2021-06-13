using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsSport.Models;

namespace TicketsSport.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private TicketContext Context;
        public IEnumerable<Ticket> Get()
        {
            return Context.Tickets;
        }
        public Ticket Get(int Id)
        {
            return Context.Tickets.Find(Id);
        }
        public TicketRepository(TicketContext context)
        {
            Context = context;
        }
        public void Create(Ticket item)
        {
            Context.Tickets.Add(item);
            Context.SaveChanges();
        }
        public void Update(Ticket updatedTicket)
        {
            Ticket currentItem = Get(updatedTicket.Id);
            currentItem.EventId = updatedTicket.EventId;
            currentItem.UserId = updatedTicket.UserId;
            currentItem.Price = updatedTicket.Price;
            currentItem.Place = updatedTicket.Place;
            currentItem.Status = updatedTicket.Status;

            Context.Tickets.Update(currentItem);
            Context.SaveChanges();
        }

        public Ticket Delete(int Id)
        {
            Ticket ticket = Get(Id);

            if (ticket != null)
            {
                Context.Tickets.Remove(ticket);
                Context.SaveChanges();
            }

            return ticket;
        }

        public IEnumerable<Ticket> GetByEventId(int EventId)
        {
            IEnumerable<Ticket> ticketsList;
            ticketsList = from i in Context.Tickets where i.EventId == EventId select i;
            return ticketsList;
        }

        public void DeleteByEventId(int EventId)
        {
            IEnumerable<Ticket> deletedTickets = GetByEventId(EventId);

            foreach (Ticket ticket in deletedTickets)
            {
                Context.Tickets.Remove(Get(ticket.Id));
            }
            Context.SaveChanges();
        }
    }
}

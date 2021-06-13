using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsSport.Models;

namespace TicketsSport.Repository
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> Get();
        Ticket Get(int id);
        void Create(Ticket item);
        void Update(Ticket item);
        Ticket Delete(int id);
        IEnumerable<Ticket> GetByEventId(int id);
        void DeleteByEventId(int id);
    }

}

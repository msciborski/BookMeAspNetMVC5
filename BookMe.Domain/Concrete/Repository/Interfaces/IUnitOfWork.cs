using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMe.Domain.Concrete.Repository.Interfaces {
    public interface IUnitOfWork{
        void Commit();
        ICityRepository Cities { get; }
        IHotelRepository Hotels { get; }
        IRoomRepository Rooms { get; }
    }
}

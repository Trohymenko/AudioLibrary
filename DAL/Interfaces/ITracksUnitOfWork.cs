using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface ITracksUnitOfWork : IDisposable
    {
        IRepository<Album> Albums { get; }
        IRepository<Author> Authors { get; }
        IRepository<Genre> Genres { get; }
        IRepository<Track> Tracks { get; }
        void Save();
    }
}

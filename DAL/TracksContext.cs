using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;

namespace DAL
{
    public class TracksContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<TrackRate> TracksRates { get; set; }
        public DbSet<AlbumRate> AlbumsRates { get; set; }


        static TracksContext()
        {
            Database.SetInitializer<TracksContext>(new DbInitializer());

        }
        public TracksContext(string connectionString) : base(connectionString)
        {
        }
    }
    public class DbInitializer :
       DropCreateDatabaseAlways<TracksContext>
    {
        protected override void Seed(TracksContext db)
        {
            Author LightningHopkins = new Author { AuthorID = 0, AuthorName = "Lightning Hopkins" };
            Author TheProdigy = new Author { AuthorID = 1, AuthorName = "The Prodigy" };
            Author JohnnyCash = new Author { AuthorID = 2, AuthorName = "Johnny Cash" };

            db.Authors.AddRange(new List<Author> { LightningHopkins, TheProdigy, JohnnyCash });
            db.SaveChanges();

            Album UnknownAlbum1 = new Album { AlbumName = "Album1", AlbumId = 0, Author = LightningHopkins };
            Album UnknownAlbum2 = new Album { AlbumName = "Album2", AlbumId = 1, Author = TheProdigy };
            Album UnknownAlbum3 = new Album { AlbumName = "Album3", AlbumId = 2, Author = JohnnyCash};

            db.Albums.AddRange(new List<Album> { UnknownAlbum1, UnknownAlbum2, UnknownAlbum3 });
            db.SaveChanges();

            Track LightningHopkinsTrack1 = new Track { TrackID = 0, TrackName = "Smokestack Lightnin'", Author = LightningHopkins, TrackAddress = "/files/lightning.mp3" };
            Track TheProdigyTrack1 = new Track { TrackID = 1, TrackName = "The day is my enemy", Author = TheProdigy, TrackAddress ="/files/theday.mp3" };
            Track JohnnyCashTrack1 = new Track { TrackID = 2, TrackName = "Ring of fire", Author = JohnnyCash, TrackAddress ="/files/ring.mp3" };

            db.Tracks.AddRange(new List<Track> { LightningHopkinsTrack1, TheProdigyTrack1, JohnnyCashTrack1 });
            db.SaveChanges();

            Genre Blues = new Genre { GenreId = 0, GenreName = "Blues" };
            Genre BreakBeat = new Genre { GenreId = 1, GenreName = "Break Beat" };
            Genre Country = new Genre { GenreId = 2, GenreName = "Country" };
    

            Blues.Authors.Add(LightningHopkins);
            BreakBeat.Authors.Add(TheProdigy);
            Country.Authors.Add(JohnnyCash);

            db.Genres.AddRange(new List<Genre>{Blues, BreakBeat, Country});
            db.SaveChanges();

            TrackRate rate1 = new TrackRate { TrackId = 0, Track = JohnnyCashTrack1, TrackRateId = 0, TrackRateValue = 1, UserName = "user1" };
            TrackRate rate2 = new TrackRate { TrackId = 0, Track = JohnnyCashTrack1, TrackRateId = 1, TrackRateValue = 1, UserName = "user2" };
            TrackRate rate3 = new TrackRate { TrackId = 0, Track = JohnnyCashTrack1, TrackRateId = 2, TrackRateValue = 1, UserName = "user3" };
            TrackRate rate4 = new TrackRate { TrackId = 0, Track = TheProdigyTrack1, TrackRateId = 3, TrackRateValue = 2, UserName = "user4" };
            TrackRate rate5 = new TrackRate { TrackId = 0, Track = TheProdigyTrack1, TrackRateId = 4, TrackRateValue = 5, UserName = "user5" };

            IEnumerable<TrackRate> rates = new List<TrackRate> { rate1, rate2, rate3, rate4, rate5 };
            db.TracksRates.AddRange(rates);

        }
    }
}

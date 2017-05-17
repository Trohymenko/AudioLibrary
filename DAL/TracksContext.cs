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
            Author ACDC = new Author { AuthorID = 2, AuthorName = "AC/DC" };

            db.Authors.AddRange(new List<Author> { LightningHopkins, TheProdigy, JohnnyCash });
            db.SaveChanges();

            Album Album1 = new Album { AlbumName = "Soul Blues", AlbumId = 0, Author = LightningHopkins };
            Album Album2 = new Album { AlbumName = "The Day Is My Enemy", AlbumId = 1, Author = TheProdigy };
            Album Album3 = new Album { AlbumName = "The Legend CD 1", AlbumId = 2, Author = JohnnyCash};
            Album Album4 = new Album { AlbumName = "Back in Black", AlbumId = 3, Author = ACDC };


            db.Albums.AddRange(new List<Album> { Album1, Album2, Album3, Album4 });
            db.SaveChanges();

            Track LightningHopkinsTrack1 = new Track { TrackID = 0, TrackName = "Black Ghost Blues", Author = LightningHopkins, TrackLocation = "/files/636306677659284421.mp3", Album= Album1 };
            Track TheProdigyTrack1 = new Track { TrackID = 1, TrackName = "The Day Is My Enemy", Author = TheProdigy, TrackLocation = "/files/636306677658674386.mp3", Album =Album2 };
            Track JohnnyCashTrack1 = new Track { TrackID = 2, TrackName = "Ring of fire", Author = JohnnyCash, TrackLocation = "/files/636306677466013367.mp3", Album=Album3 };
            Track ACDCtrack1 = new Track { TrackID = 3, TrackName = "Back In Black", Author = ACDC, TrackLocation = "/files/636306677466623402.mp3", Album=Album4 };
            Track LightningHopkinsTrack2 = new Track { TrackID = 4, TrackName = "Too many drivers", Author = LightningHopkins, TrackLocation = "/files/636306677467013424.mp3", Album=Album1 };


            db.Tracks.AddRange(new List<Track> { LightningHopkinsTrack1, TheProdigyTrack1, JohnnyCashTrack1, ACDCtrack1 ,LightningHopkinsTrack2 });
            db.SaveChanges();

            Genre Blues = new Genre { GenreId = 0, GenreName = "Blues" };
            Genre BreakBeat = new Genre { GenreId = 1, GenreName = "Break Beat" };
            Genre Country = new Genre { GenreId = 2, GenreName = "Country" };
            Genre HardRock = new Genre { GenreId = 3, GenreName = "Hard Rock" };
    

            Blues.Authors.Add(LightningHopkins);
            BreakBeat.Authors.Add(TheProdigy);
            Country.Authors.Add(JohnnyCash);
            HardRock.Authors.Add(ACDC);


            Blues.Tracks.Add(LightningHopkinsTrack1);
            Blues.Tracks.Add(LightningHopkinsTrack2);
            BreakBeat.Tracks.Add(JohnnyCashTrack1);
            BreakBeat.Tracks.Add(TheProdigyTrack1);
            HardRock.Tracks.Add(ACDCtrack1);

            db.Genres.AddRange(new List<Genre>{Blues, BreakBeat, Country, HardRock});
            db.SaveChanges();

            TrackRate rate1 = new TrackRate { Track = JohnnyCashTrack1, TrackRateId = 0, TrackRateValue = 1, UserName = "user1" };
            TrackRate rate2 = new TrackRate { Track = ACDCtrack1, TrackRateId = 1, TrackRateValue = 5, UserName = "user2" };
            TrackRate rate3 = new TrackRate {  Track = JohnnyCashTrack1, TrackRateId = 2, TrackRateValue = 1, UserName = "user3" };
            TrackRate rate4 = new TrackRate { Track = TheProdigyTrack1, TrackRateId = 3, TrackRateValue = 2, UserName = "user4" };
            TrackRate rate5 = new TrackRate {  Track = TheProdigyTrack1, TrackRateId = 4, TrackRateValue = 5, UserName = "user5" };

            IEnumerable<TrackRate> rates = new List<TrackRate> { rate1, rate2, rate3, rate4, rate5 };
            db.TracksRates.AddRange(rates);

        }
    }
}

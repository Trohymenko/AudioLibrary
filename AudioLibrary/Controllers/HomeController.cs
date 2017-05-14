using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BLL.Interfaces;
using BLL.Entities;
using AudioLibrary.Models;
using System.Text.RegularExpressions;
using System;
using System.Web;

namespace AudioLibrary.Controllers
{
    public class HomeController : Controller
    {
        IGetInfoService dbGet;
        IModifyService dbMod;
        ISearchService dbSearch;

        public HomeController(IGetInfoService dbGet, IModifyService dbMod, ISearchService dbSearch)
        {
            this.dbGet = dbGet;
            this.dbMod = dbMod;
            this.dbSearch = dbSearch;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostTrackRate(int rate, int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                TrackRateBLL trackRate = new TrackRateBLL() { TrackRateValue = rate, TrackId = id, UserName = User.Identity.Name };
                dbMod.PostTrackRate(trackRate);
                return Json(new { success = false, responseText = "Thank you" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "You are not logged in" }, JsonRequestBehavior.AllowGet);
            }

        }
        
        [HttpPost]
        public ActionResult Search(string name, string searchCategory)
        {
            switch (searchCategory)
            {
                case "Tracks":
                    IEnumerable<TrackBLL> tracks = null;

                    if (name.Length != 0)
                    {
                        tracks = dbSearch.SearchForTrack("Tracks", name);
                    }
                    else
                    {
                        tracks = dbGet.GetAllTracks().ToList();
                    }
                    if (tracks.Count() <= 0)
                    {
                        return PartialView("NotFound");
                    }
                    Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, TrackViewModel>());
                    ICollection<TrackViewModel> trackList = 
                        Mapper.Map<IEnumerable<TrackBLL>, IEnumerable<TrackViewModel>>(tracks).ToList();
                    return View("TrackSearch",trackList);

                case "Authors":
                    IEnumerable<AuthorBLL> authors = null;
                    if (name.Length != 0)
                    {
                        authors = dbSearch.SearchForAuthor("Authors", name);
                    }
                    else
                    {
                        authors = dbGet.GetAllAuthors().ToList();
                    }
                    if (authors.Count() <= 0)
                    {
                        return HttpNotFound();
                    }
                    Mapper.Initialize(cfg => cfg.CreateMap<AuthorBLL, AuthorViewModel>());
                    ICollection<AuthorViewModel> authorList =
                        Mapper.Map<IEnumerable<AuthorBLL>, IEnumerable<AuthorViewModel>>(authors).ToList();
                    return View("AuthorSearch",authorList);

                case "Albums":
                    IEnumerable<AlbumBLL> albums = null;
                    if (name.Length != 0)
                    {
                        albums = dbSearch.SearchForAlbum("Albums", name);
                    }
                    else
                    {
                        albums = dbGet.GetAllAlbums().ToList();
                    }
                    if (albums.Count() <= 0)
                    {
                        return HttpNotFound();
                    }
                    Mapper.Initialize(cfg => cfg.CreateMap<AlbumBLL, AlbumViewModel>());
                    ICollection<AlbumViewModel> albumList = 
                        Mapper.Map<IEnumerable<AlbumBLL>, IEnumerable<AlbumViewModel>>(albums).ToList();
                    return View("AlbumSearch",albumList);

                case "Genres":
                    IEnumerable<GenreBLL> genres = null;
                    if (name.Length != 0)
                    {
                        genres = dbSearch.SearchForGenre("Genres", name);
                    }
                    else
                    {
                        albums = dbGet.GetAllAlbums().ToList();
                    }
                    if (genres.Count() <= 0)
                    {
                        return HttpNotFound();
                    }
                    Mapper.Initialize(cfg => cfg.CreateMap<GenreBLL, GenreViewModel>());
                    ICollection<GenreViewModel> genreList = Mapper.Map<IEnumerable<GenreBLL>, IEnumerable<GenreViewModel>>(genres).ToList();
                    return View("GenreSearch",genreList);
            }           
            return View();
            }
        public ActionResult Details(int id)
        {
            TrackBLL dbTrack = dbGet.GetTrack(id);
            Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, TrackViewModel>());
            TrackViewModel track = Mapper.Map<TrackBLL, TrackViewModel>(dbTrack);

            IEnumerable<TrackRateBLL> trackRates = dbGet.GetTrackRate(dbTrack.TrackName);

            ViewBag.TrackRates = trackRates;


            if (dbTrack.AuthorID != null)
            {
                AuthorBLL authorBLL = dbGet.GetAuthor((int)dbTrack.AuthorID);
                Mapper.Initialize(cfg => cfg.CreateMap<AuthorBLL, AuthorViewModel>());
                AuthorViewModel author = Mapper.Map<AuthorBLL, AuthorViewModel>
                    (authorBLL);
                ViewBag.Author = author;
                return PartialView(track);
            }
            else
            return PartialView("Details2", track);
        }

    }
}
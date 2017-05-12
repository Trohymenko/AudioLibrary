using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BLL.Interfaces;
using BLL.DTO;
using AudioLibrary.Models;

namespace AudioLibrary.Controllers
{
    public class HomeController : Controller
    {
        IGetInfoService dbGet;
        IModifyService dbMod;

        public HomeController(IGetInfoService dbGet, IModifyService dbMod)
        {
            this.dbGet = dbGet;
            this.dbMod = dbMod;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TrackSearch(string name)
        {
            IEnumerable<TrackDTO> tracks = null;
            if (name.Length != 0)
            {
                 tracks = dbGet.GetAllTracks().ToList().Where(track => track.TrackName == name);
            }
            else
            {
                 tracks = dbGet.GetAllTracks().ToList();
            }
            Mapper.Initialize(cfg => cfg.CreateMap<TrackDTO, TrackViewModel>());
            ICollection<TrackViewModel> trackList =  Mapper.Map<IEnumerable<TrackDTO>, IEnumerable<TrackViewModel>>(tracks).ToList();
            if (tracks.Count() <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(trackList);
        }
        public ActionResult Details(int id)
        {
            TrackDTO dbTrack = dbGet.GetTrack(id);
            Mapper.Initialize(cfg => cfg.CreateMap<TrackDTO, TrackViewModel>());
            TrackViewModel track = Mapper.Map<TrackDTO, TrackViewModel>(dbTrack);
            
            
            if (dbTrack.AuthorID != null)
            {
                AuthorDTO authorDTO = dbGet.GetAuthor((int)dbTrack.AuthorID);
                Mapper.Initialize(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>());
                AuthorViewModel author = Mapper.Map<AuthorDTO, AuthorViewModel>
                    (authorDTO);
                ViewBag.Author = author;
                return PartialView(track);
            }
            else
            return PartialView("Details2", track);
        }

    }
}
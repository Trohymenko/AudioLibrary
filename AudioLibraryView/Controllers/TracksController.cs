using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL.Services;
using BLL.Interfaces;
using BLL.DTO;
using AudioLibraryView.Models;

namespace AudioLibraryView.Controllers
{
    public class TracksController : Controller
    {
        IGetInfoService dbGet;
        IModifyService dbMod;

        public TracksController(IGetInfoService dbGet, IModifyService dbMod)
        {
            this.dbGet = dbGet;
            this.dbMod = dbMod;
        }

        public ActionResult Index()
        {
            IEnumerable<TrackDTO> tracksDTO = dbGet.GetAllTracks();
            Mapper.Initialize(cfg => cfg.CreateMap<TrackDTO, TrackViewModel>());
            ICollection<TrackViewModel> trackList = Mapper.Map<IEnumerable<TrackDTO>, IEnumerable<TrackViewModel>>(tracksDTO).ToList();
            IEnumerable < AuthorDTO > authorsDTO = dbGet.GetAllAuthors().ToList();
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>());
            ICollection<AuthorViewModel> authors = Mapper.Map<IEnumerable<AuthorDTO>, IEnumerable<AuthorViewModel>>(authorsDTO).ToList();
            ViewBag.Authors = authors;
            return View(trackList);
        }

        // GET: Tracks/Details/5
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

        // GET: Tracks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tracks/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tracks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tracks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

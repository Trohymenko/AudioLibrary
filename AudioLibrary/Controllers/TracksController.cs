using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL.Services;
using BLL.Interfaces;
using BLL.Entities;
using AudioLibrary.Models;

namespace AudioLibrary.Controllers
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
            IEnumerable<TrackBLL> tracksBLL = dbGet.GetAllTracks();
            Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, TrackViewModel>());
            ICollection<TrackViewModel> trackList = Mapper.Map<IEnumerable<TrackBLL>, IEnumerable<TrackViewModel>>(tracksBLL).ToList();
            IEnumerable < AuthorBLL > authorsBLL = dbGet.GetAllAuthors().ToList();
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorBLL, AuthorViewModel>());
            ICollection<AuthorViewModel> authors = Mapper.Map<IEnumerable<AuthorBLL>, IEnumerable<AuthorViewModel>>(authorsBLL).ToList();
            ViewBag.Authors = authors;
            return View(trackList);
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            TrackBLL dbTrack = dbGet.GetTrack((int)id);
            {
                if (dbTrack == null)
                {
                    return HttpNotFound();
                }
            }
            Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, TrackViewModel>());
            TrackViewModel track = Mapper.Map<TrackBLL, TrackViewModel>(dbTrack);


            if (dbTrack.AuthorID != null)
            {
                AuthorBLL authorBLL = dbGet.GetAuthor((int)dbTrack.AuthorID);
                Mapper.Initialize(cfg => cfg.CreateMap<AuthorBLL, AuthorViewModel>());
                AuthorViewModel author = Mapper.Map<AuthorBLL, AuthorViewModel>
                    (authorBLL);
                ViewBag.Author = author;
            }
            var ratings = dbGet.GetTrackRate(dbTrack.TrackName);
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.TrackRateValue);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }
            return PartialView(track);
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

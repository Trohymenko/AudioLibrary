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


            return PartialView(track);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int? id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Id)
        {          
            dbMod.DeleteTrack(Id);
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

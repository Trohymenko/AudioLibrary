using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BLL.Interfaces;
using BLL.Entities;
using AudioLibrary.Models;

namespace AudioLibrary.Controllers
{
    public class GenresController : Controller
    {
        IGetInfoService dbGet;
        IModifyService dbMod;

        public GenresController(IGetInfoService dbGet, IModifyService dbMod)
        {
            this.dbGet = dbGet;
            this.dbMod = dbMod;
        }

        public ActionResult Index()
        {
            IEnumerable<GenreBLL> genresBLL = dbGet.GetAllGenres();
            Mapper.Initialize(cfg => cfg.CreateMap<GenreBLL, GenreViewModel>());
            ICollection<GenreViewModel> genreList = Mapper.Map<IEnumerable<GenreBLL>, IEnumerable<GenreViewModel>>(genresBLL).ToList();
            genreList.OrderBy(genre => genre.GenreName);
            return View(genreList);
        }

        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id, FormCollection collection)
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

        public ActionResult Delete(int id)
        {
            return View();
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

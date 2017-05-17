using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BLL.Interfaces;
using BLL.Entities;
using AudioLibrary.Models;

namespace AudioLibrary.Controllers
{
    public class AlbumsController : Controller
    {
        IGetInfoService dbGet;
        IModifyService dbMod;

        public AlbumsController(IGetInfoService dbGet, IModifyService dbMod)
        {
            this.dbGet = dbGet;
            this.dbMod = dbMod;
        }
        public ActionResult Index()
        {
            IEnumerable<AlbumBLL> albumsBLL = dbGet.GetAllAlbums();
            Mapper.Initialize(cfg => cfg.CreateMap<AlbumBLL, AlbumViewModel>());
            ICollection<AlbumViewModel> albumList = Mapper.Map<IEnumerable<AlbumBLL>, IEnumerable<AlbumViewModel>>(albumsBLL).ToList();
            albumList.OrderBy(album => album.AlbumName);
            return View(albumList);
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

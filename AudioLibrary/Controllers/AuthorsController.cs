using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BLL.Interfaces;
using BLL.DTO;
using AudioLibrary.Models;

namespace AudioLibrary.Controllers
{
    public class AuthorsController : Controller
    {
        IGetInfoService dbGet;
        IModifyService dbMod;
        // GET: Authors
        public AuthorsController(IGetInfoService dbGet, IModifyService dbMod)
        {
            this.dbGet = dbGet;
            this.dbMod = dbMod;
        }
        public ActionResult Index()
        {
            IEnumerable<AuthorDTO> authorsDTO = dbGet.GetAllAuthors();
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>());
            ICollection<AuthorViewModel> authorList = Mapper.Map<IEnumerable<AuthorDTO>, IEnumerable<AuthorViewModel>>(authorsDTO).ToList();
            return View(authorList);
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

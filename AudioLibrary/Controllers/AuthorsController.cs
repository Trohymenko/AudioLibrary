﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BLL.Interfaces;
using BLL.Entities;
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
            IEnumerable<AuthorBLL> authorsBLL = dbGet.GetAllAuthors();
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorBLL, AuthorViewModel>());
            ICollection<AuthorViewModel> authorList = Mapper.Map<IEnumerable<AuthorBLL>, IEnumerable<AuthorViewModel>>(authorsBLL).ToList();
            authorList.OrderBy(author => author.AuthorName);
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

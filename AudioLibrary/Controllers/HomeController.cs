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
using System.IO;
using System.Security.Cryptography;

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
        public ActionResult Search(string term, string searchCategory)
        {
            ICollection<TrackViewModel> trackListView = null;
            ICollection<TrackBLL> tracksListDb = null;
            if (term.Length != 0)
            {
                try
                {
                    tracksListDb = dbSearch.Search(term, searchCategory).ToList();
                }
                catch (Exception)
                {
                    return View("Index");
                }
            }
            else
            {
                tracksListDb = dbGet.GetAllTracks().ToList();
            }
            if (tracksListDb.Count() == 0)
            {
                return PartialView("NotFound");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, TrackViewModel>());

            trackListView = Mapper.Map<IEnumerable<TrackBLL>, IEnumerable<TrackViewModel>>(tracksListDb).ToList();

            return View("TrackSearch", trackListView);
        }
    
               
        [HttpGet]
        public ActionResult Upload()
        {
            if (User.Identity.IsAuthenticated)
                return View("Upload");
            else return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> upload, string genreName)
        {
            if (upload != null)
            {
                byte[] b = new byte[128];
                string titleFromStream;
                string authorFromStream;
                string albumFromStream;


                foreach (var track in upload)
                {
                    byte[] trackByteArray = new byte[track.ContentLength];
                    track.InputStream.Read(trackByteArray, 0, trackByteArray.Length);

                    track.InputStream.Seek(-128, SeekOrigin.End);

                    track.InputStream.Read(b, 0, 128);
                    bool isSet = false;
                    String sFlag = System.Text.Encoding.Default.GetString(b, 0, 3);
                    if (sFlag.CompareTo("TAG") == 0)
                    {
                        isSet = true;
                    }
                    if (isSet)
                    {
                        titleFromStream = System.Text.Encoding.Default.GetString(b, 3, 30);
                        titleFromStream = titleFromStream.Replace("\0", string.Empty);
                       var uniqueFilePath = string.Format(@"/files/{0}.mp3", DateTime.Now.Ticks);
                        try
                        {
                            track.SaveAs(Server.MapPath(uniqueFilePath));
                        }
                        catch(Exception ex)
                        {
                            Console.Write(ex.Message);
                            break;
                        }
                        
                        authorFromStream = System.Text.Encoding.Default.GetString(b, 33, 30);
                        authorFromStream = authorFromStream.Replace("\0", string.Empty);

                        albumFromStream = System.Text.Encoding.Default.GetString(b, 63, 30);
                        albumFromStream = albumFromStream.Replace("\0", string.Empty);

                        TrackBLL newTrack = new TrackBLL { TrackName = titleFromStream, TrackLocation = uniqueFilePath };
                        AuthorBLL author = new AuthorBLL { AuthorName = authorFromStream };                       
                        AlbumBLL album = new AlbumBLL() { AlbumName = albumFromStream };
                        List<GenreBLL> genres = new List<GenreBLL>();
                        GenreBLL genre = new GenreBLL() {GenreName = genreName };
                        genres.Add(genre);
                        try
                        {
                            dbMod.CreateTrack(newTrack, author, genres, album);
                            RedirectToAction("Upload");
                        }
                        catch

                         {
                            System.IO.File.Delete(Server.MapPath(uniqueFilePath));
                         }

                    }
                }                               
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            TrackBLL dbTrack = dbGet.GetTrack(Id);
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
        public ActionResult Delete(int Id)
        {
            TrackRateBLL rate = dbGet.GetTrackRate(dbGet.GetTrack(Id).TrackName).FirstOrDefault();
            dbMod.DeleteTrackRate(rate);
            dbMod.DeleteTrack(Id);

            return RedirectToAction("Index");
        }

    }
}
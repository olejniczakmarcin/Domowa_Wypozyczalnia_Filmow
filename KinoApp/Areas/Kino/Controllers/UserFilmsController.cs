using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KinoApp.Areas.Kino.DAL;
using KinoApp.Areas.Kino.Data;
using KinoApp.Areas.Kino.Models;

namespace KinoApp.Areas.Kino.Controllers
{
    public class UserFilmsController : Controller
    {
        // GET: Kino/UserFilms
        KinoContext dtBase = new KinoContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserMovieInformation(int id)
        {
            var usr = dtBase.GetUsers(x => x.UserId == id);
            if(usr != null)
            {
                UsersModel userModel = new UsersModel
                {
                    Name = usr.Name,
                    Surname = usr.Surname,
                };
                return View("UserMovieInformation", userModel);
            }
            else
            {
                return View("UserMovieInformation", null);
            }
        }

        public PartialViewResult PartialMovieDescription(int id)
        {
            var userMovies = dtBase.GetOneMovieDescription(id);
            if(userMovies != null)
            {
                ModelMovieDescription desc = new ModelMovieDescription
                {
                    MovieId = userMovies.MovieId,
                    Description = userMovies.Desciption,
                    Time = userMovies.Time,
                    Scale = userMovies.Scale,
                };
                return PartialView("PartialMovieDescription", desc);
            }
            else
                return PartialView("PartialMovieDescription", null);
        }

        public JsonResult GetDataToTable(string sord, int page, int rows, string searchString)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var results = dtBase.GetUsersMovies(x => x.UserId == 1 && x.MovieId > 0).Select(
                a => new
                {
                    a.MovieId,
                    a.MovieName,
                    a.Price,
                    a.IsWatched
                }
                );
            List<UsersMovie> tmp = new List<UsersMovie>();
            foreach(var item in results)
            {
                var a = new UsersMovie
                {
                    MovieId = item.MovieId,
                    MovieName = item.MovieName,
                };
                tmp.Add(a);
            }
            int totalRecords = results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (sord.ToUpper() == "DESC")
            {
                results = results.OrderByDescending(s => s.MovieId);
                results = results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                results = results.OrderBy(s => s.MovieId);
                results = results.Skip(pageIndex * pageSize).Take(pageSize);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                results = results.Where(m => m.MovieName == searchString);
            }
            return Json(new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = results
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
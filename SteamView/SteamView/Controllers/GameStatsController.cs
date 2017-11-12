using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SteamView.Models;
using Microsoft.AspNet.Identity;

namespace SteamView.Controllers
{
    public class GameStatsController : Controller
    {
        private ApplicationDb db = new ApplicationDb();

        // GET: GameStats
        public ActionResult Index()
        {
            var game = db.GameStats.Include(g => g.UserAcount).ToList();
            int C = db.GameStats.Count();

            for (int i = 0; i < C; i++)
            {
                switch (game[i].GameName)
                {
                    case "Eve Online":
                        game[i].GameImmage = "https://i.imgur.com/x4HScyA.png";
                        break;

                    case "Kerbal Space Program":
                        game[i].GameImmage = "https://i.imgur.com/ScuQWCK.png";
                        break;

                    case "The Witcher Wild Hunt":
                        game[i].GameImmage = "https://i.imgur.com/ZtoLJkL.png";
                        break;

                    case "Wolfenstien The New Order":
                        game[i].GameImmage = "https://i.imgur.com/egPKDcA.png";
                        break;

                    default:
                        game[i].GameImmage = "https://i.imgur.com/u4K9lU3.png";
                        break;



    }

               
              
            }
            
            
            
            return View(game);
        }

        // GET: GameStats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameStats gameStats = db.GameStats.Find(id);
            if (gameStats == null)
            {
                return HttpNotFound();
            }
            return View(gameStats);
        }

        // GET: GameStats/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.UserAcounts, "UserID", "Name");
            return View();
        }

        // POST: GameStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GaneStatID,UserID,GameName,Status,MetaScore,LastPalayed,PlayTime")] GameStats gameStats)
        {
            var userId = User.Identity.GetUserId();
            var checkingId = db.UserAcounts.Where(c => c.ApplicationUserId == userId).First().UserID;

            gameStats.UserID = checkingId;
            gameStats.GameImmage = "";
            if (ModelState.IsValid)
            {
                db.GameStats.Add(gameStats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.UserAcounts, "UserID", "Name", gameStats.UserID);
            return View(gameStats);
        }

        // GET: GameStats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameStats gameStats = db.GameStats.Find(id);
            if (gameStats == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.UserAcounts, "UserID", "Name", gameStats.UserID);
            return View(gameStats);
        }

        // POST: GameStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GaneStatID,UserID,GameName,Status,MetaScore,LastPalayed,PlayTime")] GameStats gameStats)
        {
            var userId = User.Identity.GetUserId();
            var checkingId = db.UserAcounts.Where(c => c.ApplicationUserId == userId).First().UserID;

            gameStats.UserID = checkingId;
            gameStats.GameImmage = "";

            if (ModelState.IsValid)
            {
                db.Entry(gameStats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.UserAcounts, "UserID", "Name", gameStats.UserID);
            return View(gameStats);
        }

        // GET: GameStats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameStats gameStats = db.GameStats.Find(id);
            if (gameStats == null)
            {
                return HttpNotFound();
            }
            return View(gameStats);
        }

        // POST: GameStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameStats gameStats = db.GameStats.Find(id);
            db.GameStats.Remove(gameStats);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

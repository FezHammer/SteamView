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
    public class UserAcountsController : Controller
    {
        private ApplicationDb db = new ApplicationDb();


        [Authorize]
        // GET: UserAcounts/Details/5
        public ActionResult Details()
        {
            var id = User.Identity.GetUserId();
            var checkingId = db.UserAcounts.Where(c => c.ApplicationUserId == id).First().UserID;

            UserAcount userAcount = db.UserAcounts.Find(checkingId);
            if (userAcount == null)
            {
                return HttpNotFound();
            }
            return View(userAcount);
        }

       

        // GET: UserAcounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAcount userAcount = db.UserAcounts.Find(id);
            if (userAcount == null)
            {
                return HttpNotFound();
            }
            return View(userAcount);
        }

        // POST: UserAcounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Name,Age,Phone,Email,ApplicationUserId")] UserAcount userAcount)
        {
            var userId = User.Identity.GetUserId();
            var checkingStudentId = db.UserAcounts.Where(c => c.ApplicationUserId == userId).First().UserID;

            
            if (ModelState.IsValid)
            {
                db.Entry(userAcount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAcount);
        }

        // GET: UserAcounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAcount userAcount = db.UserAcounts.Find(id);
            if (userAcount == null)
            {
                return HttpNotFound();
            }
            return View(userAcount);
        }

        // POST: UserAcounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAcount userAcount = db.UserAcounts.Find(id);
            db.UserAcounts.Remove(userAcount);
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

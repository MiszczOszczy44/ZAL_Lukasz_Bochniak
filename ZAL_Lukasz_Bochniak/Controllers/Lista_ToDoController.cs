using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZAL_Lukasz_Bochniak.Models;

namespace ZAL_Lukasz_Bochniak.Controllers
{
    public class Lista_ToDoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lista_ToDo
        public ActionResult Index()
        {
            return View(db.Lista.ToList());
        }

        // GET: Lista_ToDo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_ToDo lista_ToDo = db.Lista.Find(id);
            if (lista_ToDo == null)
            {
                return HttpNotFound();
            }
            return View(lista_ToDo);
        }

        // GET: Lista_ToDo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lista_ToDo/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Opis,Gotowe")] Lista_ToDo lista_ToDo)
        {
            if (ModelState.IsValid)
            {
                string CurrentUserID = User.Identity.GetUserId();
                ApplicationUser CurrentUser = db.Users.FirstOrDefault(x => x.Id == CurrentUserID);
                lista_ToDo.User = CurrentUser;
                db.Lista.Add(lista_ToDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lista_ToDo);
        }

        // GET: Lista_ToDo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_ToDo lista_ToDo = db.Lista.Find(id);
            if (lista_ToDo == null)
            {
                return HttpNotFound();
            }
            return View(lista_ToDo);
        }

        // POST: Lista_ToDo/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Opis,Gotowe")] Lista_ToDo lista_ToDo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lista_ToDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lista_ToDo);
        }

        // GET: Lista_ToDo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_ToDo lista_ToDo = db.Lista.Find(id);
            if (lista_ToDo == null)
            {
                return HttpNotFound();
            }
            return View(lista_ToDo);
        }

        // POST: Lista_ToDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lista_ToDo lista_ToDo = db.Lista.Find(id);
            db.Lista.Remove(lista_ToDo);
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

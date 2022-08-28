using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01_EDII.Controllers
{
    public class AVLController : Controller
    {
        // GET: AVL
        public ActionResult Index()
        {
            return View();
        }

        // GET: AVL/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AVL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AVL/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AVL/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AVL/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AVL/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AVL/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

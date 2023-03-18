using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSArticle.Models.Context;
using CMSArticle.Models.Models;
using CMSArticle.Service.Service;
using CMSArticle.Repository.Repository;
using CMSArticle.Models.ViewModels;
using CMSArticle.App_Start;

namespace CMSArticle.Areas.admin.Controllers
{
    public class CategoriesController : Controller
    {
        private DbCMSArticleContext db = new DbCMSArticleContext();
        CategoryService _CategoryService;

        public CategoriesController()
        {
            _CategoryService = new CategoryService(db);
        }


        public ActionResult Index()
        {
            var categoryList = _CategoryService.GetAll();

            var categoryListViewModel = AutoMapperConfig.mapper.Map<IEnumerable<Category>, List<CategoriesViewModels>>(categoryList);

            return PartialView(categoryListViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CategoryId,Title")] Category category)
        public ActionResult Create([Bind(Include = "CategoryId,Title")] CategoriesViewModels category)
        {
            if (ModelState.IsValid)
            {
                _CategoryService.Add(new Category() {
                    CategoryId= category.CategoryId,
                    Title=category.Title
                });
                _CategoryService.Save();
                return Redirect("Index");
            }
            return View();
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _CategoryService.GetEntity(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Title")] Category category)
        {
            if (ModelState.IsValid)
            {
                _CategoryService.Update(category);
                _CategoryService.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _CategoryService.GetEntity(id);
            _CategoryService.Delete(category);
            _CategoryService.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _CategoryService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

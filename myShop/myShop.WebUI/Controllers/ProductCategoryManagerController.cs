using myShop.Core.Contracts;
using myShop.Core.Models;
using myShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        IRepository<productCategory>  context;

        public ProductCategoryManagerController(IRepository<productCategory> context)
        {
            this.context = context;
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<productCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            productCategory ProductCategory = new productCategory();
            return View(ProductCategory);
        }

        [HttpPost]
        public ActionResult Create(productCategory ProductCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(ProductCategory);
            }
            else
            {
                context.Insert(ProductCategory);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            productCategory ProductCategory = context.Find(Id);
            if (ProductCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ProductCategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(productCategory product, string Id)
        {
            productCategory ProductCategoryToEdit = context.Find(Id);
            if (ProductCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);

                }

                ProductCategoryToEdit.Category = product.Category;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            productCategory productCategoryToDelete = context.Find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult confirmDelete(string Id)
        {
            productCategory productCategoryToDelete = context.Find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }

        }
    }
}
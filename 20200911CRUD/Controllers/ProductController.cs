using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _20200911CRUD.DataAccess;
using _20200911CRUD.Models;
namespace _20200911CRUD.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ActionName("Insert")]
        public ActionResult ProductInsert(ProductModel reqProduct)
        {
            SQLDataAccess da = new SQLDataAccess();
            ProductModel model = new ProductModel();
            model = da.InsertProduct(reqProduct);
            return Json(model.Msg, JsonRequestBehavior.AllowGet);
        }
        [ActionName("Listing")]
        public ActionResult ProductListing()
        {
            SQLDataAccess da = new SQLDataAccess();
            ProductModel model = new ProductModel();
            model = da.SelectProduct();
            return View("ProductListing",model);
        }
        [ActionName("Edit")]
        public ActionResult ProductEdit(ProductModel reqProduct)
        {
            SQLDataAccess da = new SQLDataAccess();
            ProductModel model = new ProductModel();
            model = da.EditProduct(reqProduct);
            return Json(model.Msg, JsonRequestBehavior.AllowGet);
        }

        [ActionName("Delete")]
        public ActionResult ProductDelete(string id)
        {
            SQLDataAccess da = new SQLDataAccess();
            ProductModel model = new ProductModel();
            model = da.DeleteProduct(id);
            return Json(model.Msg, JsonRequestBehavior.AllowGet);
        }
    }
}
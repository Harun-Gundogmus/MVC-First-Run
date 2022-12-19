using Microsoft.AspNetCore.Mvc;
using MVCIlkDers.Models;
using System.Collections.Generic;

namespace MVCIlkDers.Controllers
{
    public class ProductController : Controller
    {
        // Action türleri dönüş tiplerimiz var. 
        /*
         Bildiğiniz üzere client'ten gelen request'leri controller'ımız karşılayıp uygun action'a yönlendirmekteydi. 
         Action'da ihtiyacımıza göre operasyonu yönetiyodu. 
         İşte bu durumlarda metodumuzun farklı türleri olabilmekte. 
         */

        #region JsonResult
        public JsonResult GetProducts()
        {
            JsonResult result = Json(new Product
            {
                    product_Id = 1,
                    product_Name = "IPHONE",
                    product_Price = 150

            } );
            return result;
        }
        #endregion // JSON Tipi Dönüş

        //ActionResult Tipi Dönüş ve Veri Listeleme(Viewbag, data etc)
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { product_Id = 1, product_Name = "SAMSUNG", product_Price = 160},
                new Product {product_Id = 2, product_Name = "VESTEL", product_Price = 120},
                new Product {product_Id = 3, product_Name = "NOKIA", product_Price = 150}
            };


            #region Model Esaslı Veri Gönderimi
            //return View(products);
            #endregion


            #region VIEWBAG

            //Taşınacak olan veriyi dinamik bir şekilde almamızı sağlayan yapıdır.(Değişkenle)

            ViewBag.Products = products;
            #endregion

            #region VIEWDATA
            // Bu yapıda viewbag gibi veri taşımamıza yarar ancak farklı olarak boxing ve unboxing işlemleri vardır.

            ViewData["products"] = products;
            #endregion

            return View(products);
        }


        //Ekrana sayfayı taşıyan default'unda get olan alttaki action
        public IActionResult CreateProduct()
        {
            return View();
        }
        //Bu yapı ise kullanıcıdan parametrelerle verileri karşıladı.
        [HttpPost]
        public IActionResult CreateProduct(string txtName, int txtProductPrice)
        {
            return View();
        }
    }


}

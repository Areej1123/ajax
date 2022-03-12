using ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ajax.Controllers
{
    public class PostController : Controller
    {
        private string domain = "http://localhost:49910/api/product/";
        public HttpClient httpClient = new HttpClient();
        
        // GET: Home
        public ActionResult Index()
        {
            List<Product> products = null;
            httpClient.BaseAddress = new Uri(this.domain);
            var getdata = httpClient.GetAsync("getall");
            getdata.Wait();
            var result = getdata.Result;
            if(result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsAsync<IList<Product>>();
                data.Wait();
                products = (List<Product>)data.Result;
                
                if(products.Count>0)
                {
                    return View(products);
                }

            }
            return View("notfound");
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            httpClient.BaseAddress = new Uri(this.domain);
            var getdata = httpClient.PostAsJsonAsync("add",product);
            getdata.Wait();
            var result = getdata.Result;
            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsAsync<string>();
                data.Wait();
                return RedirectToAction("index");
            }
            return View("notfound");
        }
        [HttpPost]
        public ActionResult update(Product product,int id)
        {
            httpClient.BaseAddress = new Uri(this.domain);
            var getdata = httpClient.PutAsJsonAsync("add?id="+id, product);
            getdata.Wait();
            var result = getdata.Result;
            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsAsync<string>();
                data.Wait();
                return RedirectToAction("index");
            }
            return View("notfound");
        }
        [HttpGet]
        public ActionResult Del(int id)
        {
            httpClient.BaseAddress = new Uri(this.domain);
            var getdata = httpClient.DeleteAsync("add?id=" + id);
            getdata.Wait();
            var result = getdata.Result;
            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsAsync<string>();
                data.Wait();
                return RedirectToAction("index");
            }
            return View("notfound");
        }
    }
}
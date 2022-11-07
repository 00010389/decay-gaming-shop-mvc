using Newtonsoft.Json;
using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Controllers
{
    public class ProductController : Controller
    {
        string baseApiAddress = "http://ec2-18-183-214-245.ap-northeast-1.compute.amazonaws.com/";
        // GET: Product
        public async Task<ActionResult> Index()
        {
            List<Product> products = new List<Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseApiAddress);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Product");

                if (res.IsSuccessStatusCode)
                {
                    var prRes = res.Content.ReadAsStringAsync().Result;

                    products = JsonConvert.DeserializeObject<List<Product>>(prRes);
                }
            }
            return View("Index", products);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Product/
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseApiAddress);
                client.DefaultRequestHeaders.Clear();

                string json = JsonConvert.SerializeObject(product);
                StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await client.PostAsync("api/Product", httpContent);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }

        // GET: Product/Id
        public async Task<ActionResult> Edit(int ID)
        {
            Product product = new Product();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseApiAddress);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Product/" + ID);

                if (res.IsSuccessStatusCode)
                {
                    var prRes = res.Content.ReadAsStringAsync().Result;

                    product = JsonConvert.DeserializeObject<Product>(prRes);
                }
            }
            return View("Create", product);
        }

        // PUT: Product/
        [HttpPost]
        public async Task<ActionResult> Edit(Product product)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseApiAddress);
                client.DefaultRequestHeaders.Clear();

                string json = JsonConvert.SerializeObject(product);
                StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await client.PutAsync(client.BaseAddress + "api/Product", httpContent);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Create", product);

            }
        }

        // GET: Product/Id
        public async Task<ActionResult> Details(int ID)
        {
            Product product = new Product();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseApiAddress);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Product/" + ID);

                if (res.IsSuccessStatusCode)
                {
                    var prRes = res.Content.ReadAsStringAsync().Result;

                    product = JsonConvert.DeserializeObject<Product>(prRes);
                }
            }
            return View("Details", product);
        }

        // DELETE Product/Id
        public async Task<ActionResult> Delete(int ID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseApiAddress);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.DeleteAsync("api/Product/" + ID);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
    }
}
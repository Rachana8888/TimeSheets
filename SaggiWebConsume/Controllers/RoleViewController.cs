using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaggiWebConsume.Models;

namespace SaggiWebConsume.Controllers
{
    public class RoleViewController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:8082/api");
        private readonly HttpClient _client;
        public RoleViewController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<RoleView> roleViews = new List<RoleView>();
            HttpResponseMessage response = _client.GetAsync(baseAddress+"/roles").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                roleViews = JsonConvert.DeserializeObject<List<RoleView>>(data);

            }

           
        
            return View(roleViews);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoleView view)
        {
            try
            {
                String data = JsonConvert.SerializeObject(view);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/roles", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Role Added";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] =ex.Message;

                return View();
            }


              
            return View(); 
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            try
            {
                RoleView roleView = new RoleView();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/roles/"+id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    roleView = JsonConvert.DeserializeObject<RoleView>(data);
                }
                return View(roleView);
            }
            catch (Exception ex)
            {

                TempData["errorMessge"] = ex.Message;
                return View();
            }      
         }
        [HttpPost]
        public IActionResult Edit(RoleView view)
        {
            try
            {
                string data = JsonConvert.SerializeObject(view);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/roles", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Role Updated";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessge"] = ex.Message;
                return View();
            }
            return View();

        }


    }
}

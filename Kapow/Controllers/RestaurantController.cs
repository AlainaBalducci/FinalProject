using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Kapow.Models;

namespace Kapow.Controllers
{
    public class RestaurantController : Controller
    {
        //Baseurl will allow the controller to talk to the api through the local host.  i think
        string Baseurl = "https://localhost:7248";


        //Search bar function for list of restaurants
        public async Task<IActionResult> Index()
        {
            List<RestaurantDto> restaurants = new List<RestaurantDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("/api/restaurant");
                if (response.IsSuccessStatusCode)
                {
                    var RestaurantResponse = response.Content.ReadAsStringAsync().Result;
                    restaurants = JsonConvert.DeserializeObject<List<RestaurantDto>>(RestaurantResponse);
                    //ViewBag.restaurants = restaurants;
                }
            }
            return View(restaurants);
        }

        public IActionResult Create() 
        {
            return View();
        }

        public IActionResult Update() 
        {
        return View();
        }

        public IActionResult Delete() 
        { 
            return View(); 
        }    

        public IActionResult Detail()
        {
            return View();
        }
    }
}

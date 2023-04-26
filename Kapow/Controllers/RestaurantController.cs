﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Kapow.Models;
using Kapow.Data;
using Microsoft.EntityFrameworkCore;

namespace Kapow.Controllers
{
    public class RestaurantController : Controller
    {
        //Baseurl will allow the controller to talk to the api through the local host.  i think
        string Baseurl = "https://localhost:7248";
        private ProfileDbContext context;
        

        //Get request to list off all restaurants
        public async Task<IActionResult> Index()
        {
            List<RestaurantDto> allRestaurants = new List<RestaurantDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("/api/restaurant");
                if (response.IsSuccessStatusCode)
                {
                    var RestaurantResponse = response.Content.ReadAsStringAsync().Result;
                    allRestaurants = JsonConvert.DeserializeObject<List<RestaurantDto>>(RestaurantResponse);
                    
                }
            }
            return View(allRestaurants);
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            List<RestaurantDto> allRestaurants = new List<RestaurantDto>();
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("/api/restaurant");
                if (response.IsSuccessStatusCode)
                {
                    var RestaurantResponse = response.Content.ReadAsStringAsync().Result;
                    allRestaurants = JsonConvert.DeserializeObject<List<RestaurantDto>>(RestaurantResponse);

                }
            }
            return View(allRestaurants);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string selectTerm, string? keyword, string foodType, string searchType)
        {

            List<RestaurantDto> restaurants = new List<RestaurantDto>();
            List<RestaurantDto> test = new List<RestaurantDto>();


            //GET data from api and house it in a variable
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
            if (searchType == "Name")
            {
                foreach (var r in restaurants)
                {
                    if (r.Name == keyword)
                    {
                        test.Add(r);
                    }
                }
            }
            else if (searchType == "Location")
            {
                foreach (var r in restaurants)
                {
                    if (r.Location == selectTerm)
                    {
                        test.Add(r);
                    }
                }
            }
            else if (searchType == "Food Type")
            {
               
                    
                foreach (var r in restaurants)
                {
                    int num = (int)r.FoodTag;
                    if (num == Int32.Parse(foodType))
                    {
                        test.Add(r);
                    }
                }
            }




            return View("search", test);
        }


        public IActionResult Result() 
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

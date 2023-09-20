using Newtonsoft.Json;
using ProjectinMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ProjectinMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Login()
        {

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            string Baseurl = "https://localhost:44304/";
            //if (ModelState.IsValid)
            //{
                List<User> UserInfo = new List<User>();
                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.GetAsync("api/Values/GetUsers");
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        UserInfo = JsonConvert.DeserializeObject<List<User>>(EmpResponse);
                        foreach (var i in UserInfo)
                        {
                            if (i.Email == user.Email && i.Password == user.Password)
                            {
                                return RedirectToAction("About", "Home");
                            }
                            else
                            {
                                ViewBag.Message = "Invalid Username or Password";
                            ModelState.Clear();
                            return View("Login");
                            }
                        }
                    }
                    //returning the employee list to view
                    return View();
                }

            //}
            //else
            //{
            //    return View();
            //}

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Signup()
        {

            return View();
        }
    }
}
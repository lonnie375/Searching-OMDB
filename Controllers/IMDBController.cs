using Microsoft.AspNetCore.Mvc;
using SearchingOMDB.Models;

namespace SearchingOMDB.Controllers
{
    public class IMDBController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Speak to the API
        //If you use an async method then the method itself has to be async as well. 
        public async Task<IActionResult> SearchMovie(string searchTerm)
        {
            //Designed to make requests on behalf of clients. 
            //It will be able to call out the API 
           HttpClient client = new HttpClient();

            //The address/URL of the API
            client.BaseAddress = new Uri("http://www.omdbapi.com");


            //This is the last portion of the URL after you inserted your Key and Value on Postman: http://www.omdbapi.com?t=searchterm
            //Always await an async method or it will just run. This stops and make sures that the process is complete
            //Get here also correlates with the Get on PostMan's website 
            var response = await client.GetFromJsonAsync<IMDBResponse>("?t=" + searchTerm + "&apiKey=5785a2a5");

            return View(response);
        }
    }
}

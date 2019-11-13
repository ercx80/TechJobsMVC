using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;//this we have to pass to the view in each method return
            ViewBag.title = "Search";
            return View();
        }
        public IActionResult Results(string searchType,string searchTerm)//This method returns the values of all jobs based on the keyword.
        {
            
            if (searchType.Equals("all"))
            {
                List<Dictionary<string, string>> result = JobData.FindByValue(searchTerm);
                ViewBag.jobs = result;
                

               
            }
     
            else

            {
                List<Dictionary<string, string>> result = JobData.FindByColumnAndValue(searchType, searchTerm);//this method returns results based on the columns(radio buttons) and keyword
               
                ViewBag.jobs = result;
                
            }
            ViewBag.columns = ListController.columnChoices;
            //ViewBag.title = "Search by " + ListController.columnChoices[searchType] + ": " + searchTerm;
            return View("Index");

        }
     

        


        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}

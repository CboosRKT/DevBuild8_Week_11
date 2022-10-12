using _11_1_Deck_of_Cards.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _11_1_Deck_of_Cards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

 
        async  public Task <IActionResult> Index(CardResponse PlayDeck)
          {
            

              HttpClient web = new HttpClient();
              web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");
              // var connection = await web.GetAsync("");

              string deckDirect = "";

              if (PlayDeck.deck_id == null)
              {


                  deckDirect = "new/draw/?count=0";
                  var connection = await web.GetAsync(deckDirect);
                PlayDeck = await connection.Content.ReadAsAsync<CardResponse>();

               
               
                
            }
              
            else

              
            {
                 

               //   string dID = PlayDeck.deck_id;
             //   deckDirect = dID + "/draw/?count=" + 5;//drawNum;                   
                
            
            }

         //   var connection = await web.GetAsync(deckDirect);
         //   PlayDeck = await connection.Content.ReadAsAsync<CardResponse>();
            return View(PlayDeck);





        }

    /*    [ActionName("IndexDraw")]
        async public Task<IActionResult> Index(string dID, int drawNum)
        {


            HttpClient web = new HttpClient();
            web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");
            // var connection = await web.GetAsync("");

        


         


             
              string  deckDirect = dID + "/draw/?count=" + drawNum;                   


       

            var connection = await web.GetAsync(deckDirect);
            CardResponse PlayDeck = await connection.Content.ReadAsAsync<CardResponse>();
            return View("Index", PlayDeck);





        }*/


        async public Task <IActionResult> Draw(string dID, int drawNum)
        {
            


            HttpClient web = new HttpClient();
            web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");
             string deckDirect = dID+"/draw/?count="+drawNum;

           // string deckDirect = $"{dID}/draw/?count=0";

            var connection = await web.GetAsync(deckDirect);


            CardResponse PlayDeck = await connection.Content.ReadAsAsync<CardResponse>();

            // int drawNum2 = 5;

         //   var routeValues = new RouteValueDictionary { { "dID", PlayDeck.deck_id }, { "drawNum", drawNum } };//drawNum2} };
            //    return RedirectToAction("IndexDraw", routeValues); //, routeValues);  // RedirectToAction("Index", (PlayDeck,  drawNum));
            return View("index", PlayDeck);

        }
        public IActionResult Privacy()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
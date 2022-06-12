using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OorahScraper.Scraping;

namespace OorahScraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrizeController : ControllerBase
    {
        [HttpGet]
        [Route("gettenprizes")]
        public List<Prize> GettenPrizes()
        {
            var prizes = Scraper.GetTenPrizes();
            //return Scraper.GetTenPrizes();
            return prizes;
        }
    }
}

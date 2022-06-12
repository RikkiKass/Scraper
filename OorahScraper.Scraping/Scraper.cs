using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;

namespace OorahScraper.Scraping
{
    public static class Scraper
    {
        public static List<Prize> GetTenPrizes()
        {
            
            var html = GetHtml();
            var allPrizes = ParseHtml(html);
            Random rnd = new Random();
            var skip = rnd.Next(1, 47);
            return allPrizes.Skip(skip).Take(10).ToList();
            //return allPrizes;
        }
        private static string GetHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
            };
            var client = new HttpClient();
            return client.GetStringAsync("https://www.oorahauction.org/").Result;
        }
        private static List<Prize> ParseHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var resultDivs = document.QuerySelectorAll(".portfolio-item");
            var prizes = new List<Prize>();
            foreach(var div in resultDivs)
            {
                var prize = new Prize();
                var title = div.QuerySelector(".portfolio-caption");
                if (title != null)
                {
                    prize.Title = title.TextContent;
                }
                var image = div.QuerySelector(".img-responsive");
                if (image != null)
                {
                    var url = "https://www.oorahauction.org/";

                    prize.ImageUrl = url+=image.Attributes["src"].Value;
                }

                prizes.Add(prize);
            }
            return prizes;
        }
    }
}

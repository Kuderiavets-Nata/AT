using NUnit.Framework;
using HtmlAgilityPack;
using System;
using System.Text.RegularExpressions;
using System.Net;

namespace Lab5
{
    public class Tests
    {
       

        [Test]
        public void HtmlAgalityPack()
        {
            HtmlDocument doc = new HtmlDocument();
            var html = @"https://allitbooks.net/";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);
            string srt = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='main - content']/div[1]/div/div[1]/article[1]/div[2]/h2/a").Attributes["href"].Value;

            using (WebClient webClient = new WebClient())
            {
                string changeString = Regex.Match(srt, @"\d+").Value;
                int resultSring = Int32.Parse(changeString) + 1;

                for (int i = 0; i < 10; i++) //5481
                {
                    var downloadUrl = html + "download-file-" + (resultSring - 1) + ".hmtl";
                    var saveBook = (resultSring - 1) + ".pdf";
                    webClient.DownloadFileAsync(new Uri(downloadUrl), saveBook);
                }
            }
        }

    }
}
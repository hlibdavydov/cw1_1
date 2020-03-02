using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            Console.WriteLine("Enter url of webPage");
            var url = Console.ReadLine();
           // var webPageText = await httpClient.GetAsync(url);
            var client = new WebClient();
            var webPageText =  client.DownloadString(url);
            //Console.WriteLine(webPageText);
            
            foreach (var email in ExtractEmails(webPageText))
            {
                Console.WriteLine(email);
            }

            Console.ReadLine();
        }
        public static string[] ExtractEmails(string webSiteContext)
        {
            const string regexPattern = @"\b[A-Z0-9._-]+@[A-Z0-9][A-Z0-9.-]{0,61}[A-Z0-9]\.[A-Z.]{2,6}\b";

            // Find matches
            var matches
                = System.Text.RegularExpressions.Regex.Matches(webSiteContext, regexPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            var matchList = new string[matches.Count];

            // add each match
            var emailsCounter = 0;
            foreach (var match in matches)
            {
                matchList[emailsCounter] = match.ToString();
                emailsCounter++;
            }

            return matchList;
        }
    }
}
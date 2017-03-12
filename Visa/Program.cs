using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Visa
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = "21-03-2017";
            var url = "https://www.visa4uk.fco.gov.uk/Appointment/GetTimeSlots";
            var parameters = "?postId=567e0007-67d9-e511-95ad-005056922509&id=" + date + "&count=%0A++++-1%0A++&preSelectedTime=&selectedPostVisaTypeId=980";
            var username = "mehdikhanii@gmail.com";
            var password = "Mehdikhanii26842684";


            var handler = new WebRequestHandler();
            CredentialCache creds = new CredentialCache();
            handler.CookieContainer = new CookieContainer();
            handler.UseCookies = true;
            handler.UseDefaultCredentials = true;
            creds.Add(new Uri(url), "basic",
                                    new NetworkCredential(username, password));
            handler.Credentials = creds;
            handler.PreAuthenticate = true;
            using (HttpClient client = new HttpClient(handler))
            {
                //client.getParams().setAuthenticationPreemptive(true);
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response = client.GetAsync(parameters).Result;  
                if (response.IsSuccessStatusCode)
                {
                    var timeSlots = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine("{0}", timeSlots);
                    
                }
                else { Console.WriteLine(response.ReasonPhrase); }

                Console.ReadLine();
            }
        }

        void OpenBrowser()
        {
            System.Diagnostics.Process.Start("http://google.com");
        }
    }
}

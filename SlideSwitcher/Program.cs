using SliderSwitcher.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SlideSwitcher
{
    class Program
    {
        private static string sliderId = string.Empty;
        private static string sliderApiConnection = ConfigurationManager.AppSettings["SliderApiConnection"];

        static void Main(string[] args)
        {
            Console.Write("Please enter your sliderId: ");
            sliderId = Console.ReadLine();
            Console.Write("\nPowerPoint Commands: \n\n[N]ext \n[P]revious \n[F]irst \n[L]ast \n[E]xit\n");

            var stop = false;

            do
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.N:
                        {RunAsync("Next").Wait(); }
                        break;

                    case ConsoleKey.P:
                        { RunAsync("Previous").Wait(); }
                        break;

                    case ConsoleKey.F:
                        { RunAsync("First").Wait(); }
                        break;

                    case ConsoleKey.L:
                        { RunAsync("Last").Wait(); }
                        break;

                    default:
                        stop = true;
                        break;
                }

            } while (stop == false);

            
        }

        static async Task RunAsync(string command)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(sliderApiConnection);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var sliderClient = new SliderClient() { ClientId = sliderId };

                var response = await client.PostAsJsonAsync<SliderClient>(command, sliderClient);
            }
        }
    }
}



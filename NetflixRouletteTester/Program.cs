using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Reflection;
namespace NetflixRouletteTester
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var req = new NetflixRouletteAPI.NetflixRouletteAPI();
            var res = req.GetData("Justice League");
            foreach (PropertyInfo pi in res.GetType().GetProperties())
            {
                Console.WriteLine(pi.Name + ": " + pi.GetValue(res));
            }   
            Console.Read();
        }
    }
}

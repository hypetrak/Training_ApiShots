using System;
using System.IO;
using System.Net;

namespace Training_ApiShots
{
    class Program
    {
        static void Main()
        {
            TestGet();
        }

        
        //określamy typ returna!!!
        public static object TestGet()
        {
            //deklaracja Urla
            ApiMethods MethodGet = new ApiMethods();  

            MethodGet.UrlToTest = String.Format("https://jsonplaceholder.typicode.com/posts/1/comments");
            
            //stwórz Request do URL
            WebRequest RequestObject = WebRequest.Create(MethodGet.UrlToTest);
            //określ metodę
            RequestObject.Method = "GET";
            //zadeklaruj pole do przechowania odpowiedzi
            HttpWebResponse ResponseObject;
            //przypisz odpowiedz
            ResponseObject = (HttpWebResponse)RequestObject.GetResponse();
            //zadeklaruj string i przypisz mu odpowiedz w tej formie

            
            using (Stream stream = ResponseObject.GetResponseStream())
            {
            StreamReader sr = new StreamReader(stream);
            MethodGet.ResultOfGet = sr.ReadToEnd();
            //zamknij streamreadera
            sr.Close();
            }
            Console.WriteLine(MethodGet.ResultOfGet);
            return MethodGet;
        }
    }
    public class ApiMethods
    {
        public string ResultOfGet { get; set; }
        public string UrlToTest { get; set; }
    }
}

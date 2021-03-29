using System;
using System.IO;
using System.Net;
using System.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Training_ApiShots
{
    class Program
    {
        static void Main()
        {
            TestGet();
            //TestPost();
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

            DeserializedJson DeserializedGet = new DeserializedJson();
            // kurwa czemu to nie dziala
            // DeserializedGet = JsonSerializer.Deserialize<List<DeserializedJson>>(MethodGet.ResultOfGet);

            
            return MethodGet;
        }

        public static object TestPost()
        {
            //deklaracja Urla
            ApiMethods MethodPost = new ApiMethods();
           
            //credentials -----------
            //Credentials SetCredentials = new Credentials();
            //Console.WriteLine("Enter user name: ");
            //SetCredentials.UserName = Console.ReadLine();
            //Console.WriteLine("Enter password: ");
            //SetCredentials.Password = Console.ReadLine();

            MethodPost.UrlToTest = String.Format("https://jsonplaceholder.typicode.com/posts");

            //stwórz Request do URL
            WebRequest RequestObject = WebRequest.Create(MethodPost.UrlToTest);
            //określ metodę i parametry
            RequestObject.Method = "POST";
            RequestObject.ContentType = "application/json";
            
            //credentials -----------
            //RequestObject.Credentials = new NetworkCredential(SetCredentials.UserName, SetCredentials.Password);

            //zadeklaruj pole do przechowania odpowiedzi
            HttpWebResponse ResponseObject;
            //przypisz odpowiedz
            
            //zadeklaruj string i przypisz mu odpowiedz w tej formie

            MethodPost.PostData = "{\title\":\"testdata22133\",\"body\":\"testbody521212\",\"userId\":\"451212\"}";

            using (var StreamWriter = new StreamWriter(RequestObject.GetRequestStream()))
            {
                StreamWriter.Write(MethodPost.PostData);
                StreamWriter.Flush();
                StreamWriter.Close();


                ResponseObject = (HttpWebResponse)RequestObject.GetResponse();

                using (var srPost = new StreamReader(ResponseObject.GetResponseStream()))
                {
                    MethodPost.ResultOfPost = srPost.ReadToEnd();
                    //zamknij streamreadera
                    srPost.Close();
                }
            }

            Console.WriteLine(MethodPost.ResultOfPost);
            return MethodPost;
        }
    }
    
    public class ApiMethods
    {
        public string ResultOfGet { get; set; }
        public string ResultOfPost { get; set; }
        public string UrlToTest { get; set; }
        public string PostData { get; set; }
    }
    public class Credentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


}

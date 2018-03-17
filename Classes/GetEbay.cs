using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace guitarServer.Classes
{
    public class GetEbay
    {
        public static async Task<string> GetGuitarsAsync(string urlFirstHalf, string urlSecondHalf)
        {
            // empty string to hold json string
            string JsonObj = "";
            // create a new client
            using (HttpClient client = new HttpClient())
            // get response from client with desire path 
            using (HttpResponseMessage res = await client.GetAsync(path))
            // store content into new httpContent class
            using (HttpContent content = res.Content)
            {
                // capture xml as string because using read as stream breaks app
                string data = await content.ReadAsStringAsync();
                // create empty xml document
                XmlDocument doc = new XmlDocument();
                // load xml doc with xml string
                doc.LoadXml(data);
                // turn it into a xmlNode
                XmlNode newNode = doc.DocumentElement;
                // turn it into a JSON string
                JsonObj = JsonConvert.SerializeXmlNode(newNode);

                //if we got something write it to the console
                if (data != null)
                {
                Console.WriteLine(JsonObj);
                }
                
            }
            //return Json object
            return JsonObj;
        }
    }
}
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
        public static async Task<string> GetGuitarsAsync(string path)
        {
            string JsonObj = "";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(path))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);
                XmlNode newNode = doc.DocumentElement;
                JsonObj = JsonConvert.SerializeXmlNode(newNode);

                if (data != null)
                {
                Console.WriteLine(JsonObj);
                }
                
            }
            return JsonObj;
        }
    }
}
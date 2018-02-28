using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomiss
{
    public class Generator
    {
        public int Num { get; set; }

        public int Length { get; set; }

        private HtmlAgilityPack.HtmlDocument Connection { get; set; }

        public Generator(int num, int length)
        {
            this.Num = num;
            this.Length = length;
            this.Connection = SetConnection();
        }

        public string[] GetData()
        {
            var rawData = Connection.DocumentNode.SelectNodes("//pre[@class='data']").FirstOrDefault();
            return rawData.InnerText.Split('\n');
        }
        
        private HtmlAgilityPack.HtmlDocument SetConnection()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.random.org/strings/?num=" + this.Num + "&len=" + this.Length + "&digits=on&upperalpha=on&loweralpha=on&unique=on&format=html&rnd=new");
            return doc;

        }
    }
}

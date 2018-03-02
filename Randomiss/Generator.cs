namespace Randomiss
{
    using System.Collections.Generic;
    using System.Linq;

    public class Generator
    {
        public Generator(int num, int length)
        {
            this.Num = num;
            this.Length = length;
            this.Connection = this.SetConnection();
        }

        public int Num { get; set; }

        public int Length { get; set; }

        private HtmlAgilityPack.HtmlDocument Connection { get; set; }

        public List<string> GetData()
        {
            var rawData = this.Connection.DocumentNode.SelectNodes("//pre[@class='data']").FirstOrDefault();
            List<string> filteredData = new List<string>();
            foreach (var item in rawData.InnerText.Split('\n'))
            {
                if (!string.IsNullOrWhiteSpace(item.ToString()))
                {
                    filteredData.Add(item);
                }
            }

            return filteredData;
        }
        
        private HtmlAgilityPack.HtmlDocument SetConnection()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.random.org/strings/?num=" + this.Num + "&len=" + this.Length + "&digits=on&upperalpha=on&loweralpha=on&unique=on&format=html&rnd=new");
            return doc;
        }
    }
}

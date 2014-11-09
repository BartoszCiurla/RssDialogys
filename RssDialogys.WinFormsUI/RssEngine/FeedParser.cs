using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using RssDialogys.Domain.Entities;
using RssDialogys.Domain.Concrete;

namespace RssDialogys.WinFormsUI.RssEngine
{
    public class FeedParser
    {

        public IList<Item> Parse(string category,string url)
        {        
            return ReadFeed(category,url);           
        }  
       
        //po 3 dniach udalo sie pobiera wszystko czego potrzeba 
        public List<Item> ReadFeed(string category,string rss)
        {
            //zle zabezpieczenie , tzn robione na szybko gdyż kompletnie nie mam czasu na ten projekcik
            try
            {
                XDocument doc = XDocument.Load(rss);
                NlogEngine.logger.Trace("RssDialogys.WinFormsUI.RssEngine.ReadFeed category{0} rss{1}", category, rss);
                return (from i in doc.Descendants("channel").Elements("item")
                        select GetItemFromXmlElement(category, i)).ToList()
                ;
            }
            catch (Exception)
            {

                MessageBox.Show(@"Usterka", @"Brak polączenia z internetem lub kanał rss nie jest dostepny");
                NlogEngine.logger.Fatal("RssDialogys.WinFormsUI.RssEngine.ReadFeed category{0} rss{1}", category, rss);
                //moge zwrócić pustą listę bo i tak weryfikacja danych jest w feedDataRepository
                return new List<Item>();
            }
            
        }
        public Item GetItemFromXmlElement(string category,XElement pElement)
        {
            try
            {
                Item item = new Item
                {
                    Title = pElement.Element("title").Value,
                    Link = pElement.Element("link").Value,
                    Content = pElement.Element("description").Value,
                    PublishDate = ParseDate(pElement.Element("pubDate").Value),
                    Category = category               
                };
                var element = pElement.Element("enclosure");
                if (element != null)
                {
                    foreach (var xAttribute in element.Attributes())
                    {
                        if (xAttribute.Name == "url")
                        {
                            item.Href = xAttribute.Value;
                            break;
                        }
                    }
                }
                string toRegex = item.Content;
                //w lini ponizej tkwi najwiekszy problem calej aplikacji 
                //mianowicie czasami tekt ktory formatuje zawiera takie cos &#34 lub #34 lub #38 i nie wiem w jaki sposob usuwac to regexem
                //wsparcie stron : 
                //http://msdn.microsoft.com/en-us/library/vstudio/ae5bf541(v=vs.100).aspx
                //http://manual.macromates.com/en/regular_expressions
                item.Content = Regex.Replace(toRegex, "<.*?>", "");
                NlogEngine.logger.Trace("RssDialogys.WinFormsUI.RssEngine.ReadFeed category{0}", category);
                return item;
            }
            catch 
            {
                NlogEngine.logger.Fatal("RssDialogys.WinFormsUI.RssEngine.ReadFeed category{0}", category);
                return new Item();
            }
            
        }
        //nie uzywana juz 
        public List<Item> Parser(string url)
        {
            var webClient = new WebClient();
            string result = webClient.DownloadString(url);
            XDocument document = XDocument.Parse(result);
            var entities = from descedant in document.Descendants("item")
                           select new Item
                           {
                               Content = descedant.Element("description").Value,
                               Link = descedant.Element("link").Value,
                               PublishDate = ParseDate(descedant.Element("pubDate").Value),
                               Title = descedant.Element("title").Value,
                               //Href = descedant.Attribute()
                           };
            return entities.ToList();
        }

        //nie uzywana juz 
        public virtual IList<Item> ParseAtom(string url)
        {
            try
            {
                XDocument doc = XDocument.Load(url);
                var entries = from item in doc.Root.Elements().Where(i => i.Name.LocalName == "entry")
                              select new Item
                              {
                                  // FeedType = FeedType.Atom,
                                  Content = item.Elements().First(i => i.Name.LocalName == "content").Value,
                                  Link = item.Elements().First(i => i.Name.LocalName == "link").Attribute("href").Value,
                                  PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "published").Value),
                                  Title = item.Elements().First(i => i.Name.LocalName == "title").Value
                              };
                return entries.ToList();
            }
            catch
            {
                return new List<Item>();
            }
        }

        //nie uzywana juz 
        public virtual IList<Item> ParseRss(string url)
        {
            try
            {
                XDocument doc = XDocument.Load(url);
                var entries = from item in doc.Root.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item")
                              select new Item
                              {
                                  //FeedType = FeedType.RSS,
                                  Content = item.Elements().First(i => i.Name.LocalName == "description").Value,
                                  Link = item.Elements().First(i => i.Name.LocalName == "link").Value,
                                  PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "pubDate").Value),
                                  Title = item.Elements().First(i => i.Name.LocalName == "title").Value,
                                  //kurwa ale tutaj jest problem o ja pierdole ciekawe jak ja to rozwiaze juz jest sroda ... 
                                  Href = item.Element("enclosure").Value

                              };
                //to powinno zalatwic problem z gownem zamiast treści 
                //foreach (var entry in entries)
                //{
                //    entry.Content.Replace("<.+?>", string.Empty);
                //}
                return entries.ToList();
            }
            catch
            {
                return new List<Item>();
            }
        }

        //nie uzywana juz 
        public virtual IList<Item> ParseRdf(string url)
        {
            try
            {
                XDocument doc = XDocument.Load(url);
                var entries = from item in doc.Root.Descendants().Where(i => i.Name.LocalName == "item")
                              select new Item
                              {
                                  //FeedType = FeedType.RDF,
                                  Content = item.Elements().First(i => i.Name.LocalName == "description").Value,
                                  Link = item.Elements().First(i => i.Name.LocalName == "link").Value,
                                  PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "date").Value),
                                  Title = item.Elements().First(i => i.Name.LocalName == "title").Value
                              };
                return entries.ToList();
            }
            catch
            {
                return new List<Item>();
            }
        }

        private DateTime ParseDate(string date)
        {
            DateTime result;
            if (DateTime.TryParse(date, out result))
                return result;
            else
                return DateTime.MinValue;
        }
    }
}


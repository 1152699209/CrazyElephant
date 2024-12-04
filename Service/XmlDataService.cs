using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CrazyElephant.Model;

namespace CrazyElephant.Service
{
    internal class XmlDataService : IXmlDataService
    {
        public List<Dish> GetAllDishes()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"E:\VS CSharp Project\CrazyElephant\Data\Data.xml");
            XmlNode root=xmlDocument.DocumentElement;
            List<Dish> allDishes = new List<Dish>();
            foreach (XmlNode node1 in root.ChildNodes)
            {
                if(node1.Name == "Dish")
                {
                    Dish dish = new Dish();
                    foreach (XmlNode node2 in node1.ChildNodes)
                    {
                            switch (node2.Name)
                            {
                                case "Name":
                                    dish.Name = node2.InnerText;
                                    break;
                                case "Category":
                                    dish.Category = node2.InnerText;
                                    break;
                                case "Score":
                                    dish.Score = Convert.ToDouble(node2.InnerText);
                                    break;
                                case "Comment":
                                    dish.Comment = node2.InnerText;
                                    break;
                            }
                    }
                    allDishes.Add(dish);

                }
                
            }
            return allDishes;
        }
    }
}

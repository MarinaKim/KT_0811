using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KT_0811
{
    class Program
    {
        static Entity bd = new Entity();
        static void Main(string[] args)
        {

            EX09();

        }

        static void EX01()
        {
            int[] s1 = { 1, 2, 3, 4 };
            int[] s2 = { 5, 6, 7, 8 };
            // concat

            //Intersect


            //Except
            var resultExcept = s1.Except(s2);
            foreach (var item in resultExcept)
            {
                Console.WriteLine(item);

            }
        }

        static void EX02()
        {
            object[] s2 = { 5, 6, 7, 8, 1, 2 };


            //cast
            try
            {
                var resultCast = s2.Cast<int>();
                if (resultCast != null)
                {
                    foreach (var item in resultCast)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("EX: " + ex.Message);
            }

            //ofType
            var resultOfType = s2.OfType<int>();
            foreach (var item in resultOfType)
            {
                Console.WriteLine(item);
            }

            var result = s2.Select(s => (int)s);

            //toarray
            //tolist

            //toDictionary
            Dictionary<int, string> resultDic = bd.Area.ToDictionary(k => k.AreaId, v => v.Name);

            //tolookup
            ILookup<int, string> resultLookup = bd.Area.ToLookup(k => k.AreaId, v => v.IP);

            //asEnumerable
            var res = s2.AsEnumerable();

            //asQuerable
            var res1 = bd.Area.AsQueryable<Area>();
        }

        static void EX03()
        {
            //first
            //firstOrDefault
            var q = bd.Area.First(f => f.FullName.Contains("Area"));
            var q1 = bd.Area.FirstOrDefault(f => f.FullName.Contains("Area"));

            //Last
            //lastOrDefault
            var q2 = bd.Area.Last(f => f.FullName.Contains("Area"));
            var q3 = bd.Area.LastOrDefault(f => f.FullName.Contains("Area"));

            //Singl
            //singlOrDeafault
            var q4 = bd.Area.Single(f => f.FullName.Contains("Area"));
            var q5 = bd.Area.SingleOrDefault(f => f.FullName.Contains("Area"));

            //ElementAt - возвращение по индексу? не работае с SQL
            //ElementAtOrDeafult
            var q6 = bd.Area
                .ToList() //fromSQL
                .ElementAt(4);
        }

        static void EX04()
        {
            //count

            int count = bd.Area.Count();

            //LongCount
            //Min,Max
            int min = bd.Area.
                Where(w=>w.WorkingPeople!=null).
                Min(m => (int)m.WorkingPeople);// только одно условие

            int sum = bd.Area
                .Where(w => w.WorkingPeople != null)
                .Sum(m => (int)m.WorkingPeople);
            //Sum Average
        }

        static void EX05()
        {
            //contains
            List<int> areas = new List<int> { 22, 23 };

            var result=bd.Area.Where(w => areas.Contains(w.AreaId));


            var result2 = bd.Area.ToList().Select(s => s.AreaId);

            result = bd.Area.Where(w => !result2.Contains(w.AreaId));
            
            //any
            bool res = bd.Area.Any(a => a.WorkingPeople > 2);

            //all
            var res2 = bd.Area.All(a => a.WorkingPeople == 2);

            //sequence, equal
            var res3 = result.Equals(result2);

            //SEQUENCEeQUAL
            //var res4 = result.SequenceEqual(result2);

        }

        static void EX06()
        {
            foreach (Area area in bd.Area.Where(w=>w.PavilionId==1))
            {
                /* <Area>
                 <Name>dgjh</Name>
                 </Area>*/
                XElement areaElement = new XElement("Area",
                                                    new XAttribute( "AreaID",area.AreaId),  
                                                    new XElement("Name", area.Name));

                areaElement.Save(area.PavilionId + "/" + area.AreaId + ".xml");
            }
        }
        //создать элемент на основе select
        static void EX07()
        {
            XDocument doc2 = XDocument.Load("Area001,xml"); //загрузка XML документа
            XDocument doc3 = XDocument.Parse("<test></test>");//получить значение из определенной строки

            XDocument doc = new XDocument(
                new XElement("Areas",
                bd.Area.ToList()
                .Select(s =>
                new XElement("Area", new XElement
                ("Name", new XComment("testcomment"), s.Name)))
                ));
            doc.Save("Area001,xml");
            Console.WriteLine(doc.ToString());
        }

        static void EX08()
        {
            XDocument doc = XDocument.Load("https://habr.com/rss/hubs/all/");

            XElement el = doc
                .Element("rss")
                .Element("channel")
                .Element("title");

            Console.WriteLine(doc.ToString());

            //foreach (XElement item in doc
            //    .Element("rss")
            //    .Element("channel")
            //    .Elements("item"))
            //{
            //    Console.WriteLine(item.ToString());
            //}
        }
        static XDocument root;
        static void EX09()
        {
          root = new XDocument( new XElement("Names",
                new XElement("Name", "Yevgen")));

            Console.WriteLine(root);

            addName(new XElement("Name", Console.ReadLine()));

            Console.WriteLine(root);

           root.Element("Names")
                .Elements("Name")
                .FirstOrDefault(f => f.Value == "Yevgen");

            Console.WriteLine(root);
        }

        static void addName(XElement newName)
        {
            root.Element("Names").Add(newName);
        }


        
    }
}

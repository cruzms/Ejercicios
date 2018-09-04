using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static Problema2.Models;

namespace Problema2
{
    class Program
    {
        static void Main(string[] args)
        {
            string archivo = @"C:\Users\Santiago\Desktop\Markets - QA.xml";
            Console.WriteLine("Aerolinea: ");
            var aerolinea = Console.ReadLine();
            Console.WriteLine("Origen: ");
            var origen = Console.ReadLine();
            Console.WriteLine("Destino :");
            var destino = Console.ReadLine();
            Console.WriteLine("Fecha:");
            var fecha = Console.ReadLine();
            //DateTime fechafinal = DateTime.Parse(fecha);
            XmlSerializer serializer = new XmlSerializer(typeof(AirlineMarkets));
            StreamReader reader = new StreamReader(archivo);
            AirlineMarkets airlineMarkets = (AirlineMarkets)serializer.Deserialize(reader);
            if (airlineMarkets.AirlineMarket.Airline == aerolinea)
            {
                var respuesta = airlineMarkets.AirlineMarket.Markets.Market.Where(m => m.OriginCode == origen &&
                                m.DestinationCode == destino && DateTime.Parse(m.Date).ToString("dd/MM/yyy") == fecha).ToList();
                if (respuesta.Count != 0)
                {


                    Console.WriteLine("Formato de salida: \n 1. XML \n 2. JSON \n 3. Plano");
                    var opcion = Console.ReadLine();

                    using (var db = new ModelContext())
                    {
                        foreach (var item in respuesta)
                        {
                            item.Aerolinea = aerolinea;
                            db.Markets.Add(item);
                            db.SaveChanges();

                            if (opcion == "1")
                            {
                                XmlSerializer xsSubmit = new XmlSerializer(typeof(Market));
                                var subReq = new Market();
                                var xml = "";

                                using (var sww = new StringWriter())
                                {
                                    using (XmlWriter writer = XmlWriter.Create(sww))
                                    {
                                        xsSubmit.Serialize(writer, subReq);
                                        xml = sww.ToString(); // Your XML
                                        Console.WriteLine(xml);
                                    }
                                }
                            }
                            else if (opcion == "2")
                            {
                                var o = JsonConvert.SerializeObject(item);
                                Console.WriteLine(o);
                            }
                            else
                            {
                                Console.WriteLine(item.ToString());
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No hay coincidencias");
                }
            }
            else
            {
                Console.WriteLine("No hay coincidencias");
            }
            Console.ReadKey();
        }
    }


}

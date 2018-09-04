using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Problema2
{
    public class Models
    {
        public class ModelContext : DbContext
        {
            public DbSet<Market> Markets { get; set; }

        }

        [XmlRoot(ElementName = "Market")]
        public class Market
        {
            public int Id { get; set; }
            public string Aerolinea { get; set; }
            [XmlElement(ElementName = "Date")]
            public string Date { get; set; }
            [XmlElement(ElementName = "OriginCode")]
            public string OriginCode { get; set; }
            [XmlElement(ElementName = "DestinationCode")]
            public string DestinationCode { get; set; }
            [XmlElement(ElementName = "OriginName")]
            public string OriginName { get; set; }
            [XmlElement(ElementName = "DestinationName")]
            public string DestinationName { get; set; }

            public override string ToString()
            {
                return String.Format("Fecha: {0}, Origen: {1}, Destino: {2}, Nombre Origen: {3}, Nombre Destino: {4}",Date,OriginCode, DestinationCode, OriginName, DestinationName);
            }
        }

        [XmlRoot(ElementName = "Markets")]
        public class Markets
        {
            [XmlElement(ElementName = "Market")]
            public List<Market> Market { get; set; }
        }

        [XmlRoot(ElementName = "AirlineMarket")]
        public class AirlineMarket
        {
            [XmlElement(ElementName = "Airline")]
            public string Airline { get; set; }
            [XmlElement(ElementName = "Currency")]
            public string Currency { get; set; }
            [XmlElement(ElementName = "Aircraft")]
            public string Aircraft { get; set; }
            [XmlElement(ElementName = "Markets")]
            public Markets Markets { get; set; }
        }

        [XmlRoot(ElementName = "AirlineMarkets")]
        public class AirlineMarkets
        {
            [XmlElement(ElementName = "AirlineMarket")]
            public AirlineMarket AirlineMarket { get; set; }
        }
    }
}

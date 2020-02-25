using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RobotXMLParser
{
    public class TotalStats
    {
        public TotalStats()
        {

        }

        [XmlElement(ElementName = "stat")]
        public List<StatDetails> statDetail { get; set; }
    }
}

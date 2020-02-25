using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RobotXMLParser
{
    [XmlRoot(ElementName="robot")]
    public class Robot
    {
        public Robot()
        {

        }

        [XmlAttribute(AttributeName = "generated")]
        public string Generated { get; set; }

        [XmlAttribute(AttributeName = "generator")]
        public string Generator{ get; set; }

        [XmlElement(ElementName = "suite")]
        //public TestSuite[] Suite { get; set; }
        public List<TestSuite> Suite { get; set; }
        
        [XmlElement(ElementName="statistics")]
        public Statistics statistics{ get; set; }

    }
}

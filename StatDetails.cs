using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RobotXMLParser
{
    public class StatDetails
    {
        public StatDetails()
        {

        }

        [XmlAttribute(AttributeName="fail")]
        public string fail{ get; set; }

        [XmlAttribute(AttributeName = "pass")]
        public string pass { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }

        [XmlText]
        public string text { get; set; }
    }
}

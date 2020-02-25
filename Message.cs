using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RobotXMLParser
{
    public class Message
    {
        public Message()
        {
                
        }

        [XmlAttribute(AttributeName="level")]
        public string Level{ get; set; }

        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }

        [XmlText]
        public string LogVal { get; set; }
    }
}

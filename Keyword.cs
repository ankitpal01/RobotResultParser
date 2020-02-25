using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RobotXMLParser
{
    public class Keyword
    {
        public Keyword()
        {

        }

        [XmlAttribute(AttributeName="name")]
        public string Name{ get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName="kw")]
        //public Keyword[] Keywords{ get; set; }
        public List<Keyword> Keywords { get; set; }

        [XmlElement(ElementName="arguments")]
        //public Argument[] Arguments { get; set; }
        public List<Argument> Arguments { get; set; }

        [XmlElement(ElementName = "status")]
        //public ResultStatus[] Status { get; set; }
        public List<ResultStatus> Status { get; set; }

        [XmlElement(ElementName="msg")]
        //public Message[] Msg { get; set; }
        public List<Message> Msg { get; set; }

        

    }
}

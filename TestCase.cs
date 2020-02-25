using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RobotXMLParser
{
    public class TestCase
    {
        public TestCase()
        {

        }

        [XmlAttribute(AttributeName="id")]
        public string Id{ get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName="kw")]
        //public Keyword[] KeywordName{ get; set; }
        public List<Keyword> KeywordName { get; set; }

        [XmlElement(ElementName = "status")]
        //public ResultStatus[] Status { get; set; }
        public List<ResultStatus> Status { get; set; }
    }
}

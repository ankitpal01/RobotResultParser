using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RobotXMLParser
{
    public class TestSuite
    {
        public TestSuite()
        {

        }

        [XmlAttribute(AttributeName = "source")]
        public string Source{ get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "suite")]
        //public TestSuite[] TestSuites { get; set; }
        public List<TestSuite> TestSuites { get; set; }

        [XmlElement(ElementName= "test")]
        //public TestCase[] TestCases { get; set; }
        public List<TestCase> TestCases { get; set; }

        [XmlElement(ElementName = "status")]
        //public ResultStatus[] Status { get; set; }
        public List<ResultStatus> Status { get; set; }

    }
}

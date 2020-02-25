using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RobotXMLParser
{
    public class ResultStatus
    {
        public ResultStatus()
        {

        }

        [XmlAttribute(AttributeName="status")]
        public string Status { get; set; }

        [XmlAttribute(AttributeName = "endtime")]
        public string Endtime { get; set; }

        [XmlAttribute(AttributeName = "starttime")]
        public string Starttime { get; set; }

        [XmlAttribute(AttributeName = "critical")]
        public string Critical { get; set; }

        
    }
}

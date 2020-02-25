using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RobotXMLParser
{
    public class Statistics
    {
        public Statistics()
        {

        }

        [XmlElement(ElementName="total")]
        public TotalStats totalStat{ get; set; }

        [XmlElement(ElementName = "suite")]
        public SuiteStats suiteStat { get; set; }



    }
}

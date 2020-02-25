using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RobotXMLParser
{
    public class Arg
    {
        public Arg()
        {
                
        }

        [XmlText]
        public string ArgVal { get; set; }
    }
}

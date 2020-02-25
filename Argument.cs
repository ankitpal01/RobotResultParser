using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RobotXMLParser
{
    public class Argument
    {
        public Argument()
        {
                
        }

        [XmlElement(ElementName="arg")]
        //public Arg[] Args { get; set; }
        public List<Arg> Args { get; set; }
    }
}

/*
 * Created by SharpDevelop.
 * User: ankit.pal
 * Date: 6/22/2015
 * Time: 11:23 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace RobotXMLParser
{
	class Program
    {
        
        //static string xmlFilePath = @"C:\Users\Ankit\AppData\Local\Temp\RIDErqsay1.d";
        static string MyXmlFile;
        static string XMLconfigPath;
        
        public Program()
        {
            //Console.WriteLine(ConfigurationManager.AppSettings.Get("inputFilePath"));
            //Console.WriteLine(ConfigurationManager.AppSettings.Get("OutputFilePath"));
            //XMLconfigPath = AppDomain.CurrentDomain.BaseDirectory;
            XMLconfigPath = @"C:\Users\ankit.pal\Desktop\1";
            MyXmlFile = XMLconfigPath+"\\output.xml";
            
        }

        static void Main(string[] args)
        {
            //xmlFilePath = (AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Program oProg = new Program();
            var orobot = oProg.Deserialized();
            oProg.ProcessRoboXml(orobot);
            oProg.Serialized(orobot);

            string strCmdText;
            string timeStamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            strCmdText = "/C rebot --log " + XMLconfigPath + "\\" + timeStamp + "_LOG.html --report " + XMLconfigPath + "\\" + timeStamp + "_REPORT.html " + XMLconfigPath + "\\ParsedRobotXML.xml";
            //strCmdText = "/C rebot --log " + XMLconfigPath + "\\Log.html --report " + XMLconfigPath + "\\Report.html " + XMLconfigPath + "\\ParsedRobotXML.xml";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);

        }

        public Robot Deserialized()
        {
            var serializer = new XmlSerializer(typeof(Robot));
            var fileStream = new FileStream(MyXmlFile, FileMode.Open);
            //var fileStream = new FileStream(xmlFilePath+@"\output.xml", FileMode.Open);
            var result = (Robot)serializer.Deserialize(fileStream);
            return result;
        }

        public void Serialized(Robot oRobot)
        {
            
            var serializer = new XmlSerializer(typeof(Robot));
            var obj = File.Create(XMLconfigPath + "\\ParsedRobotXML.xml");
            //var obj = File.Create(xmlFilePath + @"\RobotXMLParser.xml");
            serializer.Serialize(obj, oRobot);
            obj.Flush();
        }

        public void ProcessRoboXml(Robot oRobot)
        {
            for (int i = 0; i < oRobot.Suite.Count; i++)
            {
                ProcessTestSuite(oRobot.Suite[i]);
            }
        }

        public void ProcessTestSuite(TestSuite oTestSuite)
        {
            for (int i = 0; i < oTestSuite.TestSuites.Count; i++)
            {
                ProcessTestSuite(oTestSuite.TestSuites[i]);
               
            }
            for (int j = 0; j < oTestSuite.TestCases.Count;j++)
            {
                ProcessTestCase(oTestSuite.TestCases[j]);

            }
            
            
        }
		List<Keyword> logKeywords;
        public void ProcessTestCase(TestCase oTestCase)
        {
            bool LogFlagFalse = false;
            for (int i = 0; i < oTestCase.KeywordName.Count; i++)
            {
                //LogFlagFalse = ProcessKeyWord(oTestCase.KeywordName[i]);
                LogFlagFalse = PreProcessKeyWord(oTestCase.KeywordName[i]);
                if (LogFlagFalse)
                {
                    oTestCase.KeywordName.RemoveAt(i);
                    i--;
                }
            }

        }
        
        bool isLogItem = false;

        public bool ProcessKeyWord(Keyword oKeyword)
        {
        	bool flag = false;
        	for (int i = 0; i < oKeyword.Keywords.Count; i++)
            {
        		if(oKeyword.Keywords[i].Keywords.Count>0)
        		{
        			isLogItem=false;
        			flag = ProcessKeyWord(oKeyword.Keywords[i]);
        			if(!flag)
        			{
        				i--;
//        				isLogItem = false;
        			}
//        			else
//        			{
//        				isLogItem=false;
//        			}
        		}
        		else if((oKeyword.Keywords[i].Keywords.Count==0)&&!(oKeyword.Keywords[i].Name.ToLower().Equals("builtin.log")))
        		{
        			if(oKeyword.Keywords[i].Status[0].Status.Equals("PASS"))
                	{
	        			oKeyword.Keywords.RemoveAt(i);
	        			i--;
        			}

        		}
        		else if(oKeyword.Keywords[i].Name.ToLower().Equals("builtin.log"))
        		{
        			isLogItem=true;
        		}
            }
        	

        	
            return isLogItem;
            
        }
        
        public bool PreProcessKeyWord(Keyword oKeyword)
        {
        	bool isLog=false;
        	if (oKeyword.Keywords.Count == 0) 
            {
                if (oKeyword.Name.ToLower().Equals("builtin.log"))
                {
                    return false;
                }
                if(oKeyword.Status[0].Status.Equals("PASS"))
                {
                    return true;
                }
            }
        	else
        	{
        		isLog = ProcessKeyWord(oKeyword);
        		
        	}
        	return isLog;
            
        }
        
        

    }

}
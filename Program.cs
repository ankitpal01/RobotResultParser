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
        
        static string MyXmlFile;
        static string XMLconfigPath;
        
        public Program()
        {
            //Console.WriteLine(ConfigurationManager.AppSettings.Get("inputFilePath"));
            //Console.WriteLine(ConfigurationManager.AppSettings.Get("OutputFilePath"));
            //XMLconfigPath = AppDomain.CurrentDomain.BaseDirectory;
            //XMLconfigPath = @"C:\Users\ankit.pal\Desktop\1";
            //MyXmlFile = XMLconfigPath+"\\output.xml";
            
        }

//      Warning codes:
//				101: Args are sent as null
        
        static void Main(string[] args)
        {
        	 Program oProg = new Program();
        	if (args.Length == 0) 
        	{
                Console.WriteLine("Warning Code : 101");
				XMLconfigPath = AppDomain.CurrentDomain.BaseDirectory;
				if (!XMLconfigPath.EndsWith(@"\")) 
				{
					XMLconfigPath += @"\";	
				}
				MyXmlFile = XMLconfigPath+"output.xml";
        	}
        	else
        	{
        		
	        	for (int i = 0; i < args.Length; i+=2) 
	        	{
	        		if(args[i].ToLower().Equals("--path"))
	        		{
	        			XMLconfigPath = args[i+1];
	        		}
	        	}

// #####START #### below code block is for handling the parameters which contain the path having space and not enquoted in ""
//	        	string str = "";
//                for (int i = 0; i < args.Length; i++)
//                {
//                    str += args[i] + " ";
//                    
//               }
//                str = str.TrimEnd(' ');
//                XMLconfigPath = str.Substring(7);
// #####END #### below code block is for handling the parameters which contain the path having space and not enquoted in ""

//				XMLconfigPath = @"C:\Users\ankit.pal\Desktop\1";
				if (!XMLconfigPath.EndsWith(@"\")) 
				{
					XMLconfigPath += @"\";	
				}
				MyXmlFile = XMLconfigPath+@"output.xml";
        	}
            Console.WriteLine("Running the exe from => "+AppDomain.CurrentDomain.BaseDirectory);
           
            try {
            	var orobot = oProg.Deserialized();
				oProg.ProcessRoboXml(orobot);
            	oProg.Serialized(orobot);            	
            } catch (Exception e) {
            	
            	Console.WriteLine(e.Message);
            	Console.WriteLine("\n==========> GUIDELINE: <========== \n1. Please check if the output.xml is at the path given in the arguments. \n2. if no path was given as the argument then the output.xml should be in the same directory as this RobotXMLParser.exe");
            	Console.ReadLine();
            }
            
            

            string strCmdText;
            string timeStamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            strCmdText = "/C rebot --log " + "\"" + XMLconfigPath +  timeStamp + "_LOG.html" + "\"" + " --report " + "\"" + XMLconfigPath + timeStamp + "_REPORT.html" + "\" " + "\"" + XMLconfigPath + "ParsedRobotXML.xml"+"\"";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            
            

        }

        public Robot Deserialized()
        {
        	
			var serializer = new XmlSerializer(typeof(Robot));
			var fileStream = new FileStream(MyXmlFile, FileMode.Open);
			var result = (Robot)serializer.Deserialize(fileStream);
			return result;

        }

        public void Serialized(Robot oRobot)
        {
            
            var serializer = new XmlSerializer(typeof(Robot));
            var obj = File.Create(XMLconfigPath + "\\ParsedRobotXML.xml");
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
        	
        	logKeywords = new List<Keyword>();
        	for (int i = 0; i < oTestCase.KeywordName.Count; i++) 
        	{
        		bool delete = false;
        		delete = ProcessKeywords(oTestCase.KeywordName[i]);
        		if(!delete)
        		{
        			oTestCase.KeywordName.RemoveAt(i);
        			i--;
        		}
        	}

        }
        
        
        public bool ProcessKeywords(Keyword okeyword)
        {
        	bool flag=false;
        	bool isLogPresent = false;
        	for (int i = 0; i < okeyword.Keywords.Count; i++) 
        	{
        	
        		isLogPresent = ProcessKeywords(okeyword.Keywords[i]);
        		if(isLogPresent)
        		{
        			
        			flag = true;
        		}
        		else
        		{
        			okeyword.Keywords.RemoveAt(i);
        			i--;
        			
        		}
        		
        	}

            //if(okeyword.Name.ToLower().Equals("builtin.log") && okeyword.Keywords.Count == 0)
            if (okeyword.Name.ToLower().Equals("log") && okeyword.Keywords.Count == 0)
            {
         		isLogPresent = true;
         	}
         	if(okeyword.Status[0].Status.ToLower().Equals("fail"))
         	{
         		isLogPresent = true;
         	}
         	if (flag) 
         	{
         		isLogPresent = true;
         	}
        	
        	
        	return isLogPresent;
        }

    }

}
# RobotResultParser
RobotFramework output.xml parser to generate clean and only desired log traces. 

# What issue does this utility solves?
Sometimes it’s really hard to go through the RobotFramework logs and find out the meaningful traces to debug our test cases, Reason being RobotFramework logs every single step and we generally are not interested in every step but only a few specific ones.
To overcome this, I build this utility which allows you to extract only those informative log traces in very simple and quick steps.

# Pre-requisites:
Other than your robotframework setup you would need the Microsoft .Net framework runtime  

# A quick demo reference:
Just to demonstrate the difference please refer the below given screenshots:

Rebot: log.html : Below given is the screenshot from the default RF reporting engine(rebot) which have log traces of every single steps. However, we might be interested only in the highlighted(in yellow) info.
 ![Screenshot](img_orig.png)
 
RobotParser: 20150709-113747_LOG.html : Below given is the screenshot from the RobotXMLParser logs which have the only informative log traces and have removed all the unnecessary keywords & their details.
 ![Screenshot](img_parsed.png)
 
# Usage:
It is a console application and can be used in following two ways:

<b>1. By Double Clicking:</b> you can place the exe at the same location as your output.xml file and simply double click to run it. It should produce the Report and Log file with timestamp at the same location.

<b>2. By Command line:</b> If you wish to run it from a separate location (different than your output.xml file location) which could be the case if we are calling it from Jenkins or any other app. You need to pass the path of the xml as an argument and that should be it.

Eg: if your output.xml is at the location “D:\RF_Results”

You will need to call the exe along with argument <i>--path path_of_the_output.xml</i> file as shown below:
  
<b>RobotXMLParser.exe --path "D:\RF_Results"</b>
  
# Downloading the utility:
In order to get this utility, go to <i>RobotResultParser/Publish/</i> in this repository and download the <i>RobotXMLParser.exe</i> and you are all set to use it.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using System.Collections.Generic

namespace Framework.Selenium {

public static class Driver {

//this section includes chrome driver setup implementation
[ThreadStatic]
public static IWebDriver _driver;

//Wait 
 [ThreadStatic]
        public static Wait Wait; 


public static void init () {
    
    _driver = DriverFactory.Build(Base.Config.Driver.Browser);
     Wait = new Wait(10);
}

//Page Title property
public static string Title => current.Title;

public static IWebDriver current => _driver ?? throw new NullReferenceException ("_driver is null");


//this section includes navigation to web urls implementation
public static void GotoTestEnv (String urltest) {
    //to print the url before invoke
    Base.Log.info(urltest);
    current.Navigate().GoToUrl(urltest);
}

public static void GotoStagingEnv (String urlstaging) {
    //to print the url before invoke
    Base.Log.info(urlstaging);
    current.Navigate().GoToUrl(urlstaging);
}


//screenshot implementation

 public static void TakeScreenshot(string imageName)
        {
            var ss = ((ITakesScreenshot)current).GetScreenshot();
            var ssFileName = Path.Combine(Base.CurrentTestDirectory.FullName, imageName);
            ss.SaveAsFile($"{ssFileName}.png", ScreenshotImageFormat.Png);
        }


public static void Quit()
        {
            Base.Log.info("Browser Closed");
            current.Quit();
            current.Dispose();
        }


//this section includes find elements implementation

public static Elements FindElement(By by, string elementName)
{
    return new Elements(current.FindElement(by),elementName) {
        FoundBy = by
    };
}

public static IList<IWebElement> FindElements(By by)
{
    return Driver.current.FindElements(by);
}


}
}
using System;
using System.IO;
using Framework;
using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestSystem.Pages;

namespace TestSystem.Tests
{
    public class TestsOne : TestBase
    {

        [Test]
        public void Test1(){
    
    var pagetwo = new PageTwo (); 

    //var Pageon = PagesWrapper.PageOne.
    pagetwo.Goto().PageOne.NavigatetoIndustriesPage ();

    // Assertion
    var knowledge= Driver.current.FindElement(By.CssSelector("a[href*='text']"));
    Assert.Fail();
    Assert.That(knowledge.Displayed);
    Assert.That(Driver.Title, Is.EqualTo("Provide the Webpage title here"));
}

static string[] PageNames = {" PageOne", "PageTwo"};

[Test,Category("PageChild")]
[TestCaseSource("PageNames")]
[Parallelizable(ParallelScope.Children)]
        public void Test2(){
        //click on navigation
    Driver.current.FindElement(By.CssSelector("a[href*='https://www.vsoftconsulting.com/knowledgebase/']"));
    // Assertion
    var knowledge= Driver.current.FindElement(By.CssSelector("a[href*='text']"));
    Assert.That(knowledge.Displayed);
}


    }
}
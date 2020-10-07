using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbnScrapper.Pages
{
   public class HomePage
    {
        public IWebDriver WebDriver { get; }
        public HomePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement ModalPopUp => WebDriver.FindElement(By.XPath("//button[@class='close']"));

        public IWebElement StatisticsLink => WebDriver.FindElement(By.XPath("//a[text()='STATISTICS']"));
        public IWebElement GovernmentSecDetailsLink => WebDriver.FindElement(By.LinkText("Government Securities  Details"));

        public void CloseModalPopUp() => ModalPopUp.Click();

        public void ClickStatisticsDropDown() => StatisticsLink.Click();

        public void NavigateToGovernmentSec() => GovernmentSecDetailsLink.Click();
    }
}

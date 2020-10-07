using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbnScrapper.Pages
{
    public class SecuritiesPage
    {
        public IWebDriver WebDriver { get; }
        public SecuritiesPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IEnumerable<IWebElement> GetAllSecurities => WebDriver.FindElements(By.XPath("//table[@id='mytables']/tbody/tr"));
    }
}

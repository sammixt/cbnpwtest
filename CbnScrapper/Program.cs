using CbnScrapper.Model;
using CbnScrapper.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CbnScrapper
{
    class Program
    {
        static IWebDriver WebDriver;
        static void Main(string[] args)
        {
            InputParams inputParams = new InputParams(args);
            //WebDriver = InitializeBrowser.UserChrome("https://www.cbn.gov.ng/", @"C:\Users\esc\source\repos\POS_Acquired\", false);
            WebDriver = InitializeBrowser.UserChrome(inputParams.URL, inputParams.DownloadPath, false);

            HomePage page = new HomePage(WebDriver);
            SecuritiesPage secPage = new SecuritiesPage(WebDriver);
            SaveToExcel save = new SaveToExcel();
            Thread.Sleep(4000);

            page.CloseModalPopUp();
            Thread.Sleep(1000);
            page.ClickStatisticsDropDown();
            Thread.Sleep(500);
            page.NavigateToGovernmentSec();
            Thread.Sleep(4000);
            var securities = secPage.GetAllSecurities;

            List<Properties> PropModel = new List<Properties>();

            if (securities.Any())
            {
                foreach(var item in securities)
                {
                    //var Name = item.FindElement(By.XPath("//td[@width='150']")).Text;
                    //var Details = item.FindElement(By.XPath("td[@width='200']")).Text;
                    PropModel.Add(new Properties
                    {
                        Name = item.FindElement(By.XPath("td[@width='150']")).Text,
                        Details = item.FindElement(By.XPath("td[@width='200']")).Text
                    });
                    
                }

                save.saveToExcel(PropModel, inputParams.DownloadPath);
                Console.WriteLine($"File Saved to {inputParams.DownloadPath}");
            }
            else
            {
                Console.WriteLine("No record found");
            }

            Console.WriteLine("Process Completed, Press any key to exist");
            Console.ReadKey();
           
        }
    }
}

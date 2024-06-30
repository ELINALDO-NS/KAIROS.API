using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace KAIROS.API
{
    public static class Kairos
    {
        public static ChromeDriver Login(string usuario, string senha, string url = "https://www.dimepkairos.com.br")
        {

            ChromeOptions options = new ChromeOptions();           
            //options.AddArgument("-headless");            
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            ChromeDriver Driver = new ChromeDriver(driverService,options);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
            var Usuario = Driver.FindElement(By.Id("LogOnModel_UserName"));
            Usuario.SendKeys(usuario);
            var Senha = Driver.FindElement(By.Id("LogOnModel_Password"));
            Senha.SendKeys(senha);
            var entrar = Driver.FindElement(By.Id("btnFormLogin"));
            entrar.Click();
            return Driver;
        }
    }
}

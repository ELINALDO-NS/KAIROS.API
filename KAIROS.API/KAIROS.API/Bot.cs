using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using KAIROS.API.Model;
using OpenQA.Selenium.Chrome;
using OfficeOpenXml;

namespace KAIROS.API
{
    public class Bot
    {
        public Boolean PessoaExiste(ChromeDriver chromeDriver)
        {

            Boolean existe = chromeDriver.FindElements(By.ClassName("funcionarioName")).Count() > 0;
            return existe;
        }

        public string ErroLancamento(ChromeDriver chromeDriver)
        {
            string existe = string.Empty;
            if (chromeDriver.FindElements(By.ClassName("field-validation-error-Popups")).Count() > 0)
            {
                existe = chromeDriver.FindElement(By.ClassName("field-validation-error-Popups")).Text;
                return existe;
            }
            else
            {
                return existe;
            }
        }


        public bool InsereSaldo(ChromeDriver bot , List<SaldoBH> saldoBHs,string Historico) 
        {
            using (bot)
            {

                TimeSpan t = new TimeSpan(10);
                WebDriverWait wait = new WebDriverWait(bot, t);
                // WebElement element = wait.Until(ExpectedConditions.elementToBeClickable(By.id("someid")));
                MessageBox.Show("Selecione a Empresa !");
                bot.FindElement(By.Id("Tab6")).Click();
                bot.FindElement(By.Id("userAutocomplete")).SendKeys("teste");
                bot.FindElement(By.Id("SearchButtonPessoa")).Click();


                foreach (var saldo in saldoBHs.ToList())
                {
                    int index = saldoBHs.FindIndex(x => x.Matricula == saldo.Matricula);
                    Thread.Sleep(2000);
                    bot.FindElement(By.Id("filterResumeMessagesButton")).Click();
                    bot.FindElement(By.Id("userAutocomplete")).SendKeys($"{saldo.Matricula}");
                    bot.FindElement(By.Id("SearchButtonPessoa")).Click();
                    bot.FindElement(By.XPath("//*/text()[normalize-space(.)='Lançamento de Banco de Horas']/parent::*")).Click();
                    if (PessoaExiste(bot))
                    {

                        bot.FindElement(By.ClassName("checkboxCustom")).Click();
                        bot.FindElement(By.Id("LancarBancoHoras")).Click();
                        Thread.Sleep(3000);
                        if (saldo.Posito_Negativo)
                        {
                            Thread.Sleep(3000);
                            bot.ExecuteScript($"document.getElementById('credito').value = '{saldo.Saldo}'");
                        }
                        else
                        {
                            Thread.Sleep(3000);
                            bot.ExecuteScript($"document.getElementById('debito').value = '{saldo.Saldo}'");
                        }
                        bot.FindElement(By.Id("dataLancarBancoHoras")).Clear();
                        // bot.FindElement(By.Id("dataLancarBancoHoras")).SendKeys($"{saldo.Data}");

                        bot.ExecuteScript($"document.getElementById('dataLancarBancoHoras').value = '{saldo.Data?.ToString().Replace("00:00:00","")}'");
                        bot.FindElement(By.Id("historico")).SendKeys(Historico);
                        bot.FindElement(By.Id("SaveLancarBancoHoras")).Click();
                        Thread.Sleep(3000);
                        if (!string.IsNullOrWhiteSpace(ErroLancamento(bot)))
                        {
                            Log.GravaLog($"Funcionario de Matricula: {saldo.Matricula} - " + ErroLancamento(bot));
                            Thread.Sleep(3000);
                            bot.FindElement(By.XPath("//button/span")).Click();
                            return true;
                            // bot.FindElement(By.ClassName("ui-button-icon-primary")).Click();
                        }
                      
                        

                    }
                    else
                    {                        
                        Log.GravaLog($"Funcionario de Matricula: {saldo.Matricula} não encontrado no KAIROS !");
                        return true;
                    }

                }

            }
            return false;
        }


    }
}

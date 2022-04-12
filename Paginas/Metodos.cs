using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PocCSharp.Paginas
{
    class Metodos
    {

        private static IWebDriver driver;
        private readonly IObjectContainer container;

        public Metodos(IObjectContainer container)
        {
            this.container = container;
        }

        /**
         * Abrir navegador e site
         *
         * @author Phelipe S Miranda
         *
         */
        public void AbrirNavegador(String site, String navegador, String descricaoPasso)
        {
            try
            {
                if (navegador == "chrome" || navegador == "gecko")
                {
                    if (navegador == "chrome")
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddUserProfilePreference("browser.cache.disk.enable", false);
                        options.AddUserProfilePreference("browser.cache.memory.enable", false);
                        options.AddUserProfilePreference("browser.cache.offline", false);
                        options.AddUserProfilePreference("network.http.use-cache", false);
                        //options.AddArgument("--headless");
                        driver = new ChromeDriver(options);
                        driver.Navigate().GoToUrl(site);
                        driver.Manage().Window.Maximize();
                    }
                    else if (navegador == "gecko")
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        options.SetPreference("browser.cache.disk.enable", false);
                        options.SetPreference("browser.cache.memory.enable", false);
                        options.SetPreference("browser.cache.offline.enable", false);
                        options.SetPreference("network.http.use-cache", false);
                        //options.AddArguments("--headless");
                        driver = new FirefoxDriver(options);
                        driver.Navigate().GoToUrl(site);
                        driver.Manage().Window.Maximize();
                    }
                }
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
         * Escrever
         *
         * @author Phelipe S Miranda
         *
         */
        public void Escrever(By elemento, String texto, String descricaoPasso)
        {
            try
            {
                driver.FindElement(elemento).SendKeys(texto);
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
         * Clicar
         *
         * @author Phelipe S Miranda
         *
         */
        public void Clicar(By elemento, String descricaoPasso)
        {
            try
            {
                driver.FindElement(elemento).Click();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
         * Submit
         *
         * @author Phelipe S Miranda
         *
         */
        public void Submit(By elemento, String descricaoPasso)
        {
            try
            {
                driver.FindElement(elemento).Submit();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
         * Print Screen Google
         *
         * @author Phelipe S Miranda
         *
         */
        public void PrintScreen(String nomePrint)
        {
            Directory.CreateDirectory(@".\evidencias\google\");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(@".\evidencias\google\" + nomePrint + ".png");
        }

        /**
        * Print Screen de Erros
        *
        * @author Phelipe S Miranda
        *
        */
        public void PrintScreenErros(String nomePrint)
        {
            Directory.CreateDirectory(@".\evidencias\erros\");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(@".\evidencias\erros\" + nomePrint + ".png");
        }

        /**
         * Fechar Navegador
         *
         * @author Phelipe S Miranda
         *
         */
        public void FecharNavegador(String descricaoPasso)
        {
            try
            {
                driver.Close();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }

        }

        /**
        * Pausa
        *
        * @author Phelipe S Miranda
        *
        */
        public void Pausa(int tempo, String descricaoPasso)
        {
            try
            {
                Thread.Sleep(tempo);
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
         * Validar Texto
         *
         * @author Phelipe S Miranda
         *
         */
        public void ValidarTexto(By elemento, String texto, String descricaoPasso)
        {
            try
            {
                String msg = driver.FindElement(elemento).Text;
                Assert.AreEqual(texto, msg);
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * Esperar Elementos
        *
        * @author Phelipe S Miranda
        *
        */
        public void EsperarElemento(By elemento, String descricaoPasso)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(elemento));
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * Pressionar tecla Enter
        *
        * @author Phelipe S Miranda
        *
        */

        public void TeclaEnter(String descricaoPasso)
        {
            try
            {
                Actions action = new Actions(driver);
                action.SendKeys(Keys.Enter).Perform();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * Super Click
        *
        * @author Phelipe S Miranda
        *
        */
        public void SuperClick(By elemento, String descricaoPasso)
        {
            try
            {
                SuperClick((By)driver.FindElement(elemento), descricaoPasso);
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * Duplo Click
        *
        * @author Phelipe S Miranda
        *
         */
        public void DuploCliqueNoElemento(By elemento, String descricaoPasso)
        {
            try
            {
                IWebElement action = driver.FindElement(elemento);
                Actions actionProvider = new Actions(driver);
                actionProvider.DoubleClick(action).Build().Perform();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * Selecionar Combo na Posicao
        *
        * @author Phelipe S Miranda
        *
        */
        public void SelecionarComboPosicao(By elemento, int posicao, String descricaoPasso)
        {
            try
            {
                IWebElement webElement = driver.FindElement(elemento);
                SelectElement combo = new SelectElement(webElement);
                combo.SelectByIndex(posicao);
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * Selecionar Combo no Texto
        *
        * @author Phelipe S Miranda
        *
        */
        public void SelecionarComboTexto(By elemento, String texto, String descricaoPasso)
        {
            try
            {
                IWebElement webElement = driver.FindElement(elemento);
                SelectElement combo = new SelectElement(webElement);
                combo.SelectByText(texto);
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * Validar Pagina
        *
        * @author Phelipe S Miranda
        *
        */
        public void ValidarPagina(String pagina, String descricaoPasso)
        {
            try
            {
                String pag = driver.Title;
                Assert.AreEqual(pagina, pag);
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * Esperar Alert na Tela
        *
        * @author Phelipe S Miranda
        *
        */
        public void EsperarAlert(int tempo, String descricaoPasso)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.AlertIsPresent());
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        public void SwitcPage()
        {
            driver.SwitchTo().Alert().Accept();
        }

        /**
        * Passar o Mouse no Elemento Sem Clicar
        *
        * @author Phelipe S Miranda
        *
        */
        public void passarMouse(By elemento, String descricaoPasso)
        {
            try
            {
                Actions action = new Actions(driver);
                IWebElement passarMouse = driver.FindElement(elemento);
                action.MoveToElement(passarMouse).Build().Perform();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * Clicar e segurar, mover e soltar com mouse
        *
        * @author Phelipe S Miranda
        *
        */
        public void MoverElemento(By elementoOrigem, By elementoDestino, String descricaoPasso)
        {
            try
            {
                Actions action = new Actions(driver);
                IWebElement origem = driver.FindElement(elementoOrigem);
                IWebElement destino = driver.FindElement(elementoDestino);
                action.DragAndDrop(origem, destino).Build().Perform();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * teclaPageUp
        *
        * @author Phelipe S Miranda
        *
        */
        public void TeclaPageUp(String descricaoPasso)
        {
            try
            {
                Actions action = new Actions(driver);
                action.SendKeys(Keys.PageUp).Perform();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * teclaPageUp
        *
        * @author Phelipe S Miranda
        *
        */
        public void TeclaPageDown(String descricaoPasso)
        {
            try
            {
                Actions action = new Actions(driver);
                action.SendKeys(Keys.PageDown).Perform();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * botaoVoltar
        *
        * @author Phelipe S Miranda
        *
        */
        public void BotaoVoltar(String descricaoPasso)
        {
            try
            {
                driver.Navigate().Back();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * botaoAtualizar
        *
        * @author Phelipe S Miranda
        *
        */
        public void BotaoAtualizar(String descricaoPasso)
        {
            try
            {
                driver.Navigate().Refresh();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * teclaBackSpace
        *
        * @author Phelipe S Miranda
        *
        */
        public void TeclaBackSpace(String descricaoPasso)
        {
            try
            {
                Actions action = new Actions(driver);
                action.SendKeys(Keys.Backspace).Perform();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * limparTexto
        *
        * @author Phelipe S Miranda
        *
        */
        public void LimparTexto(By elemento, String descricaoPasso)
        {
            try
            {
                driver.FindElement(elemento).Clear();
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }

        /**
        * limparTextoAlternativo
        *
        * @author Phelipe S Miranda
        *
        */
        public void LimparTextoAlternativo(By elemento, String descricaoPasso)
        {
            try
            {
                driver.FindElement(elemento).SendKeys(Keys.Control + "a");
                driver.FindElement(elemento).SendKeys(Keys.Delete);
            }
            catch (Exception)
            {
                PrintScreenErros("erro-ao-tentar----" + descricaoPasso);
                Assert.Fail("erro-ao-tentar----" + descricaoPasso);
            }
        }
    }
}

using BoDi;
using OpenQA.Selenium;

namespace PocCSharp.Elementos
{
    class ElementosWeb
    {

        private readonly IObjectContainer container;

        public ElementosWeb(IObjectContainer container)
        {
            this.container = container;
        }

        // Elementos privados

        private By pesquisa = By.Name("q");
        private By csharp = By.XPath("/html/body/div[7]/div/div[10]/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[2]/h2/span");

        //Elementos publicos

        public By Pesquisa { get => pesquisa; set => pesquisa = value; }
        public By Csharp { get => csharp; set => csharp = value; }

    }
}
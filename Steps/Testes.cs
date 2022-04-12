using PocCSharp.paginas;
using PocCSharp.Paginas;
using TechTalk.SpecFlow;

namespace PocCSharp.Steps
{
    [Binding]
    class Testes
    {

        private Metodos metodos;
        private Navegacoes nav;

        public Testes(Metodos metodos, Navegacoes nav)
        {
            this.metodos = metodos;
            this.nav = nav;
        }

        [Given(@"que eu acesso o site ""([^""]*)""")]
        public void DadoQueEuAcessoOSite(String site)
        {
            metodos.abrirNavegador(site, "chrome", "abro-navegador-e-o-site");
        }

        [When(@"que eu pesquise o site do google")]
        public void QuandoQueEuPesquiseOSiteDoGoogle()
        {
            nav.pesquisaGoogle("C#");
        }

        [When(@"valido o teste e tiro evidencias")]
        public void QuandoValidoOTesteETiroEvidencias()
        {
            nav.validacaoEvidencia("google", "C Sharp");
        }

        [Then(@"fecho o navegador")]
        public void EntaoFechoONavegador()
        {
            metodos.fecharNavegador("fecho-o-navegador");
        }
    }
}
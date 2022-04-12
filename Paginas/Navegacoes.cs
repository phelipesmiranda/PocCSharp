using PocCSharp.Elementos;
using PocCSharp.Paginas;

namespace PocCSharp.paginas
{
    class Navegacoes
    {
        private Metodos metodos;
        private ElementosWeb el;

        public Navegacoes(Metodos metodos, ElementosWeb el)
        {
            this.metodos = metodos;
            this.el = el;
        }

        public void pesquisaGoogle(string texto)
        {
            metodos.esperarElemento(el.Pesquisa, "espero-elemento-ficar-visivel");
            metodos.escrever(el.Pesquisa, texto, "faco-uma-pesquisa");
            metodos.teclaEnter("teclo-enter");
        }

        public void validacaoEvidencia(string nomePrint, string texto)
        {
            metodos.pausa(2000, "espero-2-segundos");
            metodos.printScreen(nomePrint);
            metodos.esperarElemento(el.Csharp, "espero-elemento-ficar-visivel");
            metodos.validarTexto(el.Csharp, texto, "valido-o-texto");
        }

    }
}

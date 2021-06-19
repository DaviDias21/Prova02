using System;
using System.Collections.Generic;
using System.Text;

namespace Prova02
{
    class Arvore
    {
        public NodoArvore Raiz { get; set; }

        public Arvore(string dadoRaiz_)
        {
            this.Raiz = new NodoArvore(dadoRaiz_);
        }
    }
}

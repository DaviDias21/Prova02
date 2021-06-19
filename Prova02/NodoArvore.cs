using System;
using System.Collections.Generic;
using System.Text;

namespace Prova02
{
    class NodoArvore
    {
        public string Dado { get; set; }
        public NodoArvore FilhoEsquerda { get; set; }
        public NodoArvore FilhoDireita { get; set; }

        public NodoArvore(string dado_)
        {
            this.Dado = dado_;
            this.FilhoEsquerda = null;
            this.FilhoDireita = null;
        }
    }
}

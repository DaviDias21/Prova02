using System;
using System.Collections.Generic;

namespace Prova02
{
    class Program
    {
        static void Main(string[] args)
        {
            /*QUESTÃO 01: Crie um método que apresente a relação de palavras distintas
            de um texto que possuam somente 4 letras. Para o teste, execute o método sobre o texto a seguir:*/

            Console.WriteLine("QUESTÃO 1");
            string textoQuestao01 = "O termo “gamificação” é proveniente do inglês “gamification”." +
                " Como você pode imaginar, esse tipo de estratégia tem como base o uso de" +
                " características provenientes dos games. Saiba mais sobre o conceito de gamificação" +
                " e como ela aumenta o engajamento de colaboradores e clientes.Portanto, a gamificação" +
                " utiliza mecanismos como desafios, pontuações, regras, premiações, fases, recompensas" +
                " e tudo o que você pode relacionar ao universo dos jogos, porém aplicada em outros" +
                " contextos, como a educação e, é claro, o mundo empresarial.";

            ImprimirPalavrasComQuatroCaracteres(textoQuestao01);
            Console.ReadLine();

            /*QUESTÃO 03: Implementar um programa que efetue a montagem de uma árvore
             binária de busca com os seguintes nomes de estados {Acre, Santa Catarina,
            Goiás, Tocantins, Ceará, Paraná, Bahia, Sergipe e Roraima} e retorne
            a lista de nomes em ordem alfabética*/

            Console.WriteLine("QUESTÃO 3");
            List<string> listaDosEstados = new List<string>();
            listaDosEstados.Add("Acre");
            listaDosEstados.Add("Santa Catarina");
            listaDosEstados.Add("Goiás");
            listaDosEstados.Add("Tocantins");
            listaDosEstados.Add("Ceará");
            listaDosEstados.Add("Paraná");
            listaDosEstados.Add("Bahia");
            listaDosEstados.Add("Sergipe");
            listaDosEstados.Add("Roraima");

            Arvore arvoreDosEstados = new Arvore(listaDosEstados[0]);
            for (int i = 1; i < listaDosEstados.Count; i++)
            {
                NodoArvore nodoNovo = new NodoArvore(listaDosEstados[i]);
                InserirElementoNaArvore(arvoreDosEstados.Raiz, nodoNovo);
            }

            Console.WriteLine("Estados em ordem alfabética:\n");

            ImprimirEmOrdemAlfabetica(arvoreDosEstados.Raiz);
            Console.ReadLine();

            /*QUESTÃO 05: A brincadeira "Batata Quente" é um popular jogo infantil no qual um
             objeto é passado de mão em mão pelas crianças dispostas em um círculo. A passagem
            do objeto é interrompida de forma aleatória e a criança que ficou com o objeto na mão
            é retirada do círculo. Então o jogo recomeça e o objeto retorna a ser transmitido
            de criança a criança até uma nova interrupção e consequente eliminação de mais um
            participante. O jogo procede com essa dinâmica até que reste apenas 1 criança.
            Essa brincadeira pode ser simulada por um programa que receba uma lista de crianças
            e um valor fixo ou variável que será usado como interrupção. Crie um método
            que receba essa lista de crianças e informe quem venceu a brincadeira.
            Para efeito de teste, considere a seguinte relação de crianças: {Abel, Bob, Carol,
            Duda, Eva e Franco}*/

            Console.WriteLine("QUESTÃO 5");
            List<string> criancasBatataQuente = new List<string>();
            criancasBatataQuente.Add("Abel");
            criancasBatataQuente.Add("Bob");
            criancasBatataQuente.Add("Carol");
            criancasBatataQuente.Add("Duda");
            criancasBatataQuente.Add("Eva");
            criancasBatataQuente.Add("Franco");
            BatataQuente(criancasBatataQuente);
            Console.ReadLine();

        }

        static void ImprimirPalavrasComQuatroCaracteres(string textoParaAnalise)
        {
            Dictionary<string, int> palavrasComQuatroCaracteres = new Dictionary<string, int>();
            string[] palavrasDivididas = textoParaAnalise.Split(' ', ',', ';', '.', '“', '”');
            foreach (var palavra in palavrasDivididas)
            {
                if (palavra.Length == 4)
                {
                    int count;
                    if (!palavrasComQuatroCaracteres.TryGetValue(palavra.ToLower(), out count))
                    {
                        count = 0;
                        palavrasComQuatroCaracteres.Add(palavra.ToLower(), count);
                    }
                    palavrasComQuatroCaracteres[palavra.ToLower()] = count + 1;
                }
            }

            Console.WriteLine("Palavras com quatro caracteres encontradas:\n");

            foreach(var palavra in palavrasComQuatroCaracteres)
            {
                Console.WriteLine(palavra.Key);
            }
        }

        static void InserirElementoNaArvore(NodoArvore raizArvore, NodoArvore novoElemento)
        {
            if (string.Compare(novoElemento.Dado, raizArvore.Dado) >= 0)
            {
                if (raizArvore.FilhoDireita == null)
                {
                    raizArvore.FilhoDireita = novoElemento;
                }
                else
                {
                    InserirElementoNaArvore(raizArvore.FilhoDireita, novoElemento);
                }
            }
            else
            {
                if (raizArvore.FilhoEsquerda == null)
                {
                    raizArvore.FilhoEsquerda = novoElemento;
                }
                else
                {
                    InserirElementoNaArvore(raizArvore.FilhoEsquerda, novoElemento);
                }
            }
        }

        static void ImprimirEmOrdemAlfabetica(NodoArvore raizArvore)
        {
            if(raizArvore != null)
            {
                ImprimirEmOrdemAlfabetica(raizArvore.FilhoEsquerda);
                Console.WriteLine(raizArvore.Dado);
                ImprimirEmOrdemAlfabetica(raizArvore.FilhoDireita);
            }
        }

        static void BatataQuente(List<string> criancasParticipando)
        {
            bool jogoEstaAcontecendo = true;
            Random variavelAleatoria = new Random();
            Console.WriteLine("Jogo iniciado");
            while (jogoEstaAcontecendo)
            {
                int criancaEliminada = variavelAleatoria.Next(0, criancasParticipando.Count);

                Console.WriteLine(criancasParticipando[criancaEliminada] + " eliminado(a).");
                criancasParticipando.Remove(criancasParticipando[criancaEliminada]);

                if(criancasParticipando.Count == 1)
                {
                    jogoEstaAcontecendo = false;
                }
            }
            Console.WriteLine("O jogo acabou! Quem venceu foi...");
            Console.WriteLine(criancasParticipando[0]);
        }
    }
}

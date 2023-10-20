// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;

namespace AED
{
    class CCelula
    {
        public Object Item; // O Item armazendo pela célula
        public CCelula Prox; // Referencia a próxima célula

        public CCelula()
        {
            Item = null;
            Prox = null;
        }

        public CCelula(object ValorItem)
        {
            Item = ValorItem;
            Prox = null;
        }

        public CCelula(object ValorItem, CCelula ProxCelula)
        {
            Item = ValorItem;
            Prox = ProxCelula;
        }
    }

    class CFila
    {
        private CCelula Frente; // Referencia a primeira célula da CFila (Célula cabeça)
        private CCelula Tras; // Referencia a última célula da CFila
        private int Qtde = 0;

        public CFila()
        {
            Frente = new CCelula();
            Tras = Frente;
        }

        public bool EstaVazia()
        {
            return Frente == Tras;
        }

        public void Imprimir()
        {
            Console.Write("[ ");
            for (CCelula aux = Frente.Prox; aux != null; aux = aux.Prox)
                Console.Write(aux.Item + " ");
            Console.WriteLine("]");
        }

        public void Enfileira(Object ValorItem)
        {
            Tras.Prox = new CCelula(ValorItem);
            Tras = Tras.Prox;
            Qtde++;
        }

        public Object Desenfileira()
        {
            Object Item = null;
            if (Frente != Tras)
            {
                Frente = Frente.Prox;
                Item = Frente.Item;
                Qtde--;
            }
            return Item;
        }

        public Object Peek()
        {
            if (Frente != Tras)
                return Frente.Prox.Item;
            else
                return null;
            // return (Frente != Tras)? Frente.Prox.Item : null;
        }

        public bool Contem(Object ValorItem)
        {
            bool achou = false;
            CCelula aux = Frente.Prox;
            while (aux != null && !achou)
            {
                achou = aux.Item.Equals(ValorItem);
                aux = aux.Prox;
            }
            return achou;
        }

        public bool ContemFor(Object ValorItem)
        {
            bool achou = false;
            for (CCelula aux = Frente.Prox; aux != null && !achou; aux = aux.Prox)
                achou = aux.Item.Equals(ValorItem);
            return achou;
        }

        public int Quantidade() //Função getter
        {
            return Qtde;
        }

        public IEnumerator GetEnumerator()
        {
            for (CCelula aux = Frente.Prox; aux != null; aux = aux.Prox)
                yield return aux.Item;
        }
    }

    class CPilha
    {
        private CCelula Topo = null;
        private int Qtde = 0;

        public CPilha()
        {
            // nenhum código
        }

        public bool EstaVazia()
        {
            return Topo == null;
        }

        public void Empilha(Object ValorItem)
        {
            Topo = new CCelula(ValorItem, Topo);
            Qtde++;
        }

        public Object Desempilha()
        {
            Object Item = null;
            if (Topo != null)
            {
                Item = Topo.Item;
                Topo = Topo.Prox;
                Qtde--;
            }
            return Item;
        }

        public bool Contem(Object ValorItem)
        {
            bool achou = false;
            CCelula aux = Topo;
            while (aux != null && !achou)
            {
                achou = aux.Item.Equals(ValorItem);
                aux = aux.Prox;
            }
            return achou;
        }

        public bool ContemFor(Object ValorItem)
        {
            bool achou = false;
            for (CCelula aux = Topo; aux != null && !achou; aux = aux.Prox)
                achou = aux.Item.Equals(ValorItem);
            return achou;
        }

        public Object Peek()
        {
            if (Topo != null)
                return Topo.Item;
            else
                return null;
        }

        public int Quantidade() //Função
        {
            return Qtde;
        }

        public IEnumerator GetEnumerator()
        {
            for (CCelula aux = Topo; aux != null; aux = aux.Prox)
                yield return aux.Item;
        } 

    }

    class CLista
    {
        private CCelula Primeira; // Referencia a célula cabeça 
        private CCelula Ultima; // Referencia a última célula da lista
        private int Qtde = 0;

        public CLista()
        {
            Primeira = new CCelula();
            Ultima = Primeira;
        }

        public bool Vazia()
        {
            return Primeira == Ultima;
        }

        public void InsereFim(Object ValorItem) // idêntico ao método Enfileira da classe CFila
        {
            Ultima.Prox = new CCelula(ValorItem);
            Ultima = Ultima.Prox;
            Qtde++;
        }

        public void InsereComeco(Object ValorItem)
        {
            Primeira.Prox = new CCelula(ValorItem, Primeira.Prox);
            if (Primeira.Prox.Prox == null)
                Ultima = Primeira.Prox;
            Qtde++;
        }

        public bool InsereIndice(Object ValorItem, int Posicao)
        {
            // Verifica se a posição passada por parâmetro é uma posição válida, ou seja, no intervalo entre 1 e Qtde+1
            if (Posicao >= 1 && Posicao <= Qtde + 1)
            {
                int i = 0;
                CCelula aux = Primeira;
                // Procura a posição a ser inserido
                while (i < Posicao - 1)
                {
                    aux = aux.Prox;
                    i++;
                }
                aux.Prox = new CCelula(ValorItem, aux.Prox);
                if (aux.Prox.Prox == null) // se a célula inserida está na última posição.
                    Ultima = aux.Prox;
                Qtde++;
                return true;
            }
            return false;
        }

        public void Imprime(bool ItemPorLinha)
        {
            CCelula aux = Primeira.Prox;
            while (aux != null)
            {
                Console.WriteLine(aux.Item);
                aux = aux.Prox;
            }
        }

        public void ImprimeFor()
        {
            for (CCelula aux = Primeira.Prox; aux != null; aux = aux.Prox)
                Console.Write(aux.Item);
        }

        public void ImprimeFormatoLista()
        {
            Console.Write("[/]->");
            for (CCelula aux = Primeira.Prox; aux != null; aux = aux.Prox)
                Console.Write("[" + aux.Item + "]->");
            Console.WriteLine("null");
        }

        public bool Contem(Object ValorItem) // idêntico ao método Contem da classe CFila
        {
            bool achou = false;
            CCelula aux = Primeira.Prox;
            while (aux != null && !achou)
            {
                achou = aux.Item.Equals(ValorItem);
                aux = aux.Prox;
            }
            return achou;
        }

        public bool ContemFor(Object ValorItem) // idêntico ao método ContemFor da classe CFila
        {
            bool achou = false;
            for (CCelula aux = Primeira.Prox; aux != null && !achou; aux = aux.Prox)
                achou = aux.Item.Equals(ValorItem);
            return achou;
        }

        public Object RemoveRetornaComecoSimples() // idêntico ao método Desenfileira() da classe CFila
        {
            // Verifica se há elementos na lista
            if (Primeira != Ultima)
            {
                Primeira = Primeira.Prox;
                Qtde--;
                return Primeira.Item;
            }
            return null;
        }

        public void RemoveComecoSemRetorno()
        {
            if (Primeira != Ultima)
            {
                Primeira = Primeira.Prox;
                Qtde--;
            }
        }

        public void RemoveFimSemRetorno()
        {
            if (Primeira != Ultima)
            {
                CCelula aux = Primeira;
                while (aux.Prox != Ultima)
                    aux = aux.Prox;

                Ultima = aux;
                Ultima.Prox = null;
                Qtde--;
            }
        }

        public Object RemoveRetornaFim()
        {
            if (Primeira != Ultima)
            {
                CCelula aux = Primeira;
                while (aux.Prox != Ultima)
                    aux = aux.Prox;

                CCelula aux2 = aux.Prox;
                Ultima = aux;
                Ultima.Prox = null;
                Qtde--;
                return aux2.Item;
            }
            return null;
        }

        public void Remove(Object ValorItem)
        {
            if (Primeira != Ultima)
            {
                CCelula aux = Primeira;
                bool achou = false;
                while (aux.Prox != null && !achou)
                {
                    achou = aux.Prox.Item.Equals(ValorItem);
                    if (!achou)
                        aux = aux.Prox;
                }
                if (achou) // achou o elemento
                {
                    aux.Prox = aux.Prox.Prox;
                    if (aux.Prox == null)
                        Ultima = aux;
                    Qtde--;
                }
            }
        }

        public Object RetornaPrimeiro() // Idêntico ao método Peek() da classe CFila
        {
            if (Primeira != Ultima)
                return Primeira.Prox.Item;
            else
                return null;
        }

        public Object RetornaUltimo()
        {
            if (Primeira != Ultima)
                return Ultima.Item;
            else
                return null;
        }

        public Object RetornaIndice(int Posicao)
        {
            // EXERCÍCIO : deve retornar o elemento da posição p passada por parâmetro
            // [cabeça]->[7]->[21]->[13]->null
            // retornaIndice(2) deve retornar o elemento 21. retornaIndice de uma posiçao inexistente deve retornar null.
            // Se é uma posição válida e a lista possui elementos
            if ((Posicao >= 1) && (Posicao <= Qtde) && (Primeira != Ultima))
            {
                int i = 1;
                CCelula aux = Primeira.Prox;
                // Procura a posição a ser inserido
                while (i < Posicao)
                {
                    aux = aux.Prox;
                    i++;
                }
                return aux.Item;
            }
            return null;
        }

        public int Quantidade()
        {
            return Qtde;
        }

        public IEnumerator GetEnumerator()
        {
            for (CCelula aux = Primeira.Prox; aux != null; aux = aux.Prox)
                yield return aux.Item;
        }
    }
}
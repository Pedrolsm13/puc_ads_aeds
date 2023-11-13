using System;
using System.Collections;
using System.Resources;
using System.Runtime.InteropServices;

namespace AED
{
    class Program{
        public static void Main(string [] args){
            CDicionario TAD = new CDicionario();
            int entrada = 64;
            object elemento;
            object elemento1;
            //insere os objetos na lista
            string [] linha;
            for (int j = 0; j < entrada; j++){
                linha = Console.ReadLine().Split(' ');
                elemento = linha[0];
                elemento1 = linha[1];
                TAD.adiciona(elemento, elemento1);
            }
            TAD.ImprimeFormatoLista();
            TAD.imprimeQuantidade();
            TAD.imprimeUltimo();
            string linhanova = Console.ReadLine();
            object elemento3 = linhanova;
            Console.WriteLine(TAD.recebeValor(elemento3));
        }
    }
    class CCelula{
        public object Item;
        public CCelula Prox;
        
        public CCelula(){
            Item = null;
            Prox = null;
        }
        public CCelula(object valor){
            Item = valor;
            Prox = null;
        }
        public CCelula(object valor, CCelula ProxCel){
            Item = valor;
            Prox = ProxCel;
        }
    }
    class CCeluladup{
        public object Item;
        public CCeluladup Prox;
        public CCeluladup Ant;
        public CCeluladup(){
            Ant = null;
            Item = null;
            Prox = null;
        }
        public CCeluladup(CCeluladup AntCel, object valor){
            Ant = AntCel;
            Item = valor;
            Prox = null;
        }
        public CCeluladup(CCeluladup AntCel, object valor, CCeluladup ProxCel){
            Ant = AntCel;
            Item = valor;
            Prox = ProxCel;
        }
    }
    class CListaDup{
        private CCeluladup First;
        private CCeluladup Last;
        private int Count = 0;

        public CListaDup(){
            First = new CCeluladup();
            Last = First;
        }
        public bool vazia(){
            return First == Last;
        }
        public void InsereFim(object Valor){
            Last.Prox = new CCeluladup(Last, Valor);
            Last = Last.Prox;
            Count++;
        }

        public void ConcatenaLD(CListaDup L1, CListaDup L2){
            First = L1.First;
            Last = L1.Last;
            Last.Prox = L2.First.Prox;
            Last.Prox.Ant = Last;
            Count = L1.Count + L2.Count;
            Last = L2.Last;
        }
        public int primeiraOcorrenciaDe(object elemento){
                int indice = -1, i = 1;
                CCeluladup aux = First.Prox;
                while(aux.Prox != null && !aux.Prox.Item.Equals(elemento)){
                    aux = aux.Prox;
                    i++;
                }
                if(aux.Prox != null && aux.Prox.Item.Equals(elemento)){
                    i++;
                    return i;
                }
                return indice;
        }
        public int ultimaOcorrenciaDe(object elemento){
                int indice = -1, i = Count;
                CCeluladup aux = Last;
                while(aux.Ant.Item != null && !aux.Item.Equals(elemento)){
                    aux = aux.Ant;
                    i--;
                }
                if(aux != null && aux.Item.Equals(elemento)){
                    return i;
                }
                return indice;
        }
        public void RemovePos(int n){
            if(Count > 0 && n > 0 && n <= Count){
                int i = 0;
                CCeluladup aux = First;
                while(aux != null && i != n){
                    aux = aux.Prox;
                    i++;
                }
                if(aux.Prox != null){
                aux.Ant.Prox = aux.Prox;
                aux.Prox.Ant = aux.Ant;
                }
                else{
                    Last = aux.Ant;
                    aux.Ant.Prox = aux.Prox;
                }
                Count--;                    
            }
        }
        public void ImprimeFormatoLista(){
            Console.Write("<-[/]->");
            for (CCeluladup aux = First.Prox; aux != null; aux = aux.Prox)
                Console.Write("<-[" + aux.Ant.Item + "<-[" + aux.Item + "]->");
            Console.WriteLine("null");
        }
        public void imprimeQuantidade(){
            Console.WriteLine($"quantidade = {Count}");
        }
        public void imprimeUltimo(){
            Console.WriteLine($"ultimo = [" + Last.Item + "]->");
        }
    }
    class CLista{
        private CCelula First;
        private CCelula Last;
        private int Count = 0;

        public CLista(){
            First = new CCelula();
            Last = First;
        }
        public bool vazia(){
            return First == Last;
        }
        public void InsereFim(object Valor){
            Last.Prox = new CCelula(Valor);
            Last = Last.Prox;
            Count++;
        }
        public void InsereAntesDe(Object ElementoAInserir, Object Elemento){
            //confere lista vazia
            if(Count > 0){
                CCelula aux = First;
                //encontra a posicao para inserir
                while(aux.Prox != null && !aux.Prox.Item.Equals(Elemento)){
                    aux = aux.Prox;
                }
                //se encontrou a posicao insere
                if(aux.Prox != null && aux.Prox.Item.Equals(Elemento)){
                    aux.Prox = new CCelula(ElementoAInserir, aux.Prox);
                    Count++;
                }
                else{
                    Console.WriteLine("Elemento não encontrado na lista.");
                }
            }
            else{
                Console.WriteLine("Lista vazia.");
            }
        }
        public void InsereDepoisDe(Object ElementoAInserir, Object Elemento){
            //confere lista vazia
            if(Count > 0){
                CCelula aux = First.Prox;//Pedro Assuncao auxiliou, pois nao pode fazer comparacao nula no equals
                //encontra a posicao para inserir
                while(aux != null && !aux.Item.Equals(Elemento)){
                    aux = aux.Prox;
                }
                //se encontrou a posicao insere
                if(aux.Item.Equals(Elemento)){
                    if (aux.Prox != null)
                        aux.Prox = new CCelula(ElementoAInserir, aux.Prox);
                    else{
                        Last.Prox = new CCelula(ElementoAInserir);
                        Last = Last.Prox;
                    }
                    Count++;
                }
                else{
                    Console.WriteLine("Elemento não encontrado na lista.");
                }
            }
            else{
                Console.WriteLine("Lista vazia.");
            }
        }

        public void InsereOrdenado(int ElementoAInserir){
            if(Count > 0){
                CCelula aux = First;
                while(aux.Prox != null && (int)aux.Prox.Item < ElementoAInserir){
                    aux = aux.Prox;
                }
                if (aux.Prox != null){
                    aux.Prox = new CCelula(ElementoAInserir, aux.Prox);
                    Count++;
                }
                else if(aux.Prox == null){
                    Last.Prox = new CCelula(ElementoAInserir);
                    Last = Last.Prox;
                    Count++;
                }
            }
            else{
                Last.Prox = new CCelula(ElementoAInserir);
                Last = Last.Prox;
                Count++;
            }
        }
        public void RemovePos(int n){
            if(Count > 0 && n > 0 && n <= Count){
                int i = 0;
                CCelula aux = First;
                while(aux != null && i != n-1){
                    aux = aux.Prox;
                    i++;
                }
                aux.Prox = aux.Prox.Prox;
                if(aux.Prox == null)
                    Last = aux;
                Count--;                    
            }
        }
        public void ImprimeFormatoLista(){
            Console.Write("[/]->");
            for (CCelula aux = First.Prox; aux != null; aux = aux.Prox)
                Console.Write("[" + aux.Item + "]->");
            Console.WriteLine("null");
        }
        public void imprimeQuantidade(){
            Console.WriteLine($"quantidade = {Count}");
        }
        public void imprimeUltimo(){
            Console.WriteLine($"ultimo = [" + Last.Item + "]->");
        }
    }
    class CFila{
        private CCelula First;
        private CCelula Last;
        private int Count = 0;
        public CFila(){
            First = new CCelula();
            Last = First;
        }
        public bool vazia(){
            return First == Last;
        }
        public void Enfileira(object Valor){
            Last.Prox = new CCelula(Valor);
            Last = Last.Prox;
            Count++;
        }
        public void ConcatenaFila(CFila F1, CFila F2){
            First = F1.First;
            Last = F1.Last;
            Last.Prox = F2.First.Prox;
            Last = F2.Last;
            Count = F1.Count + F2.Count;
        }
        public void ImprimeFormatoLista(){
            Console.Write("[/]->");
            for (CCelula aux = First.Prox; aux != null; aux = aux.Prox)
                Console.Write("[" + aux.Item + "]->");
            Console.WriteLine("null");
        }
        public void imprimeQuantidade(){
            Console.WriteLine($"quantidade = {Count}");
        }
        public void imprimeUltimo(){
            Console.WriteLine($"ultimo = [" + Last.Item + "]->");
        }
    }
    class CPilha{
        private CCelula Topo;
        private int Count;
        public CPilha(){

        }
        public bool EstaVazia()
        {
            return Topo == null;
        }
        public void Empilha(object valor){
            Topo = new CCelula(valor, Topo);
            Count++;
        }
        public void ConcatenaPilha(CPilha P1, CPilha P2){
            Topo = P1.Topo;
            Count = P1.Count + P2.Count;
            CCelula aux = P2.Topo;
            while (aux.Prox != null){
                aux = aux.Prox;
            }
            aux.Prox = Topo;
            Topo = P2.Topo;
            /*CPilha Pilha = new CPilha();
            while (P2.Topo != null)
            {
                Pilha.Topo = new CCelula(P2.Topo.Item, Pilha.Topo);
                P2.Topo = P2.Topo.Prox;
            }
            while (Pilha.Topo != null)
            {
                Topo = new CCelula(Pilha.Topo.Item, Topo);
                Pilha.Topo = Pilha.Topo.Prox;
            }*/
        }
        public void ImprimeFormatoLista(){
            for (CCelula aux = Topo; aux != null; aux = aux.Prox)
                Console.Write("<-[" + aux.Item + "]");
            Console.WriteLine(" ");
        }
        public void imprimeQuantidade(){
            Console.WriteLine($"quantidade = {Count}");
        }
    }
    class RandomQueue{
        private CCelula First;
        private CCelula Last;
        private int Count;
        public RandomQueue(){
            First = new CCelula();
            Last = First;
        }
        public bool IsEmpty(){
            return First == Last;
        }
        public void Enqueue(object item){
            Last.Prox = new CCelula(item);
            Last = Last.Prox;
            Count++;
        }
        public object Dequeue(){
            Random r = new Random();
            object imprime;
            int valor = r.Next(1, Count+1);
            int i = 0;
            CCelula aux = First;
            while (i < valor - 1){
                aux = aux.Prox;
                i++;
            }
            imprime = aux.Prox.Item;
            aux.Prox = aux.Prox.Prox;
            if (aux.Prox == null)
                Last = aux;
            Count--;
            return imprime;
        }
        public object Sample(){
            Random r = new Random();
            object imprime;
            int valor = r.Next(1, Count+1);
            int i = 0;
            CCelula aux = First;
            while (i < valor - 1){
                aux = aux.Prox;
                i++;
            }
            imprime = aux.Prox.Item;
            return imprime;
        }
        public void ImprimeFormatoLista(){
            Console.Write("[/]->");
            for (CCelula aux = First.Prox; aux != null; aux = aux.Prox)
                Console.Write("[" + aux.Item + "]->");
            Console.WriteLine("null");
        }
        public void imprimeQuantidade(){
            Console.WriteLine($"quantidade = {Count}");
        }
        public void imprimeUltimo(){
            Console.WriteLine($"ultimo = [" + Last.Item + "]->");
        }
    }
    class Deque{
        private CCeluladup First;
        private CCeluladup Last;
        private int Count = 0;
        public Deque(){
            First = new CCeluladup();
            Last = First;
        }
        public bool isEmpty(){
            return First == Last;
        }
        public int size(){
            return Count;
        }
        public void pushLeft(object item){
            First.Prox = new CCeluladup(First, item, First.Prox);
            if(First.Prox.Prox != null)
                First.Prox.Prox.Ant = First.Prox;
            else
                Last = First.Prox;
            Count++;
        }
        public void pushRight(object item){
            Last.Prox = new CCeluladup(Last, item);
            Last = Last.Prox;
            Count++;
        }
        public object popLeft(){
            object imprime = First.Prox.Item;
            First.Prox = First.Prox.Prox;
            First.Prox.Ant = First;
            Count--;
            return imprime;
        }
        public object popRight(){
            object imprime = Last.Item;
            Last = Last.Ant;
            Last.Prox = Last.Prox.Prox;
            Count--;
            return imprime;
        }
        public void ImprimeFormatoLista(){
            Console.Write("<-[/]->");
            for (CCeluladup aux = First.Prox; aux != null; aux = aux.Prox)
                Console.Write("<-[" + aux.Ant.Item + "<-[" + aux.Item + "]->");
            Console.WriteLine("null");
        }
        public void imprimeQuantidade(){
            Console.WriteLine($"quantidade = {Count}");
        }
        public void imprimeUltimo(){
            Console.WriteLine($"ultimo = [" + Last.Item + "]->");
        }
    }
    class CCelulaDicionario{
        // Atributos
        public object Key, Value;
        public CCelulaDicionario Prox;
        // Construtora que anula os três atributos da célula
        public CCelulaDicionario(){
            Key = null;
            Value = null;
            Prox = null;
        }
        // Construtora que inicializa key e value com os argumentos passados 
        // por parâmetro e anula a referência à próxima célula
        public CCelulaDicionario(object chave, object valor){
            Key = chave;
            Value = valor;
            Prox = null; 
        }
        // Construtora que inicializa todos os atribulos da célula com os argumentos
        // passados por parâmetro
        public CCelulaDicionario(object chave, object valor, CCelulaDicionario proxima){
            Key = chave;
            Value = valor;
            Prox = proxima;
        }
    }
    class CDicionario{
        private CCelulaDicionario First, Last;
        private int Count;
        public CDicionario(){
            First = new CCelulaDicionario();
            Last = First;
        }
        public bool vazio(){
            return First == Last;
        }
        public void adiciona(object chave, object valor){
            Last.Prox = new CCelulaDicionario(chave, valor);
            Last = Last.Prox;
            Count++;
        }
        public object recebeValor(object chave){
            CCelulaDicionario aux = First.Prox;
            while(aux != null && !aux.Key.Equals(chave)){
                aux = aux.Prox;
            }
            if(aux != null && aux.Key.Equals(chave))
                return aux.Value;
            else
                return null;
            /*while(aux != null){
                if(aux.Key.Equals(chave))
                    return aux.Value;
                aux = aux.Prox;
            }
            else
                return null;*/
        }
        public void ImprimeFormatoLista(){
            Console.Write("[/]->");
            for (CCelulaDicionario aux = First.Prox; aux != null; aux = aux.Prox)
                Console.Write("[" + aux.Key + "]["+ aux.Value +"]->");
            Console.WriteLine("null");
        }
        public void imprimeQuantidade(){
            Console.WriteLine($"quantidade = {Count}");
        }
        public void imprimeUltimo(){
            Console.WriteLine($"ultimo = [" + Last.Key + "]["+ Last.Value +"]->");
        }
    }
}
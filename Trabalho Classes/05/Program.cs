using System;
using System.Collections;
using System.Resources;
using System.Runtime.InteropServices;

namespace AED
{
    class Program
    {
        public static void Main(string [] args){
            CFila A = new CFila ();
            CFila B = new CFila ();
            CFila AmaisB = new CFila(); 
            object elemento;
            //insere os objetos na lista
            string [] linha = Console.ReadLine().Split(';');
            for (int j = 0; j < linha.Length; j++){
                elemento = linha[j];
                A.Enfileira(elemento);
            }
            string [] linha1 = Console.ReadLine().Split(';');
            for (int j = 0; j < linha1.Length; j++){
                elemento = linha1[j];
                B.Enfileira(elemento);
            }

            A.ImprimeFormatoLista();
            A.imprimeQuantidade();
            A.imprimeUltimo();
            
            B.ImprimeFormatoLista();
            B.imprimeQuantidade();
            B.imprimeUltimo();

            AmaisB.ConcatenaFila(A, B);
            AmaisB.ImprimeFormatoLista();
            AmaisB.imprimeQuantidade();
            AmaisB.imprimeUltimo();

        }
    }
    class CCelula
    {
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

    class CLista
    {
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
}
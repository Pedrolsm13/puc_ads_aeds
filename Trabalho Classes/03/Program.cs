using System;
using System.Collections;
using System.Resources;
using System.Runtime.InteropServices;

namespace AED
{
    class Program
    {
        public static void Main(string [] args){
            int qtd_vezes = int.Parse(Console.ReadLine());
            CLista Lista = new CLista();
            int elemento;
            
            //insere os objetos na lista
            for (int i = 0; i < qtd_vezes; i++){
                elemento = int.Parse(Console.ReadLine());
                Lista.InsereOrdenado(elemento);
            }
            Lista.ImprimeFormatoLista();
            Lista.imprimeQuantidade();
            Lista.imprimeUltimo();
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
}
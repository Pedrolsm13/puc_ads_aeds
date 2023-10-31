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
            object elemento;
            
            //insere os objetos na lista
            for (int i = 0; i < qtd_vezes; i++){
                elemento = Console.ReadLine();
                Lista.InsereFim(elemento);
            }
            Lista.ImprimeFormatoLista();
            
            //insere mais um objeto
            object ElementoAInserir = Console.ReadLine();
            //referencia do objeto para inserção
            object Elementoref = Console.ReadLine();
            Lista.InsereAntesDe(ElementoAInserir, Elementoref);
            Lista.ImprimeFormatoLista();
            Lista.imprimeQuantidade();
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
            if(Count > 0){
                CCelula aux = First;
                while(aux.Prox != null && aux.Prox.Item != Elemento){
                    aux = aux.Prox;
                }
                Console.WriteLine("[" + aux.Item + "]->");
                if(aux.Prox != null && aux.Prox.Item == Elemento){
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
        public void ImprimeFormatoLista()
        {
            Console.Write("[/]->");
            for (CCelula aux = First.Prox; aux != null; aux = aux.Prox)
                Console.Write("[" + aux.Item + "]->");
            Console.WriteLine("null");
        }
        public void imprimeQuantidade()
        {
            Console.WriteLine($"quantidade = {Count}");
        }
    }
}
using System;
using System.Collections.Generic;

class Program{
    public static void Main(string [] args){
        int n = 1;
        while(n != 0){
            n = int.Parse(Console.ReadLine());
            if(n == 0)
                break;
            Stack<string> pilha = new Stack<string>();
            Queue<string> fila = new Queue<string>();
            bool f = false;
            bool l = false;
            bool p = false; 
            for(int i = 0; i < n; i++){
                string [] linha = Console.ReadLine().Split(' ');
                if(linha[0] == "I"){
                    pilha.Push(linha[1]);
                    fila.Enqueue(linha[1]);
                }
                else if(linha[0] == "R"){
                    if(linha[1] == pilha.Peek()){
                        pilha.Pop();
                        fila.Dequeue();
                        f = false;
                        l = false;
                        p = true;
                    }
                    else if(linha[1] == fila.Peek()){
                        pilha.Pop();
                        fila.Dequeue();
                        f = true;
                        l = false;
                        p = false;
                    }
                    else{
                        f = false;
                        l = true;
                        p = false;
                    }
                }
            }
            if(f)
                Console.WriteLine("queue");
            else if(l)
                Console.WriteLine("list");
            else if(p)
                Console.WriteLine("stack");
        }
    }
}
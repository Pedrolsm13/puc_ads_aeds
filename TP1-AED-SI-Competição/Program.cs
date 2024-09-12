using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

class Program{
    public static void Main(string[] args){
        int qtdaluno = 0, qtdquestoes = 0;
        do{
            string linha = Console.ReadLine();
            string[] v = linha.Split(' ');
            qtdaluno = int.Parse(v[0]);
            qtdquestoes = int.Parse(v[1]);
            int premissas = 0;
            int [,] matriz = new int[qtdaluno,qtdquestoes];
            int [] vetor = new int[qtdquestoes];
            bool todos = true, ninguem = true, pelo_menos = true, nenhum = true;
            if(qtdaluno == 0)
                break;
            for (int i = 0; i < qtdaluno; i++){
                int x = 0;
                string [] l = Console.ReadLine().Split(' ');
                for (int j = 0; j < qtdquestoes; j++){
                    matriz [i,j] = int.Parse(l[j]);
                    if (matriz [i,j] > 0){
                        vetor[j]++;
                        x++;
                    }
                }
                if (x == qtdquestoes)
                    ninguem = false;
                if (x == 0)
                    todos = false;
            }
            for (int i = 0; i < qtdquestoes; i++){
                if (vetor[i] == 0)
                    pelo_menos = false;
                if (vetor[i] == qtdaluno)
                    nenhum = false;
            }
            //1 - Ninguém resolveu todos os problemas.
            if (ninguem)
                premissas++;
            //2 - Todo problema foi resolvido por pelo menos uma pessoa (não necessariamente a mesma).
            if (pelo_menos)
                premissas++;
            //3 - Não há nenhum problema resolvido por todos.
            if (nenhum)
                premissas++;
            //4 - Todos resolveram ao menos um problema (não necessariamente o mesmo).
            if (todos)
                premissas++;
            
            Console.WriteLine(premissas);
        }
        while(qtdaluno > 0 );
    }
}
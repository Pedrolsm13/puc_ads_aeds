using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

class Program{
    public static void Main(string[] args){
        int qtdposte = 0;
        while ((qtdposte = int.Parse(Console.ReadLine())) != 0){
            string [] linha = Console.ReadLine().Split(' ');
            int [] vetor = new int[linha.Length];
            int cont = 0, qtd = 0, resultado = 0, iniciomeio = 0;
            for (int i = 0; i < linha.Length; i++){
                vetor[i] = int.Parse(linha[i]);
            }
            if (vetor[0] == 0){
                for (int i = 0; i < vetor.Length; i++){
                    if (vetor[i] == 0)
                    iniciomeio++;
                    if (vetor[i] != 0){
                        break;
                    }
                }
                for (int i = iniciomeio - 1; i < vetor.Length; i++){
                    if (vetor[i] == 0){
                        cont++;
                        if (i == vetor.Length - 1){
                            cont += iniciomeio;
                            qtd = cont / 2;
                            resultado += qtd;
                        }
                    }
                    else if (vetor[i] != 0){
                        qtd = cont / 2;
                        cont = 0;
                        resultado += qtd;
                        if (i == vetor.Length - 1){
                            qtd = iniciomeio / 2;
                            resultado += qtd;
                        }
                    }
                }
            }
            else{
                for (int i = 0; i < linha.Length; i++){
                    if (vetor[i] == 0)
                        cont++;
                    if (vetor[i] != 0 || i == vetor.Length - 1){
                        qtd = cont / 2;
                        cont = 0;
                        resultado += qtd;
                    }
                }
            }
            Console.WriteLine(resultado);
        }
    }
}

/*class Program{
    public static void Main(string[] args){
        int qtdposte = 0;
        do{
            qtdposte = int.Parse(Console.ReadLine());
            if (qtdposte == 0)
                break;
            string [] linha = Console.ReadLine().Split(' ');
            int [] vetor = new int[linha.Length];
            int cont = 0, qtd = 0, resultado = 0;
            for (int i = 0; i < linha.Length; i++){
                vetor[i] = int.Parse(linha[i]);
                if (vetor[i] == 0)
                    cont++;
                if (vetor[i] != 0 || vetor.Length == i-1){
                    qtd = cont / 2;
                    cont = 0;
                    if (qtd > 0)
                    resultado += qtd;
                }
            }
            Console.WriteLine(resultado);
        }
        while(qtdposte > 0 );
    }
}*/
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

class Program{
    public static void Main(string[] args){
        int qtdtestes = 0, qtdcaso = 1;
        do{
            qtdtestes = int.Parse(Console.ReadLine());
            if (qtdtestes == 0)
                break;
            string [] linha = Console.ReadLine().Split(' ');
            double [] vetor = new double[linha.Length];
            for (int i = 0; i < linha.Length; i++)
                vetor[i] = double.Parse(linha[i]);
            double maior = -1;
            int numero = 0;
            string senha = "";
            for (int i = 0; i < qtdtestes; i++){
                for (int j = 0; j < linha.Length; j++){
                    if (vetor[j] > maior){
                        maior = vetor[j];
                        numero = j;
                    }
                }
                senha += numero;
                maior = -1;
                vetor[numero] = -1;
            }
            Console.WriteLine($"Caso {qtdcaso}: {senha}");
            qtdcaso++;
        }
        while(qtdtestes > 0 );
    }
}

// codigo beecrowd
/*
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

class Program{
    public static void Main(string[] args){
        int qtdtestes = 0, qtdcaso = 1;
        string input;
        while ((input = Console.ReadLine()) != null && input != "0"){
            qtdtestes = int.Parse(input);
            string [] linha = Console.ReadLine().Split(' ');
            double [] vetor = new double[linha.Length];
            for (int i = 0; i < linha.Length; i++)
                vetor[i] = double.Parse(linha[i]);
            double maior = -1;
            int numero = 0;
            string senha = "";
            for (int i = 0; i < qtdtestes; i++){
                for (int j = 0; j < linha.Length; j++){
                    if (vetor[j] > maior){
                        maior = vetor[j];
                        numero = j;
                    }
                }
                senha += numero;
                maior = -1;
                vetor[numero] = -1;
            }
            Console.WriteLine($"Caso {qtdcaso}: {senha}");
            qtdcaso++;
        }
    }
}*/
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

class Program{
    public static void Main(string[] args){
        int qtdtestes = 0, desempatetime1 = 0, desempatetime2 = 0;
        qtdtestes = int.Parse(Console.ReadLine());
        for (int i = 0; i < qtdtestes; i++){
            int Time1 = 0, Time2 = 0;
            string [] linha = Console.ReadLine().Split(' ');
            Time1 += int.Parse(linha[0]);
            Time2 += int.Parse(linha[2]);
            desempatetime2 = int.Parse(linha[2]);
            linha = Console.ReadLine().Split(' ');
            Time1 += int.Parse(linha[2]);
            Time2 += int.Parse(linha[0]);
            desempatetime1 = int.Parse(linha[2]);
            
            if (Time1 == Time2 && desempatetime2 == desempatetime1)
                Console.WriteLine("Penaltis");
            else if (Time1 == Time2 && desempatetime2 > desempatetime1)
                Console.WriteLine("Time 2");
            else if (Time1 == Time2 && desempatetime2 < desempatetime1)
                Console.WriteLine("Time 1");
            else if (Time1 > Time2)
                Console.WriteLine("Time 1");
            else 
                Console.WriteLine("Time 2");
        }
    }
}
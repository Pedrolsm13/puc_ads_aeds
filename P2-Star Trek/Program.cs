using System;
using System.Collections.Generic;

class Program{
    static void Main(string[] args){
        int v = int.Parse(Console.ReadLine());
        Personagem[] Pers_vet = new Personagem[v];
        for(int i = 0; i < v; i++){
            string linha = Console.ReadLine();
            Pers_vet[i] = new Personagem(linha);
        }
        bool troca = true;
        for(int i = 0; i < Pers_vet.Length-1 && troca; i++){
            troca = false;
            for(int j = 0; j < Pers_vet.Length-(i+1); j++){
                if(Pers_vet[j].nome.CompareTo(Pers_vet[j+1].nome) > 0){
                    Personagem aux = Pers_vet[j];
                    Pers_vet[j] = Pers_vet[j+1];
                    Pers_vet[j+1] = aux;
                    troca = true;
                }
            }
        }
        for(int k = 0; k < Pers_vet.Length; k++){
            Console.WriteLine($"{Pers_vet[k].nome}-{Pers_vet[k].raca}-{Pers_vet[k].serie}");
        }
    }
}

class Personagem{
    public string nome{get; private set;}
    public string raca{get; private set;}
    public string serie{get; private set;}

    public Personagem(string linha){
        string [] vet = linha.Split(';');
        this.nome = vet[0];
        this.raca = vet[1];
        this.serie = vet[2];
    }
}
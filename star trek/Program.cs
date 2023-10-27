using System;

class Program{
    static void Main(string[] args){
        int v = int.Parse(Console.ReadLine());
        Personagem[] Pers_vet = new Personagem[v];
        for(int i = 0; i < v; i++){
            string linha = Console.ReadLine();
            Pers_vet[i] = new Personagem(linha);
        }
        
        int v1 = int.Parse(Console.ReadLine());
        
        for(int i = 0; i < v1; i++){
            string [] consulta = Console.ReadLine().Split(';');
            if(consulta[0] == "nome"){
                int c = 0;
                foreach(Personagem s in Pers_vet){
                    if(s.nome == consulta[1]){
                        c++;
                    }
                }
                Console.WriteLine($"{consulta[0]} {c}");
            }
            if(consulta[0] == "raca"){
                int c = 0;
                foreach(Personagem s in Pers_vet){
                    if(s.raca == consulta[1]){
                        c++;
                    }
                }
                Console.WriteLine($"{consulta[0]} {c}");
            }
            if(consulta[0] == "serie"){
                int c = 0;
                foreach(Personagem s in Pers_vet){
                    if(s.serie == consulta[1]){
                        c++;
                    }
                }
                Console.WriteLine($"{consulta[0]} {c}");
            }
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
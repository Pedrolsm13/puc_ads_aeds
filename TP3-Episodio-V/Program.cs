using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Personagem> P = new List<Personagem>(n);
        Stack<string> pilha = new Stack<string>();
        Queue<string> fila = new Queue<string>();

        for (int i = 0; i < n; i++)
        {
            string linhaP = Console.ReadLine();
            P.Add(new Personagem(linhaP));
        }
        int m = int.Parse(Console.ReadLine());

        for (int j = 0; j < m; j++)
        {
            string[] v = Console.ReadLine().Split(";");
            
            if (v[0] == "PesqBin"){
                int i = 0, esq = 0, dir = P.Count-1;
                do {
                    i = (esq + dir ) / 2;
                    if (P[i].nome.CompareTo(v[1]) < 0)
                        esq = i + 1;
                    else if (P[i].nome.CompareTo(v[1]) > 0)
                        dir = i - 1;
                } 
                while ( (P[i].nome != v[1]) && (esq <= dir ) ) ;
                if (P[i].nome == v[1])
                    Console.WriteLine($"{v[1]} Ok");
                else
                    Console.WriteLine($"{v[1]} Nada");
            }
            else if (v[0] == "Push"){
                for(int i = 0; i < P.Count; i++){
                    if(P[i].homeworld == v[1])
                        pilha.Push(P[i].nome);
                }
            }

            else if (v[0] == "Pop"){
                int qtds = 0;
                if (v[1] == "all")
                    qtds = pilha.Count;
                else
                    qtds = int.Parse(v[1]);
                for(int i = 0; i < qtds; i++){
                    string nome_pers = pilha.Peek();
                    Console.WriteLine(nome_pers);
                    pilha.Pop();
                }
            }
            else if (v[0] == "Enqueue"){
                for(int i = 0; i < P.Count; i++){
                    if(P[i].homeworld == v[1])
                        fila.Enqueue(P[i].nome);
                }
            }
            else if (v[0] == "Dequeue"){
                int qtds = 0;
                if (v[1] == "all")
                    qtds = fila.Count;
                else
                    qtds = int.Parse(v[1]);
                for(int i = 0; i < qtds; i++){
                    string nome_pers = fila.Peek();
                    Console.WriteLine(nome_pers);
                    fila.Dequeue();
                }
            }
        }
    }
}

class Personagem
{
    public string nome { get; private set; }
    public double peso = 0.0;
    public int altura = 0;
    public string corDoCabelo { get; private set; }
    public string corDaPele { get; private set; }
    public string corDosOlhos { get; private set; }
    public string anoNascimento { get; private set; }
    public string genero { get; private set; }
    public string homeworld { get; private set; }

    public Personagem(string linhaP)
    {
        string[] valores = linhaP.Split(";");
        int.TryParse(valores[1], out this.altura);
        double.TryParse(valores[2], out this.peso);
        this.nome = valores[0];
        this.corDoCabelo = valores[3];
        this.corDaPele = valores[4];
        this.corDosOlhos = valores[5];
        this.anoNascimento = valores[6];
        this.genero = valores[7];
        this.homeworld = valores[8];
    }

    public bool getCaracteristica(string caracteristica, string valor)
    {
        switch (caracteristica)
        {
            case "nome":
                return ConsultaString(this.nome, valor);
            case "corDoCabelo":
                return ConsultaString(this.corDoCabelo, valor);
            case "corDaPele":
                return ConsultaString(this.corDaPele, valor);
            case "corDosOlhos":
                return ConsultaString(this.corDosOlhos, valor);
            case "anoNascimento":
                return ConsultaString(this.anoNascimento, valor);
            case "genero":
                return ConsultaString(this.genero, valor);
            case "homeworld":
                return ConsultaString(this.homeworld, valor);
            default:
                return false;
        }
    }

    private bool ConsultaString(string s1, string s2)
    {
        bool resp = false;
        if (s1.Equals(s2, StringComparison.OrdinalIgnoreCase))
        {
            resp = true;
        }
        return resp;
    }   
}
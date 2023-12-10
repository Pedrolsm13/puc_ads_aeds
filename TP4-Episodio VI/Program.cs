using System;
using System.Collections.Generic;
using System.Linq;
 
class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Personagem> P = new List<Personagem>(n);
        //Stack<string> pilha = new Stack<string>();
        //Queue<string> fila = new Queue<string>();
 
        for (int i = 0; i < n; i++)
        {
            string linhaP = Console.ReadLine();
            P.Add(new Personagem(linhaP));
        }

        bool troca = true;
        for(int i = 0; i < P.Count-1 && troca; i++){
            troca = false;
            for(int j = 0; j < P.Count-(i+1); j++){
                if(P[j].nome.CompareTo(P[j+1].nome) > 0){
                    Personagem aux = P[j];
                    P[j] = P[j+1];
                    P[j+1] = aux;
                    troca = true;
                }
            }
        }
        for(int k = 0; k < P.Count; k++){
            Console.WriteLine($"{P[k].nome}-{P[k].peso}-{P[k].altura}-{P[k].corDoCabelo}-{P[k].corDaPele}-{P[k].corDosOlhos}-{P[k].anoNascimento}-{P[k].genero}-{P[k].homeworld}");
        }
        /*var listOrdenada = P.ToList().OrderBy(p=> p.nome);
        foreach (var item in listOrdenada)
        {
            Console.WriteLine(item.nome);
        }*/
    }
}
class Personagem
{
    public string nome { get; private set; }
    public string peso { get; private set; }
    public string altura { get; private set; }
    public string corDoCabelo { get; private set; }
    public string corDaPele { get; private set; }
    public string corDosOlhos { get; private set; }
    public string anoNascimento { get; private set; }
    public string genero { get; private set; }
    public string homeworld { get; private set; }
 
    public Personagem(string linhaP)
    {
        string[] valores = linhaP.Split(';');
        this.nome = valores[0];
        this.peso = valores[1];
        this.altura = valores[2];
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
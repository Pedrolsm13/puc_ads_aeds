using System;

class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Personagem[] P = new Personagem[n];
        for (int i = 0; i < n; i++)
        {
            string linhaP = Console.ReadLine();
            P[i] = new Personagem(linhaP);
        }

        int m = int.Parse(Console.ReadLine());
        for (int j = 0; j < m; j++)
        {
            string linhar = Console.ReadLine();
            string[] v = linhar.Split(" ");
            
            if (v[0] == "altura")
            {
                int c = 0;
                int vi = int.Parse(v[1]);
                int vf = int.Parse(v[2]);
                foreach (Personagem a in P)
                {
                    if (a.altura >= vi && a.altura <= vf)
                    {
                        c++;
                    }
                }
                Console.WriteLine($"{v[0]} {c}");
            }

            else if (v[0] == "peso")
            {
                int c = 0;
                double pi = double.Parse(v[1]);
                double pf = double.Parse(v[2]);
                foreach (Personagem b in P)
                {
                    if (b.peso >= pi && b.peso <= pf)
                    {
                        c++;
                    }
                }
                Console.WriteLine($"{v[0]} {c}");
            }
            
            else
            {
                int c = 0;
                foreach (Personagem d in P)
                {
                    if (d.getCaracteristica(v[0], v[1]))
                    {
                        c++;
                    }
                }
                Console.WriteLine($"{v[0]} {c}");
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
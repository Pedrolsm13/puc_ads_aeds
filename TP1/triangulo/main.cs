using System;

class Program
{
    public static void Main(string[] args)
    {
        int q = 0;
        string qtd = Console.ReadLine();
        q = int.Parse(qtd);
        int[,] lado = new int[q, 3];
        for (int i = 0; i < q; i++)
        {
            string linha = Console.ReadLine();
            string[] vet = linha.Split(' ');
            for (int j = 0; j < 3; j++)
            {
                lado[i, j] = int.Parse(vet[j]);
            }
        }
        ordena(ref lado);
        for (int k = 0; k < q; k++)
        {
            if (lado[k, 2] >= lado[k, 0] + lado[k, 1])
                Console.WriteLine('n');
            else if (lado[k, 2] == Math.Sqrt(Math.Pow(lado[k, 0], 2) + Math.Pow(lado[k, 1], 2)))
                Console.WriteLine('r');
            else if (lado[k, 2] > Math.Sqrt(Math.Pow(lado[k, 0], 2) + Math.Pow(lado[k, 1], 2)))
                Console.WriteLine('o');
            else if (lado[k, 2] < Math.Sqrt(Math.Pow(lado[k, 0], 2) + Math.Pow(lado[k, 1], 2)))
                Console.WriteLine('a');
        }
    }
    public static void ordena(ref int[,] lado)
    {
        int aux = 0;
        for (int i = 0; i < lado.GetLength(0); i++)
        {
            for (int j = 0; j < 3 - 1; j++)
            {
                for (int x = 0; x < 3 - 1 - j; x++)
                {
                    if (lado[i, j] > lado[i, j + 1])
                    {
                        aux = lado[i, j];
                        lado[i, j] = lado[i, j + 1];
                        lado[i, j + 1] = aux;
                    }
                }
            }
        }
    }
}
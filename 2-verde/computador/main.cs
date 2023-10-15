using System;

class Program
{
    public static void Main(string[] args)
    {
        int n = 0, qtd = 0, func = 0, i = 0, v = 0, c = 0;
        string linha = Console.ReadLine();
        string[] vet = linha.Split(' ');
        n = int.Parse(vet[0]);
        qtd = int.Parse(vet[1]);
        int[] vetor = new int[n];
        for (int j = 0; j < qtd; j++)
        {
            string linha2 = Console.ReadLine();
            string[] vet1 = linha2.Split(' ');
            func = int.Parse(vet1[0]);
            if (func == 1)
            {
                i = int.Parse(vet1[1]);
                v = int.Parse(vet1[2]);
                c = v;
                for (int k = 0; k < v; k++)
                {
                    vetor[i - 1] += c--;
                    i++;
                    if (i - 1 == n - 1)
                    {
                        k = v;
                    }
                }
            }
            else if (func == 2)
            {
                i = int.Parse(vet1[1]);
                v = int.Parse(vet1[2]);
                c = v;
                for (int l = 0; l < v; l++)
                {
                    vetor[i - 1] += c--;
                    i--;
                    if (i == 0)
                    {
                        l = v;
                    }
                }
            }
            else if (func == 3)
            {
                i = int.Parse(vet1[1]);
                Console.WriteLine(vetor[i - 1]);
            }
            /*for (int m = 0; m < n; m++)
            {
                Console.Write(vetor[m] + " ");
            }*/
        }
    }
}
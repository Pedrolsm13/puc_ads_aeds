using System;

class Program {
  public static void Main (string[] args) {
    int l = 0, c = 0, d = 1;
    string linha = Console.ReadLine();
    string [] vet = linha.Split(' ');
    l = int.Parse(vet[0]);
    c = int.Parse(vet[1]);
    int [,] mat = new int[l,c];
    for (int i = 0; i < l; i++){
      string linha1 = Console.ReadLine();
      string [] vet1 = linha1.Split(' ');
      for ( int j = 0; j < c; j++){
        mat[i,j] = int.Parse(vet1[j]);
        if (i >= j && mat[i,j] != mat[j,i] || l != c)
          d = 0;
      }
    }
    Console.WriteLine(d);
  }
}
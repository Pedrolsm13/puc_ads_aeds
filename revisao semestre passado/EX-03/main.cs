using System;

class Program {
  public static void Main (string[] args) {
    Random r = new Random();
    int[,] mat = new int[4,4];
    for (int i = 0; i < 4; i++){
      for (int j = 0; j < 4; j++){
        mat[i,j] = r.Next(0,9);
        if (i <= j)
          Console.Write(mat[i,j]);
        else
          Console.Write(" ");
      }
      Console.WriteLine();
    }
  }
}
using System;

class Program {
  public static void Main (string[] args) {
    int N = 0, G = 0;
    double P = 0, res = 0, res1 = 1000;
    N = int.Parse(Console.ReadLine());
    for (int i = 0; i < N; i++){
      String linha = Console.ReadLine();
      String []valores = linha.Split(' ');
      P = double.Parse(valores[0]);
      G = int.Parse(valores[1]);
      res = P / G * 1000;
      if (res <= res1)
        res1 = res;
    }
    Console.WriteLine(res1.ToString("F2"));
  }
}
using System;

class Program {
  public static void Main (string[] args) {
    int x = 0, y = 0, consumo = 0, valor = 0;
    x = int.Parse(Console.ReadLine());
    y = int.Parse(Console.ReadLine());
    for (int i = 0; i < y; i++){
      consumo = int.Parse(Console.ReadLine());
      valor += x - consumo;
    }
    Console.WriteLine(valor + x);
  }
}
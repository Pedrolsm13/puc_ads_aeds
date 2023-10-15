using System;

class Program {
  public static void Main (string[] args) {
    Console.WriteLine ("digite um valor n");
    int n = int.Parse(Console.ReadLine());
    int somatorio = soma(n);
    Console.WriteLine(somatorio);
  }
  static int soma(int n){
    int i = 0;
    if (n > i){
      return n + soma(n-1);
    }
    return n;
  }
}
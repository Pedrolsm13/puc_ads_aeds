using System;

class Program {
  public static void Main (string[] args) {
    Console.WriteLine ("digite um numero inteiro");
    int numero = int.Parse(Console.ReadLine());
    binario(numero);
  }
  static void binario(int numero){
    int i;
    if (numero > 0){
     i = numero % 2; 
      binario(numero/2);
      Console.Write(i+" ");
    }
  }
}
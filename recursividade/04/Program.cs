using System;

class Program {
  public static void Main (string[] args) {
    Console.WriteLine ("digite um numero inteiro");
    string numero = Console.ReadLine();
    int i = 0;
    i = contagem(numero, i);
    Console.WriteLine(i + " digitos");
  }
  static int contagem(string numero, int i){
    if (numero.Length > i){
      return contagem(numero,++i);
    }
    return i;
  }
}
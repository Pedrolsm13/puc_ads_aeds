using System;

class Program {
  public static void Main (string[] args) {
    Console.WriteLine ("Digite um numero com pelo menos 8 casas");
    string n = Console.ReadLine();
    Console.WriteLine ("Digite um possivel numero para saber quantas vezes ele se repete");
    char k = char.Parse(Console.ReadLine());
    int c = n.Length-1;
    int resp = 0;
    resp = repete(n,k,c);
    Console.WriteLine(resp);
  }
  static int repete(string n, char k, int c){
    int i = 0;
    if (c >= 0){
      if(n[c] == k){
        i++;
      }
      return i + repete(n, k, c-1);
    }
    return i;
  }
}
using System;

class Program {
  public static void Main (string[] args) {
    int x = 0, c = 0;
    x = int.Parse(Console.ReadLine());
    int [] num = new int [x];
    char [] lad = new char [x];
    for (int i = 0; i < x; i++){
      String linha = Console.ReadLine();
      String []valores = linha.Split(' ');
      num[i] = int.Parse(valores[0]);
      lad[i] = char.Parse(valores[1]);
      for (int j = 0; j < x-1; j++){
        if (num[i] == num[j] && lad[i] != lad[j]){
          c++;
          num[i] = 0;
          num[j] = 0;
          j = x;
        }
      }
    }
    Console.WriteLine(c);
  }
}
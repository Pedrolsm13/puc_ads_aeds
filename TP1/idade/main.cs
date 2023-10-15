using System;

class Program {
  public static void Main (string[] args) {
    int m = 0, a = 0, b = 0, c = 0, velho= 0;
    m = int.Parse(Console.ReadLine());
    a = int.Parse(Console.ReadLine());
    velho = a;
    b = int.Parse(Console.ReadLine());
    if(b > a){
      velho = b;
    }
    c = m - a - b;
    if(c > velho){
      velho = c;
    }
    Console.WriteLine(velho);    
  }
}
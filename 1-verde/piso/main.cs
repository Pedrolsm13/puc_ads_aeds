using System;

class Program {
  public static void Main (string[] args) {
    int l = 0, c = 0, tip1 = 0, tip2 = 0;
    l = int.Parse(Console.ReadLine());
    c = int.Parse(Console.ReadLine());
    tip1 = l*c+((l-1)*(c-1));
    tip2 = (l+c)*2 - 4 ;
    Console.WriteLine(tip1);
    Console.WriteLine(tip2);
  }
}
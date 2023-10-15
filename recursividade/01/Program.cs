using System;

class Program {
  public static void Main (string[] args) {
    int x = 10;
    int [] vet = new int[x];
    Random r = new Random();
    for (int i = 0; i < x; i++){
      vet[i] = r.Next(0,50);
      Console.WriteLine(vet[i]);
    }
    //invert(vet,x);                     Procedimento
    int [] ivet = new int[x];
    ivet = invertfunc(vet,x,ivet,0);
    for (int i = 0; i < x; i++){
      Console.WriteLine(ivet[i]);
    }
  }
  static int [] invertfunc(int [] vet,int x, int [] ivet, int z){
    if (x > 0){
      ivet [z++] = vet[x-1];
      invertfunc(vet, x-1, ivet, z);
    }
    return ivet;
  }
  static void invert(int [] vet,int x){
    if (x > 0){
      Console.WriteLine(vet[x-1]);
      invert(vet,x-1);
    }
  }
}
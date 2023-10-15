using System;

class Program {
  public static void Main (string[] args) {
    Random r = new Random();
    int c = 0, d = 0, e = 0, f = 0;
    int[] vet = new int[10];
    for (int i = 0; i < 10; i++){
      vet[i] = r.Next(-10,11);
      if (vet[i] < 0){
        c++;}
      else{
        d++;
        }
    }
    
    int[] pos = new int[d];
    int[] neg = new int[c];
    for (int j = 0; j < 10; j++){
      if (vet[j] < 0){
        neg[e++] = vet[j];
        }
      else{
        pos[f++] = vet[j];
        }
    }

    Console.WriteLine("qtd numeros positivos: "+ d);
      Console.WriteLine("os numeros sao:");
    for (int k=0; k < d;k++){
      Console.Write(pos[k]+" ");
    }
    Console.WriteLine();
      Console.WriteLine("qtd numeros negativos: "+ c);
    for (int l=0; l<c;l++){
      Console.Write(neg[l]+" ");
    }
    
  }
}
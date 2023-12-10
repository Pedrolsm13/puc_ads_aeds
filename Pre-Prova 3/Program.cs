using System;

class Program{
    public static void Main(string [] args){
        int qtd_pesquisas = 0, qtd_elementos = 0, valor = 0;
        qtd_pesquisas = int.Parse(Console.ReadLine());
        for (int i = 0; i < qtd_pesquisas; i++){
            ArvoreBinaria arvore = new ArvoreBinaria();
            qtd_elementos = int.Parse(Console.ReadLine());
            string [] linha = Console.ReadLine().Split(' ');
            for (int j = 0; j < qtd_elementos; j++){
                valor = int.Parse(linha[j]);
                arvore.inserir(valor);
            }
            Console.WriteLine($"Case {i+1}:");
            Console.Write("Pre.: ");
            arvore.caminharPre();
            Console.WriteLine();
            Console.Write("In..: ");
            arvore.caminharCentral();
            Console.WriteLine();
            Console.Write("Post: ");
            arvore.caminharPos();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
class No{
    public int elemento;
    public No esq;
    public No dir;
    public No(int elemento){
        this.elemento = elemento;
        this.esq = null;
        this.dir = null;
    }
    public No(int elemento, No esq, No dir){
        this.elemento = elemento;
        this.esq = esq;
        this.dir = dir;
    }
}
class ArvoreBinaria {
    No raiz;
    public ArvoreBinaria(){
        raiz = null;
    }
    public void inserir(int x){
        raiz = inserir(x, raiz);
    }
    public No inserir(int x, No i){
        if (i == null){
            i = new No(x);
        }
        else if (x < i.elemento){
            i.esq = inserir(x, i.esq);
        } 
        else if (x > i.elemento){
            i.dir = inserir(x, i.dir);
        }
        /*else{
            throw new Exception("Erro!");
        }*/
        return i;
    }
    public void inserirPai(int x){
        if (raiz == null){
            raiz = new No(x);
        } 
        else if (x < raiz.elemento){
            InserirPai(x, raiz.esq, raiz);
        }
        else if (x > raiz.elemento){
            InserirPai(x, raiz.dir, raiz);
        }
        else{
            throw new Exception("Erro!");
        }
    }
    void InserirPai(int x, No i, No pai) {
        if (i == null) {
            if (x < pai.elemento){
                pai.esq = new No(x);
            }
            else{
                pai.dir = new No(x);
            }
        }
        else if (x < i.elemento){
            InserirPai(x, i.esq, i);
        }
        else if (x > i.elemento){
            InserirPai(x, i.dir, i);
        }
        else{
            throw new Exception("Erro!");
        }
    }
    public bool pesquisar(int x){
        return pesquisar(x, raiz);
    }
    bool pesquisar(int x, No i) {
        bool resp;
        if (i == null){
            resp = false;
        }
        else if (x == i.elemento){
            resp = true;
        }
        else if (x < i.elemento){
            resp = pesquisar(x, i.esq);
        }
        else{
            resp = pesquisar(x, i.dir);
        }
        return resp;
    }
    public void caminharCentral(){
        No i = raiz;
        if (i != null){
            caminharCentral(i.esq);
            Console.Write(i.elemento + " ");
            caminharCentral(i.dir);
        }
    }
    public void caminharCentral(No i){
        if (i != null){
            caminharCentral(i.esq);
            Console.Write(i.elemento + " ");
            caminharCentral(i.dir);
        }
    }
    public void caminharPos(){
        No i = raiz;
        if (i != null) {
            caminharPos(i.esq);
            caminharPos(i.dir);
            Console.Write(i.elemento + " ");
        }
    }
    public void caminharPos(No i){
        if (i != null) {
            caminharPos(i.esq);
            caminharPos(i.dir);
            Console.Write(i.elemento + " ");
        }
    }
    public void caminharPre(){
        No i = raiz;
        if (i != null) {
            Console.Write(i.elemento + " ");
            caminharPre(i.esq);
            caminharPre(i.dir);
        }
    }
    public void caminharPre(No i){
        if (i != null) {
            Console.Write(i.elemento + " ");
            caminharPre(i.esq);
            caminharPre(i.dir);
        }
    }
    public void remover(int x){
        raiz = remover(x, raiz);
    }
    public No remover(int x, No i){
        if (i == null) {
            throw new Exception("Erro!");
        } else if (x < i.elemento) {
            i.esq = remover(x, i.esq);
        } else if (x > i.elemento) {
            i.dir = remover(x, i.dir);
        } else if (i.dir == null) {
            i = i.esq;
        } else if (i.esq == null) {
            i = i.dir;
        } else {
            i.esq = Maioresq(i, i.esq);
        }
        return i;
    }
    public No Maioresq(No i, No j) {
        if (j.dir == null) {
            i.elemento = j.elemento;
            j = j.esq;
        } else {
            j.dir = Maioresq(i, j.dir);
        }
        return j;
    }
    public int getMaior(){
        int resp = -1;
        if(raiz != null){
            No i;
            for(i = raiz; i.dir != null; i = i.dir);
            resp = i.elemento;
        }
        return resp;
    }
    public int getMenor(){
        int resp = -1;
        if(raiz != null){
            No i;
            for(i = raiz; i.esq != null; i = i.esq);
            resp = i.elemento;
        }
        return resp;
    }
}
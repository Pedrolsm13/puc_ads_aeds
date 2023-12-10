using System;

class Program
{
    public static void Main(string[] args)
    {
        int qtd_pesquisas = 0, qtd_elementos = 0, valor = 0;
        qtd_pesquisas = int.Parse(Console.ReadLine());
        for (int i = 0; i < qtd_pesquisas; i++)
        {
            AVLTree arvore = new AVLTree();
            qtd_elementos = int.Parse(Console.ReadLine());
            string[] linha = Console.ReadLine().Split(' ');
            for (int j = 0; j < qtd_elementos; j++)
            {
                valor = int.Parse(linha[j]);
                arvore.inserir(valor);
            }
            Console.WriteLine($"Case {i + 1}:");
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

class AVLNode
{
    public int elemento;
    public int altura;
    public AVLNode esq;
    public AVLNode dir;

    public AVLNode(int elemento){
        this.elemento = elemento;
        this.altura = 1;
        this.esq = null;
        this.dir = null;
    }
}

class AVLTree{
    private AVLNode raiz;

    public AVLTree(){
        raiz = null;
    }

    public void inserir(int x){
        raiz = inserir(x, raiz);
    }

    private AVLNode inserir(int x, AVLNode i){
        if (i == null){
            return new AVLNode(x);
        }

        if (x < i.elemento){
            i.esq = inserir(x, i.esq);
        }
        else if (x > i.elemento){
            i.dir = inserir(x, i.dir);
        }

        // Atualiza a altura do nó atual
        i.altura = 1 + Math.Max(altura(i.esq), altura(i.dir));

        // Realiza as rotações necessárias para manter o balanceamento
        int fatorBalanceamento = calcularFatorBalanceamento(i);
        if (fatorBalanceamento > 1){
            if (x < i.esq.elemento){
                return rotacaoDireita(i);
            }
            else{
                i.esq = rotacaoEsquerda(i.esq);
                return rotacaoDireita(i);
            }
        }
        else if (fatorBalanceamento < -1)
        {
            if (x > i.dir.elemento){
                return rotacaoEsquerda(i);
            }
            else{
                i.dir = rotacaoDireita(i.dir);
                return rotacaoEsquerda(i);
            }
        }

        return i;
    }

    private int altura(AVLNode no){
        return (no == null) ? 0 : no.altura;
    }

    private int calcularFatorBalanceamento(AVLNode no){
        return altura(no.esq) - altura(no.dir);
    }

    private AVLNode rotacaoDireita(AVLNode y){
        AVLNode x = y.esq;
        AVLNode T2 = x.dir;

        // Realiza a rotação
        x.dir = y;
        y.esq = T2;

        // Atualiza alturas
        y.altura = 1 + Math.Max(altura(y.esq), altura(y.dir));
        x.altura = 1 + Math.Max(altura(x.esq), altura(x.dir));

        return x;
    }

    private AVLNode rotacaoEsquerda(AVLNode x){
        AVLNode y = x.dir;
        AVLNode T2 = y.esq;

        // Realiza a rotação
        y.esq = x;
        x.dir = T2;

        // Atualiza alturas
        x.altura = 1 + Math.Max(altura(x.esq), altura(x.dir));
        y.altura = 1 + Math.Max(altura(y.esq), altura(y.dir));

        return y;
    }

    public void caminharCentral(){
        caminharCentral(raiz);
    }

    private void caminharCentral(AVLNode no){
        if (no != null){
            caminharCentral(no.esq);
            Console.Write(no.elemento + " ");
            caminharCentral(no.dir);
        }
    }

    public void caminharPos(){
        caminharPos(raiz);
    }

    private void caminharPos(AVLNode no){
        if (no != null){
            caminharPos(no.esq);
            caminharPos(no.dir);
            Console.Write(no.elemento + " ");
        }
    }

    public void caminharPre(){
        caminharPre(raiz);
    }

    private void caminharPre(AVLNode no){
        if (no != null){
            Console.Write(no.elemento + " ");
            caminharPre(no.esq);
            caminharPre(no.dir);
        }
    }
}

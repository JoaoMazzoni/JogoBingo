int qtdJogadores = 0;
int numeroJogadores = 0;
int[] jogador;
int[,] cartelas = new int[5, 6];
int totalCartelas = 0;
int qtdlinhas = 5;
int qtdcolunas = 6;
int[,] cartela = new int[qtdlinhas, qtdcolunas];
int contador = 0;
int numeroGerado = 0;
int[] vetorNumerosSorteados = new int[100];


void guardarJogadores()
{
    Console.Write("\n|Digite a quantidade de jogadores: ");
    qtdJogadores = int.Parse(Console.ReadLine());
    jogador = new int[qtdJogadores];
}

void guardarCartelas()
{
    for (int i = 0; i < qtdJogadores; i++)
    {
        Console.Write("\n|Insira a quantidade de cartelas do {0}° jogador: ", i + 1);
        jogador[i] = int.Parse(Console.ReadLine());

    }
}

void contabilizarCartelas()
{
    for (int i = 0; i < qtdJogadores; i++)
    {
        totalCartelas += jogador[i];
    }
    Console.Write("\n|Total de Cartelas a Serem Geradas: {0}\n\n", totalCartelas);
}

void imprimirMatriz(int[,] cartela)
{
    for (int linha = 0; linha < qtdlinhas; linha++)
    {
        Console.WriteLine();

        for (int coluna = 0; coluna < qtdcolunas; coluna++)
        {
            Console.Write(cartela[linha, coluna] + " | ");
        }

    }
}

for (int i = 0; i < 100; i++)
{
    vetorNumerosSorteados[i] = 0;
}


void gerarCartela(int[,] cartela)
{
    
   
        for (int linha = 0; linha < qtdlinhas; linha++)
        {
            for (int coluna = 0; coluna < qtdcolunas - 1; coluna++)
            {
                numeroGerado = new Random().Next(1, 100);
                if (vetorNumerosSorteados[numeroGerado] == 0)
                {
                    cartela[linha, coluna] = numeroGerado;
                    vetorNumerosSorteados[numeroGerado] = 1;
                }
                else
                {
                    coluna--;
                }

            }
        }

        Console.WriteLine("\n\n");
        imprimirMatriz(cartela);
        contador++;


}



guardarJogadores();
guardarCartelas();
contabilizarCartelas();
do
{
    gerarCartela(cartela);
} while (contador < totalCartelas);
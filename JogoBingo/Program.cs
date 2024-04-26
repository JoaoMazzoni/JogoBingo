int numeroBingo = 0;
int qtdJogadores = 0;
int contador;
int qtdlinhas = 5;
int qtdcolunas = 5;
int nCartelas = 0;
int resultadoCartela;
int numeroGerado = 0;
int resultadoLinha = 0;
bool linhaFechada = false;
int[] jogadoresPontos = new int[0];
int[] vetorNumeroBingo = new int[100];
int[] vetorNumerosSorteados = new int[100];
int[][][,] cartelasJogadores; //1-[] número do Jogador | 2-[] Quantidade de Cartelas | 3-[,] Cartela/Matriz

void guardarJogadores()
{
    do
    {
        Console.Write("\n|Digite a quantidade de jogadores: ");
        qtdJogadores = int.Parse(Console.ReadLine());
        if (qtdJogadores < 2)
        {
            Console.WriteLine("\n\n|SÃO NECESSÁRIOS 2 OU MAIS JOGADORES PARA JOGAR BINGO!|\n");
        }
    }while(qtdJogadores < 2);
    cartelasJogadores = new int[qtdJogadores][][,];
}
void Cartelas()
{
    Console.Write("\n|Insira a quantidade de cartelas dos jogadores: ");
    nCartelas = int.Parse(Console.ReadLine());

    for (int j = 0; j < qtdJogadores; j++)
    {
        // Inicialize cada elemento de cartelasJogadores[j]
        cartelasJogadores[j] = new int[nCartelas][,];

        for (int nc = 0; nc < nCartelas; nc++)
        {
            for (int i = 0; i < 100; i++)
            {
                vetorNumerosSorteados[i] = 0;
            }

            // Inicialize cada cartela dentro de cartelasJogadores[j]
            cartelasJogadores[j][nc] = new int[qtdlinhas, qtdcolunas];

            for (int linha = 0; linha < qtdlinhas; linha++)
            {
                for (int coluna = 0; coluna < qtdcolunas; coluna++)
                {
                    cartelasJogadores[j][nc][linha, coluna] = new Random().Next(1, 100);

                    numeroGerado = new Random().Next(1, 100);
                    if (vetorNumerosSorteados[numeroGerado] == 0)
                    {
                        cartelasJogadores[j][nc][linha, coluna] = numeroGerado;
                        vetorNumerosSorteados[numeroGerado] = 1;
                    }
                    else
                    {
                        coluna--;
                    }

                }
            }
        }
    }
}
void imprimirMatriz(int[,] matriz)
{
    // Percorre cada linha da matriz
    for (int linha = 0; linha < qtdlinhas; linha++)
    {
        Console.WriteLine(); // Adiciona uma nova linha para cada linha da matriz

        // Percorre cada coluna da matriz
        for (int coluna = 0; coluna < qtdcolunas; coluna++)
        {
            // Imprime o valor na posição [linha, coluna] seguido de um separador
            Console.Write("{0:00} ", matriz[linha, coluna] );
        }
    }
}
void imprimirCartelasJogadores()
{
    // Percorre cada jogador
    for (int j = 0; j < qtdJogadores; j++)
    {
        Console.WriteLine($"\nJogador {j + 1}:");

        // Percorre cada cartela do jogador atual
        for (int nc = 0; nc < nCartelas; nc++)
        {
            Console.WriteLine($"\nCartela {nc + 1}:");
            imprimirMatriz(cartelasJogadores[j][nc]);
            Console.WriteLine(); // Adiciona uma linha em branco entre cada cartela
        }

        Console.WriteLine(); // Adiciona uma linha em branco entre cada jogador
    }
}
void sortearBingo()
{
    resultadoCartela = 0;
    bool cartelaCompleta = false;
    bool linhaPontuada = false;
    bool colunaPontuada = false;
    int jogadorLinhaPontuada = -1;
    int jogadorColunaPontuada = -1;

    while (cartelaCompleta == false)
    {
        int numeroBingo;
        do
        {
            numeroBingo = new Random().Next(1, 100);
        } while (vetorNumeroBingo[numeroBingo] == 1);

        vetorNumeroBingo[numeroBingo] = 1;
        Console.WriteLine("\n\n|NÚMERO SORTEADO|: {0}\n\n", numeroBingo);

        for (int j = 0; j < qtdJogadores; j++)
        {
            for (int nc = 0; nc < nCartelas; nc++)
            {
                for (int linha = 0; linha < qtdlinhas; linha++)
                {
                    for (int coluna = 0; coluna < qtdcolunas; coluna++)
                    {
                        if (cartelasJogadores[j][nc][linha, coluna] == numeroBingo)
                        {
                            cartelasJogadores[j][nc][linha, coluna] = 0;
                            
                        }
                    }
                }
            }
        }

        if (linhaPontuada == false)
        {
            for (int j = 0; j < qtdJogadores; j++)
            {
                for (int nc = 0; nc < nCartelas; nc++)
                {
                    for (int linha = 0; linha < qtdlinhas; linha++)
                    {
                        bool linhaCompleta = true;
                        for (int coluna = 0; coluna < qtdcolunas; coluna++)
                        {
                            if (cartelasJogadores[j][nc][linha, coluna] != 0)
                            {
                                linhaCompleta = false;
                                break;
                            }
                        }
                        if (linhaCompleta)
                        {
                            Console.WriteLine("\n|O JOGADOR {0} FEZ 1 PONTO AO COMPLETAR UMA LINHA!|\n", j + 1);
                            linhaPontuada = true;
                            jogadorLinhaPontuada = j;
                            break;
                        }
                    }
                    if (linhaPontuada) break;
                }
                if (linhaPontuada) break;
            }
        }

        if (colunaPontuada == false)
        {
            for (int j = 0; j < qtdJogadores; j++)
            {
                for (int nc = 0; nc < nCartelas; nc++)
                {
                    for (int coluna = 0; coluna < qtdcolunas; coluna++)
                    {
                        bool colunaCompleta = true;
                        for (int linha = 0; linha < qtdlinhas; linha++)
                        {
                            if (cartelasJogadores[j][nc][linha, coluna] != 0)
                            {
                                colunaCompleta = false;
                                break;
                            }
                        }
                        if (colunaCompleta)
                        {
                            Console.WriteLine("\n|O JOGADOR {0} FEZ 1 PONTO AO COMPLETAR UMA COLUNA!|\n", j + 1);
                            colunaPontuada = true;
                            jogadorColunaPontuada = j;
                            break;
                        }
                    }
                    if (colunaPontuada) break;
                }
                if (colunaPontuada) break;
            }
        }

        // Verificar se algum jogador completou a cartela
        for (int j = 0; j < qtdJogadores; j++)
        {
            for (int nc = 0; nc < nCartelas; nc++)
            {
                bool cartelaCompletaJogador = true;
                for (int linha = 0; linha < qtdlinhas; linha++)
                {
                    for (int coluna = 0; coluna < qtdcolunas; coluna++)
                    {
                        if (cartelasJogadores[j][nc][linha, coluna] != 0)
                        {
                            cartelaCompletaJogador = false;
                            break;
                        }
                    }
                    if (cartelaCompletaJogador == false)
                        break;
                }
                if (cartelaCompletaJogador)
                {
                    Console.WriteLine("|BINGO!|");
                    Console.WriteLine("\n|O JOGADOR {0} COMPLETOU UMA CARTELA!|\n\n", j + 1);
                    jogadoresPontos[j] += 5;
                    cartelaCompleta = true;
                    break;
                }
            }
            if (cartelaCompleta)
                break;
        }

        imprimirCartelasJogadores();

        Console.ReadKey();
        Console.Clear();
    }

    // Adicionar pontos aos jogadores
    if (jogadorLinhaPontuada != -1)
        jogadoresPontos[jogadorLinhaPontuada] += 1;
    if (jogadorColunaPontuada != -1)
        jogadoresPontos[jogadorColunaPontuada] += 1;
}

guardarJogadores();
Cartelas();
imprimirCartelasJogadores();
sortearBingo();

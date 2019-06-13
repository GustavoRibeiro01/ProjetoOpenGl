using System;

namespace ProjetoNave
{
    public static class Funcao
    {
        static int maxNivel1 = 5;
        static int maxNivel2 = 10;
        static int maxNivel3 = 15;
        static int maxNivel4 = 20;
        static int maxNivel5 = 35;

        static void VerificaFinalPedra(ref double x_pedra_direita, ref double y_pedra_direita, ref double velocidade_pedra_direita, ref double x_pedra_esquerda, ref double y_pedra_esquerda, ref double velocidade_pedra_esquerda, ref double pontuacao, ref bool duas_pedra)
        {

            if (y_pedra_direita <= -9.0f)
            {
                //Velocidade
                if (pontuacao <= maxNivel1)
                {
                    velocidade_pedra_direita = RandomNumber(20, 35) / 10000;
                }
                else if (pontuacao <= maxNivel2)
                {
                    velocidade_pedra_direita = RandomNumber(35, 50) / 10000;
                }
                else if (pontuacao <= maxNivel3)
                {
                    velocidade_pedra_direita = RandomNumber(20, 35) / 10000;
                    duas_pedra = true;
                }
                else if (pontuacao <= maxNivel4)
                {
                    velocidade_pedra_direita = RandomNumber(35, 50) / 10000;
                }
                else if (pontuacao <= maxNivel5)
                {
                    velocidade_pedra_direita = RandomNumber(50, 65) / 10000;
                }

                //Posição
                y_pedra_direita = 0;
                if (duas_pedra)
                {
                    x_pedra_direita = RandomNumber(1, 5);
                }
                else
                {
                    x_pedra_direita = RandomNumber(0, 5);
                    if (RandomNumber(1, 2) == 1) //se 1 mudar para negativo
                    {
                        x_pedra_direita *= -1;
                    }

                }
            }
            if (duas_pedra)
            {
                if (y_pedra_esquerda <= -9.0f)
                {
                    //Velocidade
                    if (pontuacao <= maxNivel1)
                    {
                        velocidade_pedra_esquerda = RandomNumber(20, 35) / 10000;
                    }
                    else if (pontuacao <= maxNivel2)
                    {
                        velocidade_pedra_esquerda = RandomNumber(35, 50) / 10000;
                    }
                    else if (pontuacao <= maxNivel3)
                    {
                        velocidade_pedra_esquerda = RandomNumber(20, 35) / 10000;
                        duas_pedra = true;
                    }
                    else if (pontuacao <= maxNivel4)
                    {
                        velocidade_pedra_esquerda = RandomNumber(35, 50) / 10000;
                    }
                    else if (pontuacao <= maxNivel5)
                    {
                        velocidade_pedra_esquerda = RandomNumber(50, 65) / 10000;
                    }

                    //Posição
                    y_pedra_esquerda = 0;

                    x_pedra_esquerda = RandomNumber(1, 5) * -1;
                    
                }
            }

        }

        private static int RandomNumber(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}

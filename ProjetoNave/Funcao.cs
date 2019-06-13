using System;

namespace ProjetoNave
{
    public static class Funcao
    {
        static int maxNivel1 = 3;
        static int maxNivel2 = 6;
        static int maxNivel3 = 9;
        static int maxNivel4 = 12;
        static int maxNivel5 = 15;

        public static void VerificaFinalPedra(ref float x_pedra_direita, ref float y_pedra_direita, ref float velocidade_pedra_direita, ref float x_pedra_esquerda, ref float y_pedra_esquerda, ref float velocidade_pedra_esquerda, ref int pontuacao, ref bool duas_pedra, ref float rotacao)
        {

            if (y_pedra_direita <= -9.0f)
            {
                //Velocidade
                if (pontuacao <= maxNivel1)
                {
                    velocidade_pedra_direita = RandomNumber(30, 45) / 10000;
                    //rotacao = 400.1f;
                }
                else if (pontuacao <= maxNivel2)
                {
                    velocidade_pedra_direita = RandomNumber(45, 60) / 10000;
                    //rotacao = 0.2f;
                }
                else if (pontuacao <= maxNivel3)
                {
                    velocidade_pedra_direita = RandomNumber(30, 45) / 10000;
                    //rotacao = 0.3f;
                    duas_pedra = true;
                }
                else if (pontuacao <= maxNivel4)
                {
                    velocidade_pedra_direita = RandomNumber(45, 50) / 10000;
                }
                else if (pontuacao <= maxNivel5)
                {
                    velocidade_pedra_direita = RandomNumber(60, 80) / 10000;
                }

                //Posição
                y_pedra_direita = 8.7f;
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
                        velocidade_pedra_esquerda = RandomNumber(30, 45) / 10000;
                    }
                    else if (pontuacao <= maxNivel2)
                    {
                        velocidade_pedra_esquerda = RandomNumber(45, 60) / 10000;
                    }
                    else if (pontuacao <= maxNivel3)
                    {
                        velocidade_pedra_esquerda = RandomNumber(30, 45) / 10000;
                        duas_pedra = true;
                    }
                    else if (pontuacao <= maxNivel4)
                    {
                        velocidade_pedra_esquerda = RandomNumber(45, 60) / 10000;
                    }
                    else if (pontuacao <= maxNivel5)
                    {
                        velocidade_pedra_esquerda = RandomNumber(60, 80) / 10000;
                    }

                    //Posição
                    y_pedra_esquerda = 8.7f;

                    x_pedra_esquerda = RandomNumber(1, 5) * -1;
                    
                }
            }

        }

        private static float RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
    
}

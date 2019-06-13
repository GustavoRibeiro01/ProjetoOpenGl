using System;

namespace ProjetoNave
{
    public static class Funcao
    {
        static int maxNivel1 = 4;
        static int maxNivel2 = 8;
        static int maxNivel3 = 12;
        static int maxNivel4 = 16;
        static int maxNivel5 = 20;

        public static void VerificaFinalPedra(ref float xPedraDireita, ref float yPedraDireita, ref float velocidadePedraDireita, ref float xPedraEsquerda, ref float yPedraEsquerda, ref float velocidadePedraEsquerda, ref int pontuacao, ref bool duasPedra, ref float rotacao)
        {

            if (yPedraDireita <= -9.0f)
            {
                //Velocidade
                if (pontuacao <= maxNivel1)
                {
                    velocidadePedraDireita = RandomNumber(40, 90) / 10000;
                    //rotacao = 400.1f;
                }
                else if (pontuacao <= maxNivel2)
                {
                    velocidadePedraDireita = RandomNumber(90, 150) / 10000;
                    //rotacao = 0.2f;
                }
                else if (pontuacao <= maxNivel3)
                {
                    velocidadePedraDireita = RandomNumber(40, 90) / 10000;
                    //rotacao = 0.3f;
                    duasPedra = true;
                }
                else if (pontuacao <= maxNivel4)
                {
                    velocidadePedraDireita = RandomNumber(90, 150) / 10000;
                }
                else if (pontuacao <= maxNivel5)
                {
                    velocidadePedraDireita = RandomNumber(150, 300) / 10000;
                }

                //Posição
                yPedraDireita = 8.7f;
                if (duasPedra)
                {
                    xPedraDireita = RandomNumber(1, 5);
                }
                else
                {
                    xPedraDireita = RandomNumber(0, 5);
                    if (RandomNumber(1, 2) == 1) //se 1 mudar para negativo
                    {
                        xPedraDireita *= -1;
                    }

                }
            }
            if (duasPedra)
            {
                if (yPedraEsquerda <= -9.0f)
                {
                    //Velocidade
                    if (pontuacao <= maxNivel1)
                    {
                        velocidadePedraEsquerda = RandomNumber(40, 90) / 10000;
                    }
                    else if (pontuacao <= maxNivel2)
                    {
                        velocidadePedraEsquerda = RandomNumber(90, 150) / 10000;
                    }
                    else if (pontuacao <= maxNivel3)
                    {
                        velocidadePedraEsquerda = RandomNumber(40, 90) / 10000;
                        duasPedra = true;
                    }
                    else if (pontuacao <= maxNivel4)
                    {
                        velocidadePedraEsquerda = RandomNumber(90, 150) / 10000;
                    }
                    else if (pontuacao <= maxNivel5)
                    {
                        velocidadePedraEsquerda = RandomNumber(150, 300) / 10000;
                    }

                    //Posição
                    yPedraEsquerda = 8.7f;

                    xPedraEsquerda = RandomNumber(1, 5) * -1;
                    
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

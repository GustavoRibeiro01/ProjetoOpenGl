using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace ProjetoNave
{
    class Program
    {
        static float angle = 0;

        static float _rot = 0.0f; //Responsavel por rotacionar a bola principal
        static bool _duasPedras; //Habilitar segunda pedra
        static int _pontuacao = 0;

        static bool _fim;

        //Variaveis Pedra Esquerda
        static float _pedraEsquerdaX = -4.0f;
        static float _pedraEsquerdaY = 6.0f;

        //Variaveis Pedra Direita
        static float _pedraDireitaX = 4.0f;
        static float _pedraDireitaY = 6.0f;

        //variaveis para locomover a bola
        static float _bolaX = 0.0f; //Mover para esquerda ou para direita
        static float _bolaY = -9.0f; //Mover para cima ou para baixo (estatico no momento)

        //Variaveis para guardar momento de colisão
        //static float Bola_X

        private static float _velocidadePedraEsquerda = 0.0030f;
        private static float _velocidadePedraDireita = 0.0030f;

        static void Inicializa()
        {
            
            //float[] posicaoLuz = { 0.0f, 50.0f, 50.0f, 1.0f };

            //Ativa o uso da luz ambiente
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, posicaoLuz);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(35.0f, 1.0, 0.001, 100.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Glu.gluLookAt(0.0, 14.0, 14.0, 0.0, 5.0, 5.0, 0.0, 10.0, 0.0);
            Gl.glClearColor(0, 0.6f, 0, 0.0f);

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glColorMaterial(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT_AND_DIFFUSE);
            Gl.glShadeModel(Gl.GL_SMOOTH);
            
        }

        static void luz()
        {
            float[] luzAmbiente = { 0.2f, 0.2f, 0.2f, 1.0f };
            // "cor"
            float[] luzDifusa = { 1.0f, 0.7f, 0.2f, 0.0f };
            float[] luzEspecular = { 0.5f, 0.5f, 0.5f, 1f };// "brilho"
            float[] posicaoLuz = { 0.0f, 5f, 5f, 1.0f };
            // Capacidade de brilho do material
            float[] especularidade = { 1.0f, 1.0f, 1.0f, 1.0f };
            int especMaterial = 60;
            // Especifica que a cor de fundo da janela será verde
            Gl.glClearColor(0.0f, 0.4f, 0f, 0.0f);
            // Habilita o modelo de colorização de Gouraud
            Gl.glShadeModel(Gl.GL_SMOOTH);
            // Define a refletância do material
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, especularidade);
            // Define a concentração do brilho
            Gl.glMateriali(Gl.GL_FRONT, Gl.GL_SHININESS, especMaterial);
            // Ativa o uso da luz ambiente
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, luzAmbiente);
            // Define os parâmetros da luz de número 0
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, luzAmbiente);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, luzDifusa);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, luzEspecular);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, posicaoLuz);
            // Habilita a definição da cor do material a partir da cor corrente
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            //Habilita o uso de iluminação
            Gl.glEnable(Gl.GL_LIGHTING);
            // Habilita a luz de número 0
            Gl.glEnable(Gl.GL_LIGHT0);
            // Habilita o depth-buffering
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            angle = 45;
        }


        static void Desenha()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            //-------------------------Pedra Direita--------------------------------------

            Gl.glPushMatrix();//salva para mover so estes objetos

            Gl.glTranslated(_pedraDireitaX, _pedraDireitaY, 0f);

            Gl.glColor3f(0.5f, 0.35f, 0.05f);

            Glut.glutSolidSphere(0.7, 5, 10);


            Gl.glPopMatrix(); //apaga da pilha

            //---------------------------------------------------------------------

            if (_duasPedras)
            {
                //-------------------------Pedra Esquerda--------------------------------------

                Gl.glPushMatrix();//salva para mover so estes objetos

                Gl.glTranslated(_pedraEsquerdaX, _pedraEsquerdaY, 0f);

                Gl.glColor3f(0.5f, 0.35f, 0.05f);

                Glut.glutSolidSphere(0.7, 5, 10);


                Gl.glPopMatrix(); //apaga da pilha

                //---------------------------------------------------------------------
            }

            //---------------------Bola Rolando--------------------------------------

            Gl.glPushMatrix();//salva para mover so estes objetos
            Gl.glTranslatef(_bolaX, -7.0f, 0.0f);
            Gl.glRotatef(90, 0.0f, 0.2f, 0.0f);
            Gl.glColor3f(1.0f, 0.666667f, 0.666667f);
            Gl.glRotatef(_rot, 0.0f, 0.0f, 0.2f);
            Glut.glutSolidSphere(0.5, 10, 10);

            //-----------------------------------------------------------------------

            Gl.glPopMatrix(); //apaga da pilha

            Glut.glutSwapBuffers();
        }

        static void MoverPedra(int value) //move as pedras em time
        {
            if(_fim) return;

            _pedraDireitaY -= _velocidadePedraDireita;

            if (_duasPedras)
                _pedraEsquerdaY -= _velocidadePedraEsquerda;

           
            
            if (_pedraEsquerdaY <= -9.0f || _pedraDireitaY <= -9.0f)
            {
                _pontuacao += 1;
                Console.Clear();
                Console.WriteLine($"Pontuação: {_pontuacao}");
            }

            //-----------------------Voltar pedra ao inicio da tela-----------------------------

            Funcao.VerificaFinalPedra(ref _pedraDireitaX, ref _pedraDireitaY, ref _velocidadePedraDireita, ref _pedraEsquerdaX, ref _pedraEsquerdaY, ref _velocidadePedraEsquerda, ref _pontuacao, ref _duasPedras, ref _rot);

            //-----------------------------------------------------------------------------------

            //-------------------------------Colisão----------------------------------------------

            float diferencaDireitaX = _pedraEsquerdaX - _bolaX;
            float diferencaDireitaY = _pedraEsquerdaY - _bolaY;

            float diferencaEsquerdaX = _pedraDireitaX - _bolaX;
            float diferencaEsquerdaY = _pedraDireitaY - _bolaY;

            if ((Math.Abs(diferencaDireitaX) < 1.03f && Math.Abs(diferencaDireitaY) < 2.9f) || (Math.Abs(diferencaEsquerdaX) < 1.03f && Math.Abs(diferencaEsquerdaY) < 2.9f))
            {
                Console.WriteLine("Game Over!");
                ManipulaArquivo arquivo = new ManipulaArquivo(@"pontuacao.txt");
                var melhorPontuacao = arquivo.LerPontuacao();
                Console.WriteLine("Sua pontuação: "+_pontuacao);
                Console.WriteLine("Pontuação Máxima: "+ melhorPontuacao);
                if (_pontuacao > melhorPontuacao)
                {
                    Console.WriteLine("Parabéns!! Nova Pontuação Máxima: " + _pontuacao);

                    arquivo.EscreverPontuacao(_pontuacao);
                }
                else
                {
                    arquivo.EscreverPontuacao(melhorPontuacao);
                }

                _fim = true;
            }

            //------------------------------------------------------------------------------------

            Glut.glutPostRedisplay();
            Glut.glutTimerFunc(1, MoverPedra, 1);
            
            _rot -= 0.2f; // Velocidade do giro da bola principal
           // Console.WriteLine($"rot: {rot}");
                         
        }

        static void TeclasBola(int key, int x, int y) //Controle da bola principal 
        {
            if (_fim) return;
            switch (key)
            {
                

                case Glut.GLUT_KEY_LEFT:

                    if (_bolaX >= -6.5f)
                        _bolaX -= 0.5f;

                    break;

                case Glut.GLUT_KEY_RIGHT:

                    if (_bolaX <= 6.5f)
                        _bolaX += 0.5f;

                    break;
            }

            Glut.glutPostRedisplay();
        }

        static void Main(string[] args)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(600, 600);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("Desvie dos obstaculos");
            Inicializa();
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Glut.glutDisplayFunc(Desenha);
            Glut.glutSpecialFunc(TeclasBola);
            Glut.glutTimerFunc(50, MoverPedra, 1);
            luz();
            Glut.glutMainLoop();

        }
    }
}



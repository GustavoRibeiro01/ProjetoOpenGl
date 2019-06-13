using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace ProjetoNave
{
    class Program
    {
        static float rot = 0.0f; //Responsavel por rotacionar a bola principal

        //Variaveis Pedra Esquerda
        static float PedraEsquerda_X = 5.0f;
        static float PedraEsquerda_Y = 0.0f;

        //Variaveis Pedra Direita
        static float PedraDireita_X = 5.0f;
        static float PedraDireita_Y = 0.0f;

        //variaveis para locomover a bola
        static float Bola_X = 0.0f; //Mover para esquerda ou para direita
        static float Bola_Y = -9.5f; //Mover para cima ou para baixo (estatico no momento)

        //Variaveis para guardar momento de colisão
        //static float Bola_X

        static void inicializa()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(35.0f, 1.0, 0.001, 100.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Glu.gluLookAt(0.0, 14.0, 14.0, 0.0, 5.0, 5.0, 0.0, 10.0, 0.0);
            Gl.glClearColor(0, 1, 0, 0.0f);

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glColorMaterial(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT_AND_DIFFUSE);
            Gl.glShadeModel(Gl.GL_SMOOTH);
        }

        static void desenha()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            //-------------------------Pedra--------------------------------------

            Gl.glPushMatrix();//salva para mover so estes objetos

            Gl.glTranslated(PedraEsquerda_X, PedraEsquerda_Y, 0f);

            Gl.glColor3f(0.5f, 0.35f, 0.05f);

            Glut.glutSolidSphere(0.7, 5, 10);


            Gl.glPopMatrix(); //apaga da pilha

            //---------------------------------------------------------------------
           
            //---------------------Bola Rolando--------------------------------------

            Gl.glPushMatrix();//salva para mover so estes objetos
            Gl.glTranslatef(Bola_X, -7.0f, 0.0f);
            Gl.glRotatef(90, 0.0f, 0.2f, 0.0f);
            Gl.glColor3f(1.0f, 0.666667f, 0.666667f);
            Gl.glRotatef(rot, 0.0f, 0.0f, 0.2f);
            Glut.glutSolidSphere(0.5, 10, 10);

            //-----------------------------------------------------------------------

            Gl.glPopMatrix(); //apaga da pilha

            Glut.glutSwapBuffers();
        }

        static void MoverPedra(int value) //move as pedras em time
        {
            PedraEsquerda_Y -= 0.020f;

            //-----------------------Voltar pedra ao inicio da tela-----------------------------

            if (PedraEsquerda_Y <= -9.0f)
            {
                PedraEsquerda_Y = 8.7f;
                PedraEsquerda_X = -5.0f; //Numero rondomico de -5 a 5
            }

            //-----------------------------------------------------------------------------------

            //-------------------------------Colisão----------------------------------------------

            float DiferencaX = PedraEsquerda_X - Bola_X;
            float DiferencaY = PedraEsquerda_Y - Bola_Y;

            if (Math.Abs(DiferencaX) < 1.05f && Math.Abs(DiferencaY) < 0.6f)
            {
                Console.WriteLine("Game Over!");
            }

            //------------------------------------------------------------------------------------

            Glut.glutPostRedisplay();
            Glut.glutTimerFunc(1, MoverPedra, 1);

            rot -= 0.2f; // Velocidade do giro da bola principal
                         
        }

        private void PararTela()
        {

        }

        static void TeclasBola(int key, int x, int y) //Controle da bola principal 
        {
            switch (key)
            {
                case Glut.GLUT_KEY_UP:

                    if (Bola_Y <= 5.5f)
                        Bola_Y += 0.5f;

                    break;

                case Glut.GLUT_KEY_DOWN:

                    if (Bola_Y >= -9.5f)
                        Bola_Y -= 0.5f;

                    break;

                case Glut.GLUT_KEY_LEFT:

                    if (Bola_X >= -6.5f)
                        Bola_X -= 0.5f;

                    break;

                case Glut.GLUT_KEY_RIGHT:

                    if (Bola_X <= 6.5f)
                        Bola_X += 0.5f;

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
            inicializa();
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Glut.glutDisplayFunc(desenha);
            Glut.glutSpecialFunc(TeclasBola);
            Glut.glutTimerFunc(50, MoverPedra, 1);

            Glut.glutMainLoop();

        }
    }
}



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
        static float rot = 0.0f;
        static double size = 2.0f;

        static float PedraX = 5.0f;
        //variaveis asteroide
        static float ax = 0.0f;
        static float ay = 0.0f;
        static float ax2 = 0.0f;
        static float ay2 = 0.0f;
        static float xstep = 0.008f;
        static float ystep = 0.008f;

        //variaveis para locomover a bola
        static float nx = 0.0f; //Mover para esquerda ou para direita
        static float ny = -9.5f; //Mover para cima ou para baixo (não usado no momento)

        //variavel do cenario
        static float cx = 0.0f;
        static float cy = 0.0f;



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

            //Pedra
            Gl.glPushMatrix();//salva para mover so estes objetos

            Gl.glTranslated(PedraX, cy, 0f);

            Gl.glColor3f(0.5f, 0.35f, 0.05f);

            Glut.glutSolidSphere(0.7, 5, 10);


            Gl.glPopMatrix();//apaga da pilha

            //---------------------------------------------------------------------
           
            //Bola Rolando
            Gl.glPushMatrix();//salva para mover so estes objetos
            Gl.glTranslatef(nx, -7.0f, 0.0f);

            //Console.WriteLine(ny);

            Gl.glRotatef(90, 0.0f, 0.2f, 0.0f);

            Gl.glColor3f(1.0f, 0.666667f, 0.666667f);
            Gl.glRotatef(rot, 0.0f, 0.0f, 0.2f);
            Glut.glutSolidSphere(0.5, 10, 10);

            Gl.glPopMatrix();//apaga da pilha

            Glut.glutSwapBuffers();
        }
        static void moverAsteroid(int value)//move o asteroid em time
        {
            // Muda a direção quando chega na borda esquerda ou direita
            if (ax > 6.5f || ax < -6.5f)
            {
                xstep = -xstep;


            }
            // Muda a direção quando chega na borda superior ou inferior
            if (ay <= -10.5f)
            {
                ay = 8.5f;

            }

            // Move o quadrado
            ax += xstep;
            ay -= ystep;

            cy -= 0.020f;

            //Voltar pedra ao inicio da tela
            if (cy <= -9.0f)
            {
                cy = 8.7f;
                PedraX = -5.0f; //Numero rondomico de -5 a 5
            }

            //-------------------------------Colisão----------------------------------------------

            float DiferencaX = PedraX - nx;
            float DiferencaY = cy - ny;

            if(Math.Abs(DiferencaX) < 1.1f && Math.Abs(DiferencaY) < 0.6f)
            {
                Console.WriteLine("Game Over!");
            }

            //------------------------------------------------------------------------------------

            // Redesenha o quadrado com as novas coordenadas
            Glut.glutPostRedisplay();
            Glut.glutTimerFunc(1, moverAsteroid, 1);

            rot -= 0.2f;// Velocidade do giro do asteroid
                        // Redesenha o quadrado com as novas coordenadas
                        //Glut.glutPostRedisplay();
                        //Glut.glutTimerFunc(10, moverAsteroid, 1);
        }
        static void Teclasnave(int key, int x, int y)//setinhas para controlar
        {
            switch (key)
            {
                case Glut.GLUT_KEY_UP:
                    if (ny <= 5.5f)
                        ny += 0.5f;

                    break;
                case Glut.GLUT_KEY_DOWN:
                    if (ny >= -9.5f)
                        ny -= 0.5f;
                    break;
                case Glut.GLUT_KEY_LEFT:
                    if (nx >= -6.5f)
                        nx -= 0.5f;

                    break;
                case Glut.GLUT_KEY_RIGHT:
                    if (nx <= 6.5f)
                        nx += 0.5f;
                    break;
            }
            Glut.glutPostRedisplay();
        }


        //static void TeclasEspeciais(int key, int x, int y)
        //{
        //    switch (key)
        //    {
        //        case Glut.GLUT_KEY_UP:
        //            rot += 3.0f;
        //            break;
        //        case Glut.GLUT_KEY_DOWN:
        //            rot -= 3.0f;
        //            break;

        //    }
        //    Glut.glutPostRedisplay();
        //}

        static void Main(string[] args)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(600, 600);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("não sei");
            inicializa();
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Glut.glutDisplayFunc(desenha);
            Glut.glutSpecialFunc(Teclasnave);
            Glut.glutTimerFunc(50, moverAsteroid, 1);

            Glut.glutMainLoop();

        }
    }
}



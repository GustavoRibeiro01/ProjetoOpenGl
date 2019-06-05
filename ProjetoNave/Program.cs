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
        //variaveis asteroide
        static float ax = 0.0f;
        static float ay = 0.0f;
        static float ax2 = 0.0f;
        static float ay2 = 0.0f;
        static float xstep = 0.008f;
        static float ystep = 0.008f;

        //variaveis nave
        static float nx = 0.0f;
        static float ny = -9.5f;

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
            Gl.glClearColor(0.0980392f, 0.0980392f, 0.439216f, 0.0f);

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

            //estrelas
            Gl.glPushMatrix();//salva para mover so estes objetos
            Gl.glColor3f(0.0f, 0.5f, 0.9f);
            Gl.glPointSize(5);
            Gl.glTranslated(0.0f, cy, -1.5f);
            Gl.glScalef(8.0F, 7.0F, 0.0F);
            Gl.glBegin(Gl.GL_POINTS);


            Gl.glVertex2f(0.1f, 0.2f);
            Gl.glVertex2f(0.5f, 0.2f);
            Gl.glVertex2f(0.4f, 0.7f);
            Gl.glVertex2f(0.3f, 0.1f);
            Gl.glVertex2f(0.5f, 0.8f);
            Gl.glVertex2f(0.6f, 0.2f);
            Gl.glVertex2f(-0.1f, 0.54f);
            Gl.glVertex2f(0.4f, -0.6f);
            Gl.glVertex2f(0.5f, -0.7f);
            Gl.glVertex2f(-0.43f, 0.123f);
            Gl.glVertex2f(-0.1f, -0.89f);
            Gl.glVertex2f(-0.21f, -0.2f);
            Gl.glVertex2f(0.1f, -0.33f);
            Gl.glVertex2f(-0.33f, 0.44f);
            Gl.glVertex2f(-0.1f, 0.2f);
            Gl.glVertex2f(-0.56f, 0.3f);
            Gl.glVertex2f(-0.66f, 0.4f);
            Gl.glVertex2f(-0.78f, 0.8f);
            Gl.glVertex2f(-0.34f, 0.4f);
            Gl.glVertex2f(-0.56f, -0.56f);
            Gl.glVertex2f(-0.76f, -0.73f);
            Gl.glVertex2f(-0.89f, -0.80f);
            Gl.glVertex2f(-0.99f, -0.30f);
            Gl.glVertex2f(-0.74f, -0.15f);
            Gl.glVertex2f(0.1f, 0.2f);
            Gl.glTranslated(0.0f, 1.0F, 0.0f);
            Gl.glVertex2f(0.1f, 0.2f);
            Gl.glVertex2f(0.5f, 0.2f);
            Gl.glVertex2f(0.4f, 0.7f);
            Gl.glVertex2f(0.3f, 0.1f);
            Gl.glVertex2f(0.5f, 0.8f);
            Gl.glVertex2f(0.6f, 0.2f);
            Gl.glVertex2f(-0.1f, 0.54f);
            Gl.glVertex2f(0.4f, -0.6f);
            Gl.glVertex2f(0.5f, -0.7f);
            Gl.glVertex2f(-0.43f, 0.123f);
            Gl.glVertex2f(-0.1f, -0.89f);
            Gl.glVertex2f(-0.21f, -0.2f);
            Gl.glVertex2f(0.1f, -0.33f);
            Gl.glVertex2f(-0.33f, 0.44f);
            Gl.glVertex2f(-0.1f, 0.2f);
            Gl.glVertex2f(-0.56f, 0.3f);
            Gl.glVertex2f(-0.66f, 0.4f);
            Gl.glVertex2f(-0.78f, 0.8f);
            Gl.glVertex2f(-0.34f, 0.4f);
            Gl.glVertex2f(-0.56f, -0.56f);
            Gl.glVertex2f(-0.76f, -0.73f);
            Gl.glVertex2f(-0.89f, -0.80f);
            Gl.glVertex2f(-0.99f, -0.30f);
            Gl.glVertex2f(-0.74f, -0.15f);
            Gl.glVertex2f(0.1f, 0.2f);
            Gl.glEnd();


            Gl.glPopMatrix();//apaga da pilha

            //asteroid
            Gl.glPushMatrix();
            Gl.glTranslatef(0.5f, 0.6f, 0.0f);



            Gl.glTranslatef(ax, ay, 0.0f);
            Gl.glColor3f(0.666667f, 0.666667f, 0.666667f);
            Gl.glRotatef(rot, 0.0f, 0.0f, 0.2f);
            //Gl.glTranslatef(-0.5f, -0.6f, 0.0f);
            Glut.glutSolidSphere(0.5, 10, 10);
            Gl.glPopMatrix();

            //asteroid
            Gl.glPushMatrix();
            Gl.glTranslatef(-1.5f, -1.6f, 0.0f);



            Gl.glTranslatef(-ax, ay, 0.0f);
            Gl.glColor3f(0.666667f, 0.666667f, 0.666667f);
            Gl.glRotatef(rot, 0.0f, 0.0f, 0.2f);
            //Gl.glTranslatef(-0.5f, -0.6f, 0.0f);
            Glut.glutSolidSphere(0.5, 10, 10);
            Gl.glPopMatrix();

            //nave
            Gl.glPushMatrix();//salva para mover so estes objetos
            Gl.glTranslatef(nx, ny, 0.0f);
            Gl.glRotatef(90, 0.0f, 0.2f, 0.0f);

            Gl.glColor3f(0.698039f, 0.133333f, 0.133333f);
            Glut.glutSolidCube(0.7);
            Gl.glTranslatef(0.8f, 0.0f, 0.0f);
            Glut.glutSolidTetrahedron();
            Gl.glTranslatef(0.8f, 0.0f, 0.0f);
            Glut.glutSolidTetrahedron();
            Gl.glTranslatef(0.0f, -1.2f, 0.0f);



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


            if (cy <= -9.0f) { cy = 8.7f; }





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



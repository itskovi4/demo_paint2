using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        bool con, quad, otr, shtr, poly;
        int rot1 = 0;
        int rot2 = 0;
        float rot = 0f;
        float rotate = 0f;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            float a = (float)numericUpDown1.Value;
            float b = (float)numericUpDown2.Value;
            float c = (float)numericUpDown3.Value;
            gl.ClearColor(a, b, c, 1);
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            otr = true;
            quad = false;
            con = false;
            shtr = false;
            poly = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            shtr = true;
            quad = false;
            con = false;
            otr = false;
            poly = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            quad = true;
            con = false;
            otr = false;
            shtr = false;
            poly = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            poly = true;
            quad = false;
            con = false;
            otr = false;
            shtr = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con = true;
            quad = false;
            otr = false;
            shtr = false;
            poly = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            rot1 = 2;
            rot2 = 2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            rot1 = 1;
            rot2 = 2;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            rot1 = 1;
            rot2 = 1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            rot1 = 2;
            rot2 = 1;
        }


        private void button11_Click(object sender, EventArgs e)
        {
            rot1 = 0;
            rot2 = 0;
        }
        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {

            OpenGL gl = this.openGLControl1.OpenGL;
            gl.Viewport(0, 0, openGLControl1.Width, openGLControl1.Height);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.Scale(1, 1, 1);

            if (otr == true)
            {
                int k = (int)numericUpDown4.Value;

                float a = (float)numericUpDown1.Value;
                float b = (float)numericUpDown2.Value;
                float c = (float)numericUpDown3.Value;

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
                gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);


                string[] Z = new string[4];
                Z[0] = textBox1.Text;
                Z[1] = textBox2.Text;
                Z[2] = textBox3.Text;
                Z[3] = textBox4.Text;

                float[] B = new float[4];
                for (int i = 0; i < 4; i++)
                    B[i] = Convert.ToSingle(Z[i]);

                gl.LineWidth(k);
                gl.Begin(OpenGL.GL_LINES);
                gl.Color(a, b, c);
                gl.Vertex(B[0] / 500, B[1] / 500);
                gl.Vertex(B[2] / 500, B[3] / 500);
                gl.End();
            }
            if (shtr == true)
            {
                int k = (int)numericUpDown4.Value;

                float a = (float)numericUpDown1.Value;
                float b = (float)numericUpDown2.Value;
                float c = (float)numericUpDown3.Value;

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
                gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);


                string[] Z = new string[4];
                Z[0] = textBox1.Text;
                Z[1] = textBox2.Text;
                Z[2] = textBox3.Text;
                Z[3] = textBox4.Text;

                float[] B = new float[4];
                for (int i = 0; i < 4; i++)
                    B[i] = Convert.ToSingle(Z[i]);

                gl.Enable(OpenGL.GL_LINE_STIPPLE);
                gl.LineStipple(6, 250);

                gl.LineWidth(k);
                gl.Begin(OpenGL.GL_LINES);
                gl.Color(a, b, c);
                gl.Vertex(B[0] / 500, B[1] / 500);
                gl.Vertex(B[2] / 500, B[3] / 500);
                gl.End();

                gl.Disable(OpenGL.GL_LINE_STIPPLE);
            }

            if (quad == true)
            {
                float a = (float)numericUpDown1.Value;
                float b = (float)numericUpDown2.Value;
                float c = (float)numericUpDown3.Value;

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
                gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);

                string[] Z = new string[4];
                Z[0] = textBox5.Text;
                Z[1] = textBox6.Text;
                Z[2] = textBox7.Text;
                Z[3] = textBox8.Text;

                float[] B = new float[4];
                for (int i = 0; i < 4; i++)
                    B[i] = Convert.ToSingle(Z[i]);

                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(a, b, c);
                gl.Vertex(B[0] / 500, B[1] / 500);
                gl.Vertex(B[0] / 500 + B[2] / 500, B[1] / 500);
                gl.Vertex(B[0] / 500 + B[2] / 500, B[1] / 500 - B[3] / 500);
                gl.Vertex(B[0] / 500, B[1] / 500 - B[3] / 500);
                gl.End();
            }

            if (poly == true)
            {
                float a = (float)numericUpDown1.Value;
                float b = (float)numericUpDown2.Value;
                float c = (float)numericUpDown3.Value;

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
                gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);

                int n = Convert.ToInt32(textBox9.Text);

                string[] G = new string[n];
                string[] H = new string[n];
                float[] X = new float[n];
                float[] Y = new float[n];
                G = textBox10.Text.Split(' ');
                H = textBox11.Text.Split(' ');
                for (int i = 0; i < n; i++)
                {
                    X[i] = Convert.ToSingle(G[i]);
                    Y[i] = Convert.ToSingle(H[i]);
                }
                if (n == 3)
                {
                    gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);
                    gl.Begin(OpenGL.GL_TRIANGLES);
                    gl.Color(a, b, c);
                    gl.Vertex(X[0] / 500, Y[0] / 500);
                    gl.Vertex(X[1] / 500, Y[1] / 500);
                    gl.Vertex(X[2] / 500, Y[2] / 500);
                    gl.End();
                }
                if (n == 4)
                {
                    gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);
                    gl.Begin(OpenGL.GL_POLYGON);
                    gl.Color(a, b, c);
                    gl.Vertex(X[0] / 500, Y[0] / 500);
                    gl.Vertex(X[1] / 500, Y[1] / 500);
                    gl.Vertex(X[2] / 500, Y[2] / 500);
                    gl.Vertex(X[3] / 500, Y[3] / 500);
                    gl.End();
                }
                if (n == 5)
                {
                    gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);
                    gl.Begin(OpenGL.GL_POLYGON);
                    gl.Color(a, b, c);
                    gl.Vertex(X[0] / 500, Y[0] / 500);
                    gl.Vertex(X[1] / 500, Y[1] / 500);
                    gl.Vertex(X[2] / 500, Y[2] / 500);
                    gl.Vertex(X[3] / 500, Y[3] / 500);
                    gl.Vertex(X[4] / 500, Y[4] / 500);
                    gl.End();
                }
                if (n == 6)
                {
                    gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);
                    gl.Begin(OpenGL.GL_POLYGON);
                    gl.Color(a, b, c);
                    gl.Vertex(X[0] / 500, Y[0] / 500);
                    gl.Vertex(X[1] / 500, Y[1] / 500);
                    gl.Vertex(X[2] / 500, Y[2] / 500);
                    gl.Vertex(X[3] / 500, Y[3] / 500);
                    gl.Vertex(X[4] / 500, Y[4] / 500);
                    gl.Vertex(X[5] / 500, Y[5] / 500);
                    gl.End();
                }
            }

            if (con == true)
            {

                if (rot2 == 1)
                {
                    gl.Rotate(rotate, 0.0f, 1.0f, 0.0f);
                }
                if (rot2 == 2)
                {
                    gl.Rotate(rotate, 1.0f, 0.0f, 0.0f);
                }
                if (rot1 == 0)
                {
                    rot = 0.0f;
                }
                if (rot1 == 1)
                {
                    rot = -0.5f;
                }
                if (rot1 == 2)
                {
                    rot = 0.5f;
                }
                rotate = rot;
                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
                gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);
                if (comboBox1.SelectedIndex == 0)
                {
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    gl.PointSize(7);
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_POINT);
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);
                }

                gl.Begin(OpenGL.GL_TRIANGLE_FAN);
                gl.Color(1.0f, 0.0f, 1.0f);
                gl.Vertex(0, 0, -500/500);
                for (int angle = 0; angle < 360; angle++)
                {
                    gl.Vertex(Math.Sin(angle) * 200/500, Math.Cos(angle) * 200 / 500, 0);
                }
                gl.End();

                gl.Begin(OpenGL.GL_TRIANGLE_FAN);
                gl.Color(0.0f, 0.0f, 1.0f);
                gl.Vertex(0, 0, 0);
                for (int angle = 0; angle < 360; angle++)
                {
                    gl.Normal(0, -1, 0);
                    gl.Vertex(Math.Sin(angle) * 200 / 500, Math.Cos(angle) * 200 / 500, 0);
                }
                gl.End();
            }

        }

    }
}
using OpenTK.Input;
using System.IO;
using System.Diagnostics;
using System.Media;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.IO;
using System.Diagnostics;
using System.Media; 

namespace TheGame
{
    public partial class Form1 : Form
    {
        int texture = 0;
        bool loaded = false;
        float width = 50;
        float x = 0, y = 0, z = 0;
        float flag = 0, kfl=0, fljump=0, flside=0; // flags 
        float t = 0, t1=0, side=0, pos=0;  //time, positionflag, camera
        float speed = 10;
        int lvl = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void gl_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.Texture2D);// allow to bind textures
            GL.Enable(EnableCap.ColorMaterial);
            GL.ShadeModel(ShadingModel.Smooth); //smoothing type
            GL.Enable(EnableCap.DepthTest); // disable objects' transparency
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            loaded=true;
            GL.ClearColor(Color.SkyBlue);
            GL.Enable(EnableCap.DepthTest);
            Matrix4 p = Matrix4.CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), 1, 20, 6000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref p);

            Matrix4 modelview = Matrix4.LookAt(width / 2, 100, 150-z, width/2, 0, -200-z, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
            Bitmap bitmap1 = new Bitmap(Properties.Resources.snow); Textur(texture, bitmap1);
            Bitmap bitmap2 = new Bitmap(Properties.Resources.wall); Textur(texture, bitmap2);
            Bitmap bitmap3 = new Bitmap(Properties.Resources.tree); Textur(texture, bitmap3);
            Bitmap bitmap4 = new Bitmap(Properties.Resources.ice); Textur(texture, bitmap4);
            Bitmap bitmap5 = new Bitmap(Properties.Resources.sky); Textur(texture, bitmap5);
        }
        private static void Resize1(int width, int height) //scene scaling
        {
            Matrix4 p = Matrix4.CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), 1, 20, 6000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref p);
        }

        private void Game()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Matrix4 modelview = Matrix4.LookAt(pos + width / 2, 150, 115 + z, pos / 5 + width / 2, 0, -200 + z, 0, 1, 0);  //camera move
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
            Resize1(gl.Width,gl.Height);

            snowmen(x, y, z);

            
            ////Floor
            //GL.Color3(Color.Pink);
            GL.BindTexture(TextureTarget.Texture2D, 4);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(2 * width + 10, 0, 100);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(-width - 10, 0, 100);
            GL.TexCoord2(50, 1); GL.Vertex3(-width - 10, 0, -8000);
            GL.TexCoord2(50, 0.0f); GL.Vertex3(2 * width + 10, 0, -8000);
            GL.End();

            /////left wall
            //GL.Color3(Color.White);
            GL.BindTexture(TextureTarget.Texture2D, 2);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f);  GL.Vertex3(-width - 10, 250, -8000);
            GL.TexCoord2(0.0f, 1);  GL.Vertex3(-width - 10, 0, -8000);
            GL.TexCoord2(10, 1); GL.Vertex3(-width - 10, 0, 100);
            GL.TexCoord2(10, 0.0f); GL.Vertex3(-width - 10, 250, 100);
            GL.End();//left wall
            


            //right wall
          
            //GL.Color3(Color.Aquamarine);
            GL.BindTexture(TextureTarget.Texture2D, 2);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(2 * width + 10, 250, 100);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(2 * width + 10, 0, 100);
            GL.TexCoord2(10, 1); GL.Vertex3(2 * width + 10, 0, -8000);
            GL.TexCoord2(10, 0.0f); GL.Vertex3(2 * width + 10, 250, -8000);            
            
            GL.End();
            
            //sky
           // GL.Color3(Color.BlueViolet);
            GL.BindTexture(TextureTarget.Texture2D, 5);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(2 * width + 10, 200, 100);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(-width - 10, 200, 100);
            GL.TexCoord2(10, 1); GL.Vertex3(-width - 10, 200, -8000);
            GL.TexCoord2(10, 0.0f); GL.Vertex3(2 * width + 10, 200, -8000);
            GL.End();



            //final wall
            GL.BindTexture(TextureTarget.Texture2D, 5);
            //GL.Color3(Color.Bisque);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-60, 0, -6000);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(-60, 200, -6000);
            GL.TexCoord2(1, 1); GL.Vertex3(-10, 200, -6000);
            GL.TexCoord2(1, 0.0f); GL.Vertex3(-10, 0, -6000);
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, 5);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(110, 200, -6000);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(110, 0, -6000);
            GL.TexCoord2(1, 1); GL.Vertex3(60, 0, -6000);
            GL.TexCoord2(1, 0.0f); GL.Vertex3(60, 200, -6000);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(60, 150, -6000);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(60, 200, -6000);
            GL.TexCoord2(1, 1); GL.Vertex3(-10, 200, -6000);
            GL.TexCoord2(1, 0.0f); GL.Vertex3(-10, 150, -6000);
            GL.End();


            ////left of the tunnel
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-10, 0, -6000);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(-10, 200, -6000);
            GL.TexCoord2(1, 1); GL.Vertex3(-10, 200, -7000);
            GL.TexCoord2(1, 0.0f); GL.Vertex3(-10, 0, -7000);
            GL.End();

            ////right of the tunnel
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(60, 0, -6000);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(60, 200, -6000);
            GL.TexCoord2(1, 1); GL.Vertex3(60, 200, -7000);
            GL.TexCoord2(1, 0.0f); GL.Vertex3(60, 0, -7000);
            GL.End();

            ////top of the tunnel
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(60, 200, -6000);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(60, 200, -7000);
            GL.TexCoord2(1, 1); GL.Vertex3(-10, 200, -7000);
            GL.TexCoord2(1, 0.0f); GL.Vertex3(-10, 200, -6000);
            GL.End();

            ////black quad
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(-10, 200, -6500);
            GL.Vertex3(-10, 0, -6500);
            GL.Vertex3(60, 0, -6500);
            GL.Vertex3(60, 200, -6500);
            GL.End();

           //obstructions    

                        
            for (int i = 10; i < 100; i+=10-lvl)
            {
                //mid line
                if(-150*i>-6000) block(0, 0, -150*i, 50, Color.Brown);
                if (-150 * i > -6000) if (-10 < x && x < 40 && z <= -150 * i + 70 && z >= -150 * i + 30 && y == 0) { speed = 0; pictureBox1.Visible = true; }
                 
                //left line
                if (-80 * i > -6000)  block(-50, 0, -80 * i, 50, Color.Brown);
                if (-80 * i > -6000) if (x < -10 && z <= -80 * i + 70 && z >= -80 * i + 30 && y == 0) { speed = 0; pictureBox1.Visible = true; }
                
                //right line
                if (-100*i > -6000)  block(50, 0, -100 * i, 50, Color.Brown);
                if (-100 * i > -6000) if (x > 40 && z <= -100 * i + 70 && z >= -100 * i + 30 && y == 0) { speed = 0; pictureBox1.Visible = true; }
            }

            GL.Color3(Color.White);
            GL.BindTexture(TextureTarget.Texture2D, 1);

            //CAMERA
           
            gl.SwapBuffers();
            GC.Collect();
        }


        private void block(float x1, float y1, float z1, float width1, Color col)  //obstructions generator
        {

            //back side
            GL.Color3(col);

            GL.BindTexture(TextureTarget.Texture2D, 3);
            GL.Begin(PrimitiveType.Quads);
            
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x1, y1, z1);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(x1 + width1, y1 + 0, z1 + 0);
            GL.TexCoord2(1, 1); GL.Vertex3(x1 + width1, y1 + width1, z1 + 0);
            GL.TexCoord2(1, 0.0f); GL.Vertex3(x1, y1 + width1, z1);
            GL.End();

            //left side
            GL.Begin(BeginMode.Polygon);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x1, y1, z1);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(x1, y1, z1 + width1);
            GL.TexCoord2(1, 1); GL.Vertex3(x1, y1 + width1, z1 + width1);
            GL.TexCoord2(1, 0.0f); GL.Vertex3(x1, y1 + width1, z1);
            GL.End();

            //bottom side
            GL.Begin(BeginMode.Polygon);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x1, y1, z1);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(x1, y1, z1 + width1);
            GL.TexCoord2(1, 1); GL.Vertex3(x1 + width1, y1, z1 + width1);
            GL.TexCoord2(1, 0.0f); GL.Vertex3(x1 + width1, y1, z1);
            GL.End();



            //top side
            GL.BindTexture(TextureTarget.Texture2D, 3);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x1, y1 + width1, z1);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(x1, y1 + width1, z1 + width1);
            GL.TexCoord2(1, 1); GL.Vertex3(x1 + width1, y1 + width1, z1 + width1);
            GL.TexCoord2(1, 0.0f); GL.Vertex3(x1 + width1, y1 + width1, z1);
            GL.End();



            //forward side
            GL.Begin(BeginMode.Polygon);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x1, y1, z1 + width1);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(x1 + width1, y1, z1 + width1);
            GL.TexCoord2(1, 1);GL.Vertex3(x1 + width1, y1 + width1, z1 + width1);
            GL.TexCoord2(1, 0.0f);GL.Vertex3(x1, y1 + width1, z1 + width1);
            GL.End();

            //right side
            GL.Begin(BeginMode.Polygon);
            GL.TexCoord2(0.0f, 0.0f);GL.Vertex3(x1 + width1, y1, z1);
            GL.TexCoord2(0.0f, 1); GL.Vertex3(x1 + width1, y1, z1 + width1);
            GL.TexCoord2(1, 1); GL.Vertex3(x1 + width1, y1 + width1, z1 + width1);
            GL.TexCoord2(1, 0.0f); GL.Vertex3(x1 + width1, y1 + width1, z1);
            GL.End();

            //edges
            GL.Color3(Color.Black);
            GL.Begin(BeginMode.LineLoop);
            GL.Vertex3(x1, y1, z1);
            GL.Vertex3(x1, y1 + width1, z1);
            GL.Vertex3(x1 + width1, y1 + width1, z1);
            GL.Vertex3(x1 + width1, y1, z1);
            GL.End();

            GL.Begin(BeginMode.LineLoop);
            GL.Vertex3(x1 + width1, y1, z1);
            GL.Vertex3(x1 + width1, y1, z1 + width1);
            GL.Vertex3(x1 + width1, y1 + width1, z1 + width1);
            GL.Vertex3(x1 + width1, y1 + width1, z1);
            GL.End();

            GL.Begin(BeginMode.LineLoop);
            GL.Vertex3(x1, y1, z1 + width1);
            GL.Vertex3(x1 + width1, y1, z1 + width1);
            GL.Vertex3(x1 + width1, y1 + width1, z1 + width1);
            GL.Vertex3(x1, y1 + width1, z1 + width1);
            GL.End();

            GL.Begin(BeginMode.LineLoop);
            GL.Vertex3(x1, y1, z1);
            GL.Vertex3(x1, y1, z1 + width1);
            GL.Vertex3(x1, y1 + width1, z1 + width1);
            GL.Vertex3(x1, y1 + width1, z1);
            GL.End();

            
            //gl.SwapBuffers();


            
        }


        void sphere(double r, double xk, double yk, double zk) 
        {
            int i, ix, iy, nx=20, ny=20;
            double x, y, z;

            for (iy = 0; iy < ny; ++iy)
            {
                GL.Begin(BeginMode.QuadStrip);
                for (ix = 0; ix <= nx; ++ix)
                {
                    x = r * Math.Sin(iy * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                    y = r * Math.Sin(iy * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                    z = r * Math.Cos(iy * Math.PI / ny);
                    GL.Normal3(x+xk, y+yk, z+zk);//normal vector - directed from the center
                    GL.TexCoord2((double)ix / (double)nx, (double)iy / (double)ny);
                    GL.Vertex3(x+xk, y+yk, z+zk);

                    x = r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                    y = r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                    z = r * Math.Cos((iy + 1) * Math.PI / ny);
                    GL.Normal3(x, y, z);
                    GL.TexCoord2((double)ix / (double)nx, (double)(iy + 1) / (double)ny);
                    GL.Vertex3(x+xk, y+yk, z+zk);
                }
                GL.End();
            }
        }



        void snowmen(double xk, double yk, double zk)
        {
            GL.Color3(Color.White);
            sphere(width / 2, width / 2 + x, width / 2 + y, -10 + z);
            sphere(width / 2 -5, width / 2 + x, width / 2 + y+40, -10 + z);
            sphere(width / 2 -10, width / 2 + x, width / 2 + y+70, -10 + z);

        }




        private void gl_Paint(object sender, PaintEventArgs e)
        {
            if(!loaded)
                return;
            Game();
         

            

        }


        private void gl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                if (flside == 0)
                {
                    kfl = 1;
                    side = 0;
                    lrtimer.Enabled = true;
                }
               
            }
            if (e.KeyCode == Keys.D)
            {
                if (flside == 0)
                {
                    kfl = 2;
                    side = 0;

                    lrtimer.Enabled = true;
                }
            }


            if (e.KeyCode == Keys.W)
            {
                if (fljump == 0)
                {
                    fljump = 1;
                    t = 0;
                    t1 = 0;
                    timer.Enabled = true;
                }

            }            
            Game();
        }

        private void timer_Tick(object sender, EventArgs e)  //jump
        {
            float v = 15; //climb speed
                t++;  //climb time
                y += v;
                if (t > 5) { y -= t1 * t1/2; t1++; if (y < 0) y = 0; } //descent params               
                
            Game();
            if ( y <= 0) { if (y < 0) { y = 0; }; timer.Enabled = false; fljump = 0; }
        }



      

        private void mtimer_Tick(object sender, EventArgs e)  //main timer
        {
            Game();
           
            if (z > -8000) { z-=speed; }  //forward movement

            if (z <= -6610) { z = 0; lvl++; speed += 5; }
        }

        private void Textur(int texture, Bitmap bitmap) // texures params
        {
            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);  //texture type
            // filtering type
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear); //the image on the screen is larger than the original image
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear); //the image on the screen is smaller than the original image
            BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            // 0-level detalisation
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bitmap.UnlockBits(data);
        }

        private void lrtimer_Tick(object sender, EventArgs e)  //side movements
        {
            flside = 1;
            if (kfl == 1) 
            {
                if (x != -60)
                {
                    side+=4;
                    x-=4;
                    if (pos > -25) { pos--; }
                }

                if (side == 60 || x == -60) { kfl = 0; flside = 0; lrtimer.Enabled = false; }
            }

            if (kfl == 2) 
            {
                if (x != 60)
                {
                    side+=4;
                    x+=4;
                    if (pos < 25) { pos++; }
                }

                if (side == 60 || x == 60) { kfl = 0; flside = 0; lrtimer.Enabled = false; }
            }  
        }


























    }
}

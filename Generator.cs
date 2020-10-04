using System;
using System.Drawing;

namespace ODSU
{
    public static class Generator
    {
        private static int dimensionX = 20;
        private static int dimensionY = 20;
        
        public static Bitmap DrawODSU(Tribit[] data)
        {
            Bitmap bitmap = new Bitmap(4000,4000);
            Graphics g = Graphics.FromImage(bitmap);
            Rectangle[] rectangles = new Rectangle[data.Length];
            int x = 20;
            int y = 0;
            bool isEven = true;
            for (int i = 0; i < 21; i++)
            {
                SolidBrush penLocal = new SolidBrush(Color.Black);
                g.FillRectangle(penLocal,x,y,dimensionX,dimensionY);
                x = x + dimensionX;
                penLocal.Dispose();
            }
            for (int i = 0; i < data.Length; i++)
            {
                if (x < 420)
                {
                    SolidBrush pen = new SolidBrush(data[i].ToColor());
                    g.FillRectangle(pen,x,y,dimensionX,dimensionY);
                    x = x + dimensionX;
                    pen.Dispose();
                }
                else
                {
                    SolidBrush pen = new SolidBrush(Color.Black);
                    if (isEven)
                    {
                        g.FillRectangle(pen,x,y,dimensionX,dimensionY);
                        isEven = false;
                    }
                    else
                    {
                        isEven = true;
                    }
                    y = y + dimensionY;
                    x = 20;
                    pen = new SolidBrush(data[i].ToColor());
                    g.FillRectangle(pen,x,y,dimensionX,dimensionY);
                    pen.Dispose();
                }
            }

            if (isEven)
            {
                SolidBrush pen = new SolidBrush(Color.Black);
                g.FillRectangle(pen,420,y,dimensionX,dimensionY);
                pen.Dispose();
            }

            x = 0;
            for (int i = 0; i < 420/20; i++)
            {
                if (x <= 420)
                {
                    SolidBrush pen = new SolidBrush(Color.Black);
                    g.FillRectangle(pen,x,y + 20,dimensionX,dimensionY);
                    x = x + 40;
                    pen.Dispose(); 
                }
                else
                {
                    break;    
                }

            }
            
            int height = (y/20) + 2; 
            x = 0;
            y = 0;
            for (int i = 0; i < height; i++)
            {
                SolidBrush pen = new SolidBrush(Color.Black);
                g.FillRectangle(pen,x,y,dimensionX,dimensionY);
                y = y + dimensionY;
                pen.Dispose();
                Console.WriteLine(x + " " + y);
            }
            g.Dispose();
            return bitmap;
        }

      /*  public static Bitmap DrawODSU(int alternativeDimensionX, int alternativeDimensionY,Tribit[] data)
        {
            Bitmap bitmap = new Bitmap(4000,4000);
            Graphics g = Graphics.FromImage(bitmap);
            Rectangle[] rectangles = new Rectangle[data.Length];
            int x = 0;
            int y = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (x < 800)
                {
                    Pen pen = new Pen(data[i].ToColor());
                    g.DrawRectangle(pen,x,y,alternativeDimensionX,alternativeDimensionY);
                    x = x + alternativeDimensionX;
                }
                else
                {
                    y = y + dimensionY;
                    Pen pen = new Pen(data[i].ToColor());
                    g.DrawRectangle(pen,x,y,dimensionX,dimensionY);
                }
            }
            return bitmap;
        }*/
    }
}
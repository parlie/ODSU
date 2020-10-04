using System.Drawing;

namespace ODSU
{
    public class Generator
    {
        private int dimensionX = 40;
        private int dimensionY = 40;
        
        public Bitmap DrawODSU(string fileName, Tribit[] data)
        {
            Bitmap bitmap = new Bitmap(fileName);
            Graphics g = Graphics.FromImage(bitmap);
            Rectangle[] rectangles = new Rectangle[data.Length];
            int x = 0;
            int y = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (x < 800)
                {
                    Pen pen = new Pen(data[i].ToColor());
                    g.DrawRectangle(pen,x,y,dimensionX,dimensionY);
                    x = x + dimensionX;
                }
                else
                {
                    y = y + dimensionY;
                    Pen pen = new Pen(data[i].ToColor());
                    g.DrawRectangle(pen,x,y,dimensionX,dimensionY);
                }
            }
            return bitmap;
        }

        public Bitmap DrawODSU(string fileName, int alternativeDimensionX, int alternativeDimensionY,Tribit[] data)
        {
            Bitmap bitmap = new Bitmap(fileName);
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
        }
    }
}
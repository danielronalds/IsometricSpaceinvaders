using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Drawing;

namespace IsometricSpaceinvaders
{
    class TextManager
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        public Font mainFont;
        public Font secondaryFont;
        public Font labelFont;

        public int fontY = 50;

        public void InitializeFonts()
        {
            byte[] fontData = Properties.Resources.FFFFORWA;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.FFFFORWA.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.FFFFORWA.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            mainFont = new Font(fonts.Families[0], 36.0F);
            secondaryFont = new Font(fonts.Families[0], 11.0F);
            labelFont = new Font(fonts.Families[0], 20.0F);
        }

        public void drawScoreText(Graphics g, int Score, Size Canvas)
        {
            Rectangle textRect;

            string text = "" + Score;

            Point textLocation;
            int x, y;

            Size textRectSize = g.MeasureString(text, mainFont).ToSize();
            textRectSize.Width += 1;

            y = 12;
            x = 12;

            textLocation = new Point(x, y);

            textRect = new Rectangle(textLocation, textRectSize);

            g.DrawString(text, mainFont, Brushes.White, textLocation);

            // Caption

            //text = "CURRENT SCORE";

            //textRectSize = g.MeasureString(text, secondaryFont).ToSize();
            //textRectSize.Width += 1;

            //y = fontY - textRectSize.Height;
            //x = ((Canvas.Width / 7) * 2) - (textRectSize.Width / 2);

            //textLocation = new Point(x, y);

            //textRect = new Rectangle(textLocation, textRectSize);

            //g.DrawString(text, secondaryFont, Brushes.White, textLocation);

        }

        //public void drawHighScoreText(Graphics g, int Score, Size Canvas)
        //{
        //    Rectangle textRect;

        //    string text = "" + Score;

        //    Point textLocation;
        //    int x, y;

        //    Size textRectSize = g.MeasureString(text, mainFont).ToSize();
        //    textRectSize.Width += 1;

        //    y = fontY;
        //    x = ((Canvas.Width / 7) * 5) - (textRectSize.Width / 2);

        //    textLocation = new Point(x, y);

        //    textRect = new Rectangle(textLocation, textRectSize);

        //    g.DrawString(text, mainFont, Brushes.White, textLocation);

        //    // Caption

        //    text = "HIGH SCORE";

        //    textRectSize = g.MeasureString(text, secondaryFont).ToSize();
        //    textRectSize.Width += 1;

        //    y = fontY - textRectSize.Height;
        //    x = ((Canvas.Width / 7) * 5) - (textRectSize.Width / 2);

        //    textLocation = new Point(x, y);

        //    textRect = new Rectangle(textLocation, textRectSize);

        //    g.DrawString(text, secondaryFont, Brushes.White, textLocation);
        //}
    }
}

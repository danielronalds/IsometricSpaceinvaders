using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace IsometricSpaceinvaders
{
    class Highscores
    {
        TextManager txt = new TextManager();

        List<Highscore> highScores = new List<Highscore>();

        string binPath;

        public Highscores(string binPathTmp) // Constructor, binPathTmp is for accesing highscores.txt
        {
            binPath = binPathTmp;

            var reader = new StreamReader(binPath);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                var values = line.Split(',');

                highScores.Add(new Highscore(values[0], Int32.Parse(values[1])));
            }

            txt.InitializeFonts();
        }

        public void SaveHighScores() // Writes to highscores.txt with updated scores
        {
            StringBuilder builder = new StringBuilder();
            foreach (Highscore score in highScores)
            {
                //{0} is for the Name, {1} is for the Score and {2} is for a new line
                builder.Append(string.Format("{0},{1}{2}", score.Name, score.Score, Environment.NewLine));
            }
            File.WriteAllText(binPath, builder.ToString());
        }

        public void CheckTopTen(int playerScore, string playerName) // Checks the currently saved highscores to see if the player has beaten them, and then saves the new score if they have
        {
            int lowest_score = highScores[(highScores.Count - 1)].Score;

            if (playerScore > lowest_score)
            {
                highScores.Add(new Highscore(playerName, playerScore));

                highScores = highScores.OrderByDescending(hs => hs.Score).Take(10).ToList();

                SaveHighScores();
            }

        }

        public void DrawHighscores(Graphics g, Size Panel, int playerScore, string playerName) // Draws the highscores on the gameover screen
        {
            Rectangle textRect;

            Point textLocation;

            Size textRectSize;

            Font font = txt.secondaryFont;

            string text;

            int x, y = 150;

            // Players Score

            text = playerName + " " + playerScore;

            textRectSize = g.MeasureString(text, txt.labelFont).ToSize();
            textRectSize.Width += 1;

            x = (Panel.Width / 2) - (textRectSize.Width / 2);

            textLocation = new Point(x, y);

            textRect = new Rectangle(textLocation, textRectSize);

            g.DrawString(text, txt.labelFont, Brushes.White, textLocation);

            y += textRectSize.Height + 20;

            // Stored Highscores

            foreach (Highscore highscore in highScores)
            {
                text = highscore.Name + " " + highscore.Score;

                textRectSize = g.MeasureString(text, font).ToSize();
                textRectSize.Width += 1;

                x = (Panel.Width / 2) - (textRectSize.Width/2);

                textLocation = new Point(x, y);

                textRect = new Rectangle(textLocation, textRectSize);

                g.DrawString(text, font, Brushes.White, textLocation);

                y += textRectSize.Height + 5;
            }
        }
    }
}

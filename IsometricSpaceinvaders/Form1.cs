using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IsometricGameEngine;

namespace IsometricSpaceinvaders
{
    public partial class Form1 : Form
    {
        private IsometricGrid3D isometricGrid = new IsometricGrid3D(545, 198, 16, 2);

        private IsometricGrid2D gameGrid;

        private Renderer2D test;

        Graphics g;

        List<Alien> Aliens = new List<Alien>();

        public Form1()
        {
            InitializeComponent();

            test = new Renderer2D(isometricGrid.to2D(0), TileMapTemplates.FilledGrid(isometricGrid), Properties.Resources._64x64_isometric_tile);

            gameGrid = isometricGrid.to2D(1);

            SpawnAliens(5, 11);
        }

        private void SpawnAliens(int lengthX, int lengthY)
        {
            for (int y = 0; y < lengthY; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    Aliens.Add(new Alien(gameGrid, x, y));
                }
            }
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            test.Render(g);

            foreach(Alien alien in Aliens)
            {
                alien.Render(g);
            }
        }
    }
}

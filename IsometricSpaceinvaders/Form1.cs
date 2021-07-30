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
        private IsometricGrid3D isometricGrid = new IsometricGrid3D(342, 300, 10, 2);

        private IsometricGrid2D gameGrid;

        private Renderer2D test;

        private RenderComponent testTwo;

        Graphics g;

        public Form1()
        {
            InitializeComponent();

            test = new Renderer2D(isometricGrid.to2D(0), TileMapTemplates.FilledGrid(isometricGrid), Properties.Resources._64x64_isometric_tile);

            gameGrid = isometricGrid.to2D(1);

            testTwo = new RenderComponent(Properties.Resources.space_invader, gameGrid.getPoint(5, 5));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            test.Render(g);

            testTwo.Render(g);
        }
    }
}

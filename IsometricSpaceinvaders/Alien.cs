using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IsometricGameEngine;

namespace IsometricSpaceinvaders
{
    class Alien
    {
        RenderComponent renderComponent;

        IsometricGrid2D gameGrid;

        Image alienImage = Properties.Resources.alien_placeholder;

        public Alien(IsometricGrid2D isometricGrid, int gridX, int gridY)
        {
            gameGrid = isometricGrid;

            renderComponent = new RenderComponent(alienImage, gameGrid.getPoint(gridX, gridY));
        }

        public void Render(Graphics g)
        {
            renderComponent.Render(g);
        }
    }
}

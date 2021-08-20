using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IsometricGameEngine;

namespace IsometricSpaceinvaders
{
    class BunkerBlock
    {
        public ColliderComponent colliderComponent; // Allows collision in the isometric plane

        RenderComponent renderComponent;

        Image bunkerImage = Properties.Resources._64x64_isometric_cube;

        public int health = 5;

        public BunkerBlock(Point location, IsometricGrid2D isometricGrid) // Constructor
        {
            colliderComponent = new ColliderComponent(location, isometricGrid);

            renderComponent = new RenderComponent(bunkerImage, location);
        }

        public void Render(Graphics g) // Draws Bunker block
        {
            renderComponent.Render(g);
        }
    }
}

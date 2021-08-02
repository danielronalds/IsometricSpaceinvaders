using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IsometricGameEngine;

namespace IsometricSpaceinvaders
{
    class Bunker
    {
        Renderer2D renderer;

        List<ColliderComponent> colliderComponents;

        public Bunker(IsometricGrid2D gameGrid)
        {
            renderer = new Renderer2D(gameGrid, BunkerTileMap.tileMap(), Properties.Resources._64x64_isometric_cube);

            colliderComponents = Collision.placeColliders(gameGrid, BunkerTileMap.tileMap());
        }

        public void Render(Graphics g)
        {
            renderer.Render(g);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IsometricGameEngine;

namespace IsometricSpaceinvaders
{
    class PlayerBolt
    {
        RenderComponent renderComponent;

        Image boltImage = Properties.Resources.player_projectile_16x16;

        IsometricGrid2D gameGrid;

        IsometricGrid2D colliderGrid;

        public ColliderComponent colliderComponent;

        List<ColliderComponent> boundaries;

        int boltSpeed = 10;

        public PlayerBolt(int spawnX, int spawnY, IsometricGrid2D colliderSize, IsometricGrid2D tempGameGrid, List<ColliderComponent> worldBorder)
        {
            boundaries = worldBorder;

            colliderGrid = colliderSize;

            gameGrid = tempGameGrid;

            renderComponent = new RenderComponent(boltImage, spawnX, spawnY);

            colliderComponent = new ColliderComponent(spawnX, spawnY, colliderSize);
        }

        public void Render(Graphics g)
        {
            renderComponent.Render(g);
        }

        public bool Move() // returns if it hit anything or not
        {
            Rectangle renderRectReset = renderComponent.renderRect;

            renderComponent.renderRect = IsometricMovement.Up(renderComponent.renderRect, boltSpeed);

            colliderComponent.position = renderComponent.renderRect.Location;

            // Collision Logic
            foreach (ColliderComponent border in boundaries)
            {
                if (UpdatedCollision.collidersColliding(colliderComponent, border, colliderGrid, gameGrid))
                {
                    renderComponent.renderRect = renderRectReset;

                    colliderComponent.position = renderComponent.renderRect.Location;

                    return true;
                }
            }

            return false;
        }
    }
}


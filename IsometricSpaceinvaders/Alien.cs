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

        public ColliderComponent colliderComponent;

        List<ColliderComponent> boundaries;

        int alienSpeed = 1;

        public int score;

        bool Left = false;

        public Alien(IsometricGrid2D isometricGrid, List<ColliderComponent> worldBorder, int gridX, int gridY, int alienScore)
        {
            gameGrid = isometricGrid;

            boundaries = worldBorder;

            renderComponent = new RenderComponent(alienImage, gameGrid.getPoint(gridX, gridY));

            colliderComponent = new ColliderComponent(renderComponent.renderRect.Location, gameGrid);

            score = alienScore;
        }

        public void Render(Graphics g)
        {
            renderComponent.Render(g);
        }

        public bool Move()
        {
            Rectangle renderRectReset = renderComponent.renderRect;

            Rectangle newRectPosition;

            if (Left)
            {
                newRectPosition = IsometricMovement.Left(renderComponent.renderRect, alienSpeed);
            } else
            {
                newRectPosition = IsometricMovement.Right(renderComponent.renderRect, alienSpeed);
            }

            renderComponent.renderRect = newRectPosition;

            colliderComponent.position = renderComponent.renderRect.Location;

            // Collision Logic
            foreach (ColliderComponent border in boundaries)
            {
                if (Collision.collidersColliding(colliderComponent, border, gameGrid))
                {
                    renderComponent.renderRect = renderRectReset;

                    //MoveDown();

                    return true;
                }
            }

            return false;
        }

        public void MoveDown()
        {
            renderComponent.renderRect = IsometricMovement.Down(renderComponent.renderRect, gameGrid.TileHeight / 4);

            Left = !Left; // This might be the most efficient line of code I have ever written in my life... 

            colliderComponent.position = renderComponent.renderRect.Location;
        }
    }
}

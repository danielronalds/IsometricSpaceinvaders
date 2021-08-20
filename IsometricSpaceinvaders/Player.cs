using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IsometricGameEngine;

namespace IsometricSpaceinvaders
{
    class Player
    {
        public RenderComponent renderComponent;

        IsometricGrid2D gameGrid;

        Image playerImage = Properties.Resources.player_placeholder;

        public ColliderComponent colliderComponent;

        List<ColliderComponent> boundaries;

        Point playerLocation;

        int playerSpeed = 3;

        public int lives = 3;

        public Player(IsometricGrid2D isometricGrid, List<ColliderComponent>worldBorder, int gridX, int gridY) // Constructor for the player
        {
            gameGrid = isometricGrid;

            boundaries = worldBorder;

            playerLocation = gameGrid.getPoint(gridX, gridY);

            renderComponent = new RenderComponent(playerImage, playerLocation);

            colliderComponent = new ColliderComponent(playerLocation, gameGrid);
        }

        public void Render(Graphics g) // Draws the player
        {
            //colliderComponent.DrawCollider(g, Pens.Red);

            renderComponent.Render(g);
        }

        public void MoveLeft() // Moves player left
        {
            Rectangle renderRectReset = renderComponent.renderRect;

            renderComponent.renderRect = IsometricMovement.Left(renderComponent.renderRect, playerSpeed);

            colliderComponent.position = renderComponent.renderRect.Location;

            // Collision Logic
            foreach(ColliderComponent border in boundaries)
            {
                if(Collision.collidersColliding(colliderComponent, border, gameGrid))
                {
                    renderComponent.renderRect = renderRectReset;

                    colliderComponent.position = renderComponent.renderRect.Location;

                    break;
                }
            }
        }

        public void MoveRight() // Moves player right
        {
            Rectangle renderRectReset = renderComponent.renderRect;

            renderComponent.renderRect = IsometricMovement.Right(renderComponent.renderRect, playerSpeed);

            colliderComponent.position = renderComponent.renderRect.Location;

            // Collision Logic
            foreach (ColliderComponent border in boundaries)
            {
                if (Collision.collidersColliding(colliderComponent, border, gameGrid))
                {
                    renderComponent.renderRect = renderRectReset;

                    colliderComponent.position = renderComponent.renderRect.Location;

                    break;
                }
            }
        }
    }
}

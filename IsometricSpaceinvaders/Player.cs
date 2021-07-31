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
        RenderComponent renderComponent;

        IsometricGrid2D gameGrid;

        Image playerImage = Properties.Resources.player_placeholder;

        ColliderComponent colliderComponent;

        Point playerLocation;

        int playerSpeed = 3;

        public Player(IsometricGrid2D isometricGrid, int gridX, int gridY)
        {
            gameGrid = isometricGrid;

            playerLocation = gameGrid.getPoint(gridX, gridY);

            renderComponent = new RenderComponent(playerImage, playerLocation);

            colliderComponent = new ColliderComponent(playerLocation, gameGrid);
        }

        public void Render(Graphics g)
        {
            //colliderComponent.DrawCollider(g, Pens.Red);

            renderComponent.Render(g);
        }

        public void MoveLeft()
        {
            renderComponent.renderRect = IsometricMovement.Left(renderComponent.renderRect, playerSpeed);
        }

        public void MoveRight()
        {
            renderComponent.renderRect = IsometricMovement.Right(renderComponent.renderRect, playerSpeed);
        }
    }
}

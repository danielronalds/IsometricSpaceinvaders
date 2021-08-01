﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IsometricGameEngine;

namespace IsometricSpaceinvaders
{
    public partial class Form1 : Form
    {
        private IsometricGrid3D isometricGrid = new IsometricGrid3D(545, 198, 16, 2);

        private IsometricGrid2D collisionGrid = new IsometricGrid2D(545, 134, 18);

        private IsometricGrid2D gameGrid;

        private Renderer2D developmentPlatform;

        Graphics g;

        List<Alien> aliens = new List<Alien>();

        List<ColliderComponent> worldBorder = new List<ColliderComponent>();

        Player player;

        bool leftDown, rightDown;

        public Form1()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, GamePanel, new object[] { true });

            developmentPlatform = new Renderer2D(isometricGrid.to2D(0), TileMapTemplates.FilledGrid(isometricGrid), Properties.Resources.Isometric_Tile_Bordered);

            gameGrid = isometricGrid.to2D(1);

            PlaceBorder();

            SpawnAliens(5, 11);

            player = new Player(gameGrid, worldBorder, 15, 8);

        }

        private void PlaceBorder()
        {
            worldBorder = Collision.placeColliders(collisionGrid, TileMapTemplates.BorderedGrid(collisionGrid));
        }

        private void SpawnAliens(int lengthX, int lengthY)
        {
            for (int y = 0; y < lengthY; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    aliens.Add(new Alien(gameGrid, worldBorder, x, y+(15-lengthY)));
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = true;
                    break;

                case Keys.Right:
                    rightDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = false;
                    break;

                case Keys.Right:
                    rightDown = false;
                    break;
            }
        }

        private void FrameRefresh_Tick(object sender, EventArgs e)
        {
            if(leftDown)
            {
                player.MoveLeft();
            }
            else if(rightDown)
            {
                player.MoveRight();
            }

            bool moveAliensDown = false;

            foreach(Alien alien in aliens)
            {
                if(!moveAliensDown)
                {
                    moveAliensDown = alien.Move();
                }
                else
                {
                    foreach(Alien alienToMoveDown in aliens)
                    {
                        alienToMoveDown.MoveDown();
                    }
                    break;
                }
            }

            GamePanel.Invalidate();
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            //developmentPlatform.Render(g);

            bool moveDown = false;

            foreach (Alien alien in aliens)
            {
                if(moveDown)
                {
                    alien.MoveDown();
                } else
                {
                    moveDown = alien.Move();
                }

                alien.Render(g);
            }

            player.Render(g);
        }
    }
}

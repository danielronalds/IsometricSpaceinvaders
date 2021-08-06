using System;
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

        private IsometricGrid2D projectileGrid = new IsometricGrid2D(545, 198, 1, 16, 16);

        private IsometricGrid2D gameGrid;

        private Bunker bunker;

        Graphics g;

        List<Alien> aliens = new List<Alien>();

        List<ColliderComponent> worldBorder = new List<ColliderComponent>();

        Player player;

        bool leftDown, rightDown;

        List<PlayerBolt> bolts = new List<PlayerBolt>();

        bool gameOn = false;

        int score;

        public Form1()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, GamePanel, new object[] { true });

            gameGrid = isometricGrid.to2D(1);

            bunker = new Bunker(gameGrid);

            PlaceBorder();

            SpawnAliens();

            player = new Player(gameGrid, worldBorder, 15, 8);
        }

        private void PlaceBorder()
        {
            worldBorder = Collision.placeColliders(collisionGrid, TileMapTemplates.BorderedGrid(collisionGrid));
        }

        private void SpawnAliens()
        {
            int alienScore;

            int lengthX = 5;
            int lengthY = 11;

            for (int y = 0; y < lengthY; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    if(x < 1)
                    {
                        alienScore = 30;
                    } else if (x < 3)
                    {
                        alienScore = 20;
                    } else
                    {
                        alienScore = 10;
                    }

                    aliens.Add(new Alien(gameGrid, worldBorder, x, y+(15-lengthY), alienScore));
                }
            }

            foreach(Alien alien in aliens)
            {
                Console.WriteLine(alien.score.ToString());
            }
        }

        private void PlayerShoot()
        {
            if(bolts.Count < 1) // Allows the player to only shoot one projectile at a time, rewarding accuracy
            {
                bolts.Add(new PlayerBolt(player.renderComponent.renderRect.X, player.renderComponent.renderRect.Y, projectileGrid, gameGrid, worldBorder));
            }
        }

        private bool BulletHit(int i)
        {
            for (int x = 0; x < aliens.Count; x++)
            {
                if (UpdatedCollision.collidersColliding(bolts[i].colliderComponent, aliens[x].colliderComponent, projectileGrid, gameGrid))
                {

                    score += aliens[x].score;

                    ScoreLbl.Text = score.ToString();

                    aliens.RemoveAt(x);

                    //GameEffects.Shake(this, 1, 3);

                    return true;
                }
            }

            for (int x = 0; x < bunker.blocks.Count; x++)
            {
                if(UpdatedCollision.collidersColliding(bolts[i].colliderComponent, bunker.blocks[x].colliderComponent, projectileGrid, gameGrid))
                {
                    bunker.blocks[x].health--;

                    if(bunker.blocks[x].health < 1)
                    {
                        bunker.blocks.RemoveAt(x);
                    }

                    return true;
                }
            }

            return false;
        }

        private bool WaveOver()
        {
            if(aliens.Count < 1)
            {
                return true;
            }
            return false;
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
                case Keys.Space:
                    PlayerShoot();
                    break;
            }

            gameOn = true;
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
            if(gameOn)
            {
                if (leftDown)
                {
                    player.MoveLeft();
                }
                else if (rightDown)
                {
                    player.MoveRight();
                }

                bool moveAliensDown = false;

                foreach (Alien alien in aliens)
                {
                    if (!moveAliensDown)
                    {
                        moveAliensDown = alien.Move();
                    }
                    else
                    {
                        foreach (Alien alienToMoveDown in aliens)
                        {
                            alienToMoveDown.MoveDown();
                        }
                        break;
                    }
                }

                for (int i = 0; i < bolts.Count; i++)
                {
                    if (bolts[i].Move() || BulletHit(i))
                    {
                        bolts.RemoveAt(i);
                    }
                }

                if(WaveOver())
                {
                    SpawnAliens();

                    player.lives++;
                }

                GamePanel.Invalidate();
            }
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            //foreach (ColliderComponent colliderComponent in worldBorder)
            //{
            //    colliderComponent.DrawCollider(g, Pens.Green);
            //}

            foreach (Alien alien in aliens)
            {
                alien.Render(g);
            }

            foreach (PlayerBolt bolt in bolts)
            {
                bolt.Render(g);
            }

            bunker.Render(g);

            player.Render(g);
        }
    }
}

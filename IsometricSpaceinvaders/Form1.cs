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

        Renderer2D renderer;

        private TextManager txt = new TextManager();

        private IsometricGrid2D gameGrid;

        private Bunker bunker;

        Graphics g;

        List<Alien> aliens = new List<Alien>();

        List<ColliderComponent> worldBorder = new List<ColliderComponent>();

        List<ColliderComponent> winZone = new List<ColliderComponent>();

        Player player;

        bool leftDown, rightDown;

        List<PlayerBolt> bolts = new List<PlayerBolt>();

        List<AlienBolt> alienBolts = new List<AlienBolt>();

        List<Panel> panels = new List<Panel>();

        bool gameOn = false;

        int currentPanel = 2;

        int score;

        int alienMoveRate = 0;
        int alienMaxMoveRate = 5;

        Random rnd = new Random();

        int chanceOfAlienShot = 4500;

        Size formSize, panelSize;

        string binPath = Application.StartupPath + @"\highscores.txt";

        Highscores highscoreManager;

        string playerName = "Daniel";

        public Form1() // Start function
        {
            InitializeComponent();

            txt.InitializeFonts();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, GamePanel, new object[] { true });

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, GameOverPnl, new object[] { true });

            highscoreManager = new Highscores(binPath);

            panels.Add(GamePanel);
            panels.Add(GameOverPnl);
            panels.Add(StartPnl);

            formSize = new Size(1105, 788);

            panelSize = new Size(1090, 760);

            ResetGame();

            SetPanel();

            
        }

        private void setFormSize() // Function that sets the form size every screen refresh, prevents the players from seeing other inactive panels by fixing the form size
        {
            this.Size = formSize;
        }

        private void PlaceBorder() // Places colliders around the game grid
        {
            worldBorder = Collision.placeColliders(collisionGrid, TileMapTemplates.BorderedGrid(collisionGrid));
        }

        private void ResetGame() // Resets the game
        {
            gameGrid = isometricGrid.to2D(1);

            bunker = new Bunker(gameGrid);

            PlaceBorder();

            winZone = Collision.placeColliders(gameGrid, WinzoneTileMap.tileMap());

            SpawnAliens();

            player = new Player(gameGrid, worldBorder, 15, 8);

            renderer = new Renderer2D(gameGrid, TileMapTemplates.FilledGrid(gameGrid), Properties.Resources.tilemarker);

            score = 0;
        }

        private void SpawnAliens() // Spawns the block of aliens at the start of the game/each wave
        {
            aliens.Clear();

            int alienScore;

            int lengthX = 5;
            int lengthY = 11;

            for (int y = 0; y < lengthY; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    if(x < 1) // Gives each alien a different point value based on their location with aliens at the back having a higher point score
                    {
                        alienScore = 30;
                    } else if (x < 3)
                    {
                        alienScore = 20;
                    } else
                    {
                        alienScore = 10;
                    }

                    aliens.Add(new Alien(gameGrid, worldBorder, x, y+(16-lengthY), alienScore));
                }
            }

            foreach(Alien alien in aliens)
            {
                Console.WriteLine(alien.score.ToString());
            }
        }

        private void PlayerShoot() // Function to shoot a projectile from the players current position
        {
            if(bolts.Count < 1) // Allows the player to only shoot one projectile at a time, rewarding accuracy
            {
                bolts.Add(new PlayerBolt(player.renderComponent.renderRect.X, player.renderComponent.renderRect.Y, projectileGrid, gameGrid, worldBorder));
            }
        }

        private void AlienShoot(Alien alien) // Function to shoot a projectile from the selected aliens current position
        {
            int x = alien.renderComponent.renderRect.X;

            int y = alien.renderComponent.renderRect.Y;

            alienBolts.Add(new AlienBolt(x, y, projectileGrid, gameGrid, worldBorder));
        }

        private bool BulletHit(int i) // Checks to see if the player projectile has hit anything, returns a bool
        {
            for (int x = 0; x < aliens.Count; x++) // Hit with alien
            {
                if (UpdatedCollision.collidersColliding(bolts[i].colliderComponent, aliens[x].colliderComponent, projectileGrid, gameGrid))
                {

                    score += aliens[x].score;

                    aliens.RemoveAt(x);

                    //GameEffects.Shake(this, 1, 3);

                    return true;
                }
            }

            for (int x = 0; x < bunker.blocks.Count; x++) // Hit with bunker
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

            for (int x = 0; x < alienBolts.Count; x++) // Hit with alien bolt
            {
                if (Collision.collidersColliding(bolts[i].colliderComponent, alienBolts[x].colliderComponent, projectileGrid))
                {
                    alienBolts.RemoveAt(x);

                    return true;
                }
            }

            return false;
        }

        private bool AlienBulletHit(int i) // Checks if selected alien bolt has hit anything, returns a bool
        {
            if(UpdatedCollision.collidersColliding(alienBolts[i].colliderComponent, player.colliderComponent, projectileGrid, gameGrid)) // Hit with player
            {
                player.lives--;

                GameEffects.Shake(this, 5, 5);

                return true;
            }

            for (int x = 0; x < bunker.blocks.Count; x++) // Hit with Bunker
            {
                if (UpdatedCollision.collidersColliding(alienBolts[i].colliderComponent, bunker.blocks[x].colliderComponent, projectileGrid, gameGrid))
                {
                    bunker.blocks[x].health--;

                    if (bunker.blocks[x].health < 1)
                    {
                        bunker.blocks.RemoveAt(x);
                    }

                    return true;
                }
            }

            return false;
        }

        private bool WaveOver() // Checks if all aliens in a wave have been destroyed and returns a bool
        {
            if(aliens.Count < 1)
            {
                return true;
            }
            return false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // Keydown event 
        {
            if(currentPanel == 0)
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
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) // Keyup event
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

        private void PlayGame(object sender, EventArgs e) // Event called by the restart game button and the play game button that shifts the current panel to the game panel
        {
            playerName = PlayerNameTxtBox.Text;

            currentPanel = 0;

            ResetGame();
            SetPanel();

            MessageBox.Show("Spacebar to shoot, left and right arrow keys to move left and right respectively. Enjoy!", "Game instructions");
        }

        private void FrameRefresh_Tick(object sender, EventArgs e) // Frame refresh time, runs every 16ms resulting in a frame rate of 60 fps
        {
            if (player.lives < 1 && gameOn) // Checks to see if the game is over 
            {
                EndGame();
            }

            SetPanel();

            if (gameOn && currentPanel == 0)
            {
                if (leftDown)
                {
                    player.MoveLeft();
                }
                else if (rightDown)
                {
                    player.MoveRight();
                }

                foreach (Alien alien in aliens)
                {
                    if(alienMoveRate == alienMaxMoveRate)
                    {
                        alien.Move();
                    }

                    if (rnd.Next(0, chanceOfAlienShot) < 1)
                    {
                        AlienShoot(alien);
                    }

                    foreach (ColliderComponent collider in winZone) // Checks to see if the game is over 
                    {
                        if (Collision.collidersColliding(alien.colliderComponent, collider, gameGrid))
                        {
                            EndGame();
                        }
                    }
                }

                if(alienMoveRate != alienMaxMoveRate) // This allows the aliens to slow down initially
                {
                    alienMoveRate++;
                } else
                {
                    alienMoveRate = 0;
                }

                for (int i = 0; i < bolts.Count; i++) // Player bolts
                {
                    if (bolts[i].Move() || BulletHit(i))
                    {
                        bolts.RemoveAt(i);
                    }
                }

                for (int i = 0; i < alienBolts.Count; i++) // Alien Bolts
                {
                    if(alienBolts[i].Move() || AlienBulletHit(i))
                    {
                        alienBolts.RemoveAt(i);
                    }
                }

                int x = bunker.blocks.Count;

                for (int i = 0; i < x; i++) // Removes blocks if touched by alien
                {
                    foreach (Alien alien in aliens)
                    {
                        if(i < bunker.blocks.Count)
                        {
                            if (Collision.collidersColliding(alien.colliderComponent, bunker.blocks[i].colliderComponent, gameGrid))
                            {
                                bunker.blocks.RemoveAt(i);

                                x = bunker.blocks.Count;
                            }
                        }
                    }
                }

                if(WaveOver()) // Wave over check
                {
                    SpawnAliens();

                    player.lives++;

                    if(alienMaxMoveRate != 0)
                    {
                        alienMaxMoveRate--;
                        alienMoveRate = 0;
                    }
                }

                GamePanel.Invalidate();
            }
        }

        private void EndGame() // Ends the game and switches to the game over screen
        {
            gameOn = false;
            currentPanel = 1;
            highscoreManager.CheckTopTen(score, playerName);
        }

        private void PlayerNameTxtBox_KeyPress(object sender, KeyPressEventArgs e) // Prevents anything but letters being typed as the username of the player
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void SetPanel() // Sets the current panel to either the start screen(2) gameover screen(1) or the actual game screen(0)
        {
            for (int i = 0; i < panels.Count; i++)
            {
                if(panels[i] == panels[currentPanel])
                {
                    panels[i].Size = panelSize;
                    panels[i].Location = new Point(0, 0);
                    if(currentPanel == 1) // Gameover screen
                    {
                        GameOverButton.Enabled = true;
                        PlayerNameTxtBox.Enabled = false;
                        StartScreenButton.Enabled = false;
                        panels[i].Invalidate();
                    } else if(currentPanel == 2) // Start screen
                    {
                        PlayerNameTxtBox.Enabled = true;
                        GameOverButton.Enabled = false;
                        StartScreenButton.Enabled = true;
                    } else // Actual game screen
                    {
                        PlayerNameTxtBox.Enabled = false;
                        GameOverButton.Enabled = false;
                        StartScreenButton.Enabled = false;
                    }
                } else
                {
                    panels[i].Left += 1000;
                }
            }
        }

        private void GameOverPnl_Paint(object sender, PaintEventArgs e) // Paints the gameover highscores
        {
            g = e.Graphics;

            highscoreManager.DrawHighscores(g, panelSize, score, playerName);
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e) // Paint event for the game panel
        {
            g = e.Graphics;

            setFormSize();

            //foreach (ColliderComponent colliderComponent in winZone)
            //{
            //    colliderComponent.DrawCollider(g, Pens.Green);
            //}

            //renderer.Render(g);

            foreach (Alien alien in aliens)
            {
                alien.Render(g);
            }

            foreach (PlayerBolt bolt in bolts)
            {
                bolt.Render(g);
            }

            foreach (AlienBolt alienBolt in alienBolts)
            {
                alienBolt.Render(g);
            }

            bunker.Render(g);

            player.Render(g);

            txt.drawScoreText(g, score, GamePanel.Size);

            txt.drawLivesText(g, player.lives, GamePanel.Size);
        }
    }
}

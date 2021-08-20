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
        public List<BunkerBlock> blocks;

        IsometricGrid2D isometricGrid;

        public Bunker(IsometricGrid2D gameGrid) // Constructor
        {
            blocks = placeBunkers(gameGrid, BunkerTileMap.tileMap());

            isometricGrid = gameGrid;
        }

        public void Render(Graphics g) // Draws Bunkers in the correct order to maintain the isometric perspective
        {
            foreach (BunkerBlock block in blocks)
            {
                block.Render(g);
            }
        }

        private List<BunkerBlock> placeBunkers(IsometricGrid2D isometricGrid, TileMap sourceMap) // Function that converts the string array tilemap into bunker objects to render and interact with
        {
            int length = isometricGrid.gridSize;

            List<BunkerBlock> bunkers = new List<BunkerBlock>();

            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    if (sourceMap.getValue(x, y) != sourceMap.VoidCharacter)
                    {
                        bunkers.Add(new BunkerBlock(isometricGrid.getPoint(x, y), isometricGrid));
                    }
                }
            }

            return bunkers;
        }
    }
}

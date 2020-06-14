using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield
{
    /** Width of board. */
    public static int WIDTH = 10;
    /** Height of board. */
    public static int HEIGHT = 13;
    /** Elements on board. */
    public static Element[,] ELEMENTS = new Element[WIDTH,HEIGHT];
    /** Number of free spaces. */
    public static int spaces = 0;
    /** The winning screen, for reference purposes. */
    public static Win winScreen;
    
    /** Uncovers all mines, run during the game over sequence. */
    public static void uncoverMines()
    {
        foreach (Element elem in ELEMENTS)
        {
            if (elem.mine)
            {
                elem.revealed = true;
                elem.loadTexture(0);
            }
        }
    }
    
    /** Find out if a mine is at the coordinates X, Y. */
    public static bool mineAt(int x, int y) {
        // Coordinates in range? Then check for mine.
        if (x >= 0 && y >= 0 && x < WIDTH && y < HEIGHT)
            return ELEMENTS[x, y].mine;
        return false;
    }
    
    /** Count adjacent mines for an element. */
    public static int adjacentMines(int x, int y) {
        int count = 0;

        if (mineAt(x,   y+1)) ++count;     // top
        if (mineAt(x+1, y+1)) ++count;   // top-right
        if (mineAt(x+1, y  )) ++count;     // right
        if (mineAt(x+1, y-1)) ++count;   // bottom-right
        if (mineAt(x,   y-1)) ++count;     // bottom
        if (mineAt(x-1, y-1)) ++count;   // bottom-left
        if (mineAt(x-1, y  )) ++count;     // left
        if (mineAt(x-1, y+1)) ++count;   // top-left
        
        return count;
    }

    /** Recursively uncover all adjacent elements from coords X, Y if they are empty. */
    public static void uncover(int x, int y, bool[,] visited)
    {
        if (x >= 0 && y >= 0 && x < WIDTH && y < HEIGHT)
        {
            if (visited[x, y])
            {
                return;
            }
            
            // uncover element
            ELEMENTS[x, y].revealed = true;
            ELEMENTS[x, y].flagged = false;
            ELEMENTS[x, y].loadTexture(adjacentMines(x, y));
            spaces -= 1;

            // close to a mine? then no more work needed here
            if (adjacentMines(x, y) > 0)
                return;
            
            visited[x, y] = true;

            uncover(x - 1, y, visited);
            uncover(x + 1, y, visited);
            uncover(x, y - 1, visited);
            uncover(x, y + 1, visited);
        }
    }
    
    /** Returns whether or not the game is finished. */
    public static bool isFinished() {
        // No non-mine spaces left to click => win
        return spaces == 0;
    }
}

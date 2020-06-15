using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Square[,] SQUARES = new Square[3, 3];
    public static Solution[] LINES = new Solution[8];
    private static bool _turn = true;
    private static int _turnCount = 0;
    public static bool Win = false;
    
    /** Finish a turn. */
    public static bool Flip()
    {
        _turnCount += 1;
        _turn = !_turn;
        return !_turn;
    }

    /** Sees whether someone won. If so, reveal the winning lines and stop
     *  all further input. */
    public static void CheckWinner()
    {
        if (_turnCount < 3)
        {
            return;
        }

        int color = 0;
        for (int i = 0; i < 3; i += 1)
        {
            color = SQUARES[0, i].color;
            if (color > 0
                && color == SQUARES[0, i].color
                && color == SQUARES[1, i].color
                && color == SQUARES[2, i].color)
            {
                LINES[i].Reveal();
                Win = true;
            }
        }
        
        for (int i = 0; i < 3; i += 1)
        {
            color = SQUARES[i, 0].color;
            if (color > 0
                && color == SQUARES[i, 0].color
                && color == SQUARES[i, 1].color
                && color == SQUARES[i, 2].color)
            {
                LINES[i + 3].Reveal();
                Win = true;
            }
        }
        
        color = SQUARES[0, 0].color;
        if (color > 0
            && color == SQUARES[0, 0].color
            && color == SQUARES[1, 1].color
            && color == SQUARES[2, 2].color)
        {
            LINES[6].Reveal();
            Win = true;
        }
        
        color = SQUARES[2, 0].color;
        if (color > 0
            && color == SQUARES[0, 2].color
            && color == SQUARES[1, 1].color
            && color == SQUARES[2, 0].color)
        {
            LINES[7].Reveal();
            Win = true;
        }
    }
}

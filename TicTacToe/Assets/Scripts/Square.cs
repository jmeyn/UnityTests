using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    /** Whether it is empty (0), X (1), or O (2). */
    public int color;

    /** Stores all the possible sprites. */
    public Sprite emptySquare;
    public Sprite xSprite;
    public Sprite oSprite;

    
    // Start is called before the first frame update
    void Start()
    {
        color = 0;
        
        int x = (int) transform.position.x;
        int y = (int) transform.position.y;
        Board.SQUARES[x, y] = this;
    }

    /** When clicked, update sprite based on what turn it is on. */
    private void OnMouseUpAsButton()
    {
        if (color > 0 || Board.Win)
        {
            return;
        }

        bool turn = Board.Flip();
        if (turn)
        {
            GetComponent<SpriteRenderer>().sprite = xSprite;
            color = 1;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = oSprite;
            color = 2;
        }
        
        Board.CheckWinner();
    }
}

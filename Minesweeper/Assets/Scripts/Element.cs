using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Element : MonoBehaviour {
    /** Whether this element is a mine or not. */
    public bool mine;
    /** Whether this element is flagged or not. */
    public bool flagged;
    /** Whether this element has already been revealed. */
    public bool revealed;

    public Sprite[] emptyTextures;
    public Sprite mineTexture;
    public Sprite flagSprite;
    public Sprite defaultSprite;

    // Start is called before the first frame update
    void Start() {
        //Each space has a 15% chance of being a mine.
        mine = Random.value < 0.15;
        if (!mine)
        {
            Playfield.spaces += 1;
        }

        flagged = false;
        
        // Register in Grid
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Playfield.ELEMENTS[x, y] = this;
    }
    
    /** Is it still covered? */
    public bool isCovered() {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }

    /** Loads the corresponding texture given the number ADJACENTCOUNT. */
    public void loadTexture(int adjacentCount)
    {
        if (flagged)
        {
            GetComponent<SpriteRenderer>().sprite = flagSprite;
        }
        else
        {
            if (!revealed)
            {
                GetComponent<SpriteRenderer>().sprite = defaultSprite;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite
                    = mine ? mineTexture : emptyTextures[adjacentCount];
            }
        }
    }

    /** Reveal element. */
    private void reveal()
    {
        if (Playfield.isFinished())
        {
            return;
        }
        
        revealed = true;
        
        // It's a mine.
        if (mine)
        {
            Playfield.uncoverMines();
            print("You lose!");
        }
        // It's not a mine.
        else
        {
            // show adjacent mine number
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            loadTexture(Playfield.adjacentMines(x, y));

            // uncover area without mines
            Playfield.uncover(x, y, new bool[Playfield.WIDTH, Playfield.HEIGHT]);

            if (Playfield.isFinished())
            {
                print("You win!");
                Playfield.winScreen.win();
            }
        }
    }

    /** Flag the element. */
    public void flag()
    {
        if (Playfield.isFinished())
        {
            return;
        }
        
        flagged = !flagged;
        // show adjacent mine number
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        loadTexture(Playfield.adjacentMines(x, y));
    }    
    
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            reveal();
        else if (Input.GetMouseButtonDown(1))
            flag();
    }
}

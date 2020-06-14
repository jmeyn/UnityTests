using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Element : MonoBehaviour {
    /** Whether this element is a mine or not. */
    public bool mine;

    public Sprite[] emptyTextures;
    public Sprite mineTexture;

    // Start is called before the first frame update
    void Start() {
        //Each space has a 15% chance of being a mine.
        mine = Random.value < 0.15;
        
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
        GetComponent<SpriteRenderer>().sprite 
            = mine ? mineTexture : emptyTextures[adjacentCount];
    }

    private void OnMouseUpAsButton()
    {
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
            }
        }
    }
}

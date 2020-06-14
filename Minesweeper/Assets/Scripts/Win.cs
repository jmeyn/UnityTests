using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        Playfield.winScreen = this;
    }

    // Win the game! Show this screen
    public void win()
    {
        GetComponent<Renderer>().enabled = true;
    }
}

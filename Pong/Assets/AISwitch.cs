using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISwitch : MonoBehaviour
{
    /** State of AI: false is manual, true is AI. */
    private bool state;

    /** Which paddle. false = left paddle, true = right. */
    public bool paddle;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        state = false;
    }

    /** Alternates AI state. */
    void Switch()
    {
        GetComponent<SpriteRenderer>().color = state ? Color.red : Color.green;

        if (paddle)
        {
            GameObject.Find("RacketRight").GetComponent<AI>().enabled = !GameObject.Find("RacketRight").GetComponent<AI>().enabled;
            GameObject.Find("RacketRight").GetComponent<MoveRacket>().enabled = !GameObject.Find("RacketRight").GetComponent<AI>().enabled;
        }
        else
        {
            GameObject.Find("RacketLeft").GetComponent<AI>().enabled = !GameObject.Find("RacketLeft").GetComponent<AI>().enabled;
            GameObject.Find("RacketLeft").GetComponent<MoveRacket>().enabled = !GameObject.Find("RacketLeft").GetComponent<AI>().enabled;
        }

        state = !state;
    }

    /** When button is clicked. */
    private void OnMouseUpAsButton()
    {
        Switch();
    }
}

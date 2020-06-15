using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solution : MonoBehaviour
{
    public int number;

    private void Start()
    {
        Board.LINES[number] = this;
        GetComponent<Renderer>().enabled = false;
    }

    public void Reveal()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    /** How fast the AI moves. */
    public float _speed = 40;
    
    void FixedUpdate()
    {
        var actualY = (int) GetComponent<Rigidbody2D>().position.y;
        var targetY = GameObject.Find("Ball").GetComponent<Rigidbody2D>().position.y;

        var compare = targetY - actualY;
        if (Math.Abs(compare) < 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            return;
        }
        
        if (compare > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * _speed;    
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * _speed;   
        }
    }    
}

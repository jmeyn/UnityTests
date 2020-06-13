using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GameObject.Find("Ball").GetComponent<Rigidbody2D>().velocity.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour {
    /** Stores each individual racket's speed. */
    public float _speed = 30;

    /** What input axis we are reading from. */
    public string _axis = "Vertical";

    void FixedUpdate() {
        float v = Input.GetAxisRaw(_axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * _speed;
    }
}

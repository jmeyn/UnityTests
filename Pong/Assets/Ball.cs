using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float _speed = 30;
    AudioSource[] _sounds;

    // Start is called before the first frame update
    void Start() {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * _speed;

        _sounds = GetComponents<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider
        if (col.gameObject.name == "RacketLeft") {
            float y = hitFactor(transform.position, col.transform.position,
                                col.collider.bounds.size.y);
            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;
            
            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * _speed;
            _sounds[0].Play();
        } else if (col.gameObject.name == "RacketRight") {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * _speed;
            _sounds[0].Play();
        /** Right player scores. 
          * Increase their points by 1, play sound, pause, reset ball. */
        } else if (col.gameObject.name == "WallLeft") {
            GameObject.Find("RightScore").GetComponent<Increment>().Inc();
            StartCoroutine(reset(-1));
        /** Left player scores. 
          * Increase their points by 1, play sound, pause, reset ball. */
        } else if (col.gameObject.name == "WallRight") {
            GameObject.Find("LeftScore").GetComponent<Increment>().Inc();
            _sounds[1].Play();
            StartCoroutine(reset(1));
        } else if (col.gameObject.name == "WallTop") {
            _sounds[2].Play();
        } else if (col.gameObject.name == "WallBottom") {
            _sounds[2].Play();
        }

        IEnumerator reset(int direction)
        {
            _sounds[1].Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            //Wait for 2 seconds
            yield return new WaitForSeconds(2);

            GetComponent<Transform>().position = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().velocity = 
                    new Vector2(Random.Range(0.2f,1f), Random.Range(-0.8f, 0.8f)) 
                    * (_speed * 0.9f) * direction;
        }
    }

    /** Returns a float value between -1 and 1 that describes the relative
      * height of the ball to the racket. */
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}

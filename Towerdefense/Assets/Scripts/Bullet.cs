using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /** Speed */
    public float speed = 10;

    /** Target (set by Tower) */
    public Transform target;
    
    
    /** Fly to the nearest monster. */
    void FixedUpdate() {
        // Still has a Target?
        if (target) {
            // Fly towards the target
            Vector3 dir = target.position - transform.position;
            GetComponent<Rigidbody>().velocity = dir.normalized * speed;
        } else {
            // Otherwise destroy self
            Destroy(gameObject);
        }
    }
    
    /** As soon as bullet enters Monster body, reduce its health. */
    void OnTriggerEnter(Collider co) {
        Health health = co.GetComponentInChildren<Health>();
        if (health) {
            health.decrease();
            Destroy(gameObject);
        }
    }
}

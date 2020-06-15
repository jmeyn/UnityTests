using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    /** Stores TextMesh Component. */
    private TextMesh tm;
    
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
    
    // Return the current Health by counting the '-'
    public int current() {
        return tm.text.Length;
    }

    // Decrease the current Health by removing one '-'
    public void decrease() {
        if (current() > 1)
            tm.text = tm.text.Remove(tm.text.Length - 1);
        else
            Destroy(transform.parent.gameObject);
    }
}

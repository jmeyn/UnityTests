using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Increment : MonoBehaviour
{
    public Text _text;
    public int _count = 0;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();    
        _count = 0;
    }

    // Called when ball hits the right wall
    public void Inc()
    {
        _count += 1;
        _text.text = _count.ToString();
    }
}

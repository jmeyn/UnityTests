using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildplace : MonoBehaviour
{
    /** The tower that will be built. */
    public GameObject towerPrefab;

    public void OnMouseUpAsButton()
    {
        // Build Tower above Buildplace
        GameObject g = (GameObject)Instantiate(towerPrefab);
        g.transform.position = transform.position + Vector3.up;
    }
}

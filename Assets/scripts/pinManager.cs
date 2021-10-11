using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinManager : MonoBehaviour
{
    public GameObject r500m;
    public GameObject r1000m;
    public GameObject r3000m;
    public GameObject r5000m;
    public int availability;
    void Start()
    {
        GameObject child;

        if (availability == 500)
        {
            child = r500m;
        }
        else if (availability == 1000)
        {
            child = r1000m;
        }
        else if (availability == 1000)
        {
            child = r3000m;
        }
        else
        {
            child = r5000m;
        }
        child = Instantiate(child, parent: gameObject.transform);
        child.transform.SetParent(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

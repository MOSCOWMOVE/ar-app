using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pin;
    void Start()
    {
        pin.GetComponent<pinManager>().availability = 1000;
        Instantiate(pin, gameObject.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

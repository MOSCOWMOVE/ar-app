using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMapScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject slider;
    public GameObject cube;
    public GameObject map;
    void Start()
    {
        slider = GameObject.FindGameObjectsWithTag("sliderManager")[0];
        if (slider.GetComponent<SliderManager>().typeOfMap  == 1)
        {
            Instantiate(cube, gameObject.transform);
        }
        else
        {
            Instantiate(map, gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

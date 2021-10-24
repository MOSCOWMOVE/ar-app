using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighDistrictManager : MonoBehaviour
{
    // Start is called before the first frame update
    //вешается на объект района
    int points = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clearPoints( float year)
    {
        this.points = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "point")
        {
            this.points += 1;
        }
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        var density = gameObject.transform.parent.gameObject.GetComponent<districtManager>().density;

        float k = (float)density[(int.Parse(gameObject.name)-1)].density / 30387f * points;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, k, gameObject.transform.localScale.z);
    }
}

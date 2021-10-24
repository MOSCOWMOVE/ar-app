using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SliderManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject map;
    public GameObject ArSession;
     ARTrackedImageManager m_TrackedImageManager;
    public int typeOfMap ;
    public GameObject mapPrefab;

    void Start()
    {
        /*        m_TrackedImageManager = ArSession.GetComponent<ARTrackedImageManager>();
        */
/*        Instantiate(mapPrefab, gameObject.transform);
*/    }

    void Update()
    {
/*        if  (m_TrackedImageManager.trackables.count > 0)
        {
            foreach (var trackedImage in m_TrackedImageManager.trackables)
            {
                if (trackedImage.name == "cube")
                {
                    this.typeOfMap = 1;
                }
                else { this.typeOfMap = 0; }
            }
        }*/

    }
    public void setNewPoints(float year)
    {
        map = GameObject.FindGameObjectsWithTag("map")[0];
        map.GetComponent<districtManager>().setPointsByDSlider(year);
    }
    public void setNewDistricrHigh(float year)
    {
        map = GameObject.FindGameObjectsWithTag("map")[0];
        map.GetComponent<districtManager>().setDistrictHigh(year);
    }

}

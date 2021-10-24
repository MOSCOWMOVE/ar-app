using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class districtManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject point;

    public List<Dencity> density;
    List<SportZone> zones;
    getColor getColor;
    Slider slider;
    public GameObject spawner;
    float previousSliderValue = 2010;
    void Start()
    {
        slider = GameObject.FindGameObjectsWithTag("slider")[0].GetComponent<Slider>();
        spawnPoints();
        drawDistricts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setDistrictHigh(float year)
    {
        int k;
        if (slider.value > previousSliderValue) { k = 1; } else { k = -1; }
        previousSliderValue = slider.value;
        for (var i = 0; i < gameObject.transform.childCount; i++) {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            child.transform.localScale = new Vector3(child.transform.localScale.x, child.transform.localScale.y + (k * UnityEngine.Random.Range(0f, 10.0f)* UnityEngine.Random.Range(0f, 10.0f) * UnityEngine.Random.Range(0f, 10.0f) / 1000f), child.transform.localScale.z);
        }
    }
    public void setPointsByDSlider(float year)
    {
        var delta = (slider.value - 2010) / 11;

        var oldSpawnerPos = GameObject.FindGameObjectsWithTag("spawner")[0].transform.localPosition;
       
        DestroyImmediate(GameObject.FindGameObjectsWithTag("spawner")[0]);
        var newSpawner = Instantiate(spawner, gameObject.transform.parent.transform);
        newSpawner.transform.localPosition = oldSpawnerPos;

        var localZones = zones;
        var copy = zones;
        localZones = localZones.GetRange(0, 100);
        localZones.AddRange(copy.GetRange(100, Convert.ToInt32(100*delta)));
        


        foreach (var zone in localZones)
        {
            /*            Debug.Log((zone.position.longitude - 36.815290f) * 16.1162f);*/
            Vector3 position = new Vector3(
                    x: (zone.position.longitude - 36.815290f) * 16.1162f,
                    y: 1,
                    z: (zone.position.latitude - 55.14071f) * 28.527f
                );
            var newPoint = Instantiate(point, parent: GameObject.FindGameObjectsWithTag("spawner")[0].transform);
            newPoint.gameObject.transform.localPosition = position;
            newPoint.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    public void spawnPoints()
    {


        zones = gameObject.GetComponent<getData>().getPointsData();

        foreach (var zone in zones)
        {
/*            Debug.Log((zone.position.longitude - 36.815290f) * 16.1162f);*/            
            Vector3 position = new Vector3(
                    x: (zone.position.longitude - 36.815290f) * 16.1162f,
                    y: 1,
                    z: (zone.position.latitude - 55.14071f) * 28.527f
                );
            Instantiate(point,parent: GameObject.FindGameObjectsWithTag("spawner")[0].transform).transform.localPosition = position;
        }
    }
    public void drawDistricts()
    {
        var invincibleShader = Shader.Find("Sprites/Diffuse");

        getColor = gameObject.GetComponent<getColor>();
        density = gameObject.GetComponent<getData>().getDistritsDencity();
        for (int i = 0; i < density.Count; i++)
        {
            getColor.RGB newColor = getDistrictColor(Convert.ToInt32(this.density[i].density));
            /*            Debug.Log(newColor.R.ToString() + " " + newColor.G.ToString() + " " + newColor.B.ToString() + " ");
            */
            GameObject child = gameObject.transform.GetChild(i).gameObject;

            child.AddComponent<MeshCollider>();
            child.AddComponent<HighDistrictManager>();
            child.tag = "district";
            child.GetComponent<MeshRenderer>().materials[0].shader = invincibleShader;
            child.GetComponent<MeshRenderer>().materials[0].color = new Color((float)(newColor.R + 0) / 255f, (float)(newColor.G + 0) / 255f, (float)(newColor.B + 0) / 255f, 0.5f);
/*            float k = (float)density[i].density / 30387f;
            child.transform.localScale = new Vector3(child.transform.localScale.x, 10f * k, child.transform.localScale.z);*/
        }
    }
    getColor.RGB getDistrictColor(int dencity)
    {
        int maxDencity = 30387;
        int h = 160 - (160 * dencity / maxDencity);
        return getColor.HSLToRGB(new getColor.HSL(h, 100, 50));
    }
 

}

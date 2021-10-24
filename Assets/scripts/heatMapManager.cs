using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class heatMapManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> models;
    public List<Dencity> density;
    List<SportZone> zones;
    getColor getColor;
    public Texture2D image;
    void Start()
    {
        drawDistricts();
        spawnPoints();
    }

    // Update is called once per frame
    public void spawnPoints()
    {


        zones = gameObject.GetComponent<getData>().getPointsData();

        foreach (var zone in zones)
        {
            /*            Debug.Log((zone.position.longitude - 36.815290f) * 16.1162f);*/
            var k = Random.RandomRange(0.5f, 15f) / 10f *1.5f;

            int i = Random.Range(0, 3);
            Vector3 position = new Vector3(
                    x: (zone.position.longitude - 36.815290f) * 16.1162f,
                    y: 1 + models[i].transform.position.y * k,
                    z: (zone.position.latitude - 55.14071f) * 28.527f
                );
            GameObject model = Instantiate(models[i], parent: GameObject.FindGameObjectsWithTag("spawner")[0].transform);
            model.transform.localPosition = position;
            model.transform.localScale = new Vector3(model.transform.localScale.x * k, model.transform.localScale.y * k, model.transform.localScale.z * k);
        }
    }
   Color getDistrictColor(int dencity)
    {
        int maxDencity = 30387;
        int h = Random.Range(1,160);
        return image.GetPixel(h,1);
    }
    public void drawDistricts()
        {
            var invincibleShader = Shader.Find("Sprites/Diffuse");

            getColor = gameObject.GetComponent<getColor>();
            density = gameObject.GetComponent<getData>().getDistritsDencity();
            for (int i = 0; i < density.Count; i++)
            {
               
                /*            Debug.Log(newColor.R.ToString() + " " + newColor.G.ToString() + " " + newColor.B.ToString() + " ");
                */
                GameObject child = gameObject.transform.GetChild(i).gameObject;

                child.AddComponent<MeshCollider>();
                child.AddComponent<HighDistrictManager>();
                child.tag = "district";
                child.GetComponent<MeshRenderer>().materials[0].shader = invincibleShader;
                Color districtColor = getDistrictColor(Convert.ToInt32(density[i].density));
                districtColor.a = 0.5f;
                child.GetComponent<MeshRenderer>().materials[0].color = districtColor;
/*            float k = (float)density[i].density / 30387f;
*/            child.transform.localScale = new Vector3(child.transform.localScale.x, 1f, child.transform.localScale.z);
        }
        }
    

}

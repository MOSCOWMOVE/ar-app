using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.JsonUtility;
using Microsoft.CSharp;
public class getData : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Dencity> dencity;
    void Start()
    {
        getPointsData();
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<SportZone> getPointsData()
    {
        string json = string.Empty;

        string url = "http://62.84.122.44:8001/api/sport_zones?limit=100&offset=100";
        List<SportZone> data = new List<SportZone>();

        for (int i = 0; i<=10; i++)
        {
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                json = httpClient.GetStringAsync(url).Result;

            }

            var res = Newtonsoft.Json.JsonConvert.DeserializeObject<SportZones>(json);

            url = res.next;
            data = res.results;
            data.AddRange(res.results);

        }


        return data;
    }

     public List<Dencity> getDistritsDencity()
    {
        string json = string.Empty;

        string url = "http://62.84.122.44:8001/api/people_density?limit=150";

        using (var httpClient = new System.Net.Http.HttpClient())
        {
            json = httpClient.GetStringAsync(url).Result;

        }

        var res = Newtonsoft.Json.JsonConvert.DeserializeObject<PersonDencity>(json);
        var data = res.results;
        return data;
    }


   
}
class PersonDencity
{
    public int count;
    public string next;
    public string previous;
    public List<Dencity> results;
}
public class Dencity
{
    public string name;
    public double density;

    public Dencity(string name, double dencity)
    {
        this.density = dencity;
        this.name = name;
    }
}

class SportZones
{
    public int count;
    public string next;
    public string previous;
    public List<SportZone> results;
}

public class SportZone
{
    public Position position;
    public Accessibility accessibility;
    public double square;

    public SportZone(Position pos, Accessibility accessibility, double square)
    {
        this.position = pos;
        this.accessibility = accessibility;
        this.square = square;
    }
}
public class Position
{
    public float latitude;
    public float longitude;

    public Position(float lat, float lon)
    {
        this.latitude = lat;
        this.longitude = lon;
    }


}
public class Accessibility
{
    public int distance;
    public string name;

    public Accessibility(int dist, string name)
    {
        this.name = name;
        this.distance = dist;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class modeSelectionScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadLogin()
    {
        SceneManager.LoadScene("login");
    }
    public void loadHauseMap()
    {
        SceneManager.LoadScene("hauseMap");
    }
    public void loadEnjoyPeople()
    {
        SceneManager.LoadScene("enjoyPeople");
    }
    public void loadHeatMap()
    {
        SceneManager.LoadScene("heatMap");
    }
}



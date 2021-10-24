using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loginScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject login;
    public GameObject password;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void onLogin()
    {
        try
        {
            if (login.GetComponent<Text>().text == "admin" && password.GetComponent<Text>().text == "admin")
            {
                SceneManager.LoadScene("modeSelection");
            }
        }
        catch
        {
            Debug.Log("fuck");
        }


    }
    void Update()
    {
        
    }
}

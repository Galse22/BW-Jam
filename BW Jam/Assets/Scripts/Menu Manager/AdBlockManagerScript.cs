using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdBlockManagerScript : MonoBehaviour
{
    
    void Start()
    {
        if(PlayerPrefs.GetInt("AdBlockPref") != 0)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            PlayerPrefs.SetInt("AdBlockPref", 1);
        }
    }
}

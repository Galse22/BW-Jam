using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdBlockManagerScript : MonoBehaviour
{
    int adBlockPrefInt;
    public bool isTrue;
    private void Start() {
        adBlockPrefInt = PlayerPrefs.GetInt("AdBlockPref");
        PlayerPrefs.SetInt("AdBlockPref", adBlockPrefInt + 1);
        if(adBlockPrefInt == 1)
        {
            SceneManager.LoadScene(5);
        }
        else if(adBlockPrefInt > 1 && isTrue)
        {
            SceneManager.LoadScene(4);
        }
        PlayerPrefs.SetInt("AdBlockPref", adBlockPrefInt + 1);
    }
    // void Start()
    // {
    //     if(PlayerPrefs.GetInt("AdBlockPref") != 0)
    //     {
    //         SceneManager.LoadScene(4);
    //     }
    // }
}

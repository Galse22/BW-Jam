using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    public Text scoreTXT;
    void Start()
    {
        if(scoreTXT != null)
        {
            scoreTXT.text = "HGIH SCORE: " + PlayerPrefs.GetInt("HighScore").ToString ();
        }
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadScene0()
    {
        SceneManager.LoadScene(0);
    }
}

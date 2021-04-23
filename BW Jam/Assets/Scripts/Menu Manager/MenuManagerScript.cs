using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerScript : MonoBehaviour {
    public Text scoreTXT;
    void Start () {
        if (scoreTXT != null) {
            scoreTXT.text = "HIGH SCORE: " + PlayerPrefs.GetInt ("HighScore").ToString ();
        }
    }

    public void LoadScene1 () {
        SceneManager.LoadScene (1);
        PlayerPrefs.SetInt("AdBlockPref", 1);
    }

    public void LoadScene2 () {
        SceneManager.LoadScene (2);
    }

    public void LoadScene3 () {
        SceneManager.LoadScene (3);
    }

    public void LoadScene4 () {
        SceneManager.LoadScene (4);
    }

    public void LoadScene0 () {
        SceneManager.LoadScene (0);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerScript : MonoBehaviour {
    public Text scoreTXT;
    string sfxString = "event:/Turret Select";
    void Start () {
        if (scoreTXT != null) {
            scoreTXT.text = "HIGH SCORE: " + PlayerPrefs.GetInt ("HighScore").ToString ();
        }
    }

    public void LoadScene1 () {
        FMODUnity.RuntimeManager.PlayOneShot(sfxString);
        SceneManager.LoadScene (1);
    }

    public void LoadScene2 () {
        FMODUnity.RuntimeManager.PlayOneShot(sfxString);
        SceneManager.LoadScene (2);
    }

    public void LoadScene3 () {
        FMODUnity.RuntimeManager.PlayOneShot(sfxString);
        SceneManager.LoadScene (3);
    }

    public void LoadScene4 () {
        FMODUnity.RuntimeManager.PlayOneShot(sfxString);
        SceneManager.LoadScene (4);
    }
}
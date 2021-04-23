using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MToGoToMenu : MonoBehaviour
{
    MusicManager musicManager;
    private void Start() {
        musicManager = GameObject.FindWithTag("MusicManagerGO").GetComponent<MusicManager>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 1f;
            musicManager.SetTo0Danger();
            SceneManager.LoadScene(1);
        }
    }
}

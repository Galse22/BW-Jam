using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MToGoToMenu : MonoBehaviour
{
    MusicManager musicManager;
    string sfxString = "event:/Turret Select";
    public GameObject player;
    private void Start() {
        musicManager = GameObject.FindWithTag("MusicManagerGO").GetComponent<MusicManager>();
        player.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            FMODUnity.RuntimeManager.PlayOneShot(sfxString);
            Time.timeScale = 1f;
            musicManager.SetTo0Danger();
            SceneManager.LoadScene(1);
        }
    }
}

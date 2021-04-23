using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MToGoToMenu : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}

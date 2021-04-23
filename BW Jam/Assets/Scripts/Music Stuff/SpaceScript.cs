using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceScript : MonoBehaviour
{
    bool usedSpace;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space") && !usedSpace)
        {
            SceneManager.LoadScene(1);
            usedSpace = true;
        }
    }
}

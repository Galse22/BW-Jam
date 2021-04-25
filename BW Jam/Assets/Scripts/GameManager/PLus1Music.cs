using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLus1Music : MonoBehaviour
{
    MusicManager musicManager;
    void Start()
    {
        musicManager = GameObject.FindWithTag("MusicManagerGO").GetComponent<MusicManager>();
        if(musicManager.InstanceFunc())
        {
            Invoke("ChangeDanger", 0.25f);
        }
        else
        {
            Invoke("ChangeDanger", 3.6f);
        }
    }

    void ChangeDanger()
    {
        musicManager.IncreaseDanger();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string music = "event:/tower defence for FMOD ";
    // John's stuff

    FMOD.Studio.EventInstance musicEv;

    public int dangerMeter = 0;


    void Awake()
    {
        musicEv = FMODUnity.RuntimeManager.CreateInstance(music);

        musicEv.start();
    }


    // must call function somewhere
    public void CheckDanger()
    {
        musicEv.setParameterByName("Danger", dangerMeter);
    }
}

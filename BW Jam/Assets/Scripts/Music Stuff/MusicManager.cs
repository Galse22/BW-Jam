using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string music = "event:/tower defence for FMOD ";
    // John's stuff
    FMOD.Studio.EventInstance instance;
    

    public int dangerMeter = 0;
    bool audioResumed;
    bool playerInput;
    
    private void Update() {
        if (playerInput == false && Input.anyKeyDown)
        {
            ResumeAudio();
            StartCoroutine("WaitSecondsAudio");
            playerInput = true;
        }
    }


    // must call function somewhere
    public void IncreaseDanger()
    {
        dangerMeter++;
        instance.setParameterByName("Danger", dangerMeter);
    }

    public void ReduceDanger(int value2Decrease)
    {
        dangerMeter = dangerMeter - value2Decrease;
        instance.setParameterByName("Danger", dangerMeter);
    }
    
    public void SetTo0Danger()
    {
        dangerMeter = 0;
        instance.setParameterByName("Danger", dangerMeter);
    }

    IEnumerator WaitSecondsAudio()
    {
        ResumeAudio();
        yield return new WaitForSeconds(3.01f);
        instance = FMODUnity.RuntimeManager.CreateInstance(music);
        instance.start();
    }

    
    public void ResumeAudio()
    {
        if (!audioResumed)
        {
            var result = FMODUnity.RuntimeManager.CoreSystem.mixerSuspend();
            result = FMODUnity.RuntimeManager.CoreSystem.mixerResume();
            audioResumed = true;
        }
    }
}

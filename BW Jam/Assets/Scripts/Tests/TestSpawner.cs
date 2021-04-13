using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestSpawner : MonoBehaviour {
    public GameObject GOtoSpawn;
    public Text txt;
    float deltaTime = 0.0f;
    void Start () {
        for (int i = 0; i < 1001; i++) {
            Instantiate (GOtoSpawn, this.gameObject.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update () {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        txt.text = fps.ToString ();
    }
}
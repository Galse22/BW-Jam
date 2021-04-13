using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float speed;

    public int direction;

    void Start () {
        direction = Random.Range (1, 9);
        speed = Random.Range(0.2f, 9.9f);
        StartCoroutine("coroutine");
    }
    void Update () {
        switch (direction) {
            case 0:
                Debug.LogError ("You fucked up something. Set direction to some value");
                break;

            case 1:
                GoRight ();
                break;

            case 2:
                GoLeft ();
                break;

            case 3:
                GoUp ();
                break;

            case 4:
                GoDown ();
                break;

            case 5:
                GoRight ();
                GoUp ();
                break;

            case 6:
                GoRight ();
                GoUp ();
                break;

            case 7:
                GoLeft ();
                GoUp ();
                break;

            case 8:
                GoLeft ();
                GoDown ();
                break;

        }
    }

    void GoRight () {
        transform.Translate (Vector2.right * speed * Time.deltaTime);
    }

    void GoLeft () {
        transform.Translate (Vector2.left * speed * Time.deltaTime);
    }

    void GoUp () {
        transform.Translate (Vector2.up * speed * Time.deltaTime);
    }

    void GoDown () {
        transform.Translate (Vector2.down * speed * Time.deltaTime);
    }

    IEnumerator coroutine()
    {
        yield return new WaitForSeconds(Random.Range(0.99f, 5.7f));
        direction = Random.Range (1, 9);
        speed = Random.Range(0.2f, 9.9f);
        StartCoroutine("coroutine");
    }
}
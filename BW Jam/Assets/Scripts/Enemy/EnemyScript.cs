using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // code stolen from: https://www.youtube.com/watch?v=KoFDDp5W5p0
    
    [Header("Paththinding Thing")]
    // Array of waypoints to walk from one to the next one
    public Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    [Header("Health Stuff")]
    public float baseHealth;
    float health;

    public float timeToResetMaterial;
    public Renderer rend;
    public Material baseMaterial;
    public Material whiteMat;

	// Use this for initialization
	private void OnEnable() {
        waypointIndex = 0;
        health = baseHealth;
        transform.position = waypoints[waypointIndex].transform.position;
    }
	
	// Update is called once per frame
	private void Update () {

        // Move Enemy
        Move();
	}

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
                if(waypointIndex < waypoints.Length)
                {
                    // checks if it should flip itself
                    ShouldFlipScript shouldFlipScript = waypoints[waypointIndex].GetComponent<ShouldFlipScript>();
                    if(shouldFlipScript.shouldFlip == true)
                    {
                        transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                }
            }
        }
    }

    public void TakeDamage(float damageTaken)
    {
        if(health - damageTaken >= 0)
        {
            health -= damageTaken;
            rend.material = whiteMat;
            Invoke("ResetMaterial", timeToResetMaterial);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    void ResetMaterial()
    {
        rend.material = baseMaterial;
    }
}

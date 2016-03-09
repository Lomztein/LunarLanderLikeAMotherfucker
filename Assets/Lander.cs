using UnityEngine;
using System.Collections;

public class Lander : MonoBehaviour {

    public float rocketFuel;
    public float thrust;
    public float turnSpeed;
    public float collisionTolorance;

    public Transform rocket;
    public Transform[] raycastSources;
    public Rigidbody2D rigidbody;

    private float raycastLength = 0.5f;
    private float currentLandTime;
    public float requiredLandTime = 1f;

    public static int score;
    public static int landings;
    private bool isLanded;

	// Use this for initialization
	void Start () {
	
	}

    void Update () {
        // Handle player input.
        float hor = -Input.GetAxis ("Horizontal");
        rigidbody.AddTorque (hor * turnSpeed * Time.deltaTime);
        if (Input.GetAxis ("Vertical") > 0.5f) {
            rigidbody.AddForceAtPosition (transform.up * thrust * Time.deltaTime, rocket.position);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Vector2.Dot (Vector2.up, transform.up) > 0.97f) {

            bool allGood = true;
            for (int i = 0; i < raycastSources.Length; i++) {
                if (!Physics2D.Raycast (raycastSources[i].position, (Vector2)transform.up * -1f, raycastLength)) {
                    allGood = false;
                }
            }

            if (allGood) {
                Debug.Log ("PENIS");
                currentLandTime += Time.fixedDeltaTime;
                if (currentLandTime > requiredLandTime)
                    Land ();
            } else {
                currentLandTime = 0f;
            }
        }
	}

    void OnCollision2D (Collision2D col) {
        if (col.relativeVelocity.magnitude > collisionTolorance) {
            DieInAFire ();
        }
    }

    void DieInAFire () {

    }

    void Land () {
        //Debug.Log ("The Eagle has landed!");
        landings++;
    }
}

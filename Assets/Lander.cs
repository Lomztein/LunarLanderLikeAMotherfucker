using UnityEngine;
using System.Collections;

public class Lander : MonoBehaviour {

    public float rocketFuel;
    public float thrust;
    public float gravity;

    public Transform[] rockets;
    public Transform[] raycastSources;
    public Rigidbody2D rigidbody;

    private float raycastLength = 0.1f;
    private float currentLandTime;
    public float requiredLandTime = 1f;

    public static int score;
    public static int landings;

	// Use this for initialization
	void Start () {
	
	}

    void Update () {
        // Handle player input.
        float hor = Input.GetAxis ("Horizontal");
        if (hor > 0f) {

        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

	    for (int i = 0; i < raycastSources.Length; i++) {

            bool anyFalse = false;
            if (!Physics2D.Raycast ((Vector2)raycastSources[i].position, (Vector2)transform.up * -1f, raycastLength) &&
                    Vector2.Dot (Vector2.up, (Vector2)transform.up) > 5) {
                anyFalse = true;
            }

            if (anyFalse) {
                currentLandTime += Time.fixedDeltaTime;
                if (currentLandTime > requiredLandTime)
                    Land ();
            } else {
                currentLandTime = 0f;
            }
        }
	}

    void Land () {
        landings++;
    }
}

using UnityEngine;
using System.Collections;

public class SpikeBehaviour : MonoBehaviour {

    private Rigidbody rb;
    public float movementSpeed = 10f;
    public float originTime;

	void Start() 
    {
        originTime = Time.time;
        rb = GetComponent<Rigidbody>();
        rb.velocity = movementSpeed * rb.rotation.eulerAngles;
	}
	
	void Update() 
    {
        if ((Time.time - originTime) > 1)
            Destroy(this);
	}
}

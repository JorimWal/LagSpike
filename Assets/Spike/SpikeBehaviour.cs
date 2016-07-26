using UnityEngine;
using System.Collections;

public class SpikeBehaviour : MonoBehaviour {

    private Rigidbody rb;
    private Transform tr;
    public float movementSpeed = 10f;
    public float originTime;

	void Start() 
    {
        originTime = Time.time;
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        rb.velocity = movementSpeed * tr.rotation.eulerAngles.normalized;
    }
	
	void Update() 
    {
        if ((Time.time - originTime) > 1)
            Destroy(this);
	}
}

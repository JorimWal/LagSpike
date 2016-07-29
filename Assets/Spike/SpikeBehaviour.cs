using UnityEngine;

public class SpikeBehaviour : MonoBehaviour
{
	public float movementSpeed = 10f;

	private Rigidbody rb;
	private Transform tr;
	private float originTime;

	void Start()
	{
		rb = GetComponentInChildren<Rigidbody>();
		tr = GetComponent<Transform>();

		originTime = Time.time;

		rb.velocity = movementSpeed * tr.forward.normalized;
	}

	void Update()
	{
		if (Time.time - originTime > 1)
			Destroy(gameObject);
	}
}
using UnityEngine;

public class SpikeBehaviour : MonoBehaviour
{
	public float movementSpeed = 10;
	public float secondsToLive = 5;

	private Rigidbody rb;
	private Transform tr;

	void Start()
	{
		rb = GetComponentInChildren<Rigidbody>();
		tr = GetComponent<Transform>();

		rb.velocity = movementSpeed * tr.forward.normalized;
	}

	void Update()
	{
		secondsToLive -= Time.deltaTime;

		if (secondsToLive < 0)
			Destroy(gameObject);
	}

	void OnCollisionEnter(Collision col)
	{
		Destroy(gameObject);
	}
}
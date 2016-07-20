using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public float movementSpeed = 10;
	public float pingInSeconds = 1;

	private Rigidbody rb;
	private Queue LagQueue = new Queue();

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		if (!isLocalPlayer)
			return;

		HandleInput();
		ProcessQueue();
	}

	private void HandleInput()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		InputObject io = new InputObject(Time.time, movement);
		LagQueue.Enqueue(io);

		if (movement.sqrMagnitude > 0.1)
			ApplyColor(Color.red);
		else
			ApplyColor(Color.white);
	}

	private void ProcessQueue()
	{
		while (true)
		{
			InputObject input = (InputObject)LagQueue.Peek();

			if (Time.time < input.TimeStamp + pingInSeconds)
				break;

			input = (InputObject)LagQueue.Dequeue();

			rb.AddForce(input.InputVector * movementSpeed);
		}
	}

	void ApplyColor(Color c)
	{
		foreach (var v in GetComponentsInChildren<Renderer>())
			v.material.color = c;
	}
}

class InputObject
{
	public float TimeStamp;
	public Vector3 InputVector;

	public InputObject(float TimeStamp, Vector3 InputVector)
	{
		this.TimeStamp = TimeStamp;
		this.InputVector = InputVector;
	}
}
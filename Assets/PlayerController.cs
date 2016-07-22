using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public float movementSpeed = 5;
	public float pingInSeconds = 0f;

	private Rigidbody rb;
	private Queue LagQueue = new Queue();
    private Camera mainCamera;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
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
        Vector3 pointToLook = Vector3.zero;

        //Determine a lookat point
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            pointToLook = cameraRay.GetPoint(rayLength);
        }

		InputObject io = new InputObject(Time.time, movement, pointToLook);
		LagQueue.Enqueue(io);

        if (movement.sqrMagnitude > 0.1)
            GetComponent<Renderer>().material.color = Color.red;
        else
            GetComponent<Renderer>().material.color = Color.white;
	}

	private void ProcessQueue()
	{
		while (true)
		{
			InputObject input = (InputObject)LagQueue.Peek();

			if (Time.time < input.TimeStamp + pingInSeconds)
				break;

			input = (InputObject)LagQueue.Dequeue();

			rb.velocity = (input.InputVector * movementSpeed);
            Vector3 LookAtVector = input.LookAtVector + transform.position;
            transform.LookAt(new Vector3(LookAtVector.x, transform.position.y, LookAtVector.z));
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
    public Vector3 LookAtVector;

	public InputObject(float TimeStamp, Vector3 InputVector, Vector3 LookAtVector)
	{
		this.TimeStamp = TimeStamp;
		this.InputVector = InputVector;
        this.LookAtVector = LookAtVector;
	}
}
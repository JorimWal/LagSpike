using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCharacterController : NetworkBehaviour
{
	[SyncVar]
	public string playerName;
	[SyncVar(hook = "ApplyColor")]
	public Color playerColor;

	public float movementSpeed = 5;
	public float pingInSeconds = 0f;
	public float fireRate = 0.5f;
	public GameObject Spike;
	public Transform ShotSpawn;

	private Rigidbody rb;
	private Queue LagQueue = new Queue();
	private Camera mainCamera;
	private float nextFire = 0.0f;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		mainCamera = FindObjectOfType<Camera>();
	}

	void FixedUpdate()
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
		bool clicked;

		//Determine a lookat point
		Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayLength;
		if (groundPlane.Raycast(cameraRay, out rayLength))
		{
			pointToLook = cameraRay.GetPoint(rayLength);
		}

		clicked = Input.GetMouseButton(0);

		InputObject io = new InputObject(Time.time, movement, pointToLook, clicked);
		LagQueue.Enqueue(io);
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
			transform.LookAt(new Vector3(input.LookAtVector.x, transform.position.y, input.LookAtVector.z));

			if (input.LeftClick && Time.time > nextFire)
			{
				Instantiate(Spike, ShotSpawn.position, ShotSpawn.rotation);
				nextFire = Time.time + fireRate;
			}
		}
	}

	void ApplyColor(Color c)
	{
		GetComponent<Renderer>().material.color = c;

		//foreach (var v in GetComponentsInChildren<Renderer>())
		//	v.material.color = c;
	}
}

class InputObject
{
	public float TimeStamp;
	public Vector3 InputVector;
	public Vector3 LookAtVector;
	public bool LeftClick;

	public InputObject(float TimeStamp, Vector3 InputVector, Vector3 LookAtVector, bool LeftClick)
	{
		this.TimeStamp = TimeStamp;
		this.InputVector = InputVector;
		this.LookAtVector = LookAtVector;
		this.LeftClick = LeftClick;
	}
}
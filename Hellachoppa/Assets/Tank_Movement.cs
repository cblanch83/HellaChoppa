using UnityEngine;
using System.Collections;

public class Tank_Movement : MonoBehaviour {

	private Transform tr;
	private Rigidbody rb;
	public float speed1, speed2;
	//private float forw, back, left, right;
	//public Transform turretRef1;
	public ParticleSystem dust;
	public bool shooting;
	private RaycastHit rch;

	void Awake()
	{
		tr = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		/*rb.AddRelativeForce(-Physics.gravity.y * rb.mass * Vector3.forward + Vector3.forward * v1 * speed1);
        rb.AddRelativeTorque(-Vector3.right * v2 * speed2 - Vector3.up * h1 * speed2 + Vector3.forward * h2 * speed2);*/

		if (Input.GetKey (KeyCode.UpArrow)) {
			rb.AddRelativeForce(Vector3.forward *  speed1);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			rb.AddRelativeForce(Vector3.back *  speed1);
		}
		//CHECKING VERTICAL MOVEMENT
		if (Input.GetKey(KeyCode.LeftArrow)){
			rb.AddRelativeTorque(Vector3.down * speed2);
			//tr.Rotate(Vector3.down * speed2);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			rb.AddRelativeTorque(Vector3.up * speed2);
			//tr.Rotate(Vector3.up * speed2);
		}

		shooting = Input.GetKey(KeyCode.Space);

		/*
		rb.AddRelativeForce(Vector3.forward *  speed1);
		rb.AddRelativeTorque(Vector3.up * speed2);*/

		//if (shooting)
		//if (Physics.Raycast(turretRef1.transform.position, turretRef1.transform.forward, out rch))
		//	Instantiate(dust, rch.point, Quaternion.Euler(270, 0, 0));
	}
}
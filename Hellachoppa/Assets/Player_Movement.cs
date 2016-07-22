using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

    private Rigidbody rb;
    public float speed1, speed2;
    private float h1, v1, h2, v2;
    public Transform turretRef1, turretRef2;
    public ParticleSystem dust;
    public bool shooting;
    private RaycastHit rch;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        //CHECKING HORIZONTAL MOVEMENT
        h1 = Input.GetAxisRaw("LeftJoystickHorizontal");
        h2 = Input.GetAxisRaw("RightJoystickHorizontal");
        //CHECKING VERTICAL MOVEMENT
        v1 = Input.GetAxisRaw("LeftJoystickVertical");
        v2 = Input.GetAxisRaw("RightJoystickVertical");

        shooting = Input.GetButton("AButton");
    }
    void FixedUpdate()
    {
        /*rb.AddRelativeForce(-Physics.gravity.y * rb.mass * Vector3.forward + Vector3.forward * v1 * speed1);
        rb.AddRelativeTorque(-Vector3.right * v2 * speed2 - Vector3.up * h1 * speed2 + Vector3.forward * h2 * speed2);*/
        rb.AddRelativeForce(-Physics.gravity.y * rb.mass * Vector3.up + Vector3.up * v1 * speed1);
        rb.AddRelativeTorque(Vector3.right * v2 * speed2 - Vector3.forward * h1 * speed2 + Vector3.up * h2 * speed2);

        if (shooting)
            if (Physics.Raycast(turretRef1.transform.position, turretRef1.transform.forward, out rch))
                Instantiate(dust, rch.point, Quaternion.Euler(270, 0, 0));
    }
}

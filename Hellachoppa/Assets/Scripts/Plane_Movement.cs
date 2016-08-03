using UnityEngine;
using System.Collections;

public class Plane_Movement : MonoBehaviour {

    private Rigidbody rb;
    public float speed1, speed2;
    private float h1, v1, h2, v2;
    public Transform turretRef1, missileRef1;
    public ParticleSystem dustPrefab;
    public GameObject missilePrefab;
    public bool shooting;
    private RaycastHit rch;
    private AudioSource[] ausos;
    public AudioClip gunSound;
    private int ausos_nmb, ausos_i;

    public string LeftJoystickHorizontal, RightJoystickHorizontal, LeftJoystickVertical, RightJoystickVertical,
        RightBumper, LeftBumper;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ausos = GetComponents<AudioSource>();
        ausos_nmb = ausos.Length;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //CHECKING HORIZONTAL MOVEMENT
        h1 = Input.GetAxisRaw(LeftJoystickHorizontal);
        h2 = Input.GetAxisRaw(RightJoystickHorizontal);
        //CHECKING VERTICAL MOVEMENT
        v1 = Mathf.Clamp01(Input.GetAxisRaw(LeftJoystickVertical));
        v2 = Input.GetAxisRaw(RightJoystickVertical);

        if (Input.GetButton(RightBumper))
        {
            PlayGun(true);
            if (Physics.Raycast(turretRef1.transform.position, turretRef1.transform.forward, out rch))
            {
                ParticleSystem obj = (ParticleSystem)Instantiate(dustPrefab, rch.point, Quaternion.Euler(270, 0, 0));
                Destroy(obj.gameObject, .1f);
            }
        }

        if (Input.GetButtonUp(RightBumper)) PlayGun(false);

        if (Input.GetButtonDown(LeftBumper))
        {
            GameObject obj = (GameObject)Instantiate(missilePrefab, missileRef1.transform.position + missileRef1.transform.forward, transform.rotation);
            obj.GetComponent<Rigidbody>().AddForce(missileRef1.transform.forward * 3000);
        }
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(-Physics.gravity.y * rb.mass * v1 * Vector3.up + Vector3.forward * v1 * speed1 + -Physics.gravity.y * rb.mass * 1.1f * Vector3.forward);
        rb.AddRelativeTorque(Vector3.back * h1 * speed2 + Vector3.up * h2 * speed2 * 1.5f + Vector3.right * v2 * speed2);
    }

    public void PlayGun(bool state)
    {
        if (state)
        {
            //ausos[ausos_i].clip = gunSound;
            if (!ausos[ausos_i].isPlaying) ausos[ausos_i].Play();
        }
        else
            ausos[ausos_i].Stop();
    }
}

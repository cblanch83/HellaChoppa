using UnityEngine;
using System.Collections;

public class Helicopter_Movement : MonoBehaviour {

    private Rigidbody rb;
    public float speed1, speed2;
    private float h1, v1, h2, v2;
	public Transform turretRef1, turretRef2, missileRef1, missileRef2;
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
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        //print("Rotation: " + transform.eulerAngles.x);
        //print("Rotation sin: " + Mathf.Sin(transform.eulerAngles.x*Mathf.PI/180));
        //print("LT: " + Input.GetAxisRaw("LeftTrigger_P1") + " RT: " + Input.GetAxisRaw("RightTrigger_P1"));
        //CHECKING HORIZONTAL MOVEMENT
        h1 = Input.GetAxisRaw(LeftJoystickHorizontal);
        h2 = Input.GetAxisRaw(RightJoystickHorizontal);
        //CHECKING VERTICAL MOVEMENT
        v1 = Input.GetAxisRaw(LeftJoystickVertical);
        v2 = Input.GetAxisRaw(RightJoystickVertical);

        //shooting = Input.GetButton("AButton_P1");
        //if (Input.GetButton("AButton_P1"))
        if (Input.GetButton(RightBumper))
        {
            PlayGun(true);
            if (Physics.Raycast(turretRef1.transform.position, turretRef1.transform.forward, out rch))
            {
                ParticleSystem obj = (ParticleSystem)Instantiate(dustPrefab, rch.point, Quaternion.Euler(270, 0, 0));
                Destroy(obj.gameObject, .1f);
                if (rch.collider.CompareTag("Player"))
                    rch.collider.GetComponent<Health_Manager>().SendMessage("ApplyDamage", 1);
            }
        }
			
        if (Input.GetButtonUp(RightBumper)) PlayGun(false);

        if (Input.GetButtonDown (LeftBumper))
		{
			GameObject obj = (GameObject)Instantiate (missilePrefab, missileRef1.transform.position + missileRef1.transform.forward, transform.rotation);
			obj.GetComponent<Rigidbody> ().AddForce (missileRef1.transform.forward * 3000);
		}
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(-Physics.gravity.y * rb.mass * Vector3.up + Vector3.up * v1 * speed1);
        rb.AddRelativeForce(Mathf.Sin(transform.eulerAngles.x * Mathf.PI / 180) * 1500 * (Vector3.forward + Vector3.up/4));
        rb.AddRelativeTorque(Vector3.right * v2 * speed2 - Vector3.forward * h1 * speed2 + Vector3.up * h2 * speed2 * 1.5f);
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

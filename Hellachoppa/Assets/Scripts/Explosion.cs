using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public GameObject Fire;
    private SphereCollider sc;
    private float expDamage;
    
    void Awake()
    {
        sc = GetComponent<SphereCollider>();
        expDamage = 70;
    }
    // Use this for initialization
    void Start () {
        Destroy(Instantiate(Fire, transform.position, transform.rotation), 2f);
        Destroy(gameObject, .1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Rigidbody col_rb = col.GetComponent<Rigidbody>();
        if (col_rb == null) return;
        col_rb.AddExplosionForce(200000f, transform.position, sc.radius);
        print(col_rb.name + " - Explosion Damage" + 1/(transform.position-col_rb.transform.position).magnitude * expDamage);
        if (col_rb.CompareTag("Player"))
        {
            col_rb.GetComponent<Health_Manager>().SendMessage("ApplyDamage", 1 / (transform.position - col_rb.transform.position).magnitude * expDamage);
        }
    }
}

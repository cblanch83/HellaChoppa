using UnityEngine;
using System.Collections;

public class Missile_Explosion : MonoBehaviour {

    private SphereCollider sc;
    //private Rigidbody col_rb;
    // Use this for initialization
    void Awake () {
        sc = GetComponent<SphereCollider>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision col)
    {
        sc.enabled = true;
        Destroy(gameObject,.1f);
    }
    void OnTriggerEnter(Collider col)
    {
        Rigidbody col_rb = col.GetComponent<Rigidbody>();
        if (col_rb == null) return;
        col_rb.AddExplosionForce(200000f, transform.position, sc.radius);
        //Destroy(gameObject,.1f);
    }
}

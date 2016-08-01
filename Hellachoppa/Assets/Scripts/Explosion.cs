using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public GameObject Fire;
    private SphereCollider sc;
    
    void Awake()
    {
        sc = GetComponent<SphereCollider>();
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
    }
}

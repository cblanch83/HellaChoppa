using UnityEngine;
using System.Collections;

public class Missile_Explosion : MonoBehaviour
{

    public GameObject missileExplosion;
    
    //private Rigidbody col_rb;
    // Use this for initialization
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        Instantiate(missileExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        Instantiate(missileExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}



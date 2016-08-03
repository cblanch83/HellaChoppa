using UnityEngine;
using System.Collections;

public class Health_Manager : MonoBehaviour {

    public GameObject Explosion;
    private BoxCollider bc;
    public int currentHP, maxHP;

    void Awake()
    {
        bc = GetComponent<BoxCollider>();
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        print(this.name + " - Collision damage: " + col.relativeVelocity.magnitude);
        int dmg = (int)col.relativeVelocity.magnitude;
        if (dmg > 10) ApplyDamage(dmg);
    }

    public void Explode()
    {
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void ApplyDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0) Explode();
    }

    void OnDestroy()
    {
        GameObject go = GameObject.Find("End screen");
        if (go == null) return;
        go.SendMessage("FirstDestroyed", this.name);
    }
}

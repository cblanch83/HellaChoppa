using UnityEngine;
using System.Collections;

public class Explosion_Sound : MonoBehaviour {

    private AudioSource auso;
    public AudioClip expSound;

    void Awake()
    {
        auso = GetComponent<AudioSource>();
        auso.clip = expSound;
    }
    // Use this for initialization
    void Start () {
        auso.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

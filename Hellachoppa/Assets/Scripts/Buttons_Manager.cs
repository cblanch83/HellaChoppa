using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("SC_01");
    }
}

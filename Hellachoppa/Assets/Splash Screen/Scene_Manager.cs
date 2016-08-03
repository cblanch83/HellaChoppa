using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Manager : MonoBehaviour {

    private Fading fd;

    void Awake()
    {
        fd = GetComponent<Fading>();
    }
	// Use this for initialization
	void Start () {
        if(SceneManager.GetActiveScene().name == "Splash_Screen") StartCoroutine(Delay_SplashScreen());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Delay_SplashScreen()
    {
        yield return new WaitForSeconds(3);
        float fadetime = fd.BeginFade(1);
        yield return new WaitForSeconds(1+fadetime);
        SceneManager.LoadScene("Main_Menu");
    }
}

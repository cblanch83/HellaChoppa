using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Screen_Manager : MonoBehaviour {

    Text txt;
    Canvas cv;
	// Use this for initialization
	void Awake () {
        txt = GetComponentInChildren<Text>();
        cv = GetComponent<Canvas>();
        //cv.enabled = true;
        //string sarasa = txt.text;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FirstDestroyed(string name)
    {
        Time.timeScale = 0;
        if (name == "Hellachoppa") txt.text = "Hellaplane wins!!";
        else if (name == "Hellaplane") txt.text = "Hellachoppa wins!!";
        cv.enabled = true;
    }
}

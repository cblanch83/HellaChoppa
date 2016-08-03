using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Screen_Manager : MonoBehaviour {

    private Text txt;
    private Canvas cv;
    private bool isEnded;

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
        if (isEnded) return;
        isEnded = true;
        if (name == "Hellachoppa") txt.text = "Hellaplane wins!!";
        else if (name == "Hellaplane") txt.text = "Hellachoppa wins!!";
        StartCoroutine(PopEndScreen());
    }

    IEnumerator PopEndScreen()
    {
        yield return new WaitForSeconds(3.5f);
        Time.timeScale = 0;
        cv.enabled = true;
        Cursor.visible = true;
    }
}

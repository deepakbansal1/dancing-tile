using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Calibrate : MonoBehaviour {

    public Text indv_Touch_no;

    private int no_of_touches;
    
	
	// Update is called once per frame
	void Update () {
        int n;

        if (Text1.actv)
        {
            if (!Int32.TryParse(transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Text>().text, out n))
            {
                no_of_touches = Input.touchCount;
                indv_Touch_no.text = no_of_touches.ToString();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Text1.actv = false;
            SceneManager.LoadScene(0);
        }
	}


    public void SaveMaxTouchValue()
    {
        Text1.actv = false;
        if (Int32.Parse(transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Text>().text) <= 20
            && Int32.Parse(transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Text>().text) >= 2)
        {
            if (!PlayerPrefs.HasKey("Max_Touch_Val"))
            {
                PlayerPrefs.SetInt("Max_Touch_Val", Mathf.Abs
                    (Int32.Parse(transform.GetChild(2).
                    GetChild(0).GetChild(1).GetComponent<Text>().text)));
            }
            else
            {
                PlayerPrefs.SetInt("Max_Touch_Val", Mathf.Abs
                    (Int32.Parse(transform.GetChild(2).
                    GetChild(0).GetChild(1).GetComponent<Text>().text)));
            }
            PlayerPrefs.Save();
            transform.GetChild(2).GetChild(1).GetComponent<Button>().interactable = false;
            Invoke("ShowHomeCanvas", 1);
        }
        else
        {
            transform.GetChild(2).GetChild(0).GetComponent<InputField>().image.color = Color.red;
            Invoke("ResetColor", 0.3f);
        }
        
    }


    void ShowHomeCanvas()
    {
        SceneManager.LoadScene(0);
    }

    void ResetColor()
    {
        transform.GetChild(2).GetChild(0).GetComponent<InputField>().image.color = Color.white;
    }
}

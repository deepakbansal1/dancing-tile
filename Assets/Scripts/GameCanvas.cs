using UnityEngine;
using UnityEngine.UI;
using System;

public class GameCanvas : MonoBehaviour {

    public GameObject gameTilesCanvas;

    public void OnOkPressed()
    {
        if ((Int32.Parse(transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>().text)) <= PlayerPrefs.GetInt("Max_Touch_Val")
            && (Int32.Parse(transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>().text)) <= 4 &&
            (Int32.Parse(transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>().text)) >= 2)
        {
            GameManager.N = Int32.Parse(transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>().text);
            transform.GetChild(0).GetChild(2).GetComponent<Button>().interactable = false;

            gameTilesCanvas.gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).GetChild(1).GetComponent<InputField>().image.color = Color.red;
            Invoke("ResetColor", 0.3f);
        }
    }

    void ResetColor()
    {
        transform.GetChild(0).GetChild(1).GetComponent<InputField>().image.color = Color.white;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public static UI instance;
    public GameObject homeCanvas, gameCanvas, scoreCanvas;


    void Start()
    {
        if (!PlayerPrefs.HasKey("Max_Touch_Val"))
        {
            homeCanvas.transform.GetChild(1).GetComponent<Button>().interactable = false;
            homeCanvas.transform.GetChild(2).GetChild(0).GetComponent<Animator>().SetTrigger("calib_missing");
        }
    }


    public void Home_OnPlayPressed()
    {
        homeCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }


    public void OnGameOver()
    {
        gameCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
    }

    public void Score_OnPlayPressed()
    {
        SceneManager.LoadScene(0);
    }


    public void OnCalibratePressed()
    {
        homeCanvas.transform.GetChild(0).gameObject.SetActive(false);
        homeCanvas.transform.GetChild(1).gameObject.SetActive(false);
        homeCanvas.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        homeCanvas.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
        homeCanvas.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);

    }
}

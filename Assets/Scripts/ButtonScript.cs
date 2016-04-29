using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    [HideInInspector]
    public bool tilePressed;
    public bool blink;

    private int child_position;
    private bool blinkWait;

	// Use this for initialization
	void Start () {
        blink = false;
        tilePressed = false;
        child_position = int.Parse(gameObject.name.Substring(6));

        GetComponent<Button>().interactable = false;
	}
	

    void Update()
    {
        if (blink)
        {
            GetComponent<Button>().interactable = true;
            if (blinkWait == false)
            {
                blinkWait = true;
                StartCoroutine(BtnAlpha());
            }
        }
        else
        {
            StopCoroutine(BtnAlpha());
        }
    }


	public void OnPressed()
    {
        if (blink == true)
        {
            tilePressed = true;
            blink = false;

            Invoke("ChangeColorOnPressed", 0.5f);

            if (GameManager.playerTurn == 1)
            {
                GameManager.instance.AddToList(1, child_position);
                GameManager.playerTurn = 2;
            }
            else
            {
                GameManager.instance.AddToList(2, child_position);
                GameManager.playerTurn = 1;
            }

            GameManager.randomBlinkRun = true;
        }
    }

    public void OnLeft()
    {
        tilePressed = false;
        GameManager.instance.GetPlayerWhoLeftButton(child_position);
    }

    IEnumerator BtnAlpha()
    {
        GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        yield return new WaitForSeconds(0.2f);
        GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 0f / 255f);
        blinkWait = false;
    }

    void ChangeColorOnPressed()
    {
        GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class GameTilesCanvas : MonoBehaviour {

    public GameObject btn;

	// Use this for initialization
	void Start () {
        GameManager.gameStarted = true;

        GetComponent<GridLayoutGroup>().constraintCount = GameManager.N;

        GameManager.playerTurn = 1;

        for (int i = 0; i < GameManager.N *GameManager.N; i++)
        {
            GameObject _button = Instantiate(btn);
            _button.transform.SetParent(transform,true);
            _button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            _button.gameObject.name = "Button" + i;
        }

        foreach (RectTransform item in transform.GetComponentsInChildren<RectTransform>())
        {
            if (item != null)
            {
                item.GetComponent<RectTransform>().localPosition = new Vector3(item.GetComponent<RectTransform>().localPosition.x,
                    item.GetComponent<RectTransform>().localPosition.y,
                    0);
            }
        }

        GameManager.randomBlinkRun = true;
	}
	
	
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemOutput : MonoBehaviour {

    public GameObject itemPanel;
    public GameObject itemText;

    public Text text;

    public void TurnOn()
    {
        itemPanel.SetActive(true);
        itemText.SetActive(true);
    }

    public void TurnOff()
    {
        ClearText();
        itemPanel.SetActive(false);
        itemText.SetActive(false);
    }

    public void SetText(string text)
    {
        ClearText();
        this.text.text = text;
    }

    public void ClearText()
    {
        this.text.text = "";

    }
}

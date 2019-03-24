using UnityEngine;
using System.Collections;
using System.Text;


public class NumbersOnly : MonoBehaviour
{
    //
    GameObject player;

    public bool show = true;

    public GameObject scris;

    private string textFieldValue = "";
    private StringBuilder textFieldTemp = null;
    public int numar;

    void Start()
    {
        scris.SetActive(false);
        player = GameObject.Find("Player");
    }

    public void OnGUI()
    {
        textFieldTemp = new StringBuilder();
        foreach (char c in textFieldValue)
        {
            if (char.IsDigit(c))
            {
                textFieldTemp.Append(c);
            }
        }
        if (show == true) {
            scris.SetActive(true);
            textFieldValue = GUI.TextField(new Rect(327F, 505F, 110F, 20F),
                                           textFieldTemp.ToString());
        }
         
    }
    public void Doneaza()
    {
        //player.GetComponent<Bani>().banile -= textFieldValue;
    }

}
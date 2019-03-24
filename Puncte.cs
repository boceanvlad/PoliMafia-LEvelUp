using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puncte : MonoBehaviour {
    //
    public int points;
    public GameObject player;


    public Text pointsText;
    public Text pointsText1;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        pointsText.text = ("Bani: " + player.GetComponent<inventar>().banile);
    }
}

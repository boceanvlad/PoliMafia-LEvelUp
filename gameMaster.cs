using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour {


    public Text InputText;
    public GameObject player;
    //
    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void salvare()
    {
        player.GetComponent<inventar>().timp = 0;
    }


}

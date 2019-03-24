using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hpNrBar: MonoBehaviour
{
    //
    public GameObject player;
    public GameObject tigan;
    public GameObject textx;

    public Text hpTigan;

    void Start()
    {
        player = GameObject.Find("Player");
        tigan = this.gameObject;
        hpTigan.text = ("" + tigan.GetComponent<AI>().maxHealth);
        
    }

    void Update()
    {

        hpTigan.text = ("" + tigan.GetComponent<AI>().curHealth);

        if (player.transform.position.x < this.transform.position.x)
        {
            textx.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (player.transform.position.x > this.transform.position.x)
        {
            textx.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
using UnityEngine;
using System.Collections;

public class MunteBani : MonoBehaviour {
    //
    public GameObject donatie;
    public GameObject nope;

    public GameObject pilar1;
    public GameObject pilar2;
    public GameObject pilar3;

    GameObject player;
    public int donati;

    void Start () {

        nope.SetActive(true);
        pilar1.SetActive(false);
        pilar2.SetActive(false);
        pilar3.SetActive(false);

        donatie.SetActive(false);
        player = GameObject.Find("Player");
    }
    public void arata()
    {
        if (donatie.activeInHierarchy)
        {
            donatie.SetActive(false);
        }
        else
        {
            donatie.SetActive(true);
        }
    }
    public void suta()
    {
        if (player.GetComponent<inventar>().banile >= 100)
        {
            player.GetComponent<inventar>().banile -= 100;
            donati += 100;
        }
    }
    public void omie()
    {
        if (player.GetComponent<inventar>().banile >= 1000)
        {
            player.GetComponent<inventar>().banile -= 1000;
            donati += 1000;
        }
    }
    public void douamii()
    {
        if (player.GetComponent<inventar>().banile >= 2000)
        {
            player.GetComponent<inventar>().banile -= 2000;
            donati += 2000;
        }
    }

    void Update () {
	if (donati >= 100)
        {
            pilar1.SetActive(true);
        }
    if (donati >= 1000)
        {
            pilar2.SetActive(true);
        }
    if (donati >= 2000)
        {
            pilar3.SetActive(true);
            nope.SetActive(false);
        }
    }

}

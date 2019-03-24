using UnityEngine;
using System.Collections;
using System;

public class upgradeuri : MonoBehaviour {
    //
    GameObject player;

    public int spawnati;

    //---- Discursuri Vendor------
    public GameObject discurs;
    public GameObject discurs1;
    public GameObject discurs2;
    //----------------------------

    //---- Discursuri Kayaba------
    public GameObject kdiscurs;
    public GameObject kdiscurs1;
    public GameObject kdiscurs2;
    //----------------------------

    //---- Discursuri Tristu------
    public GameObject tdiscurs;
    public GameObject tdiscurs1;
    public GameObject tdiscurs2;
    //----------------------------

    //---- Discursuri VTristu-----
    public GameObject vtdiscurs;
    public GameObject vtdiscurs1;
    public GameObject vtdiscurs2;

    public GameObject buton1;
    public GameObject buton2;
    public GameObject buton3;

    public GameObject cameraa;
    public GameObject dialogtrisu;
    public GameObject tristu;
    //-----------------------------

    public GameObject pret1;
    public GameObject pret2;
    public GameObject pret3;
    public GameObject pret4;


    System.Random nr=new System.Random();
    void Start()
    {
        pret1.SetActive(false);
        pret2.SetActive(false);
        pret3.SetActive(false);
        pret4.SetActive(false);
        buton3.SetActive(false);

        player = GameObject.Find("Player");
    }

    public void arata1()
    {
        pret1.SetActive(true);
    }
    public void Nuarata1()
    {
        pret1.SetActive(false);
    }
    public void arata2()
    {
        pret2.SetActive(true);
    }
    public void Nuarata2()
    {
        pret2.SetActive(false);
    }
    public void arata3()
    {
        pret3.SetActive(true);
    }
    public void Nuarata3()
    {
        pret3.SetActive(false);
    }
    public void arata4()
    {
        pret4.SetActive(true);
    }
    public void Nuarata4()
    {
        pret4.SetActive(false);
    }

    public void show()
    {
        if (player.GetComponent<NumbersOnly>().show == false)
        {
            player.GetComponent<NumbersOnly>().show = true;
        }
        
    }

    public void vindepeste()
    { int num = nr.Next(1, 10);
        if (player.GetComponent<inventar>().nrpesti1 >= 1)
        {
            player.GetComponent<inventar>().banile += num;
            player.GetComponent<inventar>().nrpesti1 -= 1;
        }
    }
    public void heal()
    {
        if (player.GetComponent<inventar>().banile >= 50 && player.GetComponent<Player>().curHealth <= 4)
        {
            player.GetComponent<inventar>().banile -= 50;
            player.GetComponent<Player>().curHealth += 1;
        }
    }
    public void sabie()
    {
        if (player.GetComponent<inventar>().banile >= 100)
        {
            player.GetComponent<inventar>().banile -= 100;
            player.GetComponent<inventar>().damage1 += 1;
        }
    }
    public void poveste()
    {
        if (discurs2.activeInHierarchy)
        {
            discurs2.SetActive(false);
            discurs.SetActive(true);
        }
        if (discurs1.activeInHierarchy)
        {
            discurs1.SetActive(false);
            discurs2.SetActive(true);
        }

        if (discurs.activeInHierarchy)
        {
            discurs.SetActive(false);
            discurs1.SetActive(true);
        }
    }
    public void kpoveste()
    {
        if (kdiscurs2.activeInHierarchy)
        {
            kdiscurs2.SetActive(false);
            kdiscurs.SetActive(true);
        }
        if (kdiscurs1.activeInHierarchy)
        {
            kdiscurs1.SetActive(false);
            kdiscurs2.SetActive(true);
        }

        if (kdiscurs.activeInHierarchy)
        {
            kdiscurs.SetActive(false);
            kdiscurs1.SetActive(true);
        }
    }
    public void tpoveste()
    {
        if (tdiscurs2.activeInHierarchy)
        {
            tdiscurs2.SetActive(false);
            tdiscurs.SetActive(true);
        }
        if (tdiscurs1.activeInHierarchy)
        {
            tdiscurs1.SetActive(false);
            tdiscurs2.SetActive(true);
        }

        if (tdiscurs.activeInHierarchy)
        {
            tdiscurs.SetActive(false);
            tdiscurs1.SetActive(true);
        }
    }

    public void vtpovesteDA()
    {
        player.GetComponent<inventar>().banile += 6000;
        vtdiscurs.SetActive(false);
        vtdiscurs1.SetActive(true);
        buton1.SetActive(false);
        buton2.SetActive(false);
        buton3.SetActive(true);
    }
    public void vtpovesteNU()
    {
        vtdiscurs.SetActive(false);
        vtdiscurs2.SetActive(true);
        buton1.SetActive(false);
        buton2.SetActive(false);
        buton3.SetActive(true);
    }
    public void vtpovesteEXIT()
    {
        cameraa.SetActive(false);
        dialogtrisu.SetActive(false);
        tristu.SetActive(false);
    }

    public void prindepeste()
    {   if (player.GetComponent<inventar>().banile >= 200)
        {
            player.GetComponent<inventar>().prindepesti1 += 1;
            player.GetComponent<inventar>().banile -= 200;
         }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class interactorSpawner : MonoBehaviour
{
    //
    public int LoadToLevel;


    public GameObject obiect;


    private gameMaster gm;

    void Start()
    {
        obiect.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        obiect.SetActive(true);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //obiect.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        obiect.SetActive(false);
    }



}
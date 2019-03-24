using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class interactie : MonoBehaviour{
    //
    public int LoadToLevel;


    public GameObject obiect;


    private gameMaster gm;

    void Start()
    {
        
       gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.InputText.text = ("Press [E] to interact");
            if (Input.GetKeyDown("e"))
            {
                SceneManager.LoadScene(LoadToLevel);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
                obiect.SetActive(true);
            //else obiect.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.InputText.text = ("");
            obiect.SetActive(false);
        }
    }



}
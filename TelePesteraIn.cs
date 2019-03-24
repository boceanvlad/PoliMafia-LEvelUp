using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TelePesteraIn : MonoBehaviour {
    //

    public int LoadToLevel;

    private gameMaster gm;
    public GameObject player;

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
                player.transform.position = new Vector3(-15, 1.25F);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.transform.position = new Vector3(-60, 2F);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.InputText.text = ("");
        }
    }

}

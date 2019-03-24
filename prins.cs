using UnityEngine;
using System.Collections;

public class prins : MonoBehaviour {
    GameObject player;
    // Use this for initialization
    //
    void Start () {
        player = GameObject.Find("Player");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
        Destroy(col.gameObject);
        player.GetComponent<inventar>().nrpesti1+=player.GetComponent<inventar>().prindepesti1;

    }
    // Update is called once per frame
    void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class groundcheck2 : MonoBehaviour {
    public AI player;
    //
    void Start()
    {
        player = gameObject.GetComponentInParent<AI>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
    }
    void OnTriggerStay2D(Collider2D Col)
    {
        player.grounded = true;
    }


    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }
}

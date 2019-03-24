using UnityEngine;
using System.Collections;

public class AtackPlayer : MonoBehaviour {
    GameObject player;
    public float atackspeed;
    public float aux;
	// Use this for initialization
    //
	void Start () {
        player = GameObject.Find("Player");
        aux = atackspeed;
	}
    void OnTriggerStay2D(Collider2D col)
    {   
        if (Input.GetMouseButton(0) && atackspeed<=0 )
        {
            
            AI enemy = col.gameObject.GetComponent<AI>();
            if (enemy != null)
            {
                col.gameObject.GetComponent<AI>().Damage(player.GetComponent<inventar>().damage1);

                col.gameObject.GetComponent<AI>().nervos = true;
            }
        }
        
    }
    // Update is called once per frame
    void Update () {
        if (atackspeed > 0)
            atackspeed -= Time.deltaTime;
	
	}
}

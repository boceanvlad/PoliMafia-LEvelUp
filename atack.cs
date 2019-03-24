using UnityEngine;
using System.Collections;

public class atack : MonoBehaviour {
    public float attackspeed=1;
    float atackspeed;
    float aux;
	// Use this for initialization
	void Start()
    {
        aux = attackspeed;
        atackspeed = attackspeed;
    }
    //
	/*void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && attackspeed<=0)
        {   
            col.GetComponent<Player>().Damage(1);
            attackspeed = aux;
        }
    }*/
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && atackspeed <= 0)
        {
            col.GetComponent<Player>().Damage(1);

            atackspeed = aux;
        }
    }
    // Update is called once per frame
    void Update () {if (attackspeed >= 0)
            atackspeed -= Time.deltaTime;
	}
}

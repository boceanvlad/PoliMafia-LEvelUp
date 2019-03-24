using UnityEngine;
using System.Collections;

public class boomerang : MonoBehaviour {
    public int damage;
	// Use this for initialization
    //
	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D col)
    {
        AI pi;
        pi = col.GetComponent<AI>();
        if (pi != null)
        {   if(this.GetComponent<intoarcere>().intors==false)
            col.gameObject.GetComponent<AI>().Damage(damage);
            else col.gameObject.GetComponent<AI>().Damage(2*damage);
            col.gameObject.GetComponent<AI>().nervos = true;
        }
        if(col.CompareTag("Player"))
            if(this.GetComponent<intoarcere>().intors==true)
            {
                col.GetComponent<spells>().CD1 = 0;
                Destroy(this.gameObject);
            }
    }
	// Update is called once per frame
	void Update () {

    }
}

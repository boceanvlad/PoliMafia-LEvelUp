using UnityEngine;
using System.Collections;

public class cutit : MonoBehaviour {
    public int damaj;
	// Use this for initialization
    //
	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D col)
    {
        AI pi;
        pi = col.GetComponent<AI>();
        if(pi!=null)
        {
            col.gameObject.GetComponent<AI>().Damage(damaj);
            col.gameObject.GetComponent<AI>().nervos = true;
            Destroy(this.gameObject);
        }

    }
	// Update is called once per frame
	void Update () {
	
	}
}

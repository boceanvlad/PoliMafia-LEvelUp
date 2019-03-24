using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spells : MonoBehaviour {
    //
    public float CD;
    public float CD1;
    float aux;
    float aux1;
    public Vector3 a;
    public GameObject obiect;
    public GameObject obiect1;
    public GameObject q;
    public GameObject q1;
    public Text cooldown;

    void Start()
    {
        aux = CD;
        aux1 = CD1;
        q.SetActive(true);
        q1.SetActive(true);
        CD = 0;
        CD1 = 0;
        
    }

	void Update()
    {   if (CD1 < 0)
            CD1 = 0F;
        if (CD > 0)
        CD -= Time.deltaTime;
        if (CD1 > 0)
        CD1 -= Time.deltaTime;
        else
        {
            q.SetActive(true);
            q1.SetActive(false);
        }
        if(Input.GetKey(KeyCode.Q) && CD <= 0)
        {   if (this.gameObject.transform.localScale.x == -1)
                a.x = -1;
            else a.x = 1;
            obiect.transform.position = this.gameObject.transform.position;
            obiect.transform.localScale=this.gameObject.transform.localScale;
            obiect.GetComponent<Movable>().direction = a;
            CD = aux;
            Instantiate(obiect);
        }
        if(Input.GetKey(KeyCode.R)&& CD1<=0)
        {
            q1.SetActive(true);
            if (this.gameObject.transform.localScale.x == -1)
                a.x = -1;
            else a.x = 1;
            obiect1.transform.position = this.gameObject.transform.position;
            obiect1.transform.localScale = this.gameObject.transform.localScale;
            obiect1.GetComponent<Movable>().direction = a;
            CD1 = aux1;
            Instantiate(obiect1);
        }
    }
}

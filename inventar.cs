using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class inventar : MonoBehaviour {
    //
    int nrpesti;
    int damage;
    private int nrbani;
    public int banile;
    int prindepesti;
    float x;
    float y;
    public float timp=10;
    public int nrpesti1;
    public int damage1;
    public int prindepesti1;
    GameObject player;
    string tempFile;
    StreamWriter wr;
    StreamWriter fo;
    // Use this for initialization
    void Start()
    {
        /*if(damage1 <= 1)
        {
            damage1 += 1;
        }*/
        player = GameObject.Find("Player");
        tempFile = Path.GetTempFileName();

        if (File.Exists("Status.inv") == false)
        {
            nrpesti = 0;
            damage = 1;
            prindepesti = 1;
            x = -15;
            y = 1.25F;
            wr = new StreamWriter(tempFile);
            wr.Write(nrpesti + " " + damage + " " + prindepesti+" "+x+" "+y + " " +100+" "+0);
            wr.Close();
            File.Copy(tempFile, "Status.inv");
            
        }
        else
        {
            StreamReader fi = new StreamReader("Status.inv");
            string s;
            s = fi.ReadLine();
            string[] a;
            a = s.Split();
            nrpesti = Convert.ToInt32(a[0]);
            damage = Convert.ToInt32(a[1]);
            prindepesti = Convert.ToInt32(a[2]);

            x = float.Parse(a[3]);
            y = float.Parse(a[4]);
            player.GetComponent<Player>().curHealth = Convert.ToInt32(a[5]);
            player.transform.position =new Vector3(x,y,1);
            nrbani = Convert.ToInt32(a[6]);
            fi.Close();
            fi.Dispose();
        }
        nrpesti1 = nrpesti;
        damage1 = damage;
        prindepesti1 = prindepesti;
        banile = nrbani;
    }

    // Update is called once per frame
    public void Update () {
        timp -= Time.deltaTime;
        if (prindepesti != prindepesti1 || damage != damage1 || nrpesti != nrpesti1 || timp <= 0 || banile!=nrbani)
        {
            timp = 10;
            wr = new StreamWriter(tempFile);
            wr.Write(nrpesti1+" "+damage1+" "+prindepesti1+" "+player.transform.position.x+" "+player.transform.position.y + " " + player.GetComponent<Player>().curHealth+" "+banile);
            wr.Close();
            nrpesti = nrpesti1;
            damage = damage1;
            nrbani = banile;
            prindepesti=prindepesti1;
            File.Delete("Status.inv");
            File.Copy(tempFile, "Status.inv");
            File.SetAttributes("Status.inv", FileAttributes.Hidden);
        }
    }
}

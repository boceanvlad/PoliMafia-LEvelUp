using UnityEngine;
using System.Collections;

public class Spini : MonoBehaviour
{
    //
    private Player player;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            player.Damage(100);

            StartCoroutine(player.Knockback(0.02f, 100, player.transform.position));

        }

    }




}
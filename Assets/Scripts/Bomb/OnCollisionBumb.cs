using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionBumb : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bomb;
    public int Count = 1;
    private int i = 0;
    public bool IsBombInst = false;
    public float distAfterPlayerInstBombInXAxis = 10;




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            InstantiateBombs();

        }
    }




    private void InstantiateBombs()
    {
        IsBombInst = true;

        while (i < Count)
        {

            Vector3 Dist = new Vector3(distAfterPlayerInstBombInXAxis, 0, 0);
            Vector3 BombStartingPoint = Player.transform.position + Dist;
            GameObject.Instantiate(Bomb, new Vector3(BombStartingPoint.x, UnityEngine.Random.Range(26, 35), 0f), Quaternion.identity);
            i++;

        }
    }
}

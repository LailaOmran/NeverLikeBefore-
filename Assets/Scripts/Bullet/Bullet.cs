using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public GameObject bullet;
    public float bulletSpeed = 100;
    public AudioClip bulletSound;
    private GameObject bulletInstance;
    private Rigidbody2D bulletRb;
    public GameObject target;
    public float Roatation=45;
   
  




    void Start()
    {

       
        InvokeRepeating("shot", 1f, 1f);//after 1 sec it will call 1 time 
    }

    public void shot()
    {
        float xDir = this.transform.position.x;
        float yDir = this.transform.position.y;
        Vector3 spawnVector = new Vector2(xDir, yDir);
        bulletInstance = Instantiate(bullet, spawnVector, Quaternion.Euler(0,0,Roatation));
        bulletInstance.AddComponent<Rigidbody2D>();
        bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
        Vector2 direction = target.transform.position - transform.position;
        bulletRb.AddForce(direction * bulletSpeed);
        AudioSource.PlayClipAtPoint(bulletSound, bulletInstance.transform.position);
       // bulletInstance.transform.rotation = Quaternion.Euler(0, YRotation, 0);

    }



}
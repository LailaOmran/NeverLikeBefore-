using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class Bomb : MonoBehaviour
    {

        public float bombSpeed = 0.03f;
        public event System.Action explode;
        public GameObject ShadowAnim;
        public AudioClip explosionSound;
        public GameObject[] Grounds;

        public AudioClip BompDroppingSound;
        public GameObject GameManger;
        private GameObject mainCamera;
        private Rigidbody2D rigidBody;
        private GameObject Shadow;
        private GameObject Explode;
        public GameObject explosionFire;
        public float radius;
        public float force;
        private GameObject colliderBombCue;
       


        void Awake()
        {
            colliderBombCue = GameObject.FindGameObjectWithTag("ColliderBombCamEffect");
            colliderBombCue.GetComponent<SetPositionBetweenPlayerBombCue>().bombsCue.Add(this.gameObject);
            Debug.Log(colliderBombCue.GetComponent<SetPositionBetweenPlayerBombCue>().bombsCue[0]);
            AudioSource.PlayClipAtPoint(BompDroppingSound, transform.position, 0.1f);
            InstatiateShadowBomb();
        }


        public void InstatiateShadowBomb()
        {
            Grounds = GameObject.FindGameObjectsWithTag("Ground");
            foreach (GameObject Ground in Grounds) {
                Shadow = Instantiate(ShadowAnim, new Vector3(transform.position.x, Ground.transform.position.y, transform.position.z), Quaternion.identity);
                Debug.Log("shadow");
            }
        }

        public void OnExplode()
        {
            /*
             * Instantiate fire from particle system. 
             */
            Instantiate(explosionFire, transform.position, Quaternion.identity);

            /*
             * Affect all rigidbodies around the explosion.
             */
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (var c in colliders)
            {
                if (c.GetComponent<Rigidbody>() == null)
                {
                    continue;
                }
                else
                {
                    c.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius,
                        0.5f, ForceMode.Impulse);
                }
            }

            if (explode != null)
            {
                explode.Invoke();
            }
        }


        void FixedUpdate()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.velocity = Vector3.down * bombSpeed;

        }

        
        public void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Ground")
            {

                Destroy(this.gameObject);
                colliderBombCue.GetComponent<SetPositionBetweenPlayerBombCue>().bombsCue.Remove(this.gameObject); Destroy(Explode, 2);
                Destroy(Shadow);
                OnExplode();
            }

            if (col.gameObject.tag == "Player")
            {
                /*
                 * Start player die animation. 
                 */
                //  Destroy(col.gameObject);
                Debug.Log("Player Died :/");
                GameManger_Master.CallEventGameOver();
            }
        }

    }
}
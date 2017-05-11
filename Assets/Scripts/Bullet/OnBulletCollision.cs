using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class OnBulletCollision : MonoBehaviour
    {
       
        public GameObject GameManger;

        private void Start()
        {
            
        }
        void OnCollisionEnter2D(Collision2D col)
        {

            if (col.gameObject.tag == "Ground")
                Destroy(this.gameObject);


            if (col.gameObject.tag == "Player")
            {
                Debug.Log("Player Died :/");
                GameManger_Master.CallEventGameOverBullet();
            }

        }
    }
}

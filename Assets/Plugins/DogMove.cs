using UnityEngine;
using System.Collections;

public class DogMove : MonoBehaviour
{
   
    public Transform target;
    public float Dist = 3.0f;
    public bool facingright;
    //public Animator animator;
    public Rigidbody2D rd;
    void Start()
    {

        facingright = true;
        target = GameObject.FindWithTag("Player").transform;
       

    }

    void Update()
    {
        LookAt();
       
        if (target.gameObject.GetComponent<Rigidbody2D>().velocity.x > 5)
        {
            
           this.GetComponent<Animator>().SetInteger("speed", 1);
        }
        else
           this.GetComponent<Animator>().SetInteger("speed", 0);

    }



    void FixedUpdate()
    {


       
        Vector2 pos = target.position;
        pos.x = target.position.x + Dist;
        pos.y = target.position.y ;

        iTween.MoveUpdate(gameObject,pos,5f);
      
    }

   
    private void LookAt()
    {
        if (target != null)
        {
            float dir = target.transform.position.x -transform.position.x+Dist ;

           
            if (dir < 0 && facingright || dir > 0 && !facingright)
            {
                facingright = !facingright;

                Vector3 theScale = transform.localScale;

                theScale.x *= -1;


                transform.localScale = theScale;
            }
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyInBackground : MonoBehaviour
{
    public GameObject boyPrefab;
    private GameObject boyInstance;
    private GameObject mainCamera;
    private Camera camComponent;
    private bool flag = true;


    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camComponent = mainCamera.GetComponent<Camera>();
    }


    private void OnTriggerEnter2D(Collider2D col2d)
    {

        if (col2d.gameObject.tag == "Player" && flag)
        {
            flag = false;
            boyInstance = Instantiate(boyPrefab, new Vector3(mainCamera.transform.position.x + (camComponent.orthographicSize * camComponent.aspect), transform.position.y, 0), Quaternion.identity);
        }
    }


    private void Update()
    {

        if (!flag)
        {
            boyInstance.transform.Translate(Vector3.left * Time.deltaTime);

            if (boyInstance.transform.position.x <= (mainCamera.transform.position.x - (camComponent.orthographicSize * camComponent.aspect)))
            {
                Destroy(boyInstance);
                flag = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleInBackground : MonoBehaviour
{
    public GameObject peoplePrefab;
    public Vector2 delayTime = new Vector2(1, 5);
    private List<GameObject> peopleInstances;
    private GameObject peopleInstance;
    private GameObject mainCamera;
    private Camera camComponent;
    private bool flag = true;
    private const int MAX_NUMBER_PEOPLE = 4;


    private void Awake()
    {
        peopleInstances = new List<GameObject>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camComponent = mainCamera.GetComponent<Camera>();
    }


    private void OnTriggerEnter2D(Collider2D col2d)
    {
        if (col2d.gameObject.tag == "Player" && flag)
        {
            InvokeRepeating("PeopleInstantiation", UnityEngine.Random.Range(delayTime.x, delayTime.y), UnityEngine.Random.Range(delayTime.x, delayTime.y));
        }
    }


    public void PeopleInstantiation()
    {
        flag = false;
        if (peopleInstances.Count >= MAX_NUMBER_PEOPLE)
        {
            CancelInvoke("PeopleInstantiation");
        }
        else
        {
            peopleInstances.Add(Instantiate(peoplePrefab, new Vector3(mainCamera.transform.position.x + (camComponent.orthographicSize * camComponent.aspect), transform.position.y, 0), Quaternion.identity));
        }
    }


    private void Update()
    {
        foreach (var item in peopleInstances)
        {

            item.transform.Translate(Vector3.left * 10 * Time.deltaTime);
            if (item.transform.position.x <= (mainCamera.transform.position.x - (camComponent.orthographicSize * camComponent.aspect)))
            {
                peopleInstances.Remove(item);
                Destroy(item);
            }
        }
    }
}

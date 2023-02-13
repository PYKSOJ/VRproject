using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welding_spark : MonoBehaviour
{

    public GameObject Prefab;
    public GameObject Prefab2;
    public GameObject SparkEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "weidingN")
        {
            Vector3 globalPositionOfContact = collision.contacts[0].point;
            Vector3 spawnPos = new Vector3(globalPositionOfContact.x, transform.position.y, globalPositionOfContact.z);
            Instantiate(Prefab, globalPositionOfContact, Quaternion.identity);
        }

    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "weidingN")
        {
            
            ContactPoint[] contacts = new ContactPoint[10];
            int numContacts = collision.GetContacts(contacts);
            for (int i = 0; i < numContacts; i++)
            {
                Instantiate(Prefab, contacts[i].point, Quaternion.identity);
                GameObject Spark = Instantiate(SparkEffect, contacts[i].point, Quaternion.Euler(-90, 0, 0));
                Spark.GetComponent<ParticleSystem>().Play();
            }
        }

        if (collision.gameObject.tag == "weidingMIG")
        {
            
            ContactPoint[] contacts = new ContactPoint[10];
            int numContacts = collision.GetContacts(contacts);
            for (int i = 0; i < numContacts; i++)
            {
                Instantiate(Prefab2, contacts[i].point, Quaternion.identity);
                GameObject Spark = Instantiate(SparkEffect, contacts[i].point, Quaternion.Euler(-90, 0, 0));
                Spark.GetComponent<ParticleSystem>().Play();
            }
        }



    }

}

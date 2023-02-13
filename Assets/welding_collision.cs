using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class welding_collision : MonoBehaviour
{

    public Material ironA;
    public GameObject Prefab;
    public int HitTime;
    private int Hit = 0;

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
        
        if (collision.gameObject.tag == "hammer")
        {
            Hit++;
            if (Hit < HitTime)
            {
                Vector3 spawnPos = new Vector3(Random.Range(transform.position.x + 0.01f, transform.position.x + 0.1f), transform.position.y, Random.Range(transform.position.z + 0.01f, transform.position.z + 0.1f));
                Instantiate(Prefab, spawnPos, Quaternion.identity);
            }
            else
            {
                GetComponent<MeshRenderer>().material = ironA;
            }


        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hammer"))
        {
            Hit++;
            if (Hit == HitTime)
            {
                int A = Random.Range(0, 10);
                if( A == 0)
                {
                    Vector3 spawnPos = new Vector3(Random.Range(transform.position.x + 0.01f, transform.position.x + 0.01f), transform.position.y, Random.Range(transform.position.z + 0.01f, transform.position.z + 0.1f));
                    Instantiate(Prefab, spawnPos, Quaternion.identity);
                }
                GetComponent<MeshRenderer>().material = ironA;
            }
            
        }
    }

}

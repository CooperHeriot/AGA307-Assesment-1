using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Target")
        {
            if (collision.gameObject.GetComponent<Target>() != false)
            {
                collision.gameObject.GetComponent<Target>().Hurt();
                Destroy(gameObject);
            } else
            {
                collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                Destroy(collision.gameObject, 1);
                Destroy(gameObject);
            }            
        }
    }
}

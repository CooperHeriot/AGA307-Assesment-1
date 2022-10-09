using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 1000;
    public Transform firingPoint;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectileInstance;
            projectileInstance = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * projectileSpeed);

            Destroy(projectileInstance, 5);
        }

        RaycastHit hit;

        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, fwd, out hit, 10))
            {
                print(hit.collider.name);

                if (hit.collider.transform.tag == "Target")
                {
                    hit.collider.GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }

        
    }
}

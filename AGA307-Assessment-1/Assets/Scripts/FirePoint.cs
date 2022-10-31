using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirePoint : MonoBehaviour
{
    public List<GameObject> Projectiles;
    public int weaponSelect;
    public TextMeshProUGUI UI;
    public GameObject projectilePrefab;
    public float projectileSpeed = 1000;
    public Transform firingPoint;

    public bool inZone;
    public GameObject tp;

    private GameObject orb;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (weaponSelect > 3)
        {
            weaponSelect = 1;
        }
        if (weaponSelect < 1)
        {
            weaponSelect = 3;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSelect = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponSelect = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponSelect = 3;
        }

        if (weaponSelect == 1)
        {
            UI.text = ("Ball");
        }
        if (weaponSelect == 2)
        {
            UI.text = ("Floater");
        }
        if (weaponSelect == 3)
        {
            UI.text = ("Bomb");
        }

        weaponSelect += (int)Input.GetAxis("Mouse ScrollWheel");


        projectilePrefab = Projectiles[weaponSelect - 1];

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
            Vector3 fwd = firingPoint.transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(firingPoint.transform.position, fwd, out hit, 10))
            {
                print(hit.collider.name);

                if (hit.collider.transform.tag == "Target")
                {
                    hit.collider.GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }

        if (inZone == true)
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(firingPoint.transform.position, fwd, out hit, 10))
            {
                if (hit.collider.transform.tag == "Orb")
                {
                    orb = hit.collider.gameObject;

                    tp.SetActive(true);

                    orb.GetComponent<MeshRenderer>().material.color = Color.yellow;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                         orb.transform.localScale = new Vector3(1.5f, 0.2f, 1.5f);
                    }

                } else
                {
                    tp.SetActive(false);

                    if (orb != null)
                    {
                        orb.GetComponent<MeshRenderer>().material.color = Color.blue;
                    }                   
                }
            }
        } else
        {
            tp.SetActive(false);

            if (orb != null)
            {
                orb.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
        }
    }
}

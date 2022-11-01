using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public GameObject sphere;   //The object we wish to change
    private Vector3 spize;
    private bool shrink;

    public bool orbMode;
    void Start()
    {
        spize = sphere.transform.localScale;
    }

    void OnTriggerEnter(Collider other)
    {
        

        if(other.CompareTag("Player"))
        {
            if (orbMode == false)
            {
                //change the spheres colour to green
                sphere.GetComponent<MeshRenderer>().material.color = Color.green;
                shrink = false;
            } else
            {
                other.gameObject.GetComponent<FirePoint>().inZone = true;
            }
            
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (orbMode == false)
            {
                //Increas the spheres scale by 0.01 on all axis
                sphere.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (orbMode == false)
            {
                //set the spheres size back to 1
                shrink = true;
                //Change the spheres colour to yellow
                sphere.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else
            {
                other.gameObject.GetComponent<FirePoint>().inZone = false;
            }

        }
    }

    void Update()
    {
        if(shrink == true)
        {
            sphere.transform.localScale = Vector3.Slerp(sphere.transform.localScale, spize, 1 * Time.deltaTime);
        }
    }
}


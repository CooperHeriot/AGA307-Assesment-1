using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public GameObject sphere;   //The object we wish to change
    private Vector3 spize;
    private bool shrink;

    void Start()
    {
        spize = sphere.transform.localScale;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //change the spheres colour to green
            sphere.GetComponent<MeshRenderer>().material.color = Color.green;
            shrink = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Increas the spheres scale by 0.01 on all axis
            sphere.transform.localScale += spize + new Vector3(0.01f, 0.01f, 0.01f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //set the spheres size back to 1
            shrink = true;
            //Change the spheres colour to yellow
            sphere.GetComponent<MeshRenderer>().material.color = Color.yellow;
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


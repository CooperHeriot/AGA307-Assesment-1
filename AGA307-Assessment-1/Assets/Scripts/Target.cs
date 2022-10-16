using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int healt = 5;
 
    public void Hurt()
    {
        healt -= 1;
        if (healt < 1)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            Destroy(gameObject, 1);
        }
    }
}

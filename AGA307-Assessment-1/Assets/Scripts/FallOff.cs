using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOff : MonoBehaviour
{
    private Vector3 starte;
    // Start is called before the first frame update
    void Start()
    {
        starte = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -10)
        {
            if (GetComponent<CharacterController>() != null)
            {
                GetComponent<CharacterController>().enabled = false;
            }
            transform.position = starte;
        } else
        {
            if (GetComponent<CharacterController>() != null)
            {
                GetComponent<CharacterController>().enabled = true;
            }
        }
    }
}

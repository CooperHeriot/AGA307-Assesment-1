using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : GameBehaiour
{
    public int healt = 5;
    public float speed;
    public TargetSize Size;
    public float sizeChange;
    public EnemyManager EM;
   // public GameManager GM;
    public Transform goTo;

    public void Start()
    {
        sizeChange = (int)_GM.difficulty;
        SizeSetup();
        StartCoroutine(Move());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            sizeChange = Random.Range(1, 4);
            print("fdfsdfb");
            SizeSetup();
        }

        if (sizeChange == 1)
        {
            Size = TargetSize.small;
        }
        if (sizeChange == 2)
        {
            Size = TargetSize.mid;
        }
        if (sizeChange == 3)
        {
            Size = TargetSize.big;
        }
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Size = (int)_GM.difficulty;
        }*/
        //manually set sizes
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Size = TargetSize.small;
            SizeSetup();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Size = TargetSize.mid;
            SizeSetup();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Size = TargetSize.big;
            SizeSetup();
        }
    }

    IEnumerator Move()
    {
        goTo = EM.spawnPoints[Random.Range(0, EM.spawnPoints.Length)];
        // transform.position = Vector3.MoveTowards(transform.position, goTo.position, speed * Time.deltaTime);
        /*if (Vector3.Distance(transform.position, goTo.transform.position) > 0.3f)
        {
            yield return new WaitForSeconds(3);
            StartCoroutine(Move());
        } else
        {
            transform.position = Vector3.Slerp(transform.position, goTo.position, speed * Time.deltaTime);
        }*/

        while (Vector3.Distance(transform.position, goTo.position) > 0.3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, goTo.position, speed * Time.deltaTime);
            transform.LookAt(goTo);
            yield return null;
        }
    }

    /*public void InputDiff(int _SizeDiff)
    {
        Size = (TargetSize)_SizeDiff;
        SizeSetup();
    }*/

    public void SizeSetup()
    {
        switch (Size)
        {
            case TargetSize.small:
                transform.localScale = Vector3.one * 0.5f;
                GetComponent<MeshRenderer>().material.color = Color.red;
                speed = 2;
                //sizeChange = 1;
                break;
            case TargetSize.mid:
                transform.localScale = Vector3.one * 1f;
                GetComponent<MeshRenderer>().material.color = Color.yellow;
                speed = 1.5f;
               // sizeChange = 2;
                break;
            case TargetSize.big:
                transform.localScale = Vector3.one * 2f;
                GetComponent<MeshRenderer>().material.color = Color.green;
                speed = 1f;
               // sizeChange = 3;
                break;
        }
    }

    public void Hurt()
    {
        healt -= 1;
        if (healt < 1)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            EM.RemoveEnemy(gameObject);
            //GM.Timer += 5;
            GameManager.instance.Timer += 5;
            Destroy(gameObject, 1);
            _GM.UpdateScore(10);
        }
    }
}

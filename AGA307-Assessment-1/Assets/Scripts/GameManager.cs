using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public static int score;
    public float Timer;
    public TextMeshProUGUI Timee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= (1 * Time.deltaTime);

        Timer = Mathf.Clamp(Timer, 0, 9999);

        Timee.text = Timer.ToString("F0");
    }
}

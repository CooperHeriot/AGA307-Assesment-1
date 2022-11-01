using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI TargetsLeft, difficulty;
    public int Targets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTargets(int _Tar)
    {
        TargetsLeft.text = _Tar.ToString();
    }
}

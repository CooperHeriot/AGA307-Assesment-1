using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI TargetsLeft, difficulty, Score,Timer;
    public Image Meter;
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
    public void ScoreCount(int _scoree)
    {
        Score.text = _scoree.ToString();
        
    }
    public void UpdateDifficulty(Difficulty _dif)
    {
        difficulty.text = _dif.ToString();
    }
    public void UpdateTimer(float _time)
    {
        Timer.text = _time.ToString("F0");

        Timer.color = _time < 10 ? Color.red : Color.white;

        Meter.fillAmount = _time / 30;
    }
}

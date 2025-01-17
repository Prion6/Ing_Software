﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPanel : MonoBehaviour
{
    public Image image;
    public Text text;
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        timer.timeLimit = GameManager.Instance.Game.turnLength;
        timer.OnTick?.AddListener(() => { image.fillAmount = ((timer.timeLimit - timer.timer) / timer.timeLimit); });
        timer.OnTick?.AddListener(() => { text.text = timer.ContdownSec().ToString(); });
        timer.OnFinish?.AddListener(() => GameManager.Instance.NextTurn());
        timer.Init();
    }
}

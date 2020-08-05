using System.Collections;
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
        timer.OnTick?.AddListener(() => { text.text = timer.ElapsedSec().ToString(); });
        timer.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

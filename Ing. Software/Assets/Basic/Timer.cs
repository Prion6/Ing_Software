﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float timeLimit;
    [SerializeField]
    public float timer;
    protected bool paused;
    [SerializeField]
    protected bool inited;
    public UnityEvent OnFinish;
    public UnityEvent OnInit;
    public UnityEvent OnTick;


    // Start is called before the first frame update
    void Awake()
    {
        if(OnFinish == null)
            OnFinish = new UnityEvent();
        if (OnInit == null)
            OnInit = new UnityEvent();
        if (OnTick == null)
            OnTick = new UnityEvent();
        timer = 0;
        //Init();
    }

    // Update is called once per frame

    void Update()
    {
        if (inited)
        {
            if (!paused)
            {
                timer += Time.deltaTime;
                if (timer >= timeLimit)
                {
                    Finish();
                }
                else
                {
                    OnTick?.Invoke();
                }
            }
        }
    }

    public void Restart()
    {
        Init();
    }

    public virtual void Init()
    {
        timer = 0;
        inited = true;
        OnInit?.Invoke();
    }

    public virtual void Finish()
    {
        inited = false;
        OnFinish?.Invoke();
    }

    public int ElapsedMin()
    {
        return (int)timer / 60;
    }

    public int ElapsedSec()
    {
        return (int)timer;
    }

    public int ElapsedMillis()
    {
        return (int)(100 * (timer));
    }

    public int ContdownMin()
    {
        float cd = timeLimit - timer;
        return (int)cd / 60;
    }

    public int ContdownSec()
    {
        float cd = timeLimit - timer;
        return (int)cd;
    }

    public int ContodownMillis()
    {
        float cd = timeLimit - timer;
        return (int)(100 * (cd));
    }

}

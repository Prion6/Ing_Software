using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visor : MonoBehaviour
{
    public Texture texture;
    public Material material;
    public TimerPanel timer;
    // Start is called before the first frame update
    void Start()
    {
        material.mainTexture = texture;
        timer.timer.OnFinish?.AddListener(() => { GameManager.Instance.NextTurn(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

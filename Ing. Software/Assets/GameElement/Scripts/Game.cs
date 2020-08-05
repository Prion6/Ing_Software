﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<Player> players;

    public int maxPlayers;
    public int minPlayers;

    public int turnLength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsFull()
    {
        return !(players.Count < maxPlayers);
    }

    public bool PlayerMinimumReached()
    {
        return !(players.Count >= minPlayers);
    }
}

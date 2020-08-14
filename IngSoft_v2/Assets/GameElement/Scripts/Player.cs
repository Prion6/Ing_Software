using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public PlayerData data;
    public int score;
    public int votes;

    public Player(PlayerData _data)
    {
        data = _data;
        score = 0;
        votes = 0;
    }
}

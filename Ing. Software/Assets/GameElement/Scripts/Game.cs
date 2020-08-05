using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<Player> players;

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
        return !(players.Count < GameManager.maxPlayers);
    }

    public bool PlayerMinimumReached()
    {
        return !(players.Count >= GameManager.minPlayers);
    }
}

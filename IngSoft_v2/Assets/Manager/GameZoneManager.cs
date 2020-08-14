using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameZoneManager : MonoBehaviour
{
    public PlayerInfo playerPanel;

    // Start is called before the first frame update
    void Start()
    {
        playerPanel.Init(GameManager.Instance.GetPlayerInTurn());
    }

    public void AbortGame()
    {
        GameManager.LoadScene("MainMenu");
    }

    public void EndTurn()
    {
        GameManager.Instance.NextTurn();
    }
}

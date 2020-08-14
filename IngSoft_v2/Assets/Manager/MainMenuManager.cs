using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        GameManager.Instance.CreateGame();
        GameManager.LoadScene("Lobby");
    }
}

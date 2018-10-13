using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pausePanel;

   public string state = "Active";

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && state == "Active")
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f; //this pauses the game
            state = "Paused";
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && state == "Paused")
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            state = "Active";
        }
    }

}

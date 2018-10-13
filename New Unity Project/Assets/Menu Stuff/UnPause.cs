using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPause : MonoBehaviour
{
    public GameObject PauseObject;
    PauseMenu Pause;
    public GameObject pausePanel;
    public void Start()
    {
        Pause = PauseObject.GetComponent<PauseMenu>();

    }
    

    public void Unpause ()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Pause.state = "Active";
    }
}

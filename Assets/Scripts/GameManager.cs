using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    #region Unity_functions

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Scene_transitions

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void WinGame()
    {
        SceneManager.LoadScene("EndCutscene");
    }
    #endregion
}

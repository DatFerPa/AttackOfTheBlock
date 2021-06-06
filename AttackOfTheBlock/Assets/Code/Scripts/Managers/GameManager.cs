using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("SampleScene"))
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }


    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void finishGame()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void enterGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}

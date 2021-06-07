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
    /**
     * <sumamry>Función que se encarga de quitar el juego</sumamry>
     */
    public void quitGame()
    {
        Application.Quit();
    }
    /**
     * <sumamry>Función que se encarga de finalizar la partida</sumamry>
     */
    public void finishGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
    /**
     * <sumamry>Función que se encarga de empezar el juego</sumamry>
     */
    public void enterGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}

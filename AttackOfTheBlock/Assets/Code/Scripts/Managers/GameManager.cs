using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
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
     * <sumamry>Función que se encarga de finalizar la partida y cargar el menú de derrota</sumamry>
     */
    public void finishGame()
    {
        SceneManager.LoadScene("MenuGameOver");
    }
    /**
     * <sumamry>Función que se encarga de finalizar la partida y cargar
     *  el menú de victoria</sumamry>
     */
    public void winGame()
    {
        SceneManager.LoadScene("MenuWin");
    }

    /**
     * <sumamry>Función que se encarga de empezar el juego</sumamry>
     */
    public void enterGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    /**
     * <summary>Función que se encarga de carga la escena del menu principal</summary>
     */
    public void goToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }




}

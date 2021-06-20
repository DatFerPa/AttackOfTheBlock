using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameManager : MonoBehaviour
{
    public Canvas pauseMenu;
    private bool _isGamepaused;

    // Start is called before the first frame update
    void Start()
    {
        showHidePauseMenu(false);
    }

    // Time.timescale = 0 / 1
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseUnpauseGame();
        }
    }
 
    /**
     * <summary>Función que se encarga de pausar y resumir el tiempo de juego además de mostrar y ocultar el menu de pausa</summary>
     */
    public void pauseUnpauseGame()
    {
        if (!_isGamepaused)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            _isGamepaused = true;
            showHidePauseMenu(true);
        }
        else
        {
            Time.timeScale = 1;
            _isGamepaused = false;
            Cursor.visible = false;
            showHidePauseMenu(false);
        }
    }


    /**
     * <summary>Función que se encarga de mostrar u ocultar el menú de pausa</summary>
     * <param name="showPauseMenu">Booleano que marca si el menú de pausa se va a ocultar o se va a mostrar</param>
     */
    private void showHidePauseMenu(bool showPauseMenu)
    {
        pauseMenu.gameObject.SetActive(showPauseMenu);
    }

}

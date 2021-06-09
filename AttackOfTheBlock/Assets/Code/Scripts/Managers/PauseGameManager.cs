using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameManager : MonoBehaviour
{

    public Canvas pauseMenu;
    private bool _isGamepaused;
    private bool _isPauseMenuDisplayed;



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

        if (_isGamepaused && !_isPauseMenuDisplayed)
        {
            displayPauseMenu();
        }
    }

    private void displayPauseMenu()
    {
        this._isPauseMenuDisplayed = true;
    }


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



    private void showHidePauseMenu(bool showPauseMenu)
    {
        pauseMenu.gameObject.SetActive(showPauseMenu);
    }

}

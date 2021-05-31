using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        
    }

    public void finishGame()
    {
        Debug.Break();
        Application.Quit();
    }

}

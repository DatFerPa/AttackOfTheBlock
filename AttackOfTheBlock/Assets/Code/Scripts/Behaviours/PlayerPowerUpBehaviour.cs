using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpBehaviour : MonoBehaviour
{
    public int timeToFinishPowerUps;
    public Vector3 playerOriginalScale;

    private float _timeWhenChangeSizeActivated;
    private bool _isChangeSizeActivated;


    void Update()
    {
        if(_isChangeSizeActivated && Time.time >= _timeWhenChangeSizeActivated + timeToFinishPowerUps)
        {
            restorePlayerSize();
        }
    }
    /**
     * <summary>Función que se encarga de cambiar la escala del jugador</summary>
     * <param name="valueToChangeSize">Valor que queremos utilizar para cambiar la escala del jugador</param>
     */
    public void playerChangeSize(float valueToChangeSize)
    {
        this.GetComponent<Transform>().localScale = new Vector3(valueToChangeSize, valueToChangeSize, 1);
        _timeWhenChangeSizeActivated = Time.time;
        _isChangeSizeActivated = true;
    }
    /**
     * <summary>Función que se encarga de devolver al jugador a su escala inicial.</summary>
     */
    private void restorePlayerSize()
    {
        GetComponent<Transform>().localScale = playerOriginalScale;
        _isChangeSizeActivated = false;
    }


}

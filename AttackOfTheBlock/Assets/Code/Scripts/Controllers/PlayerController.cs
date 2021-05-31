using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _isPlayerHitBarrier;
    private BoundsAndCameraManager _boundsAndCameraManager;
    private PlayerBehaviour _playerBehaviour;

    void Start()
    {
        //Buscamos el manager de la cámara para poder acceder a los parámetros de la cámara en cualquier momento
        _boundsAndCameraManager = GameObject.FindObjectOfType<BoundsAndCameraManager>();
        _playerBehaviour = this.GetComponent<PlayerBehaviour>();
    }   

    private void FixedUpdate()
    {
        if (_playerBehaviour.playerLives>0)
        {
            MovePlayer();
        }
    }


    private void MovePlayer()
    {
        /*
       * ScrrenToWorldPoint transforma un punto de la pantalla en un punto en el espacio de juego
       * Forzamos el punto de Z en 0, ya que si nos quedmaos con la que nos da  la función, nos da la z de en la posición donde se encuentra la cámara y no nos mostraria el sprite
       */
        Vector3 mousePositionInGame = _boundsAndCameraManager.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePositionInGame.z = 0;
        if (_boundsAndCameraManager.isPointInsideBoundries(mousePositionInGame) || !this._isPlayerHitBarrier)
        {
            Vector2 positionPlayer = new Vector2(this.transform.position.x, this.transform.position.y);
            this.GetComponent<Rigidbody2D>().MovePosition(Vector2.Lerp(positionPlayer, mousePositionInGame, 0.05f));
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el jugador entra en colisión con una barrera le colocamos al flag un valor de TRUE
        if (collision.collider.tag.Equals("Barrier"))
        {
            _isPlayerHitBarrier = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Si el jugador sale de la colisión con una barrera le colocamos al flag un valor de FALSE
        if (collision.collider.tag.Equals("Barrier"))
        {
            _isPlayerHitBarrier = false;
        }
    }
}

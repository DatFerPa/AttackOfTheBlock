using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Start is called before the first frame update
    private bool _isPlayerHitBarrier;

    private float _heightMainCamera;
    private float _widthMainCamera;
    private Camera _mainCamera;


    void Start()
    {      
        Cursor.visible = false;

        _mainCamera = Camera.main;
        updateCameraSizes();
    }

    // Update is called once per frame
    void Update()
    {
        updateCameraSizes();


        Debug.DrawLine(
            new Vector3(_mainCamera.transform.position.x - (_widthMainCamera / 2), _mainCamera.transform.position.y + (_heightMainCamera / 2), 0),
            new Vector3(_mainCamera.transform.position.x + (_widthMainCamera / 2), _mainCamera.transform.position.y + (_heightMainCamera / 2), 0)
            , Color.red);

        Debug.DrawLine(
            new Vector3(_mainCamera.transform.position.x - (_widthMainCamera / 2), _mainCamera.transform.position.y - (_heightMainCamera / 2), 0),
            new Vector3(_mainCamera.transform.position.x + (_widthMainCamera / 2), _mainCamera.transform.position.y - (_heightMainCamera / 2), 0)
            , Color.red);

        Debug.DrawLine(
            new Vector3(_mainCamera.transform.position.x - (_widthMainCamera / 2), _mainCamera.transform.position.y + (_heightMainCamera / 2), 0),
            new Vector3(_mainCamera.transform.position.x - (_widthMainCamera / 2), _mainCamera.transform.position.y - (_heightMainCamera / 2), 0)
            , Color.red);

        Debug.DrawLine(
            new Vector3(_mainCamera.transform.position.x + (_widthMainCamera / 2), _mainCamera.transform.position.y + (_heightMainCamera / 2), 0),
            new Vector3(_mainCamera.transform.position.x + (_widthMainCamera / 2), _mainCamera.transform.position.y - (_heightMainCamera / 2), 0)
            , Color.red);
    }

    private void FixedUpdate()
    {
        /*
       * ScrrenToWorldPoint transforma un punto de la pantalla en un punto en el espacio de juego
       * Poner lo de que estoy forzando el 0 para que el sprite nunca pase por debajo del punto de vista de la cámara
       * ya que al hacer la conversión de la posición del ratón, esta pilla la posición de camara, logicamente, al utilizar la cámara como el elemento 
       * desde el que saco las posiciones
       */
        Vector3 mousePositionInGame = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePositionInGame.z = 0;
        if (isPointInsideBoundries(mousePositionInGame)||!this._isPlayerHitBarrier)
        {
           //this.GetComponent<Rigidbody2D>().MovePosition(new Vector2(mousePositionInGame.x, mousePositionInGame.y));
            Vector2 positionPlayer = new Vector2(this.transform.position.x, this.transform.position.y);
            this.GetComponent<Rigidbody2D>().MovePosition(Vector2.Lerp(positionPlayer,mousePositionInGame, 0.5f));
        }
        else
        {
            Debug.Log("Epa te saliste fiera");
        }
    }

    bool isPointInsideBoundries(Vector3 newPositionForThePlayer)
    {
        if (newPositionForThePlayer.x < _mainCamera.transform.position.x - (_widthMainCamera / 2)|| newPositionForThePlayer.x > _mainCamera.transform.position.x + (_widthMainCamera / 2))
        {
            return false;
        }else if (newPositionForThePlayer.y < _mainCamera.transform.position.y - (_heightMainCamera / 2) || newPositionForThePlayer.y > _mainCamera.transform.position.y + (_heightMainCamera / 2))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Barrier"))
        {
            Debug.Log("Choque contra una barrera collision 2d");
            _isPlayerHitBarrier = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Barrier"))
        {
            Debug.Log("Sali de un choque contra una barrera collision 2d");
            _isPlayerHitBarrier = false;
        }
    }

    private void updateCameraSizes()
    {
        _heightMainCamera = 2 * _mainCamera.orthographicSize;
        _widthMainCamera = _heightMainCamera * _mainCamera.aspect;
    }


}

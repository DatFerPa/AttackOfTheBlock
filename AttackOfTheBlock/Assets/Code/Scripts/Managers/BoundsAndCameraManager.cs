using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsAndCameraManager : MonoBehaviour
{
    public GameObject prefabBarrier;
    public Camera mainCamera;
    private GameObject[] _barriers;
    private float _heightMainCamera;
    private float _widthMainCamera;
    private Vector2 _prefabBarrierSizes;

    public float heightMainCamera{ get => this._heightMainCamera; }
    public float widthMainCamera { get => this._widthMainCamera; }

    void Start()
    {
        generateBarriers();
        updateCameraSizes();
        updateBarriersPositionAndScale();   
    }


    void Update()
    {
        updateCameraSizes();
        updateBarriersPositionAndScale();
    }

    /**
     * <summary>Función que se encarga de instanciar las cuatro barreras del juego</summary>
     */
    private void generateBarriers()
    {
        //0 - arriba , 1 - derecha , 2 - Abajo, 3 - Izquierda
        _barriers = new GameObject[4];
        //instanciamos las barreras para el juego
        for (int i = 0; i < _barriers.Length; i++)
        {
            _barriers[i] = Instantiate(prefabBarrier, Vector3.zero, Quaternion.identity);
        }
        _prefabBarrierSizes = prefabBarrier.GetComponent<BoxCollider2D>().size;
    }


    /**
     * <summary>Función que se encarga de actualizar la posicón y la escala de los PREFABS Barrier, para que siempre se encuentren en consonancia con el tamaño que ocupa la visión de la cámara de juego</summary>
     */
    private void updateBarriersPositionAndScale()
    {      
        float mediumSizeX = this._prefabBarrierSizes.x / 2;
        float mediumSizeY = this._prefabBarrierSizes.y / 2;

        //Barrera Arriba
        _barriers[0].transform.position = new Vector3(0, (_heightMainCamera / 2) + mediumSizeY, 0);
        _barriers[0].transform.localScale = new Vector3(this._widthMainCamera, 1, 1);
        //Barrera Derecha
        _barriers[1].transform.position = new Vector3((_widthMainCamera / 2) + mediumSizeX, 0, 0);
        _barriers[1].transform.localScale = new Vector3(1, this._heightMainCamera, 1);
        //Barrera Abajo
        _barriers[2].transform.position = new Vector3(0, (-_heightMainCamera / 2) - mediumSizeY, 0);
        _barriers[2].transform.localScale = new Vector3(this._widthMainCamera, 1, 1);
        //Barrera Izquierda
        _barriers[3].transform.position = new Vector3((-_widthMainCamera / 2) - mediumSizeX, 0, 0);
        _barriers[3].transform.localScale = new Vector3(1, this._heightMainCamera, 1);
    }

    /**
     * <summary>Función que se encarga de actualizar el alto y el ancho de lo que puede ver la cámara en unidades de juego</summary>
     */
    private void updateCameraSizes()
    {
        _heightMainCamera = 2 * mainCamera.orthographicSize;
        _widthMainCamera = _heightMainCamera * mainCamera.aspect;
    }


    /**
     * <summary>Función que se encarga de comprobar si un punto se encuentra dentro de los límites del juego marcados por la vista de la cámara</summary>
     * <param name="pointToValidate">El punto del que se quiere comprobar si se encuentra dentro del espacio de juego, representado con un Vector3</param>
     * <returns>Devuelve el valor FALSE si el punto que se le ha pasado se encuentra fuera de los límites de juego y devuelve el valor TRUE si el punto se encuentra fuera de los límites de juego</returns>
     */
    public bool isPointInsideBoundries(Vector3 pointToValidate)
    {
        if (pointToValidate.x < mainCamera.transform.position.x - (widthMainCamera / 2))
        {
            return false;
        }
        else if (pointToValidate.x > mainCamera.transform.position.x + (widthMainCamera / 2))
        {
            return false;
        }
        else if (pointToValidate.y < mainCamera.transform.position.y - (heightMainCamera / 2))
        {
            return false;
        }
        else if (pointToValidate.y > mainCamera.transform.position.y + (heightMainCamera / 2))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

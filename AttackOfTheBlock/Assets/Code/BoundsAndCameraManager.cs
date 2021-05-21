using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsAndCameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabBarrier;
    public Camera mainCamera;
    private GameObject[] _barriers;
    private float _heightMainCamera;
    private float _widthMainCamera;


    public float heightMainCamera{ get => this._heightMainCamera; }
    public float widthMainCamera { get => this._widthMainCamera; }

    void Start()
    {
        Cursor.visible = false;

        //0 - arriba , 1 - derecha , 2 - Abajo, 3 - Izquierda
        _barriers = new GameObject[4];
        //instanciamos las barreras para el juego
        for (int i = 0; i < _barriers.Length; i++)
        {           
            _barriers[i] = Instantiate(prefabBarrier, Vector3.zero,Quaternion.identity);
        }

        updateCameraSizes();
        updateBarriersPositionAndScale();   
    }


    void Update()
    {
        updateCameraSizes();
        updateBarriersPositionAndScale();
    }


    private void updateBarriersPositionAndScale()
    {
        /*
         * El tamaño del collider es 1 por 1, por lo que si queremos que quede perfectamente en el borde
         * tenemos que sumar o restar 0.5 a la osición en x o y de las barreras
         * También podemos escalar el tamaño de las barreras en proporciones de 1
        */
        //Barrera Arriba
        _barriers[0].transform.position = new Vector3(0,(_heightMainCamera/2)+0.5f,0);
        _barriers[0].transform.localScale =  new Vector3(this._widthMainCamera,1,1) ;
        //Barrera Derecha
        _barriers[1].transform.position = new Vector3((_widthMainCamera/2)+0.5f,0,0);
        _barriers[1].transform.localScale = new Vector3(1, this._heightMainCamera, 1);
        //Barrera Abajo
        _barriers[2].transform.position = new Vector3(0, (-_heightMainCamera / 2) - 0.5f, 0);
        _barriers[2].transform.localScale = new Vector3(this._widthMainCamera, 1, 1);
        //Barrera Izquierda
        _barriers[3].transform.position = new Vector3((- _widthMainCamera / 2) - 0.5f, 0, 0);
        _barriers[3].transform.localScale = new Vector3(1, this._heightMainCamera, 1);


    }

    private void updateCameraSizes()
    {
        _heightMainCamera = 2 * mainCamera.orthographicSize;
        _widthMainCamera = _heightMainCamera * mainCamera.aspect;
    }
}

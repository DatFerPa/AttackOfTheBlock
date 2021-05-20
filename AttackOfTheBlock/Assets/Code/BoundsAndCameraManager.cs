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

        //0 - arriba , 1 - derecha , 2 - izquierda, 3 - derecha
        _barriers = new GameObject[4];
        for (int i = 0; i < _barriers.Length; i++)
        {
            _barriers[i] = Instantiate(prefabBarrier, Vector3.zero,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateCameraSizes();
    }


    private void updateBarriersPosition()
    {

    }

    private void updateCameraSizes()
    {
        _heightMainCamera = 2 * mainCamera.orthographicSize;
        _widthMainCamera = _heightMainCamera * mainCamera.aspect;
    }
}

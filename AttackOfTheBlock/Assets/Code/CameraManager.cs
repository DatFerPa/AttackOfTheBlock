using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera _mainCamera;
    private float _heightMainCamera;
    private float _widthMainCamera;
    public static CameraManager _instanceCameraManager;
        
        private CameraManager()
    {
        _instanceCameraManager = new CameraManager();
    }

    public static CameraManager getInstance()
    {
        if (_instanceCameraManager == null)
        {
            _instanceCameraManager =  new CameraManager();
        }
        return _instanceCameraManager;
        
    }

    public Camera mainCamera
    {
        get => this._mainCamera;
    }

    public float heightMainCamera
    {
        get => this._heightMainCamera;
    }

    public float widthMainCamera
    {
        get => this._widthMainCamera;
    }


    void Start()
    {
        _mainCamera = Camera.main;
        updateCameraSizes();
    }

    // Update is called once per frame
    void Update()
    {
        updateCameraSizes();

        /*
         * Lineas para comprobar el area que observa la camara
         * 
         */
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

    private void updateCameraSizes()
    {
        _heightMainCamera = 2 * _mainCamera.orthographicSize;
        _widthMainCamera = _heightMainCamera * _mainCamera.aspect;
    }
}

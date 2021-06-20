using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ErasableObjectsManager : MonoBehaviour
{
    private List<GameObject> _enemies = new List<GameObject>();
    private List<GameObject> _erasableObjects = new List<GameObject>();

    void Update()
    {
        destroyObjects();
        _enemies = (GameObject.FindGameObjectsWithTag("Enemy")).ToList();
        if (_enemies.Count <= 0)
        {
            GetComponent<GameManager>().winGame();
        }
    }

    /**
     * <summary>Función que se encarga de destruir todos los objetos que se encuentran en la lista de objetos a destruir _erasableObjects</summary>
     */
    private void destroyObjects()
    {
        foreach(GameObject gameObjectToDestroy in _erasableObjects)
        {
            Destroy(gameObjectToDestroy);
        }
        _erasableObjects.Clear();
    }

    /**
     * <summary>Función que se encarga de añadir objetos a la lista de objetos a destruir _erasableObjects</summary>
     */
    public void addErasableObject(GameObject erasableToAdd)
    {
        _erasableObjects.Add(erasableToAdd);
    }


}

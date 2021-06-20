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
            Debug.Log("no quedan enemigos");
            GetComponent<GameManager>().winGame();
        }
    }
    
    private void destroyObjects()
    {
        foreach(GameObject gameObjectToDestroy in _erasableObjects)
        {
            Destroy(gameObjectToDestroy);
        }
        _erasableObjects.Clear();
    }

    public void addErasableObject(GameObject erasableToAdd)
    {
        _erasableObjects.Add(erasableToAdd);
    }


}

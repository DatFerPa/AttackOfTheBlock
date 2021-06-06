using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas gameCanvas;
    public GameObject heartPrefab;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public string nameLayoutHearts;


    private List<GameObject> _prefabHearts;
    void Start()
    {
        _prefabHearts = new List<GameObject>();
    }

    public void generateHearts(int cuantityOfHearts)
    {
        Transform layoutTransform = searchForACertainTransform(nameLayoutHearts);
        for(int i = 0; i < cuantityOfHearts; i++)
        {
            _prefabHearts.Add(Instantiate(heartPrefab,layoutTransform));
            _prefabHearts[i].GetComponent<Image>().sprite = fullHeart;
        }
    }

    private Transform searchForACertainTransform(string name)
    {
        Transform transformToFind = null;
        Transform[] transformsInCanvas = gameCanvas.GetComponentsInChildren<Transform>();
        foreach (Transform transform in transformsInCanvas)
        {
            if (transform.name.Equals(name))
            {
                transformToFind =  transform;
            }
        }
        return transformToFind;
    }

    public void fillInOutheart(int hearToChange, bool fill)
    {
        Image imageToChange = _prefabHearts[hearToChange].GetComponent<Image>();
        if (fill)
        {
            imageToChange.sprite = fullHeart;
        }
        else
        {
            imageToChange.sprite = emptyHeart;
        }
    }
}

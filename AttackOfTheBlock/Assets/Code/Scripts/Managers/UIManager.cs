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


    private List<GameObject> _prefabHearts = new List<GameObject>();
    /**
     * <summary>Función que se encarga de generar una serie de corazones en el layout de corazones de la interrfaz</summary>
     * <param name="cuantityOfHearts">Cantidad de corazones que queremos generar en la interfaz</param>
     */
    public void generateHearts(int cuantityOfHearts)
    {
        Transform layoutTransform = searchForACertainTransform(nameLayoutHearts);
        for(int i = 0; i < cuantityOfHearts; i++)
        {
            _prefabHearts.Add(Instantiate(heartPrefab,layoutTransform));
            _prefabHearts[i].GetComponent<Image>().sprite = fullHeart;
        }
    }
    /**
     * <summary>Función que se encarga de devolver un transform concreto en función del nombre que se le pasa</summary>
     * <param name="name">Nombre del transform que se quiere buscar</param>
     * <returns>Devuelve el transform que se ha buscado, en caso de no encontrarse devulve NULL</returns>
     */
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
    /**
     * <summary>Función que se encarga de llenar o vaciar un corzaon en función de el índice que se le pasa</summary>
     * <param name="fill">Boolean donde TRUE significa que queremos llenar ese corazón y FALSE que queremos vaciarlo</param>
     * <param name="hearToChange">Indice con el que definimos que corazon es el que queremos alterar</param>
     */
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

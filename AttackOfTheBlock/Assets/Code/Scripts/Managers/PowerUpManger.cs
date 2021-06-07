using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManger : MonoBehaviour
{
    public List<GameObject> powerUpsToSpawn;
    public int secondsBetweenPowerUps;
    public float movementForceForPowerUps;
    public GameObject parentToSpawnPowerUps;
    public float extraRadius;
    private List<GameObject> _powerUpsSpawned;
    private float _timeOflastSpawn;

    void Start()
    {
        _powerUpsSpawned = new List<GameObject>();
        _timeOflastSpawn = Time.time;
    }

    void Update()
    {
        destroyPowerUpsUsed();
        if (Time.time >= _timeOflastSpawn+secondsBetweenPowerUps)
        {
            spawnPowerUp();
            _timeOflastSpawn = Time.time;
        }
    }
    /**
     * <summary>Función que se encarga de spawnear un power up de manera aleatoria en un pùnto aleatorio</summary>
     */
    private void spawnPowerUp()
    {
        int powerUpIndex = Random.Range(0, powerUpsToSpawn.Count);
        Vector2 spawnPoint = getSpawnPoint();
        Debug.Log(spawnPoint);
        GameObject powerUpSpawned = Instantiate(powerUpsToSpawn[powerUpIndex], new Vector3(spawnPoint.x, spawnPoint.y, 0), Quaternion.identity ,parentToSpawnPowerUps.transform);
        _powerUpsSpawned.Add(powerUpSpawned);
        powerUpSpawned.GetComponent<Rigidbody2D>().AddForce(getDirectionToCenter(spawnPoint)*movementForceForPowerUps);
    }

    /**
     * <summary>Función que se encarga de generar un vector que marca la dirección hacia el centro de la partida, representado por la posición de la cámara</summary>
     * <param name="spawnPoint">Punto de origen desde el que va a salir el power up generado</param>
     * <returns>Retorna un Vector2 con la dirección que seguirá el power up generado</returns>
     */
    private Vector2 getDirectionToCenter(Vector2 spawnPoint)
    {
        Vector2 center = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        return (center - spawnPoint).normalized;
    }
    /**
     * <summary>Función que se encarga de genrar el punto desde el que se generará el power point. Este punto se genera de manera aleatoria. 
     * Además la función tendrá en cuenta si queremos utilizar un radio extra para alejar más la zona de spawn</summary>
     * <returns>Devuelve un Vector2 con la posición desde la que se va a generar el power up.</returns>
     */
    private Vector2 getSpawnPoint()
    {
        BoundsAndCameraManager boundsAndCameraManager = GetComponent<BoundsAndCameraManager>();
        int directionX = 0;
        int directionY = 0;
        //Vamos a evitar que la dirección sea  0 0
        do
        {
            directionX = Random.Range(-1, 2);
            directionY = Random.Range(-1, 2);
        } while (directionX == 0 && directionY == 0);


        return new Vector2(directionX * ((boundsAndCameraManager.widthMainCamera/2)+extraRadius), directionY * ((boundsAndCameraManager.heightMainCamera / 2) + extraRadius));
    }

    /**
     * <summary>Función que se encarga de eleiminar todos los power ups que estan listos para ser eliminados.</summary>
     */
    private void destroyPowerUpsUsed()
    {
        List<GameObject> powerUpsToDestroy = _powerUpsSpawned.FindAll(isReadyToDestroy);
        foreach (GameObject powerUp in powerUpsToDestroy)
        {
            _powerUpsSpawned.Remove(powerUp);
            Destroy(powerUp);
        }
    }
    /**
     * <summary>Función que comprueba que power up está lsito para ser eliminado</summary>
     * <returns>devuelve un valor booleano TRUE si el power up esta listo para ser eliminado y FALSE si el power up todavia no esta listo para ser eliminado</returns>
     */
    private bool isReadyToDestroy(GameObject powerUp)
    {
        return powerUp.GetComponent<PowerUpBehaviour>().isUsed;
    }

}

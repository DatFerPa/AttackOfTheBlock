﻿using System.Collections;
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

    private void spawnPowerUp()
    {
        int powerUpIndex = Random.Range(0, powerUpsToSpawn.Count);
        Vector2 spawnPoint = getSpawnPoint();
        Debug.Log(spawnPoint);
        GameObject powerUpSpawned = Instantiate(powerUpsToSpawn[powerUpIndex], new Vector3(spawnPoint.x, spawnPoint.y, 0), Quaternion.identity ,parentToSpawnPowerUps.transform);
        _powerUpsSpawned.Add(powerUpSpawned);
        powerUpSpawned.GetComponent<Rigidbody2D>().AddForce(getDirectionToCenter(spawnPoint)*movementForceForPowerUps);
    }


    private Vector2 getDirectionToCenter(Vector2 spawnPoint)
    {
        Vector2 center = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        return (center - spawnPoint).normalized;
    }

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

    private void destroyPowerUpsUsed()
    {
        List<GameObject> powerUpsToDestroy = _powerUpsSpawned.FindAll(isReadyToDestroy);
        foreach (GameObject powerUp in powerUpsToDestroy)
        {
            _powerUpsSpawned.Remove(powerUp);
            Destroy(powerUp);
        }
    }

    private bool isReadyToDestroy(GameObject powerUp)
    {
        return powerUp.GetComponent<PowerUpBehaviour>().isUsed;
    }

}

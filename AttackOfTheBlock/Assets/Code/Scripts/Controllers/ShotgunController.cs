using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    public GameObject parentToSpawnShoots;
    public GameObject projectileToShoot;
    public int timeBetweenShoots;
    private float _timeWhenShoot;

    void Start()
    {
        _timeWhenShoot = int.MinValue;
    }

    void Update()
    {
        if (Time.time >= _timeWhenShoot + timeBetweenShoots)
        {           
            directionToShoot();
        }
    }

    private void directionToShoot()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            shootProjectile(new Vector2(0,1));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            shootProjectile(new Vector2(-1,0));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            shootProjectile(new Vector2(0,-1));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            shootProjectile(new Vector2(1,0));
        }
    }


    private void shootProjectile(Vector2 directionToShoot)
    {
        Vector3 posicionSpawn = this.transform.position;
        GameObject projectileSpawned = Instantiate(projectileToShoot, posicionSpawn, Quaternion.identity, parentToSpawnShoots.transform);
        projectileSpawned.GetComponent<ProjectileBehaviour>().applyForceToProjectile(directionToShoot);
        _timeWhenShoot = Time.time;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUpBehaviour : MonoBehaviour
{
    public UnityEvent eventOnCollideWithPlayer;
    public int liveTime;
    private bool _isUsed;
    private float _startTime;

    public bool isUsed
    {
        get => _isUsed;
    }
    private void Start()
    {
        _startTime = Time.time; 
    }

    private void Update()
    {
        if (Time.time >= _startTime+liveTime)
        {
            this._isUsed = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player") && !GameObject.Find("Player").GetComponent<PlayerBehaviour>().isPlayerDeath)
        {
            eventOnCollideWithPlayer.Invoke();
            this._isUsed = true;
        }
    }

    public void getPlayerOneLife()
    {
        GameObject.Find("Player").GetComponent<PlayerBehaviour>().getOneMoreLife();
    }

    public void playerSizeDown()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerPowerUpBehaviour>().playerChangeSize(0.5f);
    }

}

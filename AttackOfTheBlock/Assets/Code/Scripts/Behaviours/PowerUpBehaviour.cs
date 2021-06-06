using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUpBehaviour : MonoBehaviour
{
    public UnityEvent eventOnCollideWithPlayer;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            eventOnCollideWithPlayer.Invoke();
        }
    }

    public void getPlayerOneLive()
    {
        GameObject.Find("Player").GetComponent<PlayerBehaviour>().getOneMoreLive();
        Destroy(this.transform.parent.gameObject);
    }

}

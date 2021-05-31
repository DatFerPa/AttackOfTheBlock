using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int velocity;
    public GameObject gameManager;
    public GameObject enemyPrefab;
    private AudioSource _audioSource;

    void Start()
    {
        generateRandomForce();
        _audioSource = GetComponent<AudioSource>();
    }

    /**
     * <summary>Función que se encarga de generarle al enemigo un movimiento en una de las cuatro diagonales de manera aleatoria</summary>
     */
    private void generateRandomForce()
    {
        int randomDirection = Random.Range(0,4);
        switch (randomDirection)
        {
            case 0:
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.velocity*-1, this.velocity * -1));
                break;
            case 1:
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.velocity, this.velocity * -1));
                break;
            case 2:
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.velocity * -1, this.velocity));
                break;
            case 3:
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.velocity, this.velocity));
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Debug.Log("colisione contra el playero");
            collision.gameObject.GetComponent<PlayerBehaviour>().hitPlayer();
        }
        else
        {
            _audioSource.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}

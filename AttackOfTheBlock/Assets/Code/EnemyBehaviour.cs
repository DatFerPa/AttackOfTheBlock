using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public int BoundsVelocity;
    private int _xForce;
    private int _yForce;

    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, -100));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Debug.Log("Choque contra el player collision 2d");
            Application.Quit();
        }

    }

}

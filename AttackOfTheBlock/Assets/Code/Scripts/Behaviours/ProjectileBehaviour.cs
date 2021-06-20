using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float movementForce;
    private ErasableObjectsManager _erasableObjectsManager;


    void Start()
    {
        _erasableObjectsManager = FindObjectOfType<ErasableObjectsManager>();
    }

    public void applyForceToProjectile(Vector2 directionToMove)
    {
        this.GetComponent<Rigidbody2D>().AddForce(directionToMove* movementForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Enemy"))
        {
            _erasableObjectsManager.addErasableObject(collision.gameObject);
            _erasableObjectsManager.addErasableObject(this.gameObject);
        }
        else if (collision.collider.tag.Equals("Barrier"))
        {
            _erasableObjectsManager.addErasableObject(this.gameObject);
        }
    }
}

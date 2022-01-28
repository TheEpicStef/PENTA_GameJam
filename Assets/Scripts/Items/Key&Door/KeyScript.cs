using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public Collider2D KeyCollision;

    public int DoorId = 0;

    private void Awake()
    {
        KeyCollision = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Door Collided = collision.gameObject.GetComponent<Door>();
        if (Collided != null && Collided.DoorId == this.DoorId)
        {
            Collided.opened = true;
            Destroy(this.gameObject);
        }
    }
}

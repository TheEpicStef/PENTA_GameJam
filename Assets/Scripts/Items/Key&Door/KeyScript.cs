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
        // Cast the collided object to a door class and check the door ID
        // Will open the door and remove the key. When animations added, rework this.
        Door Collided = collision.gameObject.GetComponent<Door>();
        if (Collided != null && Collided.DoorId == this.DoorId)
        {
            Collided.OpenDoor();
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int DoorId = 0;

    public bool opened = false;

    public Collider2D doorCollider;

    void Awake()
    {
        doorCollider = GetComponent<Collider2D>();
    }

    public void OpenDoor()
    {
        doorCollider.enabled = false;
        opened = true;
    }

}

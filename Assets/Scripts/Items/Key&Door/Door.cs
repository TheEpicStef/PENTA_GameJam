using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int DoorId = 0;

    public bool opened = false;

    public Collider2D doorCollider;

    // Start is called before the first frame update
    void Awake()
    {
        doorCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (opened)
        {
            doorCollider.enabled = false;
        }
    }

}

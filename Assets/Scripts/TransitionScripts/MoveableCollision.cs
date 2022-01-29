using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableCollision : MonoBehaviour
{
    public Collider2D CollisionObject;
    public Rigidbody2D Rigid;
    public bool SolidInWinter;
    public WorldTransition CurrentSeason;

    // Start is called before the first frame update
    void Start()
    {
        CurrentSeason = GameObject.Find("Main Camera").GetComponentInChildren<WorldTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SolidInWinter == CurrentSeason.summer)
        {
            Rigid.bodyType = RigidbodyType2D.Static;
            CollisionObject.isTrigger = true;
            gameObject.layer = 0;
        }
        else
        {
            Rigid.bodyType = RigidbodyType2D.Dynamic;
            CollisionObject.isTrigger = false;
            gameObject.layer = 6;
        }
    }
}

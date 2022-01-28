using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTransition : MonoBehaviour
{
    public Collider2D CollisionObject;
    public bool SolidInWinter;
    public WorldTransition CurrentSeason;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(SolidInWinter == CurrentSeason.Summer)
        {
            CollisionObject.isTrigger = true;
            gameObject.layer = 0;
        }
        else
        {
            CollisionObject.isTrigger = false;
            gameObject.layer = 6;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTransition : MonoBehaviour
{
    public Collider2D CollisionObject;
    public bool SolidInWinter;
    public WorldTransition CurrentSeason;
    
    public List<Collider2D> inside;
    private ContactFilter2D ContactFilter;

    // Start is called before the first frame update
    void Start()
    {
        ContactFilter.SetLayerMask(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(SolidInWinter == CurrentSeason.summer)
        {
            //Lets all of the objects inside move when the object is not solid
            foreach (Collider2D i in inside)
            {
                i.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;
                PlayerController isPlayer = i.gameObject.GetComponent<PlayerController>();
                if (isPlayer != null)
                {
                    isPlayer.inWater = true;
                }
            }
            CollisionObject.isTrigger = true;
            gameObject.layer = 0;
            CollisionObject.OverlapCollider(ContactFilter, inside);
        }
        else
        {
            //disables all movement on objects inside when solid
            foreach(Collider2D i in inside)
            {
                i.attachedRigidbody.bodyType=RigidbodyType2D.Static;
                PlayerController isPlayer = i.gameObject.GetComponent<PlayerController>();
                if(isPlayer != null)
                {
                    isPlayer.inWater = true;
                }
            }
            CollisionObject.isTrigger = false;
            gameObject.layer = 6;
            
        }
    }
}

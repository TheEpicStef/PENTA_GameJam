using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTransition : MonoBehaviour
{
    private bool m_dragging;
    private float m_timeElapsed;

    public bool Summer;
    public Transform MaskTransform;
    public float m_transitionTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            SwapScene();
        }

        if(m_dragging)
        {
            m_timeElapsed += Time.deltaTime;
            if(m_timeElapsed <= m_transitionTime )
            {
                if(Summer)
                {
                    MaskTransform.position = new Vector3(Mathf.Lerp(-MaskTransform.localScale.x,0,m_timeElapsed/m_transitionTime), 0, 1);
                }
                else
                {
                    MaskTransform.position = new Vector3(Mathf.Lerp(0, MaskTransform.localScale.x, m_timeElapsed / m_transitionTime), 0, 1);
                } 
            }
            else
            {
                if (Summer)
                {
                    MaskTransform.position = new Vector3( 0, 0, 1);
                }
                else
                {
                    MaskTransform.position = new Vector3( MaskTransform.localScale.x, 0, 1);
                }
                m_dragging = false;
            }
        }
    }

    //function to transition between the world types
    public void SwapScene()
    {
        //only works if screen is not transitioning
        if(!m_dragging)
        {
            //toggles between dragging on or off
            m_dragging = true;
            Summer = !Summer;
            m_timeElapsed = 0.0f;
        }
    }
}
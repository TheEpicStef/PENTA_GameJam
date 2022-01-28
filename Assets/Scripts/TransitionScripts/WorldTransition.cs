using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldTransition : MonoBehaviour
{
    public bool summer;
    public Transform Player;
    public RectTransform MaskTransform;
    public float transitionDuration = 1.0f;
    public int beatsPerSeason;
    public int musicTempo = 115;
    public Slider changeTimer;

    private float m_timer;
    private bool m_dragging;
    private float m_timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        changeTimer.maxValue = (float)beatsPerSeason / ((float)musicTempo/60.0f);

    }

    // Update is called once per frame
    void Update()
    {
        m_timer = m_timer + Time.deltaTime;

        if (m_timer  >= changeTimer.maxValue)
        {
            m_timer -= changeTimer.maxValue;
            changeTimer.value = m_timer;
            SwapScene();
        }
        else
        {
            changeTimer.value =Mathf.Floor( m_timer / (60.0f / musicTempo)) * beatsPerSeason / (beatsPerSeason -1)* (60.0f / musicTempo);
        }

        if(m_dragging)
        {
            m_timeElapsed += Time.deltaTime;
            if(m_timeElapsed <= transitionDuration)
            {
                if(summer)
                {
                    MaskTransform.localPosition = new Vector3(Mathf.Lerp(-MaskTransform.localScale.x,0,m_timeElapsed/ transitionDuration), 0, 1);
                }
                else
                {
                    MaskTransform.localPosition = new Vector3(Mathf.Lerp(0, MaskTransform.localScale.x, m_timeElapsed / transitionDuration), 0, 1);
                } 
            }
            else
            {
                if (summer)
                {
                    MaskTransform.localPosition = new Vector3( 0, 0, 1);
                }
                else
                {
                    MaskTransform.localPosition = new Vector3( MaskTransform.localScale.x, 0, 1);
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
            summer = !summer;
            m_timeElapsed = 0.0f;
        }
    }
}

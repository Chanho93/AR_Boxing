using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Man_Damaged : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Man_body;
    public Animator Man_ani;
    private AudioSource audio_source;
    public AudioClip beat;
    public AudioClip die;
    public Text fight;
    public Text Cy_win;

    public float m_StartingHealth = 100f;
    public float m_CurrentHealth;
    
    public Image m_FillImage1;
    public Image m_FillImage2;
    public Image m_FillImage3;
    public Image m_FillImage4;
    public Image m_FillImage5;

    void Start()
    {
        m_CurrentHealth = m_StartingHealth;
        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = beat;
        audio_source.loop = false;
        audio_source.playOnAwake = false;

        Invoke("UI_1", 4.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cy_attack"))
        {
            
            Man_ani.SetBool("Beat", true);

            audio_source.Play();

            Invoke("Ani_Cancel", 1.0f);

            m_CurrentHealth -= 15;          

            if (m_CurrentHealth > 80)
                m_FillImage5.color = Color.Lerp(Color.red, Color.white, 0f);
            if (m_CurrentHealth <= 80 && m_CurrentHealth > 60)
                m_FillImage5.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 60 && m_CurrentHealth > 40)
                m_FillImage4.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 40 && m_CurrentHealth > 20)
                m_FillImage3.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 20 && m_CurrentHealth > 0)
                m_FillImage2.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 0) { 
                m_FillImage1.color = Color.Lerp(Color.red, Color.white, 1f);
                Cy_win.text = "Dump_Win";
                Invoke("UI_2", 5.0f);
            }


        }
    }
       

    void Ani_Cancel()
    {
        Man_ani.SetBool("Beat", false);

        if(m_CurrentHealth <=0 && m_CurrentHealth >= -20)
        {
            Man_ani.SetBool("Die", true);
            audio_source.clip = die;
            audio_source.Play();
            audio_source.loop = false;
        }
    }

    void UI_1()
    {
        fight.text = "";
    }

    void UI_2()
    {
        Cy_win.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

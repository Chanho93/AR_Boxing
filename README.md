# AR_Boxing
 
가상 버튼을 이용한 증강현실 복싱 게임


1. 이미지 타겟 및 가상 버튼

![image](https://user-images.githubusercontent.com/48191157/71572284-9f9cf400-2b21-11ea-8d07-5c01e0e8b8c2.png)

2. 간단한 동작_킥

![image](https://user-images.githubusercontent.com/48191157/71572289-a4fa3e80-2b21-11ea-847e-5a18b2a87407.png)

3. 간단한 동작_펀치

![image](https://user-images.githubusercontent.com/48191157/71572294-a88dc580-2b21-11ea-8787-38159d41d8dc.png)

    public class virtual_button1_1 : MonoBehaviour, IVirtualButtonEventHandler
    {
    public GameObject anim_object;
    public GameObject cy;
    //public GameObject cy_particle;
    public Animator cy_ani;
    //Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        VirtualButtonBehaviour vb_behaviour;
        vb_behaviour = this.GetComponent<VirtualButtonBehaviour>();
        vb_behaviour.RegisterEventHandler(this);
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Virtual Button Pressed");
        cy_ani.SetBool("Punch", true);
        //cy_particle.SetActive(true);
       // pos = cy.transform.rotation.eulerAngles;
       //anim_object.GetComponent<Animation>().Play();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Virtual Button Released");
        cy_ani.SetBool("Punch", false);
        //cy_particle.SetActive(false);
        //   cy.transform.eulerAngles = pos;
        //  cy.transform.DORotate(new Vector3(0f, -90f, 0f), 0.1f).SetEase(Ease.Linear);
        // anim_object.GetComponent<Animation>().Stop();
    }
    // Update is called once per frame
    void Update()
    {

    }
}


4. 간단한 동작_방어

![image](https://user-images.githubusercontent.com/48191157/71572299-ad527980-2b21-11ea-8996-e3cb56e862d4.png)

5. 격투장면_1

![image](https://user-images.githubusercontent.com/48191157/71572313-bfccb300-2b21-11ea-89dc-5b0b997a7405.png)

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

5_1. 격투장면_2

![image](https://user-images.githubusercontent.com/48191157/71572323-cf4bfc00-2b21-11ea-8088-cefc131d4499.png)

6. 승리화면

![image](https://user-images.githubusercontent.com/48191157/71572333-e25ecc00-2b21-11ea-83ef-a205acca4a96.png)

7. 경기 종료 후 카메라 거리에 따른 세리모니 이벤트 발생

![image](https://user-images.githubusercontent.com/48191157/71572338-e985da00-2b21-11ea-939b-b9cc1b63cf94.png)

    public class camera_ctrl : MonoBehaviour
    {
    // Start is called before the first frame update
    int auto_focus_mode = 0;
    bool focus_mode_set = false;
    bool is_front_camera = true;
    string focus_mode_name;
    float distance = 0.0f;
    public TrackableBehaviour tracked_target;
    bool is_format_registered = false;
    Vuforia.PIXEL_FORMAT pixel_format = Vuforia.PIXEL_FORMAT.RGBA8888;
    public GameObject cy;
    public Animator cy_ani;   

    void Start()
    {
        Debug.Log(Application.dataPath);
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
    }
    void OnVuforiaStarted()
    {
        if (CameraDevice.Instance.SetFrameFormat(pixel_format, true))
        {
            Debug.Log("Frame format is successfully registered: " + pixel_format.ToString());
            is_format_registered = true;
        }
        else
        {
            Debug.Log("Frame format is not registered: " + pixel_format.ToString());
            is_format_registered = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position_offset = tracked_target.transform.position - Camera.main.transform.position;
        distance = Mathf.Sqrt(position_offset.x * position_offset.x + position_offset.y * position_offset.y + position_offset.z * position_offset.z);
        distance = (distance * 10.5f) / 10f;
        Debug.Log(position_offset + " : " + distance);

        if (distance > 0 && distance < 23)
        {
            cy_ani.SetBool("Dance", true);
        }
        else if (distance >=23)
        {
            cy_ani.SetBool("Dance", false);
        }
    }
}

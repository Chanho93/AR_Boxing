# AR_Boxing
 
가상 버튼을 이용한 증강현실 복싱 게임


1. 이미지 타겟 및 가상 버튼

![image](https://user-images.githubusercontent.com/48191157/71572284-9f9cf400-2b21-11ea-8d07-5c01e0e8b8c2.png)

2. 간단한 동작_킥

![image](https://user-images.githubusercontent.com/48191157/71572289-a4fa3e80-2b21-11ea-847e-5a18b2a87407.png)

3. 간단한 동작_펀치

![image](https://user-images.githubusercontent.com/48191157/71572294-a88dc580-2b21-11ea-8787-38159d41d8dc.png)

4. 간단한 동작_방어

![image](https://user-images.githubusercontent.com/48191157/71572299-ad527980-2b21-11ea-8996-e3cb56e862d4.png)

5. 격투장면_1

![image](https://user-images.githubusercontent.com/48191157/71572313-bfccb300-2b21-11ea-89dc-5b0b997a7405.png)

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

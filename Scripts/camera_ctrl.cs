using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
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

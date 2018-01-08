using System.Collections;
using System;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public GameObject head;
    public GameObject EnterTrigger;
    SteamVR_Controller.Device device;
    SteamVR_TrackedObject controller;
    float speed;
    float Start_X = 0;
    float Start_Z = 0;
    private PlayerScript asd;

    void Start()
    {
        controller = gameObject.GetComponent<SteamVR_TrackedObject>();

        asd = EnterTrigger.GetComponent<PlayerScript>();
    }

    void Update()
    {
        device = SteamVR_Controller.Input((int)controller.index);
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Start_X = controller.transform.position.x;
                Start_Z = controller.transform.position.z;
            }
            float deltaX = (Start_X - controller.transform.position.x) * speed * Time.deltaTime;
            float deltaZ = (Start_Z - controller.transform.position.z) * speed * Time.deltaTime;
            Vector3 deltaVector = new Vector3(deltaX, 0, deltaZ);
            player.transform.position += deltaVector;
            if (asd.trigger_var)
            {
                speed = (float)0.001;
            } else
            {
                speed = 25;
            }
        }
    }
}

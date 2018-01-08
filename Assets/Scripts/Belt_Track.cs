using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt_Track : MonoBehaviour
{

    public GameObject Headset;
    public float Offset_x = 1.0F;
    public float Offset_y = -0.52F;
    public float Offset_z = -0.14F;

    private Vector3 offset;

    void Start()
    {
        //offset = transform.position - Headset.transform.position;
        offset = new Vector3(Offset_x,Offset_y,Offset_z);
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(Offset_x, Offset_y, Offset_z);
        transform.position = Headset.transform.position + offset;
        transform.eulerAngles = new Vector3 (0,Headset.transform.eulerAngles.y,0);
    }
}
//new Vector3 (Headset.transform.position.x,offset.y, Headset.transform.position.z);
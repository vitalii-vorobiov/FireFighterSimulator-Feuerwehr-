using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolHolder : MonoBehaviour {

    private GameObject colidingObject;
    public GameObject CollidingBelt;
    public bool belt_collision = false;
    public bool GrippingObject = false;
    //public bool GripDown = false;



    public void OnTriggerEnter(Collider col)
    {
        colidingObject = col.gameObject;
        if (colidingObject)
        {
            if (colidingObject.tag == "Belt")
            {
                Belt VS = colidingObject.GetComponent<Belt>();

                    belt_collision = true;
                    CollidingBelt = colidingObject;
                
                
            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        colidingObject = null;
        belt_collision = false;

        CollidingBelt = null;
    }
    public void OnTriggerStay(Collider other)
    {
        colidingObject = other.gameObject;
        if (colidingObject)
        {
            if (colidingObject.tag == "Belt")
            {
                Belt VS = colidingObject.GetComponent<Belt>();

                    belt_collision = true;
                    CollidingBelt = colidingObject;

            }
        }
    }

}


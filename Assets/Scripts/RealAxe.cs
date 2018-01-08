using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealAxe : MonoBehaviour {
    public GameObject colidingObject;



    public void OnTriggerEnter(Collider col)
    {
        colidingObject = col.gameObject;
        if (colidingObject)
        {
            if (colidingObject.tag == "Destructible")
            {
                Destroyer SN = colidingObject.GetComponent<Destroyer>();
                SN.BRAKE = false;
            }
        }
    }

}

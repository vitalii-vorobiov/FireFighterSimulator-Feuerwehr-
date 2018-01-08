using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour {
    private GameObject colidingObject;
    private GameObject objectInHand;
    public bool ToolCollision;
    public bool HOLD = false;
    public Vector3 MovementOffset_Cached;
    public Vector3 RotationOffset_Cached;
    public bool IsSmth = false;

    // Use this for initialization


    // Update is called once per frame
    public void OnTriggerEnter(Collider col)
        {
            colidingObject = col.gameObject;
            if (colidingObject)
            {
                if (colidingObject.tag == "Grabbable")
                {
                    ToolCollision = true;
                    ToolHolder SN = colidingObject.GetComponent<ToolHolder>();
                }
            }
        }

    public void OnTriggerExit(Collider col)
    {
        colidingObject = null;
        ToolCollision = false;
    }

    private void Update()
    {
        if (HOLD)
        {

            objectInHand.GetComponent<Rigidbody>().transform.position = this.transform.position;
            objectInHand.GetComponent<Rigidbody>().transform.Translate(MovementOffset_Cached, Space.Self);
            objectInHand.GetComponent<Rigidbody>().transform.rotation = this.transform.rotation;
            objectInHand.GetComponent<Rigidbody>().transform.Rotate(RotationOffset_Cached);
        }
    }

    public void GrabObject()
    {
        
        HOLD = true;
        Debug.Log("grab");
        objectInHand = colidingObject;
        objectInHand.GetComponent<Rigidbody>().useGravity = false;
        objectInHand.GetComponent<Rigidbody>().isKinematic = true;
        objectInHand.transform.SetParent(this.transform);
        //objectInHand.GetComponent<Rigidbody>().transform.localScale = new Vector3(objectInHand.GetComponent<Rigidbody>().transform.localScale.x, objectInHand.GetComponent<Rigidbody>().transform.localScale.y, Mathf.Abs(objectInHand.GetComponent<Rigidbody>().transform.localScale.z));

    }

    public void ReleaseObject()
    {
        Debug.Log("release");
        HOLD = false;
        //HoldingObject = false;
        objectInHand.GetComponent<Rigidbody>().useGravity = true;
        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        objectInHand.transform.SetParent(null);
        objectInHand = null;

    }
}

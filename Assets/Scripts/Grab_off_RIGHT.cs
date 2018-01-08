using UnityEngine;


public class Grab_off_RIGHT : MonoBehaviour
{
    public GameObject contr;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    public bool gripButtonDown = false;
    public bool gripButtonUp = false;
    public bool gripButtonPressed = false;


    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;



    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;
    private GameObject objectInHand;
    private bool HoldingExtinguisher = false;
    private bool HoldingObject = false;
    private Vector3 MovementOffset_Cached;
    private Vector3 RotationOffset_Cached;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = col.gameObject;
    }



    void Update()

    {
        //if (Controller.velocity.magnitude > 5)
        //{
        //    Debug.Log("Woosh");
        //}


        if (controller == null)
        {
            Debug.Log("Controller not initialise.");
            return;
        }
        gripButtonDown = controller.GetPressDown(gripButton);
        gripButtonUp = controller.GetPressUp(gripButton);
        gripButtonPressed = controller.GetPress(gripButton);

        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);
        triggerButtonPressed = controller.GetPress(triggerButton);

        if (HoldingObject)
        {
            MovementOffset_Cached = objectInHand.GetComponent<Offset_Manipulator>().MovementOffset;
            RotationOffset_Cached = objectInHand.GetComponent<Offset_Manipulator>().RotationOffset;
            objectInHand.GetComponent<Rigidbody>().transform.position = contr.transform.position;
            objectInHand.GetComponent<Rigidbody>().transform.Translate(MovementOffset_Cached, Space.Self);
            objectInHand.GetComponent<Rigidbody>().transform.rotation = contr.transform.rotation;
            objectInHand.GetComponent<Rigidbody>().transform.Rotate(RotationOffset_Cached);

        }


        if (gripButtonDown)
        {
            if (collidingObject.tag == "Grabbable")
            {
                if (objectInHand)
                {
                    ToolHolder SN = objectInHand.GetComponent<ToolHolder>();
                    SN.GrippingObject = false;
                    if (SN.belt_collision == true)
                    {
                        Belt VS = SN.CollidingBelt.GetComponent<Belt>();
                        if (VS.IsSmth != true)
                        {
                            ReleaseObject();

                            VS.GrabObject();
                            VS.IsSmth = true;
                        }

                    }
                    else
                    {
                        ReleaseObject();
                    }


                }
                else
                {
                    GrabObject();
                    ToolHolder SN = objectInHand.GetComponent<ToolHolder>();
                    if (SN.belt_collision)
                    {
                        Belt VS = SN.CollidingBelt.GetComponent<Belt>();
                        VS.ReleaseObject();
                        VS.IsSmth = false;

                    }
                    objectInHand.GetComponent<Rigidbody>().useGravity = false;
                    objectInHand.GetComponent<Rigidbody>().isKinematic = true;
                    objectInHand.transform.SetParent(contr.transform);



                    SN.GrippingObject = true;
                }
            }

        }




    }


    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;
        HoldingObject = true;
        objectInHand.GetComponent<Rigidbody>().useGravity = false;
        objectInHand.GetComponent<Rigidbody>().isKinematic = true;
        objectInHand.transform.SetParent(contr.transform);
        MovementOffset_Cached = objectInHand.GetComponent<Offset_Manipulator>().MovementOffset;
        RotationOffset_Cached = objectInHand.GetComponent<Offset_Manipulator>().RotationOffset;
        objectInHand.GetComponent<Rigidbody>().transform.localScale = new Vector3(objectInHand.GetComponent<Rigidbody>().transform.localScale.x, objectInHand.GetComponent<Rigidbody>().transform.localScale.y, Mathf.Abs(objectInHand.GetComponent<Rigidbody>().transform.localScale.z));

    }


    private void ReleaseObject()
    {
        HoldingObject = false;
        objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
        objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        objectInHand.GetComponent<Rigidbody>().useGravity = true;
        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        objectInHand.transform.SetParent(null);
        objectInHand = null;
        MovementOffset_Cached = new Vector3(0, 0, 0);
        RotationOffset_Cached = new Vector3(0, 0, 0);

    }



}
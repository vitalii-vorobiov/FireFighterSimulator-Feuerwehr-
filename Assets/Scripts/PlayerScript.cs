using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public bool trigger_var;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "collobj")
        {
            trigger_var = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "collobj")
        {
            trigger_var = false;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

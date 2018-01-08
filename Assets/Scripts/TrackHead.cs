using UnityEngine;
using System.Collections;

public class TrackHead : MonoBehaviour
{

    public GameObject Helmet;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(Helmet.transform.position.x, 0, Helmet.transform.position.z);
        gameObject.transform.position = newPosition;
    }
}

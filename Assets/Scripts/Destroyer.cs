using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
    public int HP = 3;
    public float Force = 50f;
    public bool BRAKE = true;
    public List<GameObject> ShutterList;

    private GameObject RandomObj;
    private Rigidbody rb;
    // Use this for initialization
    private void Update()
    {
        if (BRAKE == false)
        {
            BRAKE = true;
            HP = HP - 1;
            if (HP <= 0)
            {
                for (int i=0; i < ShutterList.Count; i++)
                {
                    RandomObj = ShutterList[i];
                    rb = RandomObj.GetComponent<Rigidbody>();
                    rb.constraints = RigidbodyConstraints.None;
                    rb.AddRelativeForce(Random.onUnitSphere * Force);
                }
                Destroy(this.gameObject);
            } else
            {
                for (int i = 0; i < 3; i++)
                {
                    RandomObj = ShutterList[Random.Range(0, ShutterList.Count - 1)];
                    rb = RandomObj.GetComponent<Rigidbody>();
                    rb.constraints = RigidbodyConstraints.None;
                    ShutterList.Remove(RandomObj);
                    rb.AddRelativeForce(Random.onUnitSphere * Force);
                }
            }
            
        }
        
    }
}

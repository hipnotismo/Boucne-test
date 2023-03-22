using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class RiggitTest : MonoBehaviour
{
    private Rigidbody rig;
    public int upMultiply;
    public Vector3 minForce;
    public Vector3 maxForce;

    private Vector3 force;

    //min max y random range para la fuerza inicial

    // Start is called before the first frame update
    void Start()
    {
        force = new Vector3(UnityEngine.Random.Range(minForce.x, maxForce.x), UnityEngine.Random.Range(minForce.y, maxForce.y), 
            UnityEngine.Random.Range(minForce.z, maxForce.z));
        rig = GetComponent<Rigidbody>();
        rig.AddForce(force * upMultiply, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        force = new Vector3(UnityEngine.Random.Range(minForce.x, maxForce.x), UnityEngine.Random.Range(minForce.y, maxForce.y),
            UnityEngine.Random.Range(minForce.z, maxForce.z));
        rig.AddForce(force/* * upMultiply*/);

    }
   
}

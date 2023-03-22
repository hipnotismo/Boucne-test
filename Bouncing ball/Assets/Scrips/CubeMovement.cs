using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] int type;

    public GameObject obj;

    Rigidbody m_Rigidbody;
    public float m_Thrust = 10f;

    // Start is called before the first frame update

    void Start()
    {
        // obj = GetComponent<GameObject>();
        if (type==2)
        {
            m_Rigidbody = GetComponent<Rigidbody>();

        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case 1:
                if (Input.GetKey(KeyCode.A))
                {
                    obj.transform.position += new Vector3(-5f * Time.deltaTime,0f,0f);
                   
                }

                if (Input.GetKey(KeyCode.D))
                {
                    obj.transform.position += new Vector3(5f * Time.deltaTime, 0f, 0f);

                }

                if (Input.GetKey(KeyCode.W))
                {
                    obj.transform.position += new Vector3(0f, 0f, 5f * Time.deltaTime);

                }

                if (Input.GetKey(KeyCode.S))
                {
                    obj.transform.position += new Vector3(0f,  0f, -5f * Time.deltaTime);

                }

                break;
            case 2:

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    m_Rigidbody.AddForce(new Vector3(0f, 0f, 5f));

                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    m_Rigidbody.AddForce(new Vector3(0f, 0f, -5f));

                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    m_Rigidbody.AddForce(new Vector3(-5f, 0f, 0f));

                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    m_Rigidbody.AddForce(new Vector3(5f, 0f, 0f));

                }
                break;
            default:
                break;
        }
       
    }
}

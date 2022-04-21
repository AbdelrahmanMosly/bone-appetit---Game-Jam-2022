using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToFollow;

    // Update is called once per frame
    void Update()
    {
        if(objectToFollow != null && objectToFollow.transform.position.y> transform.position.y)
        {
            transform.position=new Vector3(transform.position.x,transform.position.y+0.01f,transform.position.z);
        }
        
    }
}

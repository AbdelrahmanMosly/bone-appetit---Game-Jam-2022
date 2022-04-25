using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 Offset = new Vector3(10, 10, 0);
    public float ratio = 0.3f;


    Vector3 previous_loc;


    private void Start()
    {
        previous_loc = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (target.position.y >= transform.position.y - 3)
        {
            Vector3 interpolatedPosition = Vector3.Lerp(previous_loc, target.position, ratio);
            previous_loc = interpolatedPosition;

            transform.position = interpolatedPosition + Offset;
        }
    }
}

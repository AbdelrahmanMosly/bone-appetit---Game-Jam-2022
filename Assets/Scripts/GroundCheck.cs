using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool Grounded = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Platform")
        {
            Grounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Platform")
        {
            Grounded = false;
        }
    }
}

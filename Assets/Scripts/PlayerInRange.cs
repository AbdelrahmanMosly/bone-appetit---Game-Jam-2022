using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRange : MonoBehaviour
{
    RaycastHit hit;
    public bool playerInRange = false;
    private Transform player;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(Physics.Raycast(transform.position, (other.transform.position-transform.position), out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    playerInRange = true;
                    player = other.transform;
                }
                else
                {
                    playerInRange = false;
                }
            }

        }
    }
    public Transform getPlayerTransform()
    {
       return player;
    }

}

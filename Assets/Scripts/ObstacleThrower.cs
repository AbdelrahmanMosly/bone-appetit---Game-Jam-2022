using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleThrower : MonoBehaviour
{
    [SerializeField]
    private Transform obstacle;
    [SerializeField]
    private float projectileVelocityMultiplier;
    [SerializeField]
    private PlayerInRange playerInRange;

    private bool justThrow;
    private void Update()
    {
        if (!justThrow && playerInRange.playerInRange)
        {
            StartCoroutine( throwObstacle());
        }
    }
    private IEnumerator throwObstacle()
    {
        justThrow = true;
        Transform obstacleInstance = Instantiate(obstacle, transform.position, transform.rotation);
        Rigidbody rigidbody = obstacleInstance.GetComponent<Rigidbody>();
        rigidbody.velocity = (playerInRange.getPlayerTransform().position - transform.position) * projectileVelocityMultiplier;
        Destroy(obstacleInstance.gameObject, 3f);
        yield return new WaitForSeconds(0.3f);
        justThrow = false;
    }
}

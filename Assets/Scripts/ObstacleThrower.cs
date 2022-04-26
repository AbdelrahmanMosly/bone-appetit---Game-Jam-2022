using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleThrower : MonoBehaviour
{
    [SerializeField]
    private Transform obstacle;
    private float projectileVelocityMultiplier = 5;
    [SerializeField]
    private PlayerInRange playerInRange;
    
    public Animator anim;

    private bool justThrow;
    
    
    private void Update()
    {
        if (!justThrow && playerInRange.playerInRange)
        {
            StartCoroutine( throwObstacle());
        }
    }
    public void updateProjectileSpeed(float score)
    {
      projectileVelocityMultiplier += score/200.0f ;
    }
    private IEnumerator throwObstacle()
    {
        justThrow = true;
        anim.SetBool("throw", true);
        Transform obstacleInstance = Instantiate(obstacle, transform.position, Quaternion.identity);
        Rigidbody rigidbody = obstacleInstance.GetComponent<Rigidbody>();
        rigidbody.velocity = (playerInRange.getPlayerTransform().position - transform.position) * projectileVelocityMultiplier;
        rigidbody.velocity += new Vector3(0, 5f, 0); 
        Destroy(obstacleInstance.gameObject, 3f);
        yield return new WaitForSeconds(1f);
        justThrow = false;
        anim.SetBool("throw", false);
    }
    public float getProjectileVelocity()
    {
        return projectileVelocityMultiplier;
    }
}

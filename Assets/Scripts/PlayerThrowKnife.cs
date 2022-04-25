using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowKnife : MonoBehaviour
{
    [SerializeField]
    private Transform knife;
    [SerializeField]
    private float projectileVelocityMultiplier;
    [SerializeField]
    private float destroyTime;

    [SerializeField] private GameObject PlayerMesh;
    [SerializeField] private GroundCheck GC;

    Vector3 aimDirection;
    Vector3 worldPosition;
    private void Update()
    {
        RotateGeneratorToMousePosition();
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)){
            ThrowKnife();

            if (GC.Grounded)
            {
                GetComponent<Animator>().Play("Throw", 0);
            }
            else
            {
                GetComponent<Animator>().Play("Falling_Throwing", 0);
            }


            if (worldPosition.x < transform.position.x)
            {
                PlayerMesh.transform.localScale = new Vector3(100, -100, 100);
            }
            else
            {
                PlayerMesh.transform.localScale = new Vector3(100, 100, 100);

            }
        }
    }

    private void RotateGeneratorToMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        aimDirection = (worldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        //transform.eulerAngles = new Vector3(0, 0, angle-90);
    }
    private  void ThrowKnife()
    {
        Transform knifeInstance = Instantiate(knife, transform.position+ new Vector3(0,1,0), transform.rotation);
        Rigidbody rigidbody = knifeInstance.GetComponent<Rigidbody>();
        rigidbody.velocity = aimDirection * projectileVelocityMultiplier;
        Destroy(knifeInstance.gameObject, destroyTime);
    }
}

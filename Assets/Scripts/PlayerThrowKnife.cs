using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowKnife : MonoBehaviour
{
    [SerializeField]
    private Transform knife;
    [SerializeField]
    private float projectileVelocityMultiplier;

    Vector3 aimDirection;
    private void Update()
    {
        RotateGeneratorToMousePosition();
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)){
            ThrowKnife();
        }
    }
    private void RotateGeneratorToMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        aimDirection = (worldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle-90);
    }
    private  void ThrowKnife()
    {
        Transform knifeInstance = Instantiate(knife, transform.position, transform.rotation);
        Rigidbody2D rigidbody2D = knifeInstance.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = aimDirection * projectileVelocityMultiplier;
        Destroy(knifeInstance.gameObject,5f);
    }
}

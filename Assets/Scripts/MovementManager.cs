using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private float speed = 10f;
    private float ratio = 0.03f;
    private float jumpForce = 5f;

    public void LerpMove(Rigidbody Target, Vector2 dir, float speed, float LerpRatio) //for movement with sliding
    {
        Vector2 lerping = Vector2.Lerp(Target.velocity, dir.normalized * speed, ratio);
        Target.velocity = lerping;
    }
    public void Move(Rigidbody Target, Vector2 dir, float speed) // for normal movement
    {
        Target.velocity = new Vector2(dir.x*speed, Target.velocity.y);
    }
}

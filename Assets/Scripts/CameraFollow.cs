using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;

    bool moveToTarget = false;
    public void SetFollow(Transform _target,bool isFollow)
    {
        target = _target;
        moveToTarget = isFollow;
    }
    public void CloseFollow()
    {
        moveToTarget = false;
    }
    private void LateUpdate()
    {
        if (moveToTarget)
        {
            transform.position = Vector3.Lerp(transform.position, target.position - new Vector3(0, 0, 10), 1.5f * Time.deltaTime);
        }
    }
}

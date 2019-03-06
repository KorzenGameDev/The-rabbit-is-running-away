using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject target = null;
    float offset = 0f;

    private void LateUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(target.transform.position.x + offset, gameObject.transform.position.y, gameObject.transform.position.z),1f);
    }

    public void SetTarget(GameObject target) {
        this.target = target;
        offset = Mathf.Abs(target.transform.position.x - gameObject.transform.position.x);
    }
}

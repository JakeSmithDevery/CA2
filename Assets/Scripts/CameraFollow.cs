using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    Vector3 nextPosition;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition.z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target)
        {
            nextPosition.x = Target.position.x;
            nextPosition.y = Target.position.y;

            transform.position = nextPosition;
        }
    }
}

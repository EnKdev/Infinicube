using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    [SerializeField]
    Transform p1;
    [SerializeField]
    Transform p2;
    [SerializeField]
    public float speed;
    Vector3 nextP;

    // Start is called before the first frame update
    void Start()
    {
        nextP = p2.position;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (transform.position == p2.position)
            nextP = p1.position;
        if (transform.position == p1.position)
            nextP = p2.position;
        transform.position = Vector3.MoveTowards(transform.position, nextP, speed * Time.deltaTime);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(p1.position, p2.position);
    }
}

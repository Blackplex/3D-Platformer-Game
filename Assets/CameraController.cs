using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position - offset;
        transform.LookAt(target);
    }*/

    public Transform focus;
    public float perimiterX = 5f;
    public float perimiterY = 5f;
    public float offset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        focus = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 frameDiff = Vector3.zero;

        //This is to check if the camera is within the perimiter on the X axis.
        float frameDiffX = focus.position.x - transform.position.x;

        if (frameDiffX > perimiterX || frameDiffX < -perimiterX)
        {
            if (transform.position.x < focus.position.x)
            {
                frameDiff.x = frameDiffX - perimiterX;
            }
            else
            {
                frameDiff.x = frameDiffX + perimiterX;
            }
        }

        //This is to check if the camera is within the perimiter on the Y axis.
        float frameDiffY = focus.position.y - transform.position.y;

        if (frameDiffY > perimiterY || frameDiffY < -perimiterY)
        {
            if (transform.position.y < focus.position.y)
            {
                frameDiff.y = frameDiffY - perimiterY;
            }
            else
            {
                frameDiff.y = frameDiffY + perimiterY;
            }
        }

        transform.position += new Vector3(frameDiff.x, frameDiff.y+offset, 0f);
    }
}

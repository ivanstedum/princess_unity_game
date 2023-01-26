using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float yOffset;
    [SerializeField] private float xOffset;
    public BoxCollider2D cameraBounds;
    [SerializeField] private Vector3 minPos, maxPos;
    [SerializeField] private float cameraSpeed;


    void Update()
    {
        Vector3 targetPos = player.position + new Vector3(xOffset, yOffset);
        Vector3 boundPos = new Vector3(
            Mathf.Clamp(targetPos.x, minPos.x, maxPos.x),
            Mathf.Clamp(targetPos.y, minPos.y, maxPos.y),
            Mathf.Clamp(targetPos.z, minPos.z, maxPos.z));

        transform.position = Vector3.Lerp(transform.position, boundPos, Time.deltaTime * cameraSpeed);
    
    }
    void Start ()
    {
    }
}

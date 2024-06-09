using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    public Transform PlayerTransform;

    public float Speed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = PlayerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MaxDistanceFollow();

    }
    private void MaxDistanceFollow()
    {
        if (PlayerTransform != null)
        {
            float clampedX = Mathf.Clamp(PlayerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(PlayerTransform.position.y, minY, maxY);
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), Speed);
        }
    }

    public void SetMaxX(float Increase){
        maxX = Increase;
    }
    public void SetMaxY(float Increase){
        maxY = Increase;
    }
    public void SetMinX(float Increase){
        minX = Increase;
    }
    public void SetMinY(float Increase){
        minY = Increase;
    }


}

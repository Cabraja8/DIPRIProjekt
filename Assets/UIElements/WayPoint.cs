using UnityEngine;
using UnityEngine.UI;

public class WayPoint : MonoBehaviour
{
    public RectTransform waypointIcon;
    public Transform target;
    public Camera mainCamera;
    public Canvas canvas;

    void Update()
    {
        if (target == null || waypointIcon == null || mainCamera == null || canvas == null)
        {
            Debug.LogWarning("Waypoint: Missing references or target. Please ensure all references are assigned.");
            return;
        }

        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position);

        // Check if the target is behind the camera
        if (screenPos.z < 0)
        {
            screenPos *= -1;
        }

        // Clamp the waypoint to the screen bounds
        screenPos.x = Mathf.Clamp(screenPos.x, 0, Screen.width);
        screenPos.y = Mathf.Clamp(screenPos.y, 0, Screen.height);

        // Convert screen position to canvas position
        Vector2 canvasPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), screenPos, canvas.worldCamera, out canvasPos);

        waypointIcon.localPosition = canvasPos;
    }
}

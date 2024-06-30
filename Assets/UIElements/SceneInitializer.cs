using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SceneInitializer : MonoBehaviour
{
    public void Initialize()
    {
        // Reassign the necessary components for WayPointManager
        WayPointManager wayPointManager = WayPointManager.Instance;

        if (wayPointManager != null)
        {
            // Reassign player, camera, and UI elements
            wayPointManager.player = GameObject.FindWithTag("Player").transform;
            wayPointManager.mainCamera = Camera.main;
            wayPointManager.waypointImage = GameObject.Find("WaypointImage").GetComponent<Image>();
        }

        // Reassign the necessary components for QuestManager
        QuestManager questManager = QuestManager.Instance;

        if (questManager != null)
        {
            questManager.questWindow = GameObject.Find("QuestWindow");
            questManager.titleText = GameObject.Find("TitleText").GetComponent<TextMeshProUGUI>();
            questManager.descriptionText = GameObject.Find("DescriptionText").GetComponent<TextMeshProUGUI>();
        }
    }
}

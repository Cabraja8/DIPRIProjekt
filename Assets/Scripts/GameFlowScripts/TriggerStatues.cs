using UnityEngine;

public class TriggerStatues : MonoBehaviour
{
    public OpenTheDoorInsideTheCastle Backdoor;
    public OpenTheDoorInsideTheCastle LastDoor;
    public StatueEnemy[] statues;  

    public GameObject[] interactions;

    private int currentStatueIndex = 0;

    void Start()
    {
       LastDoor.enabled = false;
    DisableInteractions();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Backdoor.CloseDoor();
            Invoke("EnableSecondRoom", 2f);
        }
    }

    void EnableSecondRoom()
    {
        foreach (var statue in statues)
        {
            statue.BecomeAlive();
        }
    }

    void Update()
    {
        foreach (var statue in statues)
        {
            if(statue.isAlive && GameObject.FindGameObjectsWithTag("Enemy").Length == 0){
                EnableInteractionForPuzzle();
                FollowPlayerKnights();
            }
        }
    }

    public void FollowPlayerKnights(){
    NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours) {
    Debug.Log("follow player");
    knightBehaviour.Target = null;
    knightBehaviour.isFollowing = true;
    
}
}

public void EnableInteractionForPuzzle(){
    foreach (var interaction in interactions)
        {
            interaction.SetActive(true);
        }
}
   void DisableInteractions()
    {
        foreach (var interaction in interactions)
        {
            interaction.SetActive(false);
        }
    }


    public void EnableLastDoor(){
         LastDoor.enabled = true;
         LastDoor.OpenDoor();
         DisableInteractions();
    }
    
}


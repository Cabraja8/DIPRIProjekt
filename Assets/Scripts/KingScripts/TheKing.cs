using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TheKing : MonoBehaviour
{   

    public bool IsFollowing;
    public Transform Player;

    public NavMeshAgent navMeshAgent;

    // Start is called before the first frame update

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
         navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false; 
        navMeshAgent.updateUpAxis = false; 
        navMeshAgent.avoidancePriority = 30;
    }
    void Start()
    {
        Player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {   
        if(IsFollowing){
        FollowPlayer();
    }
        
    }

    public void FollowPlayer(){
   if (Player != null) 
        {
            navMeshAgent.SetDestination(Player.position);
        }
}

public void RedirectTheKing(){
    GameObject kingStand = GameObject.FindGameObjectWithTag("KingStand");

    if (kingStand != null)
        {   
            IsFollowing = false;
            navMeshAgent.SetDestination(kingStand.transform.position);
        }

}

}

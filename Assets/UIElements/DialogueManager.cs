using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI  nameText;
    public TextMeshProUGUI  dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences=new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text=dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count==0)
        {
            EndDialogue();
            return;
        }

        string sentence=sentences.Dequeue();
        dialogueText.text=sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of convo");
         if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
            foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours)
            {
                knightBehaviour.isFollowing = true;
            }
        }else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
            foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours)
            {
                knightBehaviour.ArmTheDefences();
            }
        }
        animator.SetBool("IsOpen", false);
        nameText.text = ""; // Clear the name text
        dialogueText.text = ""; // Clear the dialogue text
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    private QuestGiver questGiver; // Reference to the QuestGiver

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, QuestGiver questGiver = null)
    {
        this.questGiver = questGiver; // Assign the QuestGiver
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
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
            
            
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();

            bool allKnightsUnarmed = true;

            foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours)
            {
                if (knightBehaviour.ArmedTheDefence)
                {
                    allKnightsUnarmed = false;
                    break;
                }
            }

            if (allKnightsUnarmed)
            {
                foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours)
                {
                    knightBehaviour.ArmTheDefences();
                }
            }
            if (!FindObjectOfType<InteractWithKing>().IsInteracted)
            {
                KingDialogueEnable();
            }
        }

        animator.SetBool("IsOpen", false);
        nameText.text = ""; // Clear the name text
        dialogueText.text = ""; // Clear the dialogue text

        // Start the quest if a QuestGiver is assigned
        if (questGiver != null)
        {
            questGiver.StartQuest();
        }
    }

    public void KingDialogueEnable()
{
    var collider = FindObjectOfType<CannotPassCollider>();
    if (collider == null)
    {
        Debug.LogError("CannotPassCollider not found!");
    }
    else
    {
        collider.DisableCollider();
    }

    var kingInteraction = FindObjectOfType<EnableKingInteraction>();
    if (kingInteraction == null)
    {
        Debug.LogError("EnableKingInteraction not found!");
    }
    else
    {
        kingInteraction.EnableKingInteract();
    }
}
}

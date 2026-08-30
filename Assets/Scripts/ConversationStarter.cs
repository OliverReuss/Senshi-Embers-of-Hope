using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private NPCConversation myConversation;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                canvas.gameObject.SetActive(false);
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }
    }
}
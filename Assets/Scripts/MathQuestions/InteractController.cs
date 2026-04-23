using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class InteractController : MonoBehaviour
{
    public bool interactable;
    public bool isSpeaking;
    public bool forceInteractable;

    public DialogueAsset dialogueBox;
    public DialoguePanelControl panel;
    public Movement player;

    void Start()
    {
        interactable = false;
        isSpeaking = false;
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }
    */
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!forceInteractable)
            interactable = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!forceInteractable)
            interactable = false;
    }

    public void Interact(Vector3Int  tilePosition)
    {
        player.stopMove();
        panel.currentTilePosition = tilePosition;
        panel.StartDialogue();
        isSpeaking = true;

    }
}

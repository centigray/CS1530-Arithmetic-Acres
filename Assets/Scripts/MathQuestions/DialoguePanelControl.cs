using UnityEngine;
using TMPro;
using System;
using System.Collections;
using System.Diagnostics;
using System.Numerics;

public class DialoguePanelControl : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI speaker;
    public GameObject dialoguePanel;
    public TMP_InputField input;
    public GameObject button;

    public MathProblemGeneration mathProb;
    public Movement player;

    public bool speaking;
    public bool answered;
    public int myAnswer;

    public GameObject cropPrefab; 
    public Vector3Int currentTilePosition; 

    void Awake()
    {
        HideAll();
        speaking = false;
        answered = false;
    }

    // show name and box of dialogue UI
    public void ShowAll()
    {
        dialoguePanel.SetActive(true);
        input.gameObject.SetActive(true);
        button.SetActive(true);
    }

    // hide all the dialogue UI
    public void HideAll()
    {
        dialogueText.text = null;
        speaker.text = null;
        dialoguePanel.SetActive(false);
        input.gameObject.SetActive(false);
        button.SetActive(false);
    }

    public void StartDialogue()
    {
        ShowAll();
        mathProb.prob = mathProb.GenerateProblem(mathProb.t);
        dialogueText.text = "" + mathProb.prob.Question;
        
    }

    public void Submit()
    {
        myAnswer = int.Parse(input.text);
        // if they got the question right, it says they answered correctly
        if(mathProb.prob.Answer == myAnswer)
        {
            answered = true;
            HideAll();
            player.startMove();
            GameManager.instance.tileManager.SetGrown(currentTilePosition, cropPrefab);
        }
        // otherwise, tells them to try again
        else
        {
            speaker.text = "Try again!";
        }
    }

}

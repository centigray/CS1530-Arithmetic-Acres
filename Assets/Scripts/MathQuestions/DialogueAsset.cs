using UnityEngine;

[CreateAssetMenu(fileName = "DialogueAsset", menuName = "Scriptable Objects/DialogueAsset")]
public class DialogueAsset : ScriptableObject
{
    public DialogueLine[] dialogue;
}

[System.Serializable]
public class DialogueLine
{
    public string speaker;

    [TextArea]
    public string text;
}
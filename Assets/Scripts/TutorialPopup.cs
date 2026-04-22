using UnityEngine;
using TMPro;

// Attach this to each pop-up panel GameObject.
// Fill in the text fields via the Inspector or let TutorialManager handle visibility.
public class TutorialPopup : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text titleText;
    public TMP_Text bodyText;

    [Header("Movement Tutorial Content")]
    [TextArea] public string movementTitle = "How to Move";
    [TextArea] public string movementBody =
        "Use the Arrow Keys or WASD to move your character around the farm.\n\n" +
        "W / ↑  —  Move Up\n" +
        "S / ↓  —  Move Down\n" +
        "A / ←  —  Move Left\n" +
        "D / →  —  Move Right\n\n" +
        "Press TAB to open your inventory.";

    [Header("Planting Tutorial Content")]
    [TextArea] public string plantingTitle = "Planting & Math Game";
    [TextArea] public string plantingBody =
        "Walk over seeds on the ground to collect them into your inventory.\n\n" +
        "Stand on a dirt patch and press E to plant a seed from your inventory.\n\n" +
        "Crops grow over time through several stages — keep an eye on them!\n\n" +
        "When a crop is ready, a Math Challenge will appear. " +
        "Solve the problem correctly to harvest your crop and earn points.";

    // Call this from TutorialManager to set which content to display
    public void SetContent(bool isMovement)
    {
        if (isMovement)
        {
            titleText.text = movementTitle;
            bodyText.text = movementBody;
        }
        else
        {
            titleText.text = plantingTitle;
            bodyText.text = plantingBody;
        }
    }
}
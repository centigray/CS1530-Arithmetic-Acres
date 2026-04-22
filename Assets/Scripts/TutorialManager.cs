using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("Tutorial Pop-ups")]
    public GameObject movementPopup;
    public GameObject plantingPopup;

    void Start()
    {
        // Make sure both are hidden, then show first
        movementPopup.SetActive(false);
        plantingPopup.SetActive(false);
        ShowMovementTutorial();
    }

    public void ShowMovementTutorial()
    {
        movementPopup.SetActive(true);
        Time.timeScale = 0f; // pause game while tutorial is up
    }

    // Called by the "Next" or "Close" button on the movement pop-up
    public void OnMovementPopupClosed()
    {
        movementPopup.SetActive(false);
        ShowPlantingTutorial();
    }

    public void ShowPlantingTutorial()
    {
        plantingPopup.SetActive(true);
    }

    // Called by the "Close" or "Got it!" button on the planting pop-up
    public void OnPlantingPopupClosed()
    {
        plantingPopup.SetActive(false);
        Time.timeScale = 1f; // resume game
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButtonController : MonoBehaviour
{
    public Button pressButton;
    public StoryTextDialogueController storyTextDialogueController;
    private bool isEnabled;

    void Awake() {
        pressButton.interactable = false;
        Disable();
        storyTextDialogueController.OnFinishReading += AllowPress;
        storyTextDialogueController.OnStartReading += DisallowPress;
    }

    public void Enable() {
        isEnabled = true;
        pressButton.gameObject.SetActive(isEnabled);
    }

    public void Disable() {
        isEnabled = false;
        pressButton.gameObject.SetActive(isEnabled);
    }

    private void AllowPress() {
        if(isEnabled) {
            pressButton.interactable = true;
        }
    }

    private void DisallowPress() {
        pressButton.interactable = false;
    }
}

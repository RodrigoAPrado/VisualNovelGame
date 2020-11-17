using UnityEngine;
using Csharp.Service;

public class CrossExamDialogueFinishController : DialogueFinishController
{
    public GameObject button;    

    private bool isEnabled;

    CrossExamDialogueFinishController() : base() {

    }   

    void Awake() {
        storyTextDialogueController.OnFinishReading += CheckPlayFinishSprite;
        storyTextDialogueController.OnStartReading += HideFinishSprite;
    }
    
    public void Enable() {
        isEnabled = true;
    }

    public void Disable() {
        isEnabled = false;
        button.SetActive(false);
    }

    private void CheckPlayFinishSprite() {
        if(isEnabled) {
            PlayFinishSprite();
            button.SetActive(true);
        }
    }
}
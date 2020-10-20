using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Csharp.Service;

public class DialogueFinishController : MonoBehaviour
{
    public Animator dialogueFinishAnimator;

    public StoryTextDialogueController storyTextDialogueController;

    private StoryDialogueService storyDialogueService;

    private bool isAwatingPlayerChoice;

    DialogueFinishController() {
        storyDialogueService = StoryDialogueService.GetInstance();
    }

    void Awake() {
        storyTextDialogueController.OnFinishReading += PlayFinishSprite;
        storyTextDialogueController.OnStartReading += HideFinishSprite;
        storyDialogueService.AwaitPlayerChoice += AwaitPlayerChoice;
    }

    private void HideFinishSprite() {
        dialogueFinishAnimator.SetBool("Play", false);
    }

    private void PlayFinishSprite() {
        if(isAwatingPlayerChoice) {
            return; 
        }
        dialogueFinishAnimator.SetBool("Play", true);
    }

    private void AwaitPlayerChoice() {
        isAwatingPlayerChoice = true;
    }
}

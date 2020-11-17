using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Csharp.Service;

public class DialogueFinishController : MonoBehaviour
{
    public Animator dialogueFinishAnimator;

    public StoryTextDialogueController storyTextDialogueController;

    protected StoryDialogueService storyDialogueService;

    private bool isAwatingPlayerChoice;

    protected DialogueFinishController() {
        storyDialogueService = StoryDialogueService.GetInstance();
    }

    void Awake() {
        storyTextDialogueController.OnFinishReading += CheckPlayFinishSprite;
        storyTextDialogueController.OnStartReading += HideFinishSprite;
        storyDialogueService.AwaitPlayerChoice += AwaitPlayerChoice;
        storyDialogueService.AwaitCrossExamChoice += AwaitPlayerChoice;
        storyDialogueService.FinishPlayerChoice += FinishPlayerChoice;
    }

    private void CheckPlayFinishSprite() {
        if(isAwatingPlayerChoice) {
            return; 
        }
        PlayFinishSprite();
    }

    protected void HideFinishSprite() {
        dialogueFinishAnimator.SetBool("Play", false);
    }

    protected void PlayFinishSprite() {
        dialogueFinishAnimator.SetBool("Play", true);
    }

    private void AwaitPlayerChoice() {
        isAwatingPlayerChoice = true;
    }

    private void FinishPlayerChoice() {
        isAwatingPlayerChoice = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueFinishController : MonoBehaviour
{
    public Animator dialogueFinishAnimator;

    public StoryTextDialogueController storyTextDialogueController;

    void Awake() {
        storyTextDialogueController.OnFinishReading += PlayFinishSprite;
        storyTextDialogueController.OnStartReading += HideFinishSprite;
    }

    private void HideFinishSprite() {
        dialogueFinishAnimator.SetBool("Play", false);
    }

    private void PlayFinishSprite() {
        dialogueFinishAnimator.SetBool("Play", true);
    }
}

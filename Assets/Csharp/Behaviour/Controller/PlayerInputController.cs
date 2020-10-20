using System.Collections;
using UnityEngine;
using Csharp.Service;

public class PlayerInputController : MonoBehaviour
{
    private StoryTextDialogueController dialogueController;

    private SceneController sceneController;

    private bool playerInputDelay;

    private bool isAwatingPlayerChoice;

    private StoryDialogueService storyDialogueService;

    PlayerInputController() {
        storyDialogueService = StoryDialogueService.GetInstance();
    }

    void Awake() {
        storyDialogueService.AwaitPlayerChoice += AwaitPlayerchoice;
    }

    void Start() {
        dialogueController = GameObject.FindGameObjectWithTag("StoryTextDialogueController").GetComponent<StoryTextDialogueController>();
        sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
    }

    public void AdvanceText() {
        if(playerInputDelay) {
            return;
        }

        if(dialogueController.IsReading) {
            dialogueController.FinishReading();
            playerInputDelay = true;
            StartCoroutine(ReducePlayerInputDelay());
            return;
        } 

        if(isAwatingPlayerChoice) {
            return;
        }
        
        sceneController.NextDialogue();
    }

    private IEnumerator ReducePlayerInputDelay() {
        yield return new WaitForSeconds(.2f);
        playerInputDelay = false;
    }

    private void AwaitPlayerchoice() {
        isAwatingPlayerChoice = true;
    }
}
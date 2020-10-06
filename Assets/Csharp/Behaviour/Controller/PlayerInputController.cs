using System.Collections;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private StoryTextDialogueController dialogueController;

    private SceneController sceneController;

    private bool playerInputDelay;

    void Start() {
        dialogueController = GameObject.FindGameObjectWithTag("StoryTextDialogueController").GetComponent<StoryTextDialogueController>();
        sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
    }

    public void AdvanceText() {
        Debug.Log("OK");

        if(playerInputDelay) {
            return;
        }

        if(dialogueController.IsReading) {
            dialogueController.FinishReading();
            playerInputDelay = true;
            StartCoroutine(ReducePlayerInputDelay());
            return;
        } 
        sceneController.NextDialogue();
    }

    private IEnumerator ReducePlayerInputDelay() {
        yield return new WaitForSeconds(.2f);
        playerInputDelay = false;
    }
}
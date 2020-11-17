using Csharp.Service;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CrossExaminationController : MonoBehaviour
{
    public bool IsCrossExam { get; private set; }

    private OptionSelectService optionSelectService;

    private CrossExamDialogueFinishController crossExamNextController;

    private CrossExamDialogueFinishController crossExamPreviousController;

    private List<string> currentChoices;

    private const string crossExamNextOption = "cross-next";
    private const string crossExamPreviousOption = "cross-previous";

    CrossExaminationController() {
        optionSelectService = OptionSelectService.GetInstance();
    }

    void Awake() {
        crossExamNextController = GameObject.FindGameObjectWithTag("CrossExamNext").GetComponent<CrossExamDialogueFinishController>();
        crossExamPreviousController = GameObject.FindGameObjectWithTag("CrossExamPrevious").GetComponent<CrossExamDialogueFinishController>();
        optionSelectService.SetupCrossExam += SetupCrossExam;
    }

    public void SelectOption(string selectedOptionName) {
        if(!IsCrossExam) {
            return;
        }
        int choiceIndex = currentChoices.Count -1;
        while(choiceIndex >= 0) {
            if(selectedOptionName == currentChoices[choiceIndex]) {
                break;
            }
            choiceIndex --;
        }
        if(choiceIndex < 0) {
            throw new Exception("Option name not found: " + selectedOptionName);
        }
        EndCrossExam();
        optionSelectService.SelectOption(choiceIndex);
    }

    private void SetupCrossExam() {
        IsCrossExam = true;
        currentChoices = optionSelectService.GetChoices();
        CheckAdvanceButton(crossExamNextOption, crossExamNextController);
        CheckAdvanceButton(crossExamPreviousOption, crossExamPreviousController);
    }

    private void CheckAdvanceButton(string advanceOption, CrossExamDialogueFinishController advanceController) {
        if(currentChoices.Contains(advanceOption)) {
            advanceController.Enable();
        } else {
            advanceController.Disable();
        }
    }

    private void EndCrossExam() {
        crossExamNextController.Disable();
        crossExamPreviousController.Disable();
        IsCrossExam = false;
    }
}

using Csharp.Service;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CrossExaminationController : MonoBehaviour
{
    public bool IsCrossExam { get; private set; }

    public event Action CrossExamStart;

    private OptionSelectService optionSelectService;

    private CrossExamDialogueFinishController crossExamNextController;

    private CrossExamDialogueFinishController crossExamPreviousController;

    private PressButtonController pressButtonController;

    private List<string> currentChoices;

    private const string crossExamNextOption = "cross-next";
    private const string crossExamPreviousOption = "cross-previous";
    private const string presentWrongOption = "present:wrong-item";

    CrossExaminationController() {
        optionSelectService = OptionSelectService.GetInstance();
    }

    void Awake() {
        crossExamNextController = GameObject.FindGameObjectWithTag("CrossExamNext").GetComponent<CrossExamDialogueFinishController>();
        crossExamPreviousController = GameObject.FindGameObjectWithTag("CrossExamPrevious").GetComponent<CrossExamDialogueFinishController>();
        pressButtonController = GameObject.FindGameObjectWithTag("CrossExamPress").GetComponent<PressButtonController>();
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
            SelectOption(CheckPresentWrongItem(selectedOptionName));
            return;
        }
        EndCrossExam();
        optionSelectService.SelectOption(choiceIndex);
    }

    private void SetupCrossExam() {
        IsCrossExam = true;
        CrossExamStart?.Invoke();
        currentChoices = optionSelectService.GetChoices();
        CheckAdvanceButton(crossExamNextOption, crossExamNextController);
        CheckAdvanceButton(crossExamPreviousOption, crossExamPreviousController);
        pressButtonController.Enable();
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
        pressButtonController.Disable();
        IsCrossExam = false;
    }

    private string CheckPresentWrongItem(string selectedOptionName) {
        if(!selectedOptionName.Contains("present:")) {
            throw new Exception("Option selected does not exist " + selectedOptionName);
        }
        return presentWrongOption;
    }
}

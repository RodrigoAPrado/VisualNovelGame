using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Csharp.Service;

public class OptionSelectController : MonoBehaviour
{
    public GameObject optionButtonPrefab;

    private OptionSelectService optionSelectService;

    private StoryTextDialogueController storyTextDialogueController;

    private GameObject canvas;

    private List<GameObject> currentOptionButtons = new List<GameObject>();

    [SerializeField]
    private float firstButtonPosition = -130;

    [SerializeField]
    private float buttonSpacing = 100;

    private float buttonShowDelay = .1f;

    private bool optionSelected;

    OptionSelectController() {
        optionSelectService = OptionSelectService.GetInstance();
    }

    void Awake() {
        storyTextDialogueController = GameObject.FindGameObjectWithTag("StoryTextDialogueController").GetComponent<StoryTextDialogueController>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        optionSelectService.Setup();
        optionSelectService.SetupPlayerChoice += SetupOptions;
        storyTextDialogueController.OnFinishReading += BeginShowOptions;

    }

    public void SelectOption(int choiceIndex) {
        if(optionSelected) {
            return;
        }
        optionSelected = true;
        StopAllCoroutines();
        foreach(GameObject choice in currentOptionButtons) {
            choice.GetComponent<Animator>().SetTrigger("Exit");
        }
        currentOptionButtons.Clear();
        optionSelectService.SelectOption(choiceIndex);
    }

    private void SetupOptions() {
        var choices = optionSelectService.GetChoices();
        for(int index = 0; index < choices.Count; index ++) {
            var choiceButton = GameObject.Instantiate(optionButtonPrefab);
            SetupButtonPosition(choiceButton, index);
            SetupButtonScript(choiceButton, index);
            SetupButtonText(choiceButton, choices[index]);
            currentOptionButtons.Add(choiceButton);
        }
    }

    private void SetupButtonPosition(GameObject choiceButton, int choiceIndex) {
            choiceButton.transform.SetParent(canvas.transform);
            choiceButton.transform.localPosition = 
                new Vector2(choiceButton.transform.localPosition.x, firstButtonPosition + buttonSpacing * choiceIndex);
            choiceButton.transform.localScale = 
                new Vector3Int(1, 1, 1);
    }

    private void SetupButtonScript(GameObject buttonGameObject, int choiceIndex) {
        var buttonScript = buttonGameObject.GetComponent<Button>();
        buttonScript.onClick.AddListener(delegate { SelectOption(choiceIndex); });
    }

    private void SetupButtonText(GameObject buttonGameObject, string choice) {
        buttonGameObject.GetComponentInChildren<TMP_Text>().text = choice;
    }

    private void BeginShowOptions() {
        StartCoroutine(ShowOptionsRoutine());
    }

    private IEnumerator ShowOptionsRoutine() {
        foreach(GameObject choiceButton in currentOptionButtons) {
            choiceButton.SetActive(true);
            yield return new WaitForSeconds(buttonShowDelay);
        }
    }
}

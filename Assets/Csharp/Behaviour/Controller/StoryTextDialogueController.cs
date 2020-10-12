using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Csharp.Service;
using TMPro;
using System;

public class StoryTextDialogueController : MonoBehaviour
{   
    private const int TagEscape = 2; 

    private readonly List<char> PhraseEnds = new List<char>(){'.', '!', '?'};  

    public string CurrentDialogueTextShow { get; private set; }

    public bool IsReading { get; private set; }

    public TMP_Text dialogueText;

    public event Action OnFinishReading;

    public event Action OnStartReading;

    private StoryDialogueService service;

    private string currentDialogueText;

    private float phraseEndCharacterDelay = .5f;

    private float defaultCharacterDelay = .05f;

    public StoryTextDialogueController() {
        service = StoryDialogueService.GetInstance();
    }

    void Awake() {
        service.DialogueSet += OnTextSet;  
    }

    public void FinishReading() {
        StopAllCoroutines();
        ShowFullText(); 
    } 

    private void OnTextSet() {
        dialogueText.color = service.CurrentColor;
        currentDialogueText = service.CurrentText;
        CurrentDialogueTextShow = "";
        IsReading = true;
        OnStartReading?.Invoke();
        StartCoroutine(ReadTextRoutine());
    }

    private IEnumerator ReadTextRoutine() {
        var addClosingTag = false;
        var tagValue = "";
        dialogueText.ForceMeshUpdate();

        for(var currentDialogueTextIndex = 0; currentDialogueTextIndex < currentDialogueText.Length; currentDialogueTextIndex++) {
            if(IsHtmlStartingTag(currentDialogueText[currentDialogueTextIndex])) {
                if(addClosingTag) {
                    currentDialogueTextIndex += GetTagLengh(tagValue);
                    addClosingTag = false;
                    continue;     
                } else {
                    var evalResult = ReadTextHtmlTag(currentDialogueText[currentDialogueTextIndex+1]); 
                    currentDialogueTextIndex = evalResult.Item1;
                    tagValue = evalResult.Item2;
                    addClosingTag = true;
                    continue;
                }
            }

            CurrentDialogueTextShow = currentDialogueText.Remove(currentDialogueTextIndex);
            if(addClosingTag) {
                CurrentDialogueTextShow += GetHtmlClosingTag(tagValue); 
            }

            dialogueText.text = CurrentDialogueTextShow;

            if(currentDialogueTextIndex > 0 && IsLastCharacterAPhraseEnd(currentDialogueText[currentDialogueTextIndex-1]) && IsCurrentCharacterANewPhrase(currentDialogueTextIndex)) {
                yield return new WaitForSeconds(phraseEndCharacterDelay);
            } else {
                yield return new WaitForSeconds(defaultCharacterDelay);
            }
        }
        ShowFullText();      
    }

    private void ShowFullText() {
        CurrentDialogueTextShow = currentDialogueText;
        dialogueText.text = CurrentDialogueTextShow;
        IsReading = false; 
        OnFinishReading?.Invoke();
    }

    private bool IsHtmlStartingTag(char text) {
        return text.Equals('<');
    }

    private (int, string) ReadTextHtmlTag(int currentDialogueIndex, string htmlTag = "") {
        if(currentDialogueText[currentDialogueIndex].Equals('>')) {
            return (currentDialogueIndex, htmlTag);
        }

        htmlTag += currentDialogueText[currentDialogueIndex];
        return ReadTextHtmlTag(currentDialogueIndex+1, htmlTag);
    }

    private string GetHtmlClosingTag(string tagValue) {
        return "<\\" + tagValue + ">"; 
    }

    private bool IsLastCharacterAPhraseEnd(char text) {
        return PhraseEnds.Contains(text); 
    }

    private bool IsCurrentCharacterANewPhrase(int currentTextIndex) {
        return currentDialogueText[currentTextIndex].Equals(' ');
    }

    private int GetTagLengh(string tagValue) {
        return tagValue.Length + TagEscape;
    }
}
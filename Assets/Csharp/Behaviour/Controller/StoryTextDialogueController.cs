using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Csharp.Service;
using TMPro;

public class StoryTextDialogueController : MonoBehaviour
{    
    private readonly List<char> PhraseEnds = new List<char>(){'.', '!', '?'};  

    public string CurrentDialogueTextShow { get; private set; }

    public TMP_Text dialogueText;

    public bool IsReading { get; private set; }

    private StoryDialogueService service;

    private string currentDialogueText;

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
        StartCoroutine(ReadTextRoutine());
    }

    private IEnumerator ReadTextRoutine() {
        var addClosingTag = false;
        var tagValue = "";
        dialogueText.ForceMeshUpdate();

        for(var i = 0; i < currentDialogueText.Length; i++) {
            if(IsHtmlStartingTag(currentDialogueText[i])) {
                if(addClosingTag) {
                    i += tagValue.Length + 2;
                    addClosingTag = false;
                    continue;     
                } else {
                    var evalResult = ReadTextHtmlTag(currentDialogueText[i+1]); 
                    i = evalResult.Item1;
                    tagValue = evalResult.Item2;
                    addClosingTag = true;
                    continue;
                }
            }
            CurrentDialogueTextShow = currentDialogueText.Remove(i);
            if(addClosingTag) {
                CurrentDialogueTextShow += GetHtmlClosingTag(tagValue); 
            }

            dialogueText.text = CurrentDialogueTextShow;

            if(i > 0 && IsLastCharacterAPhraseEnd(currentDialogueText[i-1]) && IsCurrentCharacterANewPhrase(i)) {
                yield return new WaitForSeconds(.5f);
            } else {
                yield return new WaitForSeconds(.02f);
            }
        }
        ShowFullText();      
    }
    private void ShowFullText() {
        CurrentDialogueTextShow = currentDialogueText;
        dialogueText.text = CurrentDialogueTextShow;
        IsReading = false; 
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Csharp.Service;
using TMPro;

public class StoryTextSpeakerController : MonoBehaviour
{
    private StoryDialogueService service;

    public TMP_Text speakerText;

    public TMP_Text speakerTitleText;

    public StoryTextSpeakerController(){
        service = StoryDialogueService.GetInstance();
    }

     void Awake() {
        service.DialogueSet += OnSpeakerSet;  
    }

    private void OnSpeakerSet() {
        speakerText.text = service.CurrentSpeaker;
        speakerTitleText.text = service.CurrentSpeakerTitle;
    }
}

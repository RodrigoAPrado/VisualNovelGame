using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using Csharp.Service;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public TextAsset sceneScript;

    private StoryReadingService storyReadingService;

    public SceneController() {
        storyReadingService = StoryReadingService.GetInstance();
    }

    void Awake() {
        storyReadingService.Setup(sceneScript.text);
    }

    void Start() {
        storyReadingService.BeginReadingStory();
    }

    public void NextDialogue() {
        storyReadingService.NextDialogue();
    }
}

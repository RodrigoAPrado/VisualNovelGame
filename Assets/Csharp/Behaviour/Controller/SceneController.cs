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
    
    void Start() {
        storyReadingService.Setup(sceneScript.name, sceneScript.text);
        storyReadingService.BeginReadingStory();
    }

    public void NextDialogue() {
        storyReadingService.NextDialogue();
    }
}

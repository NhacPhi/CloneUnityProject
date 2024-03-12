using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameSceneSO : DescriptionBaseSO
{
    public GameSceneType sceneType;
    public AssetReference sceneReference; // used at runtime to load the scene from the right AssetBundle
}

public enum GameSceneType
{
    // Playable scenes
    Location,
    Menu,

    // Special scenes
    Initialization,
    PersistentManagers,
    GamePlay,
    Art
}
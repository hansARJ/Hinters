﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour
{
  public Camera mainCamera;
  private List<Scene> scenes = new List<Scene>();
  // Start is called before the first frame update

  public IEnumerator PushScene(string sceneName)
  {
    AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    while (!op.isDone)
    {
      Debug.Log($"Navigator: Pushing scene - {sceneName}");
      yield return 0;
    }

    var scene = SceneManager.GetSceneByName(sceneName);
    scenes.Add(scene);

    var canvas = GetSceneCanvas(scene);
    canvas.worldCamera = mainCamera;
    canvas.sortingOrder = NextSortLayer();
    Debug.Log($"Navigator: Successfully pushed scene - {sceneName}");
  }

  private int NextSortLayer()
  {
    if (scenes.Count == 0) { return 0; }

    var scene = scenes[scenes.Count - 1];
    var canvas = GetSceneCanvas(scene);
    return canvas.sortingOrder + 1;
  }

  private Canvas GetSceneCanvas(Scene scene)
  {
    var objects = scene.GetRootGameObjects();
    return Array.Find(objects, el => el.GetComponent<Canvas>() != null).GetComponent<Canvas>();
  }
}

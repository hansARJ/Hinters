using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
  public Navigator navigator;
  void Start()
  {
    StartCoroutine(navigator.PushScene("SelectNumberOfPlayers"));
  }
}

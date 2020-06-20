using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerCounterController : MonoBehaviour
{
  public Slider slider;
  public TextMeshProUGUI title;

  // Start is called before the first frame update
  void Start()
  {
    title.text = slider.minValue.ToString();
    slider.onValueChanged.AddListener(delegate { UpdatePlayerCount(); });
  }

  public void UpdatePlayerCount()
  {
    title.text = slider.value.ToString();
  }
}

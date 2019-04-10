using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PBMenu : MonoBehaviour
{
    public Button francis;
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.Pause();
        francis.onClick.AddListener(ButtonClicked);
    }

    void ButtonClicked()
    {
        videoPlayer.Play();
        Debug.Log("Beach");
        gameObject.SetActive(false);                // Hide the menu
        BWEventManager.TriggerEvent("Start");
    }

    // Update is called once per frame
    void Update()
    {
    }
}

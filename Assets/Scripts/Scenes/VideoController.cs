using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField]
    VideoPlayer myVideoPlayer;
    RawImage myRawImage;

    void Start()
    {
        Debug.Log("VideoController Start");
        GameObject.Find("Spieler 2").GetComponent<PlayerController2>().canMove = false;
        myRawImage = GetComponent<RawImage>();
        myVideoPlayer.loopPointReached += EndOfVideo;
    }

    void EndOfVideo(VideoPlayer vp)
    {
        Debug.Log("Video vorbei");
        Destroy(myRawImage);
        GameObject.Find("Spieler 2").GetComponent<PlayerController2>().canMove = true;

    }
}

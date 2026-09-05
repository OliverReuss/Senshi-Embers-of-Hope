using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] VideoPlayer myVideoPlayer;
    RawImage myRawImage;

    void Start()
    {
        Debug.Log("VideoController Start");
        GameObject.Find("Spieler 2").GetComponent<PlayerController2>().canMove = false;
        myRawImage = GetComponent<RawImage>();

        // 1. Get raw path to StreamingAssets file
        string filePath = Path.Combine(Application.streamingAssetsPath, "1.mp4");

        // 2. Assign path directly (WebGL automatically resolves relative StreamingAssets paths)
        myVideoPlayer.source = VideoSource.Url;

        // Dynamischen Pfad wieder aktivieren:
        myVideoPlayer.url = filePath;

        // 3. Register event handlers
        myVideoPlayer.loopPointReached += EndOfVideo;
        myVideoPlayer.prepareCompleted += OnVideoPrepared;

        // 4. Asynchronously prepare video
        myVideoPlayer.Prepare();
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        Debug.Log("Video prepared successfully. Playing now...");
        vp.Play();
    }

    void EndOfVideo(VideoPlayer vp)
    {
        Debug.Log("Video finished.");
        Destroy(myRawImage);
        GameObject.Find("Spieler 2").GetComponent<PlayerController2>().canMove = true;
    }
}
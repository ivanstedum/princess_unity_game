using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class videoPlayerMain : MonoBehaviour

{
    public VideoPlayer videoPlayer;
    public float loopStartTime = 2f;
    public float loopEndTime = 5f;
    private bool isFirstLoop = true;

    void Start(){
        
        GameObject videoPlayerGO = GameObject.Find("Video Player");
        videoPlayer = videoPlayerGO.GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += VideoEnded;
        
    }

    void VideoEnded(VideoPlayer vp)
    {
        if (isFirstLoop)
        {
            videoPlayer.time = loopStartTime;
            videoPlayer.playbackSpeed = 1f;
    
            
            
        }
        videoPlayer.time = loopStartTime;
        videoPlayer.isLooping = true;
        videoPlayer.Play();
    }
}
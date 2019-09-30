﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.EventSystems;

/*
 * PlayVideo(): Reactivates the vpSurface gameobject and plays the video.

 * EndVideo(): Deactivates the vpSurface gameobject, stops the video, and temporarily releases the rendertexture on the vpSurface
   so there is no remaining frame from a previous video.
*/

public class VideoController : MonoBehaviour
{
    public GameObject vpSurface; //The quad that the VideoPlayer is drawn onto
    public RenderTexture vpRenderTexture;//The RenderTexture attached to the quad that the VideoPlayer is drawn onto

    public VideoPlayer vp;
    public VideoClip[] videos;

    private string videoName = "";

    public AudioSource vpAudio;

    private void OnDisable()
    {
        vpRenderTexture.Release();
    }

    public void PlayVideo() //Controls Play button on-click actions
    {
        vp.Prepare();
        vpSurface.SetActive(true);
        vp.Play();
    }

   public void PauseVideo() //Controls Pause button on-click actions
    {
        vp.Pause();
    }

   public void EndVideo() //Controls End button on-click actions
    {
        vpSurface.SetActive(false);
        vp.Stop();
        vpRenderTexture.Release();
        
    }

    public void SetTargetTexture() //Sets the targetTexture for the VideoPlayer to draw on
    {
        vp.targetTexture = vpRenderTexture;
    }

}

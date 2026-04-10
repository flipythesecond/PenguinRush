using UnityEngine;
using UnityEngine.Video;
public class VideoSetFix : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.source = VideoSource.Url;

        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "mountain_loop.mp4");
        videoPlayer.url = videoPath;

        videoPlayer.isLooping = true;
        videoPlayer.playOnAwake = true;

        videoPlayer.SetDirectAudioMute(0, true);

        videoPlayer.Play();
    }
}

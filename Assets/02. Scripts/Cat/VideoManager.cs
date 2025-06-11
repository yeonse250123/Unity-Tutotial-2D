using UnityEngine;
using UnityEngine.Video;

namespace Cat
{
    public class VideoManager : MonoBehaviour
    {
        public GameObject videoPanel;

        public VideoPlayer vPlayer;
        public VideoClip[] vClips;

        private void Start()
        {
            vPlayer = GetComponent<VideoPlayer>();
        }

        public void VideoPlayer(bool isHappy)
        {
            videoPanel.SetActive(true);

            var ending = isHappy ? vClips[0] : vClips[1];
            vPlayer.clip = ending;
            vPlayer.Play();
        }
    }
}

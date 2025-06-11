using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    public GameObject videoScreen;
    public Button[] buttonUI;

    public VideoClip[] clips; // ���� ���� �迭

    private VideoPlayer videoPlayer;

    public int currentClipIndex = 0;

    // public bool isOn = false;
    public bool isMute = false;

    void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0];
    }

    void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(OnPrevChannel);
        buttonUI[3].onClick.AddListener(OnNextChannel);
    }

    public void OnScreenPower()
    {
        // GameObject �Ӽ��� Ȱ���� ���
        videoScreen.SetActive(!videoScreen.activeSelf);

        // NOT�� Ȱ���Ͽ� �ٿ��� ���� ���
        // isOn = !isOn;
        // videoScreen.SetActive(isOn);

        // ��� ���� ���
        // if (!isOn) // isOn == false
        // {
        //     videoScreen.SetActive(true);
        //     isOn = true; // ���� Ƽ�� On
        // }
        // else // isOn == true
        // {
        //     videoScreen.SetActive(false);
        //     isOn = false;
        // }
    }

    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute); // ������ �Ҹ� ���Ұ�

        // ���� ������ Mute �Ӽ��� Ȱ���� ���
        // videoPlayer.SetDirectAudioMute(0, !videoPlayer.GetDirectAudioMute(0));
    }

    public void OnNextChannel() // ������ ��
    {
        currentClipIndex++;
        if (currentClipIndex > clips.Length -1)
            currentClipIndex = 0;

        videoPlayer.clip = clips[currentClipIndex];
        videoPlayer.Play();
    }

    public void OnPrevChannel() // ���� ��
    {
        currentClipIndex--;
        if (currentClipIndex < 0)
            currentClipIndex = clips.Length -1;

        videoPlayer.clip = clips[currentClipIndex];
        videoPlayer.Play();
    }
}
using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip jumpClip;
        public AudioClip bgmClip;

        private void Start()
        {
            SetBGMSound();
        }

        public void SetBGMSound()
        {
            audioSource.clip = bgmClip; // ����� �ҽ��� ���� ���� ����
            audioSource.playOnAwake = true; // ������ �� �ڵ� ���
            audioSource.loop = true; // �ݺ� ���
            audioSource.volume = 0.8f; // �Ҹ� ����

            audioSource.Play(); // ����

            //audioSource.Stop(); // ����
            //audioSource.Pause(); // �Ͻ�����

        }

        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }
    }
}

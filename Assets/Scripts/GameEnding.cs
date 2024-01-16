using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public float fadeDuration = 4f;
    public float displayImageDuration = 4f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void Update()
    {
         if (m_IsPlayerAtExit)
          {
            EndLevel(exitBackgroundImageCanvasGroup, exitAudio);
        }
    }


    void EndLevel(CanvasGroup imageCanvasGroup, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
           SceneManager.LoadScene(0);
        }
    }
}

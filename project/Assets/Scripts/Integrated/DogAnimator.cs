// using UnityEngine;

// public class DogAnimator : MonoBehaviour
// {
//     [SerializeField] private Transcript transcript;
//     [SerializeField] private Animation dogAnimation;
//     [SerializeField] private string keyword = "hello";

//     void Start()
//     {
//         if (transcript == null || dogAnimation == null)
//         {
//             Debug.LogWarning("hours in silence");
//             enabled = false;
//             return;
//         }

//         transcript.OnNewPlayerResponse += HandlePlayerMessage;
//     }

//     void OnDestroy()
//     {
//         if (transcript != null)
//             transcript.OnNewPlayerResponse -= HandlePlayerMessage;
//     }

//     private void HandlePlayerMessage(string message)
//     {
//         if (string.IsNullOrWhiteSpace(message))
//             return;

//         if (message.ToLower().Contains(keyword.ToLower()))
//         {
//             dogAnimation.Play();  
//             Debug.Log("Dog shake animation playing");
//         }
//     }
// }
using UnityEngine;

/// <summary>
/// Listens for player messages, and—only once the bot’s audio is actually playing—triggers the legacy default Animation on the dog.
/// Make sure:
///  • Your Animation component’s “Animation” (Default Clip) is set to your shake_0 clip,  
///  • And this script’s “Avatar Audio Source” is pointed at the AudioSource that plays your LLM’s TTS.
/// </summary>
using UnityEngine;

public class DogAnimator : MonoBehaviour
{
    [SerializeField] private Transcript transcript;
    [SerializeField] private Animation dogAnimation;
    [SerializeField] private JetsIntegrated  jets;
    [SerializeField] private string[]  keywords  = { "sit", "roll", "hello", "stand", "act" };
    [SerializeField] private AnimationClip[] clips;

    private string  queuedClipName;
    private bool  queued = false;

    void Start()
    {
        if (transcript == null || dogAnimation == null || jets == null)
        {
            Debug.LogWarning("missing components");
            enabled = false;
            return;
        }

        if (keywords.Length != clips.Length)
        {
            Debug.LogError("keyword and clip length mismatch");
        }

        for (int i = 0; i < clips.Length; i++)
        {
            var clip = clips[i];
            if (clip != null && dogAnimation.GetClip(clip.name) == null)
                dogAnimation.AddClip(clip, clip.name);
        }
        transcript.OnNewPlayerResponse += QueueIfKeyword;
        jets.OnBotAudioStarted   += PlayQueuedAnimation;
    }

    void OnDestroy()
    {
        transcript.OnNewPlayerResponse -= QueueIfKeyword;
        jets.OnBotAudioStarted   -= PlayQueuedAnimation;
    }

    private void QueueIfKeyword(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            return;

        var msg = message.ToLower();
        for (int i = 0; i < keywords.Length; i++)
        {
            if (!string.IsNullOrEmpty(keywords[i]) 
             && clips[i] != null 
             && msg.Contains(keywords[i].ToLower()))
            {
                queuedClipName = clips[i].name;
                queued = true;
                Debug.Log($"Queued '{queuedClipName}' for keyword '{keywords[i]}'");
                return;
            }
        }
    }

    private void PlayQueuedAnimation()
    {
        if (!queued) return;

        dogAnimation.Play(queuedClipName);
        Debug.Log($"animation playing");
        queued = false;
    }
}



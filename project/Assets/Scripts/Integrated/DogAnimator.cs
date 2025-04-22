using UnityEngine;

public class DogAnimator : MonoBehaviour
{
    [SerializeField] private Transcript transcript;
    [SerializeField] private Animation dogAnimation;
    [SerializeField] private string keyword = "hello";

    void Start()
    {
        if (transcript == null || dogAnimation == null)
        {
            Debug.LogWarning("hours in silence");
            enabled = false;
            return;
        }

        transcript.OnNewPlayerResponse += HandlePlayerMessage;
    }

    void OnDestroy()
    {
        if (transcript != null)
            transcript.OnNewPlayerResponse -= HandlePlayerMessage;
    }

    private void HandlePlayerMessage(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            return;

        if (message.ToLower().Contains(keyword.ToLower()))
        {
            dogAnimation.Play();  
            Debug.Log("Dog shake animation playing");
        }
    }
}

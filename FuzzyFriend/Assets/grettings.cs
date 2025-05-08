
using UnityEngine;
using TMPro;
using System.Collections;


public class greetings : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField petInput;
    public TextMeshProUGUI greetingText;

    public float typingSpeed = 0.07f;

    public void GreetPlayer()
    {
        string playerName = nameInputField.text;
        string petName = petInput.text;

        if (!string.IsNullOrEmpty(playerName))
            if (!string.IsNullOrEmpty(playerName) && !string.IsNullOrEmpty(petName))
            {
                greetingText.text = "Hello, " + playerName + "!";
                string fullMessage = $"Hello {playerName} and welcome to Fuzzy Fun!\n\n" +
                    $"We are so glad you are playing. This game helps you grow and care for your little fuzzy friend, {petName}. " +
                    $"In order to be Pet Certified, you need to get Pet Points by playing our mini games at the Pet Park " +
                    $"or by talking to your Pet with nice words.\n\n" +
                    $"Please check on your pets energy and to replenish their energy click P! If not you will put your Pet, {petName}, in terrible danger.";

                StopAllCoroutines(); // Stop previous coroutines if any
                StartCoroutine(TypeText(fullMessage));
            }
            else
            {
                greetingText.text = "Please enter your name.";
                greetingText.text = "Please enter you and your pet's name.";
            }
    }

    IEnumerator TypeText(string message)
    {
        greetingText.text = ""; // Clear current text
        foreach (char c in message)
        {
            greetingText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

    }
}

using UnityEngine;
using TMPro;

public class NameGreeter : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI greetingText;

    public void GreetPlayer()
    {
        string playerName = nameInputField.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            greetingText.text = "Hello, " + playerName + "!";
        }
        else
        {
            greetingText.text = "Please enter your name.";
        }
    }
}

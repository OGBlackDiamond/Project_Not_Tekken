using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TMP_Text))]
public class ConsoleInput : MonoBehaviour
{
    [SerializeField] private BattleManager battleManager;
    [SerializeField] private int maxLength;

    private TMP_Text textComponent;

    private string text = "";

    // OnEnable runs when the object is created
    private void OnEnable()
    {
        // Get text component
        textComponent = GetComponent<TMP_Text>();

        Keyboard.current.onTextInput += OnTextInput;
    }

    // OnDisable runs when the object is destroyed
    private void OnDisable()
    {
        Keyboard.current.onTextInput -= OnTextInput;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnTextInput event will run for each key pressed
    private void OnTextInput(char character)
    {
        // Delete the last character in the text component if backspace is pressed and the string is not empty
        if (character == (byte)KeyCode.Backspace && text.Length > 0)
        {
            text = text.Substring(0, text.Length - 1);
        }
        // Submit the command if enter is pressed
        else if (character == (byte)KeyCode.Return)
        {
            battleManager.ExecuteCommand(text);
            text = "";
        }
        // Type pressed character into text component if the font contains the character and the string is not below the max length
        else if (textComponent.font.HasCharacter(character) && text.Length < maxLength) text += character;

        // Don't allow the text component to be an empty string to avoid text box disappearing
        textComponent.text = text == "" ? " " : text;
    }
}

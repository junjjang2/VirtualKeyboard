using System;
using UnityEngine;

namespace VKey
{
    public class VPrinter
    {
        private string _textLine;
        private int _cursorPosition;

        public event Action OnUpdate;

        public VPrinter()
        {
            Input.imeCompositionMode = IMECompositionMode.On;
        }
        
        public void AddCharacter(char c)
        {
            // Do something with the character
            _textLine += c;
            OnUpdate?.Invoke();
        }

        public void Print()
        {
            // Print the text
            Debug.Log("Text: " + _textLine);
        }
        
        public void DeleteCharacter()
        {
            // Delete a character
            OnUpdate?.Invoke();
        }
        
        public string GetCurrentLine()
        {
            // Get the current line
            return _textLine;
        }
        
        public int GetCursorPosition()
        {
            // Get the cursor position
            return _cursorPosition;
        }
    }
}
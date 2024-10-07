
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace VKey
{
    [Serializable]
    public class Key
    {
        public char KeyCode;
    }

    
    [Serializable]
    public class KeyLayer
    {
        public Key Up;
        public Key Down;
        public Key Left;
        public Key Right;
        public Key Click;

        public Key Get(KeyDirection dir)
        {
            return dir switch
            {
                KeyDirection.Up => Up,
                KeyDirection.Down => Down,
                KeyDirection.Left => Left,
                KeyDirection.Right => Right,
                KeyDirection.Click => Click,
                _ => throw new ArgumentOutOfRangeException(nameof(dir), dir, null)
            };
        }
        
        public Key Get(char keyCode)
        {
            if (Up.KeyCode == keyCode)
                return Up;
            if (Down.KeyCode == keyCode)
                return Down;
            if (Left.KeyCode == keyCode)
                return Left;
            if (Right.KeyCode == keyCode)
                return Right;
            if (Click.KeyCode == keyCode)
                return Click;
            return null;
        }
    }
    
    public enum KeyDirection
    {
        Up,
        Down,
        Left,
        Right,
        Click
    }

    public class VKeyboard
    {
        private List<KeyLayer> _keyLayers = new List<KeyLayer>();
        public List<KeyLayer> KeyLayers => _keyLayers;

        private KeyLayer vowelLayer;
        public KeyLayer VowelLayer => vowelLayer;
        
        private int _currentLayerIndex = 0;
        public int CurrentLayerIndex => _currentLayerIndex;
        private int MaxLayer => _keyLayers.Count;
        
        public event Action<int> OnLayerChanged;
        
        public event Action<Key> OnKeyPressed;
        
        private VPrinter _vPrinter;
        
        public KeyLayer CurrentLayer => _keyLayers[_currentLayerIndex];
        
        public VKeyboard()
        { }
        
        public VKeyboard(List<KeyLayerSO> keyLayerSO, KeyLayerSO vowelLayerSO)
        {
            _keyLayers = new List<KeyLayer>();
            keyLayerSO.ForEach(k => _keyLayers.Add(new KeyLayer
            {
                Up = k.Up,
                Down = k.Down,
                Left = k.Left,
                Right = k.Right,
                Click = k.Click
            }));
            
            vowelLayer = new KeyLayer
            {
                Up = vowelLayerSO.Up,
                Down = vowelLayerSO.Down,
                Left = vowelLayerSO.Left,
                Right = vowelLayerSO.Right,
                Click = vowelLayerSO.Click
            };
        }
        
        #region Core
        public void ReceiveInput(KeyDirection direction)
        {
            var key = CurrentLayer.Get(direction);
            if (key == null)
            {
                Debug.Log("Key not found");
                return;
            }
            Process(key);
            OnKeyPressed?.Invoke(key);
        }
        
        public void ReceiveVowelInput(KeyDirection direction)
        {
            var key = vowelLayer.Get(direction);
            if (key == null)
            {
                Debug.Log("Key not found");
                return;
            }
            Process(key);
            OnKeyPressed?.Invoke(key);
        }
        
        public void Process(Key key)
        {
            Debug.Log(key.KeyCode);
            
            _vPrinter.AddCharacter(key.KeyCode);
        }
        #endregion

        #region Layer Management
        public void AddLayer(KeyLayerSO keyLayerSO)
        {
            _keyLayers.Add(new KeyLayer
            {
                Up = keyLayerSO.Up,
                Down = keyLayerSO.Down,
                Left = keyLayerSO.Left,
                Right = keyLayerSO.Right,
                Click = keyLayerSO.Click
            });
        }
        
        public void RemoveLayer(int index)
        {
            if (index < 0 || index >= MaxLayer)
            {
                Debug.Log("Invalid layer");
                return;
            }
            _keyLayers.RemoveAt(index);
        }
        
        public void ChangeLayer(int layer)
        {
            if (layer < 0 || layer >= MaxLayer)
            {
                Debug.Log("Invalid layer");
                return;
            }
            _currentLayerIndex = layer;
            OnLayerChanged?.Invoke(_currentLayerIndex);
        }

        public void MoveToNextLayer()
        {
            ChangeLayer(_currentLayerIndex + 1 >= MaxLayer ? 0 : _currentLayerIndex + 1);
        }

        public void MoveToPreviousLayer()
        {
            ChangeLayer(_currentLayerIndex - 1 < 0 ? MaxLayer - 1 : _currentLayerIndex - 1);
        }
        #endregion
        
        #region Getter/Setter

        public void SetCallback()
        {
        }
        
        #endregion

        public void Delete()
        {
        }

        public void NextLine()
        {
        }

        public void AssignPrinter(VPrinter vPrinter)
        {
            _vPrinter = vPrinter;
        }
    }
}
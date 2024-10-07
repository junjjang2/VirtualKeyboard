using System;
using VKey;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "KeyLayerSO", menuName = "VKeyKeyLayerSO", order = 0)]
public class KeyLayerSO : ScriptableObject
{
    public Key Up;
    public Key Down;
    public Key Left;
    public Key Right;
    public Key Click;
}
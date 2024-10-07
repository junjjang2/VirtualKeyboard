using System.Collections.Generic;
using UnityEngine;
using VKey;

public class VKeyboardManager : MonoBehaviour
{
    public VKeyboard vKeyboard;
    
    public VPrinter vPrinter;
    
    [SerializeField] public VPrinterView vPrinterView;
    
    [SerializeField] public VirtualKeyboardView virtualKeyboardView;
    
    [SerializeField] public List<KeyLayerSO> keyLayerSOs;
    
    [SerializeField] public KeyLayerSO vowelLayer;
    public void Awake()
    {
        vPrinter = new VPrinter();
        
        vPrinterView.Initialize(vPrinter);
        
        vKeyboard = new VKeyboard(keyLayerSOs, vowelLayer);
        
        vKeyboard.AssignPrinter(vPrinter);
        
        virtualKeyboardView.Initialize(vKeyboard);
    }
}
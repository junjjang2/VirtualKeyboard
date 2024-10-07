using TMPro;
using UnityEngine;

namespace VKey
{
    public class VPrinterView : MonoBehaviour
    {
        private VPrinter _vPrinter;
        
        public TMP_Text text;
        
        public void Initialize(VPrinter vPrinter)
        {
            _vPrinter = vPrinter;
            vPrinter.OnUpdate += OnPrinterUpdate;
        }

        private void OnPrinterUpdate()
        {
            text.text = "Text: " + _vPrinter.GetCurrentLine();
        }
    }
}
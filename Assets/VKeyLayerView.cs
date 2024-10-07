using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VKey
{
    public class VKeyLayerView : MonoBehaviour
    {
        private KeyLayer _keyLayer;

        [SerializeField] private Image background;
        [SerializeField] private Image _up;
        [SerializeField] private TMP_Text _upText;
        [SerializeField] private Image _down;
        [SerializeField] private TMP_Text _downText;
        [SerializeField] private Image _left;
        [SerializeField] private TMP_Text _leftText;
        [SerializeField] private Image _right;
        [SerializeField] private TMP_Text _rightText;
        [SerializeField] private Image _click;
        [SerializeField] private TMP_Text _clickText;

        
        public void Initialize(KeyLayer keyLayer)
        {
            _keyLayer = keyLayer;
            var tmp = background.color;
            tmp.a = 0f;
            background.color = tmp;
            
            _upText.text = keyLayer.Up.KeyCode.ToString();
            _downText.text = keyLayer.Down.KeyCode.ToString();
            _leftText.text = keyLayer.Left.KeyCode.ToString();
            _rightText.text = keyLayer.Right.KeyCode.ToString();
            _clickText.text = keyLayer.Click.KeyCode.ToString();
        }

        public void HighlightKey(KeyDirection direction)
        {
            
            StartCoroutine(Highlight(Get(direction)));
        }

        public void OnSelected()
        {
            var tmp = background.color;
            tmp.a = 0.7f;
            background.color = tmp;
        }
        
        public void OnDeselected()
        {
            var tmp = background.color;
            tmp.a = 0f;
            background.color = tmp;
        }

        private Image Get(KeyDirection direction)
        {
            return direction switch
            {
                KeyDirection.Up => _up,
                KeyDirection.Down => _down,
                KeyDirection.Left => _left,
                KeyDirection.Right => _right,
                KeyDirection.Click => _click,
                _ => null
            };
        }

        private IEnumerator Highlight(Image image)
        {
            image.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            image.color = Color.white;
        }
    }
}
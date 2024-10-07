using System.Collections.Generic;
using UnityEngine;
using VKey;

public class VirtualKeyboardView : MonoBehaviour
{
    private VKeyboard _vKeyboard;
    
    public List<VKeyLayerView> vKeyLayerViews;
    
    [SerializeField] private GameObject vKeyLayerViewPrefab;
    
    public int CurrentLayerIndex => _vKeyboard.CurrentLayerIndex;
    
    [SerializeField] private VKeyboardManager vKeyboardManager;

    // private void Awake()
    // {
    //     if (vKeyboardManager == null)
    //         vKeyboardManager = FindObjectOfType<VKeyboardManager>();
    //
    //     _vKeyboard = vKeyboardManager.VKeyboard;
    //
    //     Initialize(_vKeyboard);
    // }

    public void Initialize(VKeyboard virtualKeyboard)
    {
        _vKeyboard = virtualKeyboard;
        foreach (var layer in virtualKeyboard.KeyLayers)
        {
            var layerView = Instantiate(vKeyLayerViewPrefab, transform).GetComponent<VKeyLayerView>();
            layerView.Initialize(layer);
            vKeyLayerViews.Add(layerView);
        }
        var vowelLayer = Instantiate(vKeyLayerViewPrefab, transform).GetComponent<VKeyLayerView>();
        vowelLayer.Initialize(virtualKeyboard.VowelLayer);
        vKeyLayerViews.Add(vowelLayer);
        OnLayerChanged(_vKeyboard.CurrentLayerIndex);
        RegisterEvents();
    }
    
    private void OnDestroy()
    {
        UnregisterEvents();
    }

    private void RegisterEvents()
    {
        _vKeyboard.OnKeyPressed += OnKeyPressed;
        _vKeyboard.OnLayerChanged += OnLayerChanged;
    }
    
    private void UnregisterEvents()
    {
        _vKeyboard.OnKeyPressed -= OnKeyPressed;
        _vKeyboard.OnLayerChanged -= OnLayerChanged;
    }

    private void OnKeyPressed(Key obj)
    {
        Debug.Log("UI : " + obj.KeyCode);

        // _virtualKeyboard.CurrentLayer.Get(obj.KeyCode);
        //
        // vKeyLayerViews[CurrentLayerIndex].HighlightKey();
    }

    private void OnLayerChanged(int obj)
    {
        Debug.Log("Layer Changed : " + obj);
        foreach (var layer in vKeyLayerViews)
        {
            layer.OnDeselected();
        }
        vKeyLayerViews[obj].OnSelected();
    }
}
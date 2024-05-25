using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookSensitivitySlider : MonoBehaviour
{
    public Slider SliderCzulosc;
    public ThirdPersonController thirdPersonController;
    void Start()
    {
        SliderCzulosc.value = 1f;
        if (SliderCzulosc == null || thirdPersonController == null)
        {
            Debug.LogError("Slider lub ThirdPersonController nie jest przypisany!");
            return;
        }

        SliderCzulosc.value = thirdPersonController.LookSensitivity;
        SliderCzulosc.onValueChanged.AddListener(OnSensitivityChanged);
    }

    void OnSensitivityChanged(float value)
    {
        thirdPersonController.LookSensitivity = value;
    }
}

using System;
using TechTweaking.Bluetooth;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class BtConn : MonoBehaviour
{
    // @formatter:off
    [Header("Set Up")] 
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI deviceNameInput;
    // @formatter:on


    private void Awake()
    {
        Assert.IsNotNull(resultText);
        Assert.IsNotNull(deviceNameInput);
        
        resultText.text = String.Empty;
    }

    public void GetPairedDevices()
    {
        resultText.text = "Paired devices:\n";
        
        var devices = BluetoothAdapter.getPairedDevices();
        foreach (var device in devices)
        {
            resultText.text += $"{device.Name} - {device.MacAddress}\n";
        }
    }

    public void ShowDevices()
    {
        resultText.text = "Detected devices:\n";
        
        BluetoothAdapter.showDevices();

        BluetoothAdapter.OnDevicePicked += device =>
        {
            resultText.text += $"{device.Name} - {device.MacAddress}\n";
        };
    }
}

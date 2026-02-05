using System;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

public class SerialStream : MonoBehaviour
{
    public Toggle lightToggle; // The checkbox (Toggle) on your Unity canvas
    private SerialPort serialPort; // Serial port for communication

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the serial port
        serialPort = new SerialPort("COM7", 9600);  // Adjust the port (COM3) to your Arduino's port
        serialPort.Open(); // Open the port
        //serialPort.ReadTimeout = 10; // Timeout for serial read

        // Set up toggle event
        lightToggle.onValueChanged.AddListener(ToggleLight);
    }

    // Function to send a command to the Arduino when the checkbox is toggled
    void ToggleLight(bool isOn)
    {
        if (serialPort.IsOpen)
        {
            if (isOn) // If the checkbox is checked, send "1"
            {
                serialPort.WriteLine("1"); // Turn on light on Arduino
            }
            else // If the checkbox is unchecked, send "0"
            {
                serialPort.WriteLine("0"); // Turn off light on Arduino
            }
        }
    }

    // On application quit, close the serial port
    private void OnApplicationQuit()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Close(); // Close the serial connection when the app quits
        }
    }
}

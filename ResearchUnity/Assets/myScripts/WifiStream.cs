using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WifiStream : MonoBehaviour
{
    //Arduino IP address
    private string arduinoIp = "192.168.135.204";
    //Port number for the arduino server
    private int port = 80;
    private TcpClient client;
    private NetworkStream stream;
    private bool isConnected = false;

    void Start(){
        //Create the connection to the arduino server
        client = new TcpClient();
        ConnectToArduino();
    }

    //When you close the Unity scene, close wifi connection to arduino
    void OnApplicationQuit(){
        if(client != null && client.Connected){
            stream.Close();
            client.Close();
            isConnected = false;
            Debug.Log("Connection to Arduino closed.");
        }
    }

    //Asynchronous method to establish a connection to arduino
    //Reduces lag, improves runtime
    private async void ConnectToArduino(){
        if(client != null && !client.Connected){
            try{
                Debug.Log("Attempting to connect to Arduino...");
                await client.ConnectAsync(arduinoIp, port);
                stream = client.GetStream();
                isConnected = true;
                Debug.Log("Connected to Arduino!");
            }
            catch(System.Exception e){
                Debug.LogError($"Failed to connect to Arduino: {e.Message}");
                isConnected = false;
            }
        }
        else{
            Debug.LogWarning("Already connected to Arduino.");
        }
    }

    //Method to send data to Arduino once connection is established
    public async void SendData(string command){
        if(!isConnected){
            Debug.LogError("Not connected to Arduino.");
            return;
        }
        try{
            //Remove excess whitespace from the message
            command = command.Trim();
            //Convert the message into a form that can be sent to the arduino
            byte[] message = Encoding.ASCII.GetBytes(command + "\r\n");

            //Write to stream (to the arduino)
            await Task.Run(() => {
                try{
                    stream.Write(message, 0, message.Length);
                    Debug.Log("Message sent to Arduino.");
                }
                catch(System.Exception e){
                    Debug.LogError("Error writing to stream: " + e.Message);
                }
            });
        }
        catch(System.Exception e){
            Debug.LogError("Error in SendData: " + e.Message);
        }
    }

    //Check to see if a connection is established
    //If it has, messages can now be sent
    void FixedUpdate(){   
        if(isConnected){
            if(Input.GetKeyDown(KeyCode.F)){
                SendData("F");
            }
            else if(Input.GetKeyDown(KeyCode.G)){
                SendData("G");
            }
        }
    }
}
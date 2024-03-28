using UnityEngine;
using System.Net.Sockets;
using System.Text;

public class ButtonInteraction : MonoBehaviour
{
    string esp32IP = "192.168.1.XXX"; // Replace with your ESP32's IP address
    int port = 80;

    public void OnButtonPressed() // Call this method when the VR button is pressed
    {
        try
        {
            TcpClient client = new TcpClient(esp32IP, port);
            NetworkStream stream = client.GetStream();

            byte[] message = Encoding.ASCII.GetBytes("1");
            stream.Write(message, 0, message.Length);

            stream.Close();
            client.Close();
        }
        catch (SocketException e)
        {
            Debug.Log("SocketException: " + e.ToString());
        }
    }
}

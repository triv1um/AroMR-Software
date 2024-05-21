// 引入 Unity 引擎、网络连接和文本编码所需的命名空间
using UnityEngine;
using System.Net.Sockets;
using System.Text;

// 定义一个名为 testWIFI 的类，它继承自 MonoBehaviour，允许它附加到 GameObject 上
public class testWIFI : MonoBehaviour
{
    // 定义 ESP32 设备的 IP 地址
    string esp32IP = "192.168.71.15";
    // 定义要连接的端口号，这里使用 HTTP 默认的 80 端口
    int port = 80;

    // 定义一个公共方法，预期在某个按钮被按下时调用
    public void OnButtonPressed()
    {
        try
        {
            // 尝试创建一个 TcpClient 实例，连接到指定的 IP 地址和端口号
            using (TcpClient client = new TcpClient(esp32IP, port))
            // 获取 TcpClient 的网络流，用于发送和接收数据
            using (NetworkStream stream = client.GetStream())
            {
                // 将字符串 "1" 转换为 ASCII 编码的字节序列
                byte[] data = Encoding.ASCII.GetBytes("1");
                // 通过网络流发送转换后的字节数据
                stream.Write(data, 0, data.Length);
            } // 使用完毕后，自动关闭 TcpClient 和 NetworkStream，释放资源
        }
        catch (SocketException e) // 捕获网络连接过程中可能出现的异常
        {
            // 如果出现异常，将错误信息输出到 Unity 控制台
            Debug.LogError("SocketException: " + e.ToString());
        }
    }
}

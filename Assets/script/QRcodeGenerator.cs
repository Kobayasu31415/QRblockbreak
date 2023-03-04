using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

class QRcodeGenerator: MonoBehaviour
{
    [SerializeField]
    RawImage m_QR;

    void Start()
    {
        var texture = GenerateQR(256,256,"http://www.entcomp.iit.tsukuba.ac.jp/");
        m_QR.texture = texture;
    }
    
    Texture GenerateQR(int width, int height, string url)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Width = width,
                Height = height
            }

        };

        var texture = new Texture2D(width, height, TextureFormat.ARGB32, false);

        var colors =writer.Write(url);
        texture.SetPixels32(colors);
        texture.Apply();

        return texture;
    }
}
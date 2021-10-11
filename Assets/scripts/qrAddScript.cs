using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.XR.ARSubsystems;
public class qrAddScript : MonoBehaviour
{
    // Start is called before the first frame update
    public XRReferenceImageLibrary lib;
    void Start()
    {
        addQRtoLib();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private static Color32[] EncodeQR(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }

    public Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = EncodeQR(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

    void addQRtoLib()
    {
        Texture2D myQR = generateQR("test");
        

        //var img = new XRReferenceImage(texture: myQR, name:"qr", guid: );

        //lib.addImage();
    }
}

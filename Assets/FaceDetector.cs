using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;



public class FaceDetector : MonoBehaviour
{
    // Start is called before the first frame update

    WebCamTexture _webCamTexture; 
    CascadeClassifier cascade; //classificador do OpenCV para reconhecer face
    OpenCvSharp.Rect MyFace;
    public float faceY; //variavel que conecta ao passaro. Ao movimentar face na posição Y irá mover o passaro

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices; //Array para armazenar os dispositivos de webcam

        _webCamTexture = new WebCamTexture(devices[0].name); //variavel _webcamtecture recebe a primeira webcam que encontrar
        _webCamTexture.Play();

        cascade = new CascadeClassifier(Application.dataPath + @"\OpenCV+Unity\Demo\Face_Detector\haarcascade_frontalface_default.xml");//localiza o classificador cascade para reconhecimento facial

    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Renderer>().material.mainTexture = _webCamTexture;

        Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture); //Utiliza a textura da webcam para dispor frame por frame

        findNewFace(frame);
        display(frame);
    }

    void findNewFace(Mat frame) //Função para identificar posição do rosto a cada frame
    {
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);
        if (faces.Length >= 1)
        {
            Debug.Log(faces[0].Location);
            MyFace = faces[0];
            faceY = faces[0].Y;
            Debug.Log(faceY);
        }
    }

    void display(Mat frame) //função para mostrar o retangulo que rastreia o rosto
    {
        if (MyFace != null) //Se Myface contem dados do rosto entao adiciona um retangulo a imagem
        {
            frame.Rectangle(MyFace, new Scalar(250, 0, 0), 2);//tamanho do retangulo 
        }
        Texture newtexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newtexture;
    }

}
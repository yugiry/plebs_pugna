using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Camera_Operation : MonoBehaviour
{
    private Camera mainCamera;
    Transform CT;

    public float CameraSize;
    private bool ZoomIn;
    private bool ZoomOut;
    public float ZoomPct;
    private float CameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        mainCamera = Camera.main;
        CT = this.gameObject.GetComponent<Transform>();
        CameraSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //カメラのズーム
        {
            //XキーorZキーを押してズームインとズームアウトを行う
            if (Input.GetKeyDown(KeyCode.X) && !ZoomIn)
            {
                ZoomIn = true;
            }
            else
            {
                ZoomIn = false;
            }
            if (Input.GetKeyDown(KeyCode.Z) && !ZoomOut)
            {
                ZoomOut = true;
            }
            else
            {
                ZoomOut = false;
            }

            if (ZoomIn)
            {
                ZoomPct -= 0.2f;
                if (ZoomPct < 0.2f)
                {
                    ZoomPct = 0.2f;
                }
            }
            if (ZoomOut)
            {
                ZoomPct += 0.2f;
                if (ZoomPct > 1.0f)
                {
                    ZoomPct = 1.0f;
                }
            }
            //カメラのSizeにズームインorズームアウトした分を入れる
            mainCamera.orthographicSize = CameraSize * ZoomPct;
        }

        //カメラの移動
        {
            if (ZoomPct != 1.0f)
            {
                float x = 5 - ZoomPct * 5;
                float tmp;
                tmp = 0.7f;
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                {
                    CT.position = CT.position + new Vector3(0.0f, CameraSpeed, 0.0f);
                }
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                {
                    CT.position = CT.position - new Vector3(0.0f, CameraSpeed, 0.0f);
                }
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    CT.position = CT.position - new Vector3(CameraSpeed, 0.0f, 0.0f);
                }
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    CT.position = CT.position + new Vector3(CameraSpeed, 0.0f, 0.0f);
                }

                if (CT.position.x > tmp + 11 * x)
                {
                    CT.position = new Vector3(tmp + 11 * x, CT.position.y, CT.position.z);
                }
                if (CT.position.x < -tmp - 11 * x)
                {
                    CT.position = new Vector3(-tmp - 11 * x, CT.position.y, CT.position.z);
                }
                if (CT.position.y > tmp + 11 * x)
                {
                    CT.position = new Vector3(CT.position.x, tmp + 11 * x, CT.position.z);
                }
                if (CT.position.y < -tmp - 11 * x)
                {
                    CT.position = new Vector3(CT.position.x, -tmp - 11 * x, CT.position.z);
                }
            }
            else
            {
                CT.position = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }
    }
}

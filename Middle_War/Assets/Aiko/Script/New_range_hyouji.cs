using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_range_hyouji : MonoBehaviour
{
    int range_flag = 0;

    public GameObject unit_click;
    public Transform parent;
    public GameObject base_point_unit;
    private GameObject unitclick;


    GameObject apobj;
    // public APchange AP;

    float masume_size = 4.5f;
    public void Click_unit()
    {




        //unitclick = unit_click as GameObject; 
        Vector3 pos = parent.transform.localPosition;//�N���b�N���ꂽ���j�b�g�̈ʒu���
        if (this.gameObject.name == "Pinfantry(Clone)"/*&&range_flag!=0*/)
        {
            //range_flag = 1;
            Destroy_Range();
            Destroy_Range();
            for (float x = -masume_size; x <= +masume_size; x += masume_size)
            {
                for (float y = -masume_size; y <= +masume_size; y += masume_size)
                {
                    if (x == 0 && y == 0)
                    {

                    }
                    else
                    {
                        unitclick = Instantiate(unit_click, new Vector3(pos.x + x, pos.y + y, 15.0f), Quaternion.identity, parent) as GameObject;
                    }
                }
            }

            Debug.Log("�N���b�N���ꂽ�����B");

            // Destroy(unitclick, 1);
        }
        //�|������
        else if (this.gameObject.name == "Parcher(Clone)"/* && range_flag != 0*/)
        {
            //range_flag = 1;
            Destroy_Range();
            Destroy_Range();
            for (float x = -masume_size * 2; x <= +masume_size * 2; x += masume_size)
            {
                for (float y = -masume_size * 2; y <= +masume_size * 2; y += masume_size)
                {
                    if (x == 0 && y == 0)
                    {

                    }
                    else
                    {
                        unitclick = Instantiate(unit_click, new Vector3(pos.x + x, pos.y + y, 15.0f), Quaternion.identity, parent) as GameObject;
                    }

                }

            }
            Debug.Log("Archer clicked");
        }
        //�J�^�p���g����
        else if (this.gameObject.name == "Pcatapalt(Clone)"/* && range_flag != 0*/)
        {
            //range_flag = 1;
            Destroy_Range();
            Destroy_Range();
            for (float x = -masume_size * 4; x <= +masume_size * 4; x += masume_size)
            {
                for (float y = -masume_size * 4; y <= +masume_size * 4; y += masume_size)
                {
                    if (x >= -masume_size * 1 && x <= masume_size * 1 && y >= -masume_size * 1 && y <= masume_size * 1)
                    {

                    }
                    else
                    {
                        unitclick = Instantiate(unit_click, new Vector3(pos.x + x, pos.y + y, 15.0f), Quaternion.identity, parent) as GameObject;
                    }
                }

            }
            Debug.Log("Catapult clicked");
        }



    }

    public void Destroy_Range()
    {
        GameObject[] unitclick = GameObject.FindGameObjectsWithTag("Respawn");

        if (unit_click.activeSelf)
        {
            //var unitclick = Instantiate(unit_click) as GameObject;
            foreach (GameObject range_child in unitclick)
            {
                Destroy(range_child);
                Debug.Log("destroy");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //unitclick= Instantiate(unit_click)/* as GameObject*/;


    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    if (range_flag == 0)
        //    {
        //        range_flag = 1;
        //        Debug.Log("flag on!" + range_flag);
        //    }
        //    else if (range_flag == 1)
        //    {
        //        range_flag = 0;
        //        Destroy_Range();
        //        Debug.Log("flag off!" + range_flag);
        //    }
            //�G���[�����@�t���O�I�t�̏�ԂŃ��j�b�g�ȊO���N���b�N���G���[
            //�����@�}�b�v�^�C����ǂݍ���łȂ���ԂŃN���b�N��������H
            //�I�y���[�V�����ɂ̓}�b�v�^�C���N���b�N���̏���������
            //������̃V�[���ł̓}�b�v�^�C�����ǂݍ��߂Ȃ��������߃}�b�v�Ȃ��Ŏ��s���Ă���B
            //}
        //    if (Input.GetMouseButton(0))
        //    {
        //        Destroy_Range();
        //        //range_flag = 0;
        //    }
        //}
    }
}

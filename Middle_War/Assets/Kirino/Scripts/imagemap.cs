//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class imagemap : MonoBehaviour
//{
//    public int countrynum;
//    private Image image;
//    public Sprite[] newSprite;
//    //public Sprite newSprite2;
//    //public Sprite newSprite3;
//    //public Sprite newSprite4;

//    //public GameObject islandUI;

//    // Start is called before the first frame update
//    void Start()
//    {
//        image = GetComponent<Image>();
//    }
    
//    public void Shew_island(int countrynum)
//    {//�摜�����`�F���W�i�N���b�N���ꂽ����mapClick�X�N���v�g����l�����L���Ă��̒l�̏����Ƃ��ĕ\���������摜�����j
//        image.sprite = newSprite[countrynum - 1];
//        switch (countrynum)
//        {
//            case 1:
//                //image.sprite = newSprite[countrynum];//�摜�Ȃ�image�I�u�W�F�N�g�ɐV�����摜�P��\��t����image�I�u�W�F�N�g�͕ς��Ȃ�
//                //islandUI.transform.position = new Vector3(-0, 0, 50);
//                break;
//            case 2:
//                //image.sprite = newSprite2;
//                //islandUI.transform.position = new Vector3(-0, 0, 50);
//                break;
//            case 3:
//                //image.sprite = newSprite3;
//                //islandUI.transform.position = new Vector3(-0, 0, 50);
//                break;
//            case 4:
//                //image.sprite = newSprite4;
//                //islandUI.transform.position = new Vector3(-0, 0, 50);
//                break;
//            default://swithe�����I���ɕK�v�I
//                break;
//        }
//    }

//    //�����P
//    // Update is called once per frame
//    //void Update()
//    //{
//    //    //void show_image(int countrynum)
//    //    //{ }
//    //    {
//    //        if (Input.GetKeyDown(KeyCode.Space))
//    //        {
//    //            image.sprite = newSprite1;
//    //        }
//    //    }
//    //}

//    //�����Q
//    //public void Shew_image(int countrynum)
//    //{
//    //    if (countrynum == 1)
//    //    {
//    //        image.sprite = newSprite1;
//    //    }
//    //    if (countrynum == 2)
//    //    {
//    //        image.sprite = newSprite2;
//    //    }
//    //    if (countrynum == 3)
//    //    {
//    //        image.sprite = newSprite3;
//    //    }
//    //    if (countrynum == 4)
//    //    {
//    //        image.sprite = newSprite4;
//    //    }
//    //}
//}

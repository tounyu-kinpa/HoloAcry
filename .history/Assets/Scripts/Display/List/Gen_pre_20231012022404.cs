using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour
{
    // �v���n�u�i�[�p
    public GameObject Panel;
    public GameObject Wall;
    public GameObject ListUI;

    public int n = GlobalVariables.workNumber + 1;//�K���ɓ���Đ�������邩�e�X�g����B���xml�Ȃǂɂ��鐔�l���Q�Ƃ���B

    GameObject Obj;

    // Start is called before the first frame update
    public void OnClick()
    {

        if (n == 0)
        {
            Vector3 vec = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 vec2 = new Vector3(900.0f, 0.0f, 0.0f);

            for (int i = 1; i < 30; i++) //30�Ƃ������l�͓K����ŕς���
            {
                if ((i % 2) == 1)
                {
                    Obj = Instantiate(Wall, vec, Quaternion.identity);
                    Obj.transform.SetParent(ListUI.transform, false);
                    vec.y -= 880.0f;
                }

                if ((i % 2) == 0)
                {
                    Obj = Instantiate(Wall, vec2, Quaternion.identity);
                    Obj.transform.SetParent(ListUI.transform, false);
                    vec2.y -= 880.0f;
                }

            }
        }

        n += 1;//n�̌��|����̒l�Ǝ��ۂɐ��������prefab�̍���1�A�߂�l��ݒ肷��ꍇ��-1����B

        if (0 < n)
        {
            Vector3 vec = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 vec2 = new Vector3(830.0f, 0.0f, 0.0f);

            for (int i = 1; i < n; i++) //30�Ƃ������l�͓K����ŕς���
            {
                if ((i % 2) == 1)
                {
                    Obj = Instantiate(Panel, vec, Quaternion.identity);
                    Obj.transform.SetParent(ListUI.transform, false);
                    vec.y -= 880.0f;
                }

                if ((i % 2) == 0)
                {
                    Obj = Instantiate(Panel, vec2, Quaternion.identity);
                    Obj.transform.SetParent(ListUI.transform, false);
                    vec2.y -= 880.0f;
                }
                if ((n - 1) == i)//�Ō�̃��[�v�ł����
                {
                    for (; i < 30; i++) //30�Ƃ������l�͓K����ŕς���
                    {
                        vec2.x = 900.0f;
                        if ((i % 2) == 1)
                        {
                            Obj = Instantiate(Wall, vec, Quaternion.identity); ;
                            Obj.transform.SetParent(ListUI.transform, false);
                            vec.y -= 880.0f;
                        }

                        if ((i % 2) == 0)
                        {
                            Obj = Instantiate(Wall, vec2, Quaternion.identity);
                            Obj.transform.SetParent(ListUI.transform, false);
                            vec2.y -= 880.0f;
                        }

                    }
                }

            }

        }

        for (int i = 0; i < n; i++)
        {
            Obj = Instantiate(Panel);
            Obj.transform.SetParent(ListUI.transform, false);
        }
        for (int i = 0; i < 20; i++)
        {
            Obj = Instantiate(Wall);
            Obj.transform.SetParent(ListUI.transform, false);
        }


    }

}

// Update is called once per frame

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Display.Production;

public class ObjectFixer : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log(GlobalVariables.workNumber - 2);
        //work‚ÌScaleŽæ“¾
        float ScaleX = GlobalVariables.CurrentWork.transform.localScale.x;
        float ScaleY = GlobalVariables.CurrentWork.transform.localScale.y;
        float ScaleZ = GlobalVariables.CurrentWork.transform.localScale.z;

        List<float> ChildScaleX = new List<float>();
        List<float> ChildScaleY = new List<float>();
        List<float> ChildScaleZ = new List<float>();

        //work‚ÌŽq
        for (int n = 0; n <= GlobalVariables.CurrentWork.transform.childCount; n++)
        {
            Debug.Log("HEAD");

            ChildScaleX.Add(GlobalVariables.CurrentWork.transform.GetChild(n).localScale.x);
            ChildScaleY.Add(GlobalVariables.CurrentWork.transform.GetChild(n).localScale.y);
            ChildScaleZ.Add(GlobalVariables.CurrentWork.transform.GetChild(n).localScale.z);

            Debug.Log(ScaleX);
            Debug.Log(ScaleY);
            Debug.Log(ScaleZ);

            Debug.Log(ChildScaleX[n]);
            Debug.Log(ChildScaleY[n]);
            Debug.Log(ChildScaleZ[n]);

            if ((ScaleX * ChildScaleX[n]) > 6)
            {
                Debug.Log("1");
                float times = ScaleX * (6 / ChildScaleX[n]);

                GlobalVariables.CurrentWork.transform.GetChild(n).localScale = new Vector3(ScaleX * times, ScaleY * times, ScaleZ * times);

            }
            else if ((ScaleY * ChildScaleY[n]) > 6)
            {
                Debug.Log("2");
                float times = ScaleY * (6 / ChildScaleY[n]);

                GlobalVariables.CurrentWork.transform.GetChild(n).localScale = new Vector3(ScaleX * times, ScaleY * times, ScaleZ * times);
            }
            else if ((ScaleZ * ChildScaleZ[n]) > 6)
            {
                Debug.Log("3");
                float times = ScaleZ * (6 / ChildScaleZ[n]);
                GlobalVariables.CurrentWork.transform.GetChild(n).localScale = new Vector3(ScaleX * times, ScaleY * times, ScaleZ * times);
            }

        }
    }         /*for (int n = 0; n <= ProductionManager.selectedGameObjects[GlobalVariables.workNumber - 2].transform.childCount; n++)
        {
            Debug.Log("b");
            ChildScaleX[n] = ProductionManager.selectedGameObjects[GlobalVariables.workNumber - 2].transform.GetChild(n).position.x;
            ChildScaleY[n] = ProductionManager.selectedGameObjects[GlobalVariables.workNumber - 2].transform.GetChild(n).position.y;
            ChildScaleZ[n] = ProductionManager.selectedGameObjects[GlobalVariables.workNumber - 2].transform.GetChild(n).position.z;
        }

        for (int n = 0; n <= ProductionManager.selectedGameObjects[GlobalVariables.workNumber - 2].transform.childCount; n++)
        {
            Debug.Log("c");
            if ((ScaleX * ChildScaleX[n]) <= 6)
            {
                float times = ScaleX * (6 / ChildScaleX[n]);

                ScaleX *= times;
                ScaleY *= times;
                ScaleZ *= times;

            }
            else if((ScaleY * ChildScaleY[n]) <= 6)
            {
                float times = ScaleY * (6 / ChildScaleY[n]);

                ScaleX *= times;
                ScaleY *= times;
                ScaleZ *= times;
            }
            else if ((ScaleZ * ChildScaleZ[n]) <= 6)
            {
                float times = ScaleZ * (6 / ChildScaleZ[n]);

                ScaleX *= times;
                ScaleY *= times;
                ScaleZ *= times;
            }


        }

        
       


    }*/


}
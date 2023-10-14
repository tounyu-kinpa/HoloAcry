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
        float ScaleX = ProductionManager.selectedGameObjects[0].transform.localScale.x;
        float ScaleY = ProductionManager.selectedGameObjects[0].transform.localScale.y;
        float ScaleZ = ProductionManager.selectedGameObjects[0].transform.localScale.z;

        List<float> ChildScaleX = new List<float>();
        List<float> ChildScaleY = new List<float>();
        List<float> ChildScaleZ = new List<float>();

        //work‚ÌŽq
        for (int n = 0; n <= ProductionManager.selectedGameObjects[0].transform.childCount; n++)
        {
            Debug.Log("HEAD");

            ChildScaleX.Add(ProductionManager.transform.GetChild(n).localScale.x);
            ChildScaleY[n] = ProductionManager.selectedGameObjects[0].transform.GetChild(n).localScale.y;
            ChildScaleZ[n] = ProductionManager.selectedGameObjects[0].transform.GetChild(n).localScale.z;

            Debug.Log("c");
            if ((ScaleX * ChildScaleX[n]) > 6)
            {
                Debug.Log("1");
                float times = ScaleX * (6 / ChildScaleX[n]);

                ProductionManager.selectedGameObjects[0].transform.GetChild(n).localScale = new Vector3(ScaleX * times, ScaleY * times, ScaleZ * times);

            }
            else if ((ScaleY * ChildScaleY[n]) > 6)
            {
                Debug.Log("2");
                float times = ScaleY * (6 / ChildScaleY[n]);

                ProductionManager.selectedGameObjects[0].transform.GetChild(n).localScale = new Vector3(ScaleX * times, ScaleY * times, ScaleZ * times);
            }
            else if ((ScaleZ * ChildScaleZ[n]) > 6)
            {
                Debug.Log("3");
                float times = ScaleZ * (6 / ChildScaleZ[n]);
                ProductionManager.selectedGameObjects[0].transform.GetChild(n).localScale = new Vector3(ScaleX * times, ScaleY * times, ScaleZ * times);
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
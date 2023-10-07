using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class DoubleClick : MonoBehaviour, IPointerClickHandler 
    {
        public void OnPointerClick (PointerEventData eventData)
        {
            if( eventData.clickCount > 1 ){
                Debug.Log(eventData.clickCount);
            }
        }
        
        void addSelectedGameObject()
        {
            ProductionManager.selectedGameObjects.Add(gameObject);
        }
    }
    
}
    //シングルタップの場合は拡大、ダブルタップの場合は縮小するメソッド



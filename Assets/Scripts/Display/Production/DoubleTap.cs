using UnityEngine;
using UnityEngine.EventSystems;

namespace Display.Production
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



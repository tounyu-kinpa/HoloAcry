using UnityEngine;
namespace Display.Production
{
    public class DoubleTap : MonoBehaviour 
    {
        public void onTouched()
        {
            Debug.Log("タッチされました");
        }
        void addSelectedGameObject()
        {
            ProductionManager.selectedGameObjects.Add(gameObject);
        }
    }
    
}


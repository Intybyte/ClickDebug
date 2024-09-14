using BepInEx;
using UnityEngine;

namespace ClickDebug
{
    [BepInPlugin("me.vaan.debugclick", "DebugClick", "1.0.0")]
    public class Class1 : BaseUnityPlugin
    {   
        public void Update() {
            if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
            {
                Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
                ShowComponentsAtMouse(mousePosition);
            }
        }
        private void ShowComponentsAtMouse(Ray position)
        {
            RaycastHit[] hits = Physics.RaycastAll(position, float.PositiveInfinity, -1, QueryTriggerInteraction.Collide);

            Debug.Log("[CD] === BEGIN ALL HITS === ");
            foreach (RaycastHit hit in hits)
            {

                GameObject clickedObject = hit.collider.gameObject;

                Debug.Log("[CD] Clicked GameObject START: " + clickedObject.name);

                Component[] components = clickedObject.GetComponents<Component>();
                foreach (Component component in components)
                {
                    Debug.Log("[CD] Component: " + component.GetType().Name);
                }
                Debug.Log("[CD] Clicked GameObject END");
            }
            Debug.Log("[CD] === END ALL HITS === ");
        }
    }
}

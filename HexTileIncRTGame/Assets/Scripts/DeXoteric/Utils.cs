using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DeXoteric
{
    public class Utils
    {
        public static bool IsPointerOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }

        public static bool IsOnMobile()
        {
            bool value;

#if UNITY_ANDROID || UNITY_IOS
            value = true;
#endif
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
            value = false;
#endif

            return value;
        }
    }
}
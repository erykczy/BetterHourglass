using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace BetterHourglass
{
    public static class BetterHourglassIcon
    {
        public static void create(MonoBehaviour monoBehaviour)
        {
            /*
            Debug.Log("create");
            Debug.Log("created object");
            Debug.Log("added components");
            Debug.Log("gameObject: "+gameObject);
            Debug.Log("gameObject.transform: " + gameObject.transform);
            Debug.Log("canvas: " + canvas);
            Debug.Log("canvas.name: " + canvas.name);
            */
            //Debug.Log("a: " + ((PowersTab)GameObject.FindObjectOfType(typeof(PowersTab))).transform.GetComponentInParent<Canvas>().gameObject.name);
            //Debug.Log("b: " + ((PowersTab)GameObject.FindObjectOfType(typeof(PowersTab))).transform.GetComponentInParent<Canvas>().transform.parent.GetComponentInParent<Canvas>().gameObject.name);
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<RectTransform>().SetAnchor(AnchorPresets.TopRight);
            gameObject.AddComponent<CanvasRenderer>();
            gameObject.AddComponent<Image>().sprite = Sprites.sprites[Sprites.ESprite.BETTER_HOURGLASS];
            gameObject.AddComponent<Button>();
            
            gameObject.transform.SetParent(BetterHourglass.canvas.transform);
            
            gameObject.transform.position = new Vector3(Screen.width-gameObject.GetComponent<RectTransform>().rect.width, Screen.height- gameObject.GetComponent<RectTransform>().rect.height, 0);
        }
        
    }
}

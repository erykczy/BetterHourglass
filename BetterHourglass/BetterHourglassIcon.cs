using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BetterHourglass
{
    public class BetterHourglassIcon : MonoBehaviour
    {
        public int timeScale = 1;
        private static bool expanded = false;
        private static float space = 10;
        private static float scale = 65;
        private static List<GameObject> childs = new List<GameObject>();
        private static GameObject main = null;
        public static void update()
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                if (Vector2.Distance(Camera.main.ScreenToWorldPoint(main.transform.position), Camera.main.ScreenToWorldPoint(Input.mousePosition)) < 20)
                {
                    if (Input.mouseScrollDelta.y > 0)
                    {
                        updateScale(scale + 2);
                    }
                    if (Input.mouseScrollDelta.y < 0)
                    {
                        updateScale(scale - 2);
                    }
                }
            }
        }
        public static void create()
        {
            if(PlayerPrefs.HasKey("betterHourglassScale"))
            {
                scale = PlayerPrefs.GetFloat("betterHourglassScale");
            }
            main = createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.BETTER_HOURGLASS], new Vector3(), -4, 1);
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x1], new Vector3(), 1, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x2], new Vector3(), 2, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x5], new Vector3(), 5, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x10], new Vector3(), 10, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x20], new Vector3(), 20, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x50], new Vector3(), 50, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x100], new Vector3(), 100, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x200], new Vector3(), 200, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x500], new Vector3(), 500, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x1k], new Vector3(), 1000, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x2k], new Vector3(), 2000, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x5k], new Vector3(), 5000, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x10k], new Vector3(), 10000, 0.5F));
            childs.Add(createIcon(BetterHourglass.canvas.transform, Sprites.sprites[Sprites.ESprite.x20k], new Vector3(), 20000, 0.5F));
            main.transform.position = new Vector3(Screen.width - (main.GetComponent<RectTransform>().rect.width/2 + space), Screen.height - (main.GetComponent<RectTransform>().rect.height / 2 + space));
            for (int i = 0; i < childs.Count; i++)
            {
                GameObject lastGameObject = i - 1 >= 0 ? childs[i - 1] : main;
                childs[i].transform.position = new Vector3(Screen.width - (childs[i].GetComponent<RectTransform>().rect.width / 2 + space), (lastGameObject.transform.position.y - lastGameObject.GetComponent<RectTransform>().rect.height) - 0);

                childs[i].SetActive(false);
            }
        }
        private static void updateScale(float newScale)
        {
            scale = newScale;
            PlayerPrefs.SetFloat("betterHourglassScale", scale);
            main.GetComponent<RectTransform>().sizeDelta = new Vector2(scale, scale);
            main.transform.position = new Vector3(Screen.width - (main.GetComponent<RectTransform>().rect.width / 2 + space), Screen.height - (main.GetComponent<RectTransform>().rect.height / 2 + space));
            for (int i = 0; i < childs.Count; i++)
            {
                childs[i].GetComponent<RectTransform>().sizeDelta = new Vector2(scale, scale);
            }
            for (int i = 0; i < childs.Count; i++)
            {
                GameObject lastGameObject = i - 1 >= 0 ? childs[i - 1] : main;
                childs[i].transform.position = new Vector3(Screen.width - (childs[i].GetComponent<RectTransform>().rect.width / 2 + space), (lastGameObject.transform.position.y - lastGameObject.GetComponent<RectTransform>().rect.height) - 0);
            }
        }
        public static GameObject createIcon(Transform parent, Sprite sprite, Vector3 position, int timeScale, float a)
        {
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<RectTransform>().SetAnchor(AnchorPresets.TopRight);
            gameObject.AddComponent<CanvasRenderer>();
            gameObject.AddComponent<Image>().sprite = sprite;
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, a);
            if(timeScale != -4)
            {
                gameObject.AddComponent<Button>().onClick.AddListener(delegate { childClick(timeScale); });
                gameObject.AddComponent<BetterHourglassIcon>().timeScale = timeScale;
            }
            else
            {
                gameObject.AddComponent<Button>().onClick.AddListener(mainClick);
            }
            

            gameObject.transform.SetParent(parent);
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(scale, scale);
            gameObject.transform.position = new Vector3(position.x, position.y, 0);
            return gameObject;
        }
        public static void mainClick()
        {
            bool b = !expanded;
            expanded = b;
            for (int i = 0; i < childs.Count; i++)
            {
                updateChild(childs[i]);
                childs[i].SetActive(b);
            }
        }
        public static void updateChilds()
        {
            for (int i = 0; i < childs.Count; i++)
            {
                updateChild(childs[i]);
            }
        }
        public static void updateChild(GameObject child)
        {
            if (Config.timeScale == child.GetComponent<BetterHourglassIcon>().timeScale)
            {
                child.GetComponent<Image>().color = new Color(child.GetComponent<Image>().color.r, child.GetComponent<Image>().color.g, child.GetComponent<Image>().color.b, 1);
            }
            else
            {
                child.GetComponent<Image>().color = new Color(child.GetComponent<Image>().color.r, child.GetComponent<Image>().color.g, child.GetComponent<Image>().color.b, 0.5F);
            }
        }
        public static void childClick(int timeScale)
        {
            Config.timeScale = timeScale;
            updateChilds();
        }
    }
}

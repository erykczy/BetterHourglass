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
    public class Sprites
    {
        public enum ESprite
        {
            BETTER_HOURGLASS
        }
        private static BetterHourglass betterHourglass;
        public static Dictionary<ESprite, Sprite> sprites = new Dictionary<ESprite, Sprite>();

        public static void setup(BetterHourglass main)
        {
            betterHourglass = main;
            betterHourglass.StartCoroutine(downloadSprite(ESprite.BETTER_HOURGLASS, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/BetterHourglass.png?raw=true"));
        }

        private static IEnumerator downloadSprite(ESprite eSprite, string path)
        {
            WWW www = new WWW(path);
            yield return www;
            sprites.Add(eSprite, Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0)));
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace BetterHourglass
{
    public class Sprites
    {
        public enum ESprite
        {
            BETTER_HOURGLASS,
            x1,
            x2,
            x3,
            x5,
            x10,
            x20,
            x50,
            x100,
            x200,
            x500,
            x1k,
            x2k,
            x5k,
            x10k,
            x20k
        }
        private static BetterHourglass betterHourglass;
        public static Dictionary<ESprite, Sprite> sprites = new Dictionary<ESprite, Sprite>();

        public static void setup(BetterHourglass main)
        {
            betterHourglass = main;
            betterHourglass.StartCoroutine(downloadSprite(ESprite.BETTER_HOURGLASS, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/BetterHourglass.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x1, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x1.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x2, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x2.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x5, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x5.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x10, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x10.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x20, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x20.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x50, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x50.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x100, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x100.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x200, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x200.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x500, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x500.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x1k, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x1k.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x2k, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x2k.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x5k, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x5k.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x10k, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x10k.png?raw=true"));
            betterHourglass.StartCoroutine(downloadSprite(ESprite.x20k, "https://github.com/thecodeyt/BetterHourglass/blob/main/Sprites/x20k.png?raw=true"));
        }

        private static IEnumerator downloadSprite(ESprite eSprite, string path)
        {
            UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(path);
            yield return webRequest.SendWebRequest();
            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Mod \""+BetterHourglass.pluginName+"\" requires internet connection to download textures!");
            }
            else if(webRequest.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
                sprite.texture.filterMode = FilterMode.Point;
                sprites.Add(eSprite, sprite);
            }
            else
            {
                Debug.Log(webRequest.error);
            }
        }
    }
}

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
        public static Dictionary<ESprite, Sprite> sprites = new Dictionary<ESprite, Sprite>();

        public static void setup()
        {
            loadSprite(ESprite.BETTER_HOURGLASS, @"Mods/BetterHourglass/GameResources/ui/Icons/BetterHourglass.png");
            loadSprite(ESprite.x1, @"Mods/BetterHourglass/GameResources/ui/Icons/x1.png");
            loadSprite(ESprite.x2, @"Mods/BetterHourglass/GameResources/ui/Icons/x2.png");
            loadSprite(ESprite.x5, @"Mods/BetterHourglass/GameResources/ui/Icons/x5.png");
            loadSprite(ESprite.x10, @"Mods/BetterHourglass/GameResources/ui/Icons/x10.png");
            loadSprite(ESprite.x20, @"Mods/BetterHourglass/GameResources/ui/Icons/x20.png");
            loadSprite(ESprite.x50, @"Mods/BetterHourglass/GameResources/ui/Icons/x50.png");
            loadSprite(ESprite.x100,@"Mods/BetterHourglass/GameResources/ui/Icons/x100.png");
            loadSprite(ESprite.x200,@"Mods/BetterHourglass/GameResources/ui/Icons/x200.png");
            loadSprite(ESprite.x500,@"Mods/BetterHourglass/GameResources/ui/Icons/x500.png");
            loadSprite(ESprite.x1k, @"Mods/BetterHourglass/GameResources/ui/Icons/x1k.png");
            loadSprite(ESprite.x2k, @"Mods/BetterHourglass/GameResources/ui/Icons/x2k.png");
            loadSprite(ESprite.x5k, @"Mods/BetterHourglass/GameResources/ui/Icons/x5k.png");
            loadSprite(ESprite.x10k, @"Mods/BetterHourglass/GameResources/ui/Icons/x10k.png");
            loadSprite(ESprite.x20k, @"Mods/BetterHourglass/GameResources/ui/Icons/x20k.png");
        }

        private static void loadSprite(ESprite eSprite, string path)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(System.IO.File.ReadAllBytes(path));
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
            sprite.texture.filterMode = FilterMode.Point;
            sprites.Add(eSprite, sprite);
        }
    }
}

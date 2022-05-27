using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using UnityEngine;

namespace BetterHourglass
{

    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class BetterHourglass : BaseUnityPlugin
    {
        public const string pluginGuid = "dd8b2111-28b2-4d7d-936a-b0abf1a090c6";
        public const string pluginName = "Better Hourglass";
        public const string pluginVersion = "0.1.0";
        public static GameObject canvas;
        //public BetterHourglassWindow betterHourglassWindow;

        public void Awake()
        {
            Sprites.setup(this);
        }

        public void FixedUpdate()
        {
            if (canvas == null)
            {
                try
                {
                    canvas = ((PowersTab)GameObject.FindObjectOfType(typeof(PowersTab))).transform.GetComponentInParent<Canvas>().transform.parent.GetComponentInParent<Canvas>().transform.parent.GetComponentInParent<Canvas>().gameObject;
                    BetterHourglassIcon.create();
                }
                catch
                {

                }
            }
        }
    }
}

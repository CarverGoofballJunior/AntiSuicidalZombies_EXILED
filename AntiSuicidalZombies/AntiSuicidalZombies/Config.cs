using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;

namespace AntiSuicidalZombies
{
    public class Config : IConfig
    {
        [Description("Is plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should Debug be enabled?")]
        public bool Debug { get; set; } = false;

        [Description("What effects should be applied to zombies after walking into tesla and for how long?")]
        public Dictionary<EffectType, float> TeslaEffect { get; set; } = new Dictionary<EffectType, float>
        {
            {EffectType.Blinded, 5f }
        };
    }
}

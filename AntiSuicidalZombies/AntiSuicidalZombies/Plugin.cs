using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace AntiSuicidalZombies
{
    public class Plugin : Plugin<Config>
	{
		public override string Author { get; } = "Aidualk";

		public override string Name { get; } = "AntiSuicidalZombies";

		public override string Prefix { get; } = "AntiSuicidalZombies";

		public override Version Version { get; } = new Version(1, 0, 0);

		public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

		public override void OnEnabled()
		{
			Plugin.Singleton = this;
			this.EventHandlers = new EventHandlers();
			Exiled.Events.Handlers.Player.Hurting += EventHandlers.OnHurting;
			
			base.OnEnabled();
		}
		public override void OnDisabled()
		{
			if (this.EventHandlers != null)
			{
				Exiled.Events.Handlers.Player.Hurting -= EventHandlers.OnHurting;
			}
			this.EventHandlers = null;
			Plugin.Singleton = null;
			base.OnDisabled();
		}

		private EventHandlers EventHandlers;

		public static Plugin Singleton;
	}
}

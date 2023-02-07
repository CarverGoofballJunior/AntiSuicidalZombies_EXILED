using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerRoles;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Enums;
using Exiled.API.Features;
using UnityEngine;

namespace AntiSuicidalZombies
{
    public class EventHandlers
    {
        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Player.Role.Type == RoleTypeId.Scp0492)
            {
                if (ev.DamageHandler.Type == DamageType.Tesla)
                {
                    foreach (var effect in from e in config.TeslaEffect where e.Value > 0 select e)
                    {
                        ev.Player.EnableEffect(effect.Key, effect.Value);
                        Log.Debug($"Applied effect {effect.Key} to {ev.Player.Nickname} for {effect.Value}s.");
                    }
                    ev.IsAllowed = false;
                    return;
                }

                if (ev.DamageHandler.Type == DamageType.Crushed && (ev.Player.CurrentRoom.Type == RoomType.Hcz106 || ev.Player.CurrentRoom.Type == RoomType.HczArmory || ev.Player.CurrentRoom.Type == RoomType.HczTestRoom))
                {
                    var roomdoors = ev.Player.CurrentRoom.Doors.Where(d => d.RequiredPermissions.RequiredPermissions == Interactables.Interobjects.DoorUtils.KeycardPermissions.None).ToList();
                    var doorpos = roomdoors.ElementAt(RandInt.Next(roomdoors.Count)).Position;
                    doorpos += Vector3.forward * 0.2f;
                    doorpos += Vector3.up;
                    ev.Player.Position = doorpos;
                    ev.IsAllowed = false;
                    return;
                }
            }
        }

        private static Config config = Plugin.Singleton.Config;

        private static readonly System.Random RandInt = new System.Random();
    }
}

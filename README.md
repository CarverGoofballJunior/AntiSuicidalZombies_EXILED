# AntiSuicidalZombies_EXILED
Plugin AntiSuicidalZombies for EXILED. Prevent Zombies from suiciding on Tesla or by jumping into void (in Hcz106, HczTestRoom and HczArmory).
- Zombies can have effects applied after walking into Tesla.
- Zombies that jump into void will be teleported to one of the doors in the room, that doesn't require any keycard permission.

## Config
|Name|Type|Default value|Description|
|---|---|---|---|
|is_enabled|bool|true|Is plugin enabled?|
|debug|bool|false|Should Debug be enabled?|
|tesla_effect|Dictionary<EffectType, float>|Blinded: 5|What effects should be applied to zombies after walking into tesla and for how long?|

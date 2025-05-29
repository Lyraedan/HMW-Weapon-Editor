using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public class WeaponJson
    {
        // General group, no subgroup
        [Group("General")]
        public string szInternalName { get; set; }

        [Group("General")]
        public string szDisplayName { get; set; }

        [Group("General")]
        public string szAltWeaponName { get; set; }


        // Models group
        [Group("Models")]
        public List<string> gunModel { get; set; }

        [Group("Models")]
        public List<string> worldModel { get; set; }

        [Group("Models")]
        public string handModel { get; set; }

        [Group("Models")]
        public string persistentArmXModel { get; set; }

        [Group("Models")]
        public string worldClipModel { get; set; }

        [Group("Models")]
        public string rocketModel { get; set; }

        [Group("Models")]
        public string knifeModel { get; set; }

        [Group("Models")]
        public string worldKnifeModel { get; set; }


        // Animations group, subgroup "RightHanded"
        [Group("Animations", "RightHanded")]
        public Dictionary<string, string> szXAnimsRightHanded { get; set; }

        // Animations group, subgroup "LeftHanded"
        [Group("Animations", "LeftHanded")]
        public Dictionary<string, string> szXAnimsLeftHanded { get; set; }

        // Animations group, subgroup "General"
        [Group("Animations", "General")]
        public Dictionary<string, string> szXAnims { get; set; }


        [Group("Attachments")]
        public List<string> attachments { get; set; }


        [Group("Sound Notetracks")]
        public List<string> notetrackSoundMapKeys { get; set; }

        [Group("Sound Notetracks")]
        public List<string> notetrackSoundMapValues { get; set; }

        [Group("Sound Notetracks")]
        public List<string> notetrackRumbleMapKeys { get; set; }

        [Group("Sound Notetracks")]
        public List<string> notetrackRumbleMapValues { get; set; }

        [Group("Sound Notetracks")]
        public List<string> notetrackFXMapKeys { get; set; }

        [Group("Sound Notetracks")]
        public List<string> notetrackFXMapValues { get; set; }

        [Group("Sound Notetracks")]
        public List<string> notetrackFXMapTagValues { get; set; }

        [Group("Sound Notetracks")]
        public List<string> notetrackUnknownKeys { get; set; }

        [Group("Sound Notetracks")]
        public List<int> notetrackUnknown { get; set; }

        [Group("Sound Notetracks")]
        public List<string> notetrackUnknownValues { get; set; }


        // FX group, subgroup "Effects"
        [Group("FX")]
        public string viewFlashEffect { get; set; }

        [Group("FX")]
        public string worldFlashEffect { get; set; }

        [Group("FX")]
        public string viewBodyFlashEffect { get; set; }

        [Group("FX")]
        public string viewFlashADSEffect { get; set; }

        [Group("FX")]
        public string signatureViewFlashEffect { get; set; }

        [Group("FX")]
        public string signatureWorldFlashEffect { get; set; }

        [Group("FX")]
        public string viewMagEjectEffect { get; set; }

        [Group("FX")]
        public string viewShellEjectEffect { get; set; }

        [Group("FX")]
        public string worldShellEjectEffect { get; set; }

        [Group("FX")]
        public string viewLastShotEjectEffect { get; set; }

        [Group("FX")]
        public string worldLastShotEjectEffect { get; set; }


        [Group("Tags")]
        public List<string> hideTags { get; set; }


        [Group("Sounds")]
        public Sounds sounds { get; set; }


        [Group("Overlay")]
        public Overlay overlay { get; set; }


        [Group("Accuracy Graph")]
        public AccuracyGraph accuracy_graph { get; set; }


        [Group("State Timers")]
        public StateTimers stateTimers { get; set; }

        [Group("State Timers")]
        public StateTimers stateTimersAkimbo { get; set; }


        [Group("Position and Rotation", "Stand")]
        public List<float> standMove { get; set; }

        [Group("Position and Rotation", "Stand")]
        public List<float> standRot { get; set; }

        [Group("Position and Rotation", "Strafe")]
        public List<float> strafeMove { get; set; }

        [Group("Position and Rotation", "Strafe")]
        public List<float> strafeRot { get; set; }

        [Group("Position and Rotation", "Ducked")]
        public List<float> duckedOfs { get; set; }

        [Group("Position and Rotation", "Ducked")]
        public List<float> duckedMove { get; set; }

        [Group("Position and Rotation", "Ducked")]
        public List<float> duckedRot { get; set; }

        [Group("Position and Rotation", "Prone")]
        public List<float> proneOfs { get; set; }

        [Group("Position and Rotation", "Prone")]
        public List<float> proneMove { get; set; }

        [Group("Position and Rotation", "Prone")]
        public List<float> proneRot { get; set; }


        [Group("Misc")]
        public float posMoveRate { get; set; }

        [Group("Misc")]
        public float posProneMoveRate { get; set; }

        [Group("Misc")]
        public float standMoveMinSpeed { get; set; }

        [Group("Misc")]
        public float duckedMoveMinSpeed { get; set; }

        [Group("Misc")]
        public float proneMoveMinSpeed { get; set; }

        [Group("Misc")]
        public float posRotRate { get; set; }

        [Group("Misc")]
        public float posProneRotRate { get; set; }


        [Group("Icons")]
        public string hudIcon { get; set; }

        [Group("Icons")]
        public string pickupIcon { get; set; }

        [Group("Icons")]
        public string minimapIconFriendly { get; set; }

        [Group("Icons")]
        public string minimapIconEnemy { get; set; }

        [Group("Icons")]
        public string minimapIconNeutral { get; set; }

        [Group("Icons")]
        public string ammoCounterIcon { get; set; }


        [Group("Ammo")]
        public string szAmmoName { get; set; }

        [Group("Ammo")]
        public string szClipName { get; set; }

        [Group("Ammo")]
        public string szSharedAmmoCapName { get; set; }


        [Group("Weapon Stats")]
        public int clipSize { get; set; }

        [Group("Weapon Stats")]
        public int startAmmo { get; set; }

        [Group("Weapon Stats")]
        public int maxAmmo { get; set; }

        [Group("Weapon Stats")]
        public int minAmmoReq { get; set; }

        [Group("Weapon Stats")]
        public int damage { get; set; }

        [Group("Weapon Stats")]
        public int playerDamage { get; set; }

        [Group("Weapon Stats")]
        public int meleeDamage { get; set; }

        [Group("Weapon Stats")]
        public int fireType { get; set; }

        [Group("Weapon Stats")]
        public int weapType { get; set; }

        [Group("Weapon Stats")]
        public int weapClass { get; set; }

        [Group("Weapon Stats")]
        public int penetrateType { get; set; }

        [Group("Weapon Stats")]
        public float penetrateDepth { get; set; }

        [Group("Weapon Stats")]
        public int impactType { get; set; }


        [Group("Spread", "Min")]
        public float hipSpreadStandMin { get; set; }

        [Group("Spread", "Min")]
        public float hipSpreadDuckedMin { get; set; }

        [Group("Spread", "Min")]
        public float hipSpreadProneMin { get; set; }


        [Group("Spread", "Max")]
        public float hipSpreadStandMax { get; set; }

        [Group("Spread", "Max")]
        public float hipSpreadSprintMax { get; set; }

        [Group("Spread", "Max")]
        public float hipSpreadSlideMax { get; set; }

        [Group("Spread", "Max")]
        public float hipSpreadDuckedMax { get; set; }

        [Group("Spread", "Max")]
        public float hipSpreadProneMax { get; set; }


        [Group("Spread", "Decay")]
        public float hipSpreadDecayRate { get; set; }

        [Group("Spread", "Decay")]
        public float hipSpreadFireAdd { get; set; }

        [Group("Spread", "Decay")]
        public float hipSpreadTurnAdd { get; set; }

        [Group("Spread", "Decay")]
        public float hipSpreadMoveAdd { get; set; }

        [Group("Spread", "Decay")]
        public float hipSpreadDuckedDecay { get; set; }

        [Group("Spread", "Decay")]
        public float hipSpreadProneDecay { get; set; }


        [Group("Sway", "Base")]
        public float swayMaxAngleSteadyAim { get; set; }

        [Group("Sway", "Base")]
        public float swayMaxAngle { get; set; }

        [Group("Sway", "Base")]
        public float swayLerpSpeed { get; set; }

        [Group("Sway", "Base")]
        public float swayPitchScale { get; set; }

        [Group("Sway", "Base")]
        public float swayYawScale { get; set; }

        [Group("Sway", "Base")]
        public float swayVertScale { get; set; }

        [Group("Sway", "Base")]
        public float swayHorizScale { get; set; }

        [Group("Sway", "Base")]
        public float swayShellShockScale { get; set; }

        [Group("Sway", "ADS")]
        public float adsSwayMaxAngle { get; set; }

        [Group("Sway", "ADS")]
        public float adsSwayLerpSpeed { get; set; }

        [Group("Sway", "ADS")]
        public float adsSwayPitchScale { get; set; }

        [Group("Sway", "ADS")]
        public float adsSwayYawScale { get; set; }

        [Group("Sway", "ADS")]
        public float adsSwayHorizScale { get; set; }

        [Group("Sway", "ADS")]
        public float adsSwayVertScale { get; set; }


        // Continue adding all other fields with similar Group/SubGroup pattern...


        // Nested classes for complex properties:
        public class Sounds
        {
            [Group("Sounds", "Pickup")]
            public string pickupSound { get; set; }

            [Group("Sounds", "Pickup")]
            public string pickupSoundPlayer { get; set; }

            [Group("Sounds", "Pickup")]
            public string ammoPickupSound { get; set; }

            [Group("Sounds", "Pickup")]
            public string ammoPickupSoundPlayer { get; set; }

            [Group("Sounds", "Projectile")]
            public string projectileSound { get; set; }

            [Group("Sounds", "Pullback")]
            public string pullbackSound { get; set; }

            [Group("Sounds", "Pullback")]
            public string pullbackSoundPlayer { get; set; }

            [Group("Sounds", "Pullback")]
            public string pullbackSoundQuick { get; set; }

            [Group("Sounds", "Pullback")]
            public string pullbackSoundQuickPlayer { get; set; }

            [Group("Sounds", "Fire")]
            public string fireSound { get; set; }

            [Group("Sounds", "Fire")]
            public string fireSoundPlayer { get; set; }

            [Group("Sounds", "Fire")]
            public string fireSoundPlayerAkimbo { get; set; }

            [Group("Sounds", "Fire")]
            public string fireMedSound { get; set; }

            [Group("Sounds", "Fire")]
            public string fireMedSoundPlayer { get; set; }

            [Group("Sounds", "Fire")]
            public string fireHighSound { get; set; }

            [Group("Sounds", "Fire")]
            public string fireHighSoundPlayer { get; set; }

            [Group("Sounds", "FireLoop")]
            public string fireLoopSound { get; set; }

            [Group("Sounds", "FireLoop")]
            public string fireLoopSoundPlayer { get; set; }

            [Group("Sounds", "FireLoop")]
            public string fireMedLoopSound { get; set; }

            [Group("Sounds", "FireLoop")]
            public string fireMedLoopSoundPlayer { get; set; }

            [Group("Sounds", "FireLoop")]
            public string fireHighLoopSound { get; set; }

            [Group("Sounds", "FireLoop")]
            public string fireHighLoopSoundPlayer { get; set; }

            [Group("Sounds", "FireLoopEndPoint")]
            public string fireLoopEndPointSound { get; set; }

            [Group("Sounds", "FireLoopEndPoint")]
            public string fireLoopEndPointSoundPlayer { get; set; }

            [Group("Sounds", "FireStop")]
            public string fireStopSound { get; set; }

            [Group("Sounds", "FireStop")]
            public string fireStopSoundPlayer { get; set; }

            [Group("Sounds", "FireStop")]
            public string fireMedStopSound { get; set; }

            [Group("Sounds", "FireStop")]
            public string fireMedStopSoundPlayer { get; set; }

            [Group("Sounds", "FireStop")]
            public string fireHighStopSound { get; set; }

            [Group("Sounds", "FireStop")]
            public string fireHighStopSoundPlayer { get; set; }

            [Group("Sounds", "FireLast")]
            public string fireLastSound { get; set; }

            [Group("Sounds", "FireLast")]
            public string fireLastSoundPlayer { get; set; }

            [Group("Sounds", "FireFirst")]
            public string fireFirstSound { get; set; }

            [Group("Sounds", "FireFirst")]
            public string fireFirstSoundPlayer { get; set; }

            [Group("Sounds", "FireCustom")]
            public string fireCustomSound { get; set; }

            [Group("Sounds", "FireCustom")]
            public string fireCustomSoundPlayer { get; set; }

            [Group("Sounds", "EmptyFire")]
            public string emptyFireSound { get; set; }

            [Group("Sounds", "EmptyFire")]
            public string emptyFireSoundPlayer { get; set; }

            [Group("Sounds", "ADS")]
            public string adsRequiredFireSoundPlayer { get; set; }

            [Group("Sounds", "Melee")]
            public string meleeSwipeSound { get; set; }

            [Group("Sounds", "Melee")]
            public string meleeSwipeSoundPlayer { get; set; }

            [Group("Sounds", "Melee")]
            public string meleeHitSound { get; set; }

            [Group("Sounds", "Melee")]
            public string meleeHitSoundPlayer { get; set; }

            [Group("Sounds", "Melee")]
            public string meleeMissSound { get; set; }

            [Group("Sounds", "Melee")]
            public string meleeMissSoundPlayer { get; set; }

            [Group("Sounds", "Rechamber")]
            public string rechamberSound { get; set; }

            [Group("Sounds", "Rechamber")]
            public string rechamberSoundPlayer { get; set; }

            [Group("Sounds", "Reload")]
            public string reloadSound { get; set; }

            [Group("Sounds", "Reload")]
            public string reloadSoundPlayer { get; set; }

            [Group("Sounds", "Reload")]
            public string reloadEmptySound { get; set; }

            [Group("Sounds", "Reload")]
            public string reloadEmptySoundPlayer { get; set; }

            [Group("Sounds", "Reload")]
            public string reloadStartSound { get; set; }

            [Group("Sounds", "Reload")]
            public string reloadStartSoundPlayer { get; set; }

            [Group("Sounds", "Reload")]
            public string reloadEndSound { get; set; }

            [Group("Sounds", "Reload")]
            public string reloadEndSoundPlayer { get; set; }

            [Group("Sounds", "Detonate")]
            public string detonateSound { get; set; }

            [Group("Sounds", "Detonate")]
            public string detonateSoundPlayer { get; set; }

            [Group("Sounds", "NightVision")]
            public string nightVisionWearSound { get; set; }

            [Group("Sounds", "NightVision")]
            public string nightVisionWearSoundPlayer { get; set; }

            [Group("Sounds", "NightVision")]
            public string nightVisionRemoveSound { get; set; }

            [Group("Sounds", "NightVision")]
            public string nightVisionRemoveSoundPlayer { get; set; }

            [Group("Sounds", "Raise")]
            public string raiseSound { get; set; }

            [Group("Sounds", "Raise")]
            public string raiseSoundPlayer { get; set; }

            [Group("Sounds", "Raise")]
            public string firstRaiseSound { get; set; }

            [Group("Sounds", "Raise")]
            public string firstRaiseSoundPlayer { get; set; }

            [Group("Sounds", "AltSwitch")]
            public string altSwitchSound { get; set; }

            [Group("Sounds", "AltSwitch")]
            public string altSwitchSoundPlayer { get; set; }

            [Group("Sounds", "Putaway")]
            public string putawaySound { get; set; }

            [Group("Sounds", "Putaway")]
            public string putawaySoundPlayer { get; set; }

            [Group("Sounds", "Misc")]
            public string scanSound { get; set; }

            [Group("Sounds", "Misc")]
            public string changeVariableZoomSound { get; set; }

            [Group("Sounds", "ADS")]
            public string adsUpSound { get; set; }

            [Group("Sounds", "ADS")]
            public string adsDownSound { get; set; }

            [Group("Sounds", "ADS")]
            public string adsCrosshairEnemySound { get; set; }
        }

        public class Overlay
        {
            [Group("Overlay")]
            public string shader { get; set; }

            [Group("Overlay")]
            public string shaderLowRes { get; set; }

            [Group("Overlay")]
            public string shaderEMP { get; set; }

            [Group("Overlay")]
            public string shaderEMPLowRes { get; set; }

            [Group("Overlay")]
            public int reticle { get; set; }

            [Group("Overlay")]
            public float width { get; set; }

            [Group("Overlay")]
            public float height { get; set; }

            [Group("Overlay")]
            public float widthSplitscreen { get; set; }

            [Group("Overlay")]
            public float heightSplitscreen { get; set; }
        }

        public class AccuracyGraph
        {
            [Group("Accuracy Graph")]
            public List<string> accuracyGraphName { get; set; }
        }

        public class StateTimers
        {
            [Group("State Timers", "Fuse")]
            public int aiFuseTime { get; set; }
            public int fuseTime { get; set; }

            [Group("State Timers", "Raise/Drop")]
            public int altDropTime { get; set; }
            public int altRaiseTime { get; set; }
            public int dropTime { get; set; }
            public int raiseTime { get; set; }
            public int quickDropTime { get; set; }
            public int quickRaiseTime { get; set; }
            public int emptyDropTime { get; set; }
            public int emptyRaiseTime { get; set; }

            [Group("State Timers", "Fire")]
            public int fireTime { get; set; }
            public int fireDelay { get; set; }
            public int holdFireTime { get; set; }

            [Group("State Timers", "Melee")]
            public int meleeTime { get; set; }
            public int meleeDelay { get; set; }
            public int meleeChargeTime { get; set; }
            public int meleeChargeDelay { get; set; }

            [Group("State Timers", "NVG")]
            public int nightVisionRemoveTime { get; set; }
            public int nightVisionWearTime { get; set; }
            public int nightVisionRemoveTimeFadeInStart { get; set; }
            public int nightVisionWearTimeFadeOutEnd { get; set; }
            public int nightVisionRemoveTimePowerDown { get; set; }
            public int nightVisionWearTimePowerUp { get; set; }

            [Group("State Timers", "Reload")]
            public int reloadTime { get; set; }
            public int reloadAddTime { get; set; }
            public int reloadEndTime { get; set; }
            public int reloadStartTime { get; set; }
            public int reloadShowRocketTime { get; set; }

            [Group("State Timers", "Movement")]
            public int sprintInTime { get; set; }
            public int sprintLoopTime { get; set; }
            public int sprintOutTime { get; set; }
            public int slideInTime { get; set; }
            public int slideLoopTime { get; set; }
            public int slideOutTime { get; set; }

            [Group("State Timers", "Other")]
            public bool bHoldFullPrime { get; set; }
            public int breachRaiseTime { get; set; }
            public int dodgeTime { get; set; }
            public int landDipTime { get; set; }
            public int stunnedTimeBegin { get; set; }
            public int stunnedTimeEnd { get; set; }
            public int stunnedTimeLoop { get; set; }
            // Add more reorganized entries if desired...
        }

    }
}

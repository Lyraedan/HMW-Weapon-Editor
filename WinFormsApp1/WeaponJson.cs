using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public class WeaponJson
    {
        [Group("General")]
        public string szInternalName { get; set; }
        [Group("General")]
        public string szDisplayName { get; set; }
        [Group("General")]
        public string szAltWeaponName { get; set; }

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

        [Group("Animations")]
        public Dictionary<string, string> szXAnimsRightHanded { get; set; }
        [Group("Animations")]
        public Dictionary<string, string> szXAnimsLeftHanded { get; set; }
        [Group("Animations")]
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

        [Group("State Timers Akimbo")]
        public StateTimers stateTimersAkimbo { get; set; }

        [Group("Position and Rotation")]
        public List<float> standMove { get; set; }
        public List<float> standRot { get; set; }
        public List<float> strafeMove { get; set; }
        public List<float> strafeRot { get; set; }
        public List<float> duckedOfs { get; set; }
        public List<float> duckedMove { get; set; }
        public List<float> duckedRot { get; set; }
        public List<float> proneOfs { get; set; }
        public List<float> proneMove { get; set; }
        public List<float> proneRot { get; set; }

        [Group("Misc")]
        public float posMoveRate { get; set; }
        public float posProneMoveRate { get; set; }
        public float standMoveMinSpeed { get; set; }
        public float duckedMoveMinSpeed { get; set; }
        public float proneMoveMinSpeed { get; set; }
        public float posRotRate { get; set; }
        public float posProneRotRate { get; set; }

        [Group("Icons")]
        public string hudIcon { get; set; }
        public string pickupIcon { get; set; }
        public string minimapIconFriendly { get; set; }
        public string minimapIconEnemy { get; set; }
        public string minimapIconNeutral { get; set; }
        public string ammoCounterIcon { get; set; }

        [Group("Ammo")]
        public string szAmmoName { get; set; }
        public string szClipName { get; set; }
        public string szSharedAmmoCapName { get; set; }

        [Group("Weapon Stats")]
        public int clipSize { get; set; }
        public int startAmmo { get; set; }
        public int maxAmmo { get; set; }
        public int minAmmoReq { get; set; }
        public int damage { get; set; }
        public int playerDamage { get; set; }
        public int meleeDamage { get; set; }
        public int fireType { get; set; }
        public int weapType { get; set; }
        public int weapClass { get; set; }
        public int penetrateType { get; set; }
        public float penetrateDepth { get; set; }
        public int impactType { get; set; }

        [Group("Spread")]
        public float hipSpreadStandMin { get; set; }
        public float hipSpreadDuckedMin { get; set; }
        public float hipSpreadProneMin { get; set; }
        public float hipSpreadStandMax { get; set; }
        public float hipSpreadSprintMax { get; set; }
        public float hipSpreadSlideMax { get; set; }
        public float hipSpreadDuckedMax { get; set; }
        public float hipSpreadProneMax { get; set; }
        public float hipSpreadDecayRate { get; set; }
        public float hipSpreadFireAdd { get; set; }
        public float hipSpreadTurnAdd { get; set; }
        public float hipSpreadMoveAdd { get; set; }
        public float hipSpreadDuckedDecay { get; set; }
        public float hipSpreadProneDecay { get; set; }

        [Group("Sway")]
        public float swayMaxAngleSteadyAim { get; set; }
        public float swayMaxAngle { get; set; }
        public float swayLerpSpeed { get; set; }
        public float swayPitchScale { get; set; }
        public float swayYawScale { get; set; }
        public float swayVertScale { get; set; }
        public float swayHorizScale { get; set; }
        public float swayShellShockScale { get; set; }
        public float adsSwayMaxAngle { get; set; }
        public float adsSwayLerpSpeed { get; set; }
        public float adsSwayPitchScale { get; set; }
        public float adsSwayYawScale { get; set; }
        public float adsSwayHorizScale { get; set; }
        public float adsSwayVertScale { get; set; }

        // Add all other fields similarly, with correct types...

        // Nested classes for complex properties:
        public class Sounds
        {
            public string pickupSound { get; set; }
            public string pickupSoundPlayer { get; set; }
            public string ammoPickupSound { get; set; }
            public string ammoPickupSoundPlayer { get; set; }
            public string projectileSound { get; set; }
            public string pullbackSound { get; set; }
            public string pullbackSoundPlayer { get; set; }
            public string pullbackSoundQuick { get; set; }
            public string pullbackSoundQuickPlayer { get; set; }
            public string fireSound { get; set; }
            public string fireSoundPlayer { get; set; }
            public string fireSoundPlayerAkimbo { get; set; }
            public string fireMedSound { get; set; }
            public string fireMedSoundPlayer { get; set; }
            public string fireHighSound { get; set; }
            public string fireHighSoundPlayer { get; set; }
            public string fireLoopSound { get; set; }
            public string fireLoopSoundPlayer { get; set; }
            public string fireMedLoopSound { get; set; }
            public string fireMedLoopSoundPlayer { get; set; }
            public string fireHighLoopSound { get; set; }
            public string fireHighLoopSoundPlayer { get; set; }
            public string fireLoopEndPointSound { get; set; }
            public string fireLoopEndPointSoundPlayer { get; set; }
            public string fireStopSound { get; set; }
            public string fireStopSoundPlayer { get; set; }
            public string fireMedStopSound { get; set; }
            public string fireMedStopSoundPlayer { get; set; }
            public string fireHighStopSound { get; set; }
            public string fireHighStopSoundPlayer { get; set; }
            public string fireLastSound { get; set; }
            public string fireLastSoundPlayer { get; set; }
            public string fireFirstSound { get; set; }
            public string fireFirstSoundPlayer { get; set; }
            public string fireCustomSound { get; set; }
            public string fireCustomSoundPlayer { get; set; }
            public string emptyFireSound { get; set; }
            public string emptyFireSoundPlayer { get; set; }
            public string adsRequiredFireSoundPlayer { get; set; }
            public string meleeSwipeSound { get; set; }
            public string meleeSwipeSoundPlayer { get; set; }
            public string meleeHitSound { get; set; }
            public string meleeHitSoundPlayer { get; set; }
            public string meleeMissSound { get; set; }
            public string meleeMissSoundPlayer { get; set; }
            public string rechamberSound { get; set; }
            public string rechamberSoundPlayer { get; set; }
            public string reloadSound { get; set; }
            public string reloadSoundPlayer { get; set; }
            public string reloadEmptySound { get; set; }
            public string reloadEmptySoundPlayer { get; set; }
            public string reloadStartSound { get; set; }
            public string reloadStartSoundPlayer { get; set; }
            public string reloadEndSound { get; set; }
            public string reloadEndSoundPlayer { get; set; }
            public string detonateSound { get; set; }
            public string detonateSoundPlayer { get; set; }
            public string nightVisionWearSound { get; set; }
            public string nightVisionWearSoundPlayer { get; set; }
            public string nightVisionRemoveSound { get; set; }
            public string nightVisionRemoveSoundPlayer { get; set; }
            public string raiseSound { get; set; }
            public string raiseSoundPlayer { get; set; }
            public string firstRaiseSound { get; set; }
            public string firstRaiseSoundPlayer { get; set; }
            public string altSwitchSound { get; set; }
            public string altSwitchSoundPlayer { get; set; }
            public string putawaySound { get; set; }
            public string putawaySoundPlayer { get; set; }
            public string scanSound { get; set; }
            public string changeVariableZoomSound { get; set; }
            public string adsUpSound { get; set; }
            public string adsDownSound { get; set; }
            public string adsCrosshairEnemySound { get; set; }
        }

        public class Overlay
        {
            public string shader { get; set; }
            public string shaderLowRes { get; set; }
            public string shaderEMP { get; set; }
            public string shaderEMPLowRes { get; set; }
            public int reticle { get; set; }
            public float width { get; set; }
            public float height { get; set; }
            public float widthSplitscreen { get; set; }
            public float heightSplitscreen { get; set; }
        }

        public class AccuracyGraph
        {
            public List<string> accuracyGraphName { get; set; }
        }

        public class StateTimers
        {
            public int aiFuseTime { get; set; }
            public int altDropTime { get; set; }
            public int altRaiseTime { get; set; }
            public bool bHoldFullPrime { get; set; }
            public int blastBackTime { get; set; }
            public int blastLeftTime { get; set; }
            public int blastRightTime { get; set; }
            public int breachRaiseTime { get; set; }
            public int detonateDelay { get; set; }
            public int detonateTime { get; set; }
            public int dodgeTime { get; set; }
            public int dropTime { get; set; }
            public int emptyDropTime { get; set; }
            public int emptyRaiseTime { get; set; }
            public int fireDelay { get; set; }
            public int fireTime { get; set; }
            public int firstRaiseTime { get; set; }
            public int fuseTime { get; set; }
            public int grenadePrimeReadyToThrowTime { get; set; }
            public int heatCooldownInTime { get; set; }
            public int heatCooldownOutReadyTime { get; set; }
            public int heatCooldownOutTime { get; set; }
            public int highJumpDropInTime { get; set; }
            public int highJumpDropLandTime { get; set; }
            public int highJumpDropLoopTime { get; set; }
            public int highJumpInTime { get; set; }
            public int holdFireTime { get; set; }
            public int hybridSightInTime { get; set; }
            public int hybridSightOutTime { get; set; }
            public int landDipTime { get; set; }
            public int meleeChargeDelay { get; set; }
            public int meleeChargeTime { get; set; }
            public int meleeDelay { get; set; }
            public int meleeTime { get; set; }
            public int missileTime { get; set; }
            public int nightVisionRemoveTime { get; set; }
            public int nightVisionRemoveTimeFadeInStart { get; set; }
            public int nightVisionRemoveTimePowerDown { get; set; }
            public int nightVisionWearTime { get; set; }
            public int nightVisionWearTimeFadeOutEnd { get; set; }
            public int nightVisionWearTimePowerUp { get; set; }
            public int offhandSwitchTime { get; set; }
            public int overheatOutReadyTime { get; set; }
            public int overheatOutTime { get; set; }
            public int primeTime { get; set; }
            public int quickDropTime { get; set; }
            public int quickRaiseTime { get; set; }
            public int raiseTime { get; set; }
            public int rechamberBoltTime { get; set; }
            public int rechamberTime { get; set; }
            public int rechamberTimeOneHanded { get; set; }
            public int reloadAddTime { get; set; }
            public int reloadAddTimeDualWield { get; set; }
            public int reloadEmptyAddTime { get; set; }
            public int reloadEmptyAddTimeDualMag { get; set; }
            public int reloadEmptyDualMag { get; set; }
            public int reloadEmptyTime { get; set; }
            public int reloadEndTime { get; set; }
            public int reloadShowRocketTime { get; set; }
            public int reloadStartAddTime { get; set; }
            public int reloadStartTime { get; set; }
            public int reloadTime { get; set; }
            public int reloadTimeDualWield { get; set; }
            public int slideInTime { get; set; }
            public int slideLoopTime { get; set; }
            public int slideOutTime { get; set; }
            public int speedReloadAddTime { get; set; }
            public int speedReloadTime { get; set; }
            public int sprintInTime { get; set; }
            public int sprintLoopTime { get; set; }
            public int sprintOutTime { get; set; }
            public int stunnedTimeBegin { get; set; }
            public int stunnedTimeEnd { get; set; }
            public int stunnedTimeLoop { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public class WeaponJson
    {
        // General group, no subgroup
        [Group("General", "Base")]
        public string szInternalName { get; set; }

        [Group("General", "Base")]
        public string szDisplayName { get; set; }

        [Group("General", "Base")]
        public string szAltWeaponName { get; set; }


        // Models group
        [Group("Models")]
        public List<string> gunModel { get; set; }

        [Group("Models")]
        public List<string> worldModel { get; set; }

        [Group("Models")]
        public List<string> reticleViewModels { get; set; }

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
        public string viewBodyFlashADSEffect { get; set; }

        [Group("FX")]
        public string signatureViewFlashEffect { get; set; }

        [Group("FX")]
        public string signatureViewBodyFlashEffect { get; set; }

        [Group("FX")]
        public string signatureWorldFlashEffect { get; set; }

        [Group("FX")]
        public string signatureViewFlashADSEffect { get; set; }

        [Group("FX")]
        public string signatureViewBodyFlashADSEffect { get; set; }

        [Group("FX")]
        public string meleeHitEffect { get; set; }

        [Group("FX")]
        public string meleeMissEffect { get; set; }

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

        [Group("Physics")]
        public string physCollmap { get; set; }

        [Group("Physics")]
        public string physPreset { get; set; }

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
        public int hudIconRatio { get; set; }

        [Group("Icons")]
        public int pickupIconRatio { get; set; }

        [Group("Icons")]
        public int ammoCounterIconRatio { get; set; }

        [Group("Icons")]
        public int ammoCounterClip { get; set; }

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

        [Group("Ammo")]
        public int ammoDropStockMin { get; set; }

        [Group("Ammo")]
        public int ammoDropStockMax { get; set; }

        [Group("Ammo")]
        public int ammoDropClipPercentMin { get; set; }

        [Group("Ammo")]
        public int ammoDropClipPercentMax { get; set; }

        [Group("Weapon Stats")]
        public int clipSize { get; set; }

        [Group("Weapon Stats")]
        public int startAmmo { get; set; }

        [Group("Weapon Stats")]
        public int maxAmmo { get; set; }

        [Group("Weapon Stats")]
        public int minAmmoReq { get; set; }

        [Group("Weapon Stats")]
        public int shotCount { get; set; }

        [Group("Weapon Stats")]
        public int sharedAmmoCap { get; set; }

        [Group("Weapon Stats")]
        public int damage { get; set; }

        [Group("Weapon Stats")]
        public int playerDamage { get; set; }

        [Group("Weapon Stats")]
        public int meleeDamage { get; set; }

        [Group("Weapon Stats")]
        public int damageType { get; set; }

        [Group("Weapon Stats")]
        public float autoAimRange { get; set; }

        [Group("Weapon Stats")]
        public float aimAssistRangeAds { get; set; }

        [Group("Weapon Stats")]
        public float aimAssistRange { get; set; }

        [Group("Weapon Stats")]
        public float aimPadding { get; set; }

        [Group("Weapon Stats")]
        public float enemyCrosshairRange { get; set; }

        [Group("Weapon Stats")]
        public float moveSpeedScale { get; set; }

        [Group("Weapon Stats")]
        public float adsMoveSpeedScale { get; set; }

        [Group("Weapon Stats")]
        public float sprintDurationScale { get; set; }

        [Group("Weapon Stats")]
        public float adsZoomFov { get; set; }

        [Group("Weapon Stats")]
        public float adsZoomInFrac { get; set; }

        [Group("Weapon Stats")]
        public float adsZoomOutFrac { get; set; }

        [Group("Weapon Stats")]
        public float adsSceneBlurStrength { get; set; }

        [Group("Weapon Stats")]
        public float adsSceneBlurPhysicalScale { get; set; }

        [Group("Weapon Stats")]
        public float adsBobFactor { get; set; }

        [Group("Weapon Stats")]
        public float adsViewBobMult { get; set; }

        [Group("Weapon Stats")]
        public int fireType { get; set; }

        [Group("Weapon Stats")]
        public int fireBarrels { get; set; }

        [Group("Weapon Stats")]
        public int adsFireMode { get; set; }

        [Group("Weapon Stats")]
        public float burstFireCooldown { get; set; }

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

        [Group("Weapon Stats")]
        public int inventoryType { get; set; }

        [Group("Weapon Stats")]
        public int greebleType { get; set; }

        [Group("Weapon Stats")]
        public int autoReloadType { get; set; }

        [Group("Weapon Stats")]
        public int autoHolsterType { get; set; }

        [Group("Weapon Stats")]
        public int offhandClass { get; set; }

        [Group("Weapon Stats")]
        public int stance { get; set; }

        [Group("Weapon Stats")]
        public int reticleCenterSize { get; set; }

        [Group("Weapon Stats")]
        public int reticleSideSize { get; set; }

        [Group("Weapon Stats")]
        public int reticleMinOfs { get; set; }

        [Group("Weapon Stats")]
        public int activeReticleType { get; set; }

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
        [Group("Uncharacterized", "Base")]
        public string szScript { get; set; }

        [Group("Uncharacterized", "Base")]
        public string szAdsrBaseSetting { get; set; }

        [Group("Uncharacterized", "Base")]
        public string szUseHintString { get; set; }

        [Group("Uncharacterized", "Base")]
        public string dropHintString { get; set; }

        [Group("Uncharacterized", "World")]
        public string lobWorldModelName { get; set; }

        [Group("Uncharacterized", "Rumble")]
        public string fireRumble { get; set; }

        [Group("Uncharacterized", "Rumble")]
        public string fireMedRumble { get; set; }

        [Group("Uncharacterized", "Rumble")]
        public string fireHighRumble { get; set; }

        [Group("Uncharacterized", "Rumble")]
        public string meleeImpactRumble { get; set; }

        [Group("Uncharacterized", "Damage")]
        public List<float> locationDamageMultipliers { get; set; }

        [Group("Uncharacterized", "Sounds")]
        public string bounceSound { get; set; }

        [Group("Uncharacterized", "Sounds")]
        public string rollingSound { get; set; }

        [Group("Uncharacterized", "Ads")]
        public float adsViewErrorMin { get; set; }

        [Group("Uncharacterized", "Ads")]
        public float adsViewErrorMax { get; set; }

        [Group("Uncharacterized", "Ads")]
        public float adsFireAnimFrac { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float dualWieldViewModelOffset { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float scopeDriftDelay { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float scopeDriftLerpInTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float scopeDriftSteadyTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float scopeDriftLerpOutTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float scopeDriftSteadyFactor { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float scopeDriftUnsteadyFactor { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public int explosionRadius { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public int explosionRadiusMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public int explosionInnerDamage { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public int explosionOuterDamage { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float damageConeAngle { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float bulletExplDmgMult { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float bulletExplRadiusMult { get; set; }

        [Group("Uncharacterized", "Other")]
        public float bobVerticalFactor { get; set; }

        [Group("Uncharacterized", "Other")]
        public float bobHorizontalFactor { get; set; }

        [Group("Uncharacterized", "Other")]
        public float bobViewVerticalFactor { get; set; }

        [Group("Uncharacterized", "Other")]
        public float bobViewHorizontalFactor { get; set; }

        [Group("Uncharacterized", "Other")]
        public float stationaryZoomFov { get; set; }

        [Group("Uncharacterized", "Other")]
        public float stationaryZoomDelay { get; set; }

        [Group("Uncharacterized", "Other")]
        public float stationaryZoomLerpInTime { get; set; }

        [Group("Uncharacterized", "Other")]
        public float stationaryZoomLerpOutTime { get; set; }

        [Group("Uncharacterized", "Other")]
        public float adsDofStart { get; set; }

        [Group("Uncharacterized", "Other")]
        public float adsDofEnd { get; set; }

        [Group("Uncharacterized", "Other")]
        public string reticleCenter { get; set; }

        [Group("Uncharacterized", "Other")]
        public string reticleSide { get; set; }

        [Group("Uncharacterized", "Other")]
        public string tracerType { get; set; }

        [Group("Uncharacterized", "Other")]
        public string signatureTracerType { get; set; }

        [Group("Uncharacterized", "Other")]
        public string laserType { get; set; }

        [Group("Uncharacterized", "Other")]
        public string stowOffsetModel { get; set; }

        [Group("Uncharacterized", "Other")]
        public string killIcon { get; set; }

        [Group("Uncharacterized", "Other")]
        public int killIconRatio { get; set; }

        [Group("Uncharacterized", "Other")]
        public string dpadIcon { get; set; }

        [Group("Uncharacterized", "Other")]
        public int dpadIconRatio { get; set; }

        [Group("Uncharacterized", "Other")]
        public string hudProximityWarningIcon { get; set; }

        [Group("Uncharacterized", "Other")]
        public int fireAnimLength { get; set; }

        [Group("Uncharacterized", "Other")]
        public int fireAnimLengthAkimbo { get; set; }

        [Group("Uncharacterized", "Other")]
        public int inspectAnimTime { get; set; }

        [Group("Uncharacterized", "Other")]
        public int reloadAmmoAdd { get; set; }

        [Group("Uncharacterized", "Other")]
        public int reloadStartAdd { get; set; }

        [Group("Uncharacterized", "Other")]
        public string missileConeSoundAlias { get; set; }

        [Group("Uncharacterized", "Other")]
        public string missileConeSoundAliasAtBase { get; set; }

        [Group("Uncharacterized", "Other")]
        public string stowTag { get; set; }

        [Group("Uncharacterized", "Other")]
        public int altWeapon { get; set; }

        [Group("Uncharacterized", "Other")]
        public int playerAnimType { get; set; }

        [Group("Uncharacterized", "Other")]
        public float hipReticleSidePos { get; set; }

        [Group("Uncharacterized", "Other")]
        public float adsIdleAmount { get; set; }

        [Group("Uncharacterized", "Other")]
        public float adsIdleSpeed { get; set; }

        [Group("Uncharacterized", "Other")]
        public float hipIdleSpeed { get; set; }

        [Group("Uncharacterized", "Other")]
        public float idleCrouchFactor { get; set; }

        [Group("Uncharacterized", "Other")]
        public int stickiness { get; set; }

        [Group("Uncharacterized", "Other")]
        public float lowAmmoWarningThreshold { get; set; }

        [Group("Uncharacterized", "Other")]
        public float ricochetChance { get; set; }

        [Group("Uncharacterized", "Other")]
        public float riotShieldHealth { get; set; }

        [Group("Uncharacterized", "Other")]
        public float riotShieldDamageMult { get; set; }

        [Group("Uncharacterized", "Other")]
        public List<float> parallelBounce { get; set; }

        [Group("Uncharacterized", "Other")]
        public List<float> perpendicularBounce { get; set; }

        [Group("Uncharacterized", "Other")]
        public float idleProneFactor { get; set; }

        [Group("Uncharacterized", "Other")]
        public float fightDist { get; set; }

        [Group("Uncharacterized", "Other")]
        public float maxDist { get; set; }

        [Group("Uncharacterized", "Other")]
        public float leftArc { get; set; }

        [Group("Uncharacterized", "Other")]
        public float rightArc { get; set; }

        [Group("Uncharacterized", "Other")]
        public float topArc { get; set; }

        [Group("Uncharacterized", "Other")]
        public float bottomArc { get; set; }

        [Group("Uncharacterized", "Other")]
        public float accuracy { get; set; }

        [Group("Uncharacterized", "Other")]
        public float aiSpread { get; set; }

        [Group("Uncharacterized", "Other")]
        public float playerSpread { get; set; }

        [Group("Uncharacterized", "Other")]
        public List<float> minTurnSpeed { get; set; }

        [Group("Uncharacterized", "Other")]
        public List<float> maxTurnSpeed { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float gunMaxPitch { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float gunMaxYaw { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsIdleLerpStartTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsIdleLerpTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public int adsTransInTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public int adsTransInFromSprintTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public int adsTransOutTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsAimPitch { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsCrosshairInFrac { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsCrosshairOutFrac { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public int adsGunKickReducedKickBullets { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsGunKickReducedKickPercent { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsGunKickPitchMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsGunKickPitchMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsGunKickYawMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsGunKickYawMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsGunKickMagMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsGunKickAccel { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsGunKickSpeedMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsGunKickSpeedDecay { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsGunKickStaticDecay { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsViewKickPitchMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsViewKickPitchMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsViewKickYawMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsViewKickYawMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsViewKickMagMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsViewKickCenterSpeed { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsViewScatterMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsViewScatterMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float adsSpread { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public int hipGunKickReducedKickBullets { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipGunKickPitchMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipGunKickPitchMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipGunKickYawMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipGunKickYawMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipGunKickMagMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipGunKickAccel { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipGunKickSpeedMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipGunKickSpeedDecay { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipGunKickStaticDecay { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipViewKickPitchMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipViewKickPitchMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipViewKickYawMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipViewKickYawMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipViewKickMagMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipViewKickCenterSpeed { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipViewScatterMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float hipViewScatterMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public float viewKickScale { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public int positionReloadTransTime { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public string projectileName { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public string projectileModel { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public string projExplosionEffect { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public string projDudEffect { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public string projExplosionSound { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public string projDudSound { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public string projTrailEffect { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public string projBeaconEffect { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public string projIgnitionEffect { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public string projIgnitionSound { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public int projectileSpeed { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public int projectileSpeedUp { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public int projectileSpeedForward { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public int projectileActivateDist { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public float projLifetime { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public float timeToAccelerate { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public float projectileCurvature { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public int projExplosion { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public List<float> projectileColor { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public int guidedMissileType { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public float maxSteeringAccel { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public int projIgnitionDelay { get; set; }

        [Group("Uncharacterized", "Turret")]
        public string turrentOverheatSound { get; set; }

        [Group("Uncharacterized", "Turret")]
        public string turrentOverheatEffect { get; set; }

        [Group("Uncharacterized", "Turret")]
        public string turrentBarrelSpinRumble { get; set; }

        [Group("Uncharacterized", "Turret")]
        public string turrentBarrelSpinMaxSnd { get; set; }

        [Group("Uncharacterized", "Turret")]
        public List<string> turrentBarrelSpinUpSnd { get; set; }

        [Group("Uncharacterized", "Turret")]
        public List<string> turrentBarrelSpinDownSnd { get; set; }

        [Group("Uncharacterized", "View Jitter")]
        public float pitchConvergenceTime { get; set; }
        [Group("Uncharacterized", "View Jitter")]
        public float yawConvergenceTime { get; set; }
        [Group("Uncharacterized", "View Jitter")]
        public float suppressTime { get; set; }
        [Group("Uncharacterized", "View Jitter")]
        public float playerPositionDist { get; set; }
        [Group("Uncharacterized", "View Jitter")]
        public float horizViewJitter { get; set; }
        [Group("Uncharacterized", "View Jitter")]
        public float vertViewJitter { get; set; }
        [Group("Uncharacterized", "Scan")]
        public float scanSpeed { get; set; }
        [Group("Uncharacterized", "Scan")]
        public float scanAccel { get; set; }
        [Group("Uncharacterized", "Scan")]
        public int scanPauseTime { get; set; }
        [Group("Uncharacterized", "Damage")]
        public int minDamage { get; set; }
        [Group("Uncharacterized", "Damage")]
        public int midDamage { get; set; }
        [Group("Uncharacterized", "Damage")]
        public int minPlayerDamage { get; set; }
        [Group("Uncharacterized", "Damage")]
        public int midPlayerDamage { get; set; }
        [Group("Uncharacterized", "Damage")]
        public float maxDamageRange { get; set; }
        [Group("Uncharacterized", "Damage")]
        public float minDamageRange { get; set; }
        [Group("Uncharacterized", "Signature Damage")]
        public int signatureAmmoInClip { get; set; }
        [Group("Uncharacterized", "Signature Damage")]
        public int signatureDamage { get; set; }
        [Group("Uncharacterized", "Signature Damage")]
        public int signatureMidDamage { get; set; }
        [Group("Uncharacterized", "Signature Damage")]
        public int signatureMinDamage { get; set; }
        [Group("Uncharacterized", "Signature Damage")]
        public float signatureMaxDamageRange { get; set; }
        [Group("Uncharacterized", "Signature Damage")]
        public float signatureMinDamageRange { get; set; }
        [Group("Uncharacterized", "Destabilization")]
        public float destabilizationRateTime { get; set; }
        [Group("Uncharacterized", "Destabilization")]
        public float destabilizationCurvatureMax { get; set; }
        [Group("Uncharacterized", "Destabilization")]
        public int destabilizeDistance { get; set; }
        [Group("Uncharacterized", "Turret Zoom")]
        public float turretADSTime { get; set; }
        [Group("Uncharacterized", "Turret Zoom")]
        public float turretFov { get; set; }
        [Group("Uncharacterized", "Turret Zoom")]
        public float turretFovADS { get; set; }
        [Group("Uncharacterized", "Turret Zoom")]
        public float turretScopeZoomRate { get; set; }
        [Group("Uncharacterized", "Turret Zoom")]
        public float turretScopeZoomMin { get; set; }
        [Group("Uncharacterized", "Turret Zoom")]
        public float turretScopeZoomMax { get; set; }
        [Group("Uncharacterized", "Overheat")]
        public float overheatUpRate { get; set; }
        [Group("Uncharacterized", "Overheat")]
        public float overheatDownRate { get; set; }
        [Group("Uncharacterized", "Overheat")]
        public float overheatCooldownRate { get; set; }
        [Group("Uncharacterized", "Overheat")]
        public float overheatPenalty { get; set; }
        [Group("Uncharacterized", "Turret Barrel")]
        public float turretBarrelSpinSpeed { get; set; }
        [Group("Uncharacterized", "Turret Barrel")]
        public float turretBarrelSpinUpTime { get; set; }
        [Group("Uncharacterized", "Turret Barrel")]
        public float turretBarrelSpinDownTime { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundRadiusAtTop { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundRadiusAtBase { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundHeight { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundOriginOffset { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundVolumescaleAtCore { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundVolumescaleAtEdge { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundVolumescaleCoreSize { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundPitchAtTop { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundPitchAtBottom { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundPitchTopSize { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundPitchBottomSize { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundCrossfadeTopSize { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public float missileConeSoundCrossfadeBottomSize { get; set; }
        [Group("Uncharacterized", "Auto Melee")]
        public float aim_automelee_lerp { get; set; }
        [Group("Uncharacterized", "Auto Melee")]
        public float aim_automelee_range { get; set; }
        [Group("Uncharacterized", "Auto Melee")]
        public float aim_automelee_region_height { get; set; }
        [Group("Uncharacterized", "Auto Melee")]
        public float aim_automelee_region_width { get; set; }
        [Group("Uncharacterized", "Player Melee")]
        public float player_meleeHeight { get; set; }
        [Group("Uncharacterized", "Player Melee")]
        public float player_meleeRange { get; set; }
        [Group("Uncharacterized", "Player Melee")]
        public float player_meleeWidth { get; set; }
        [Group("Uncharacterized", "Fire Timing")]
        public float changedFireTime { get; set; }
        [Group("Uncharacterized", "Fire Timing")]
        public int changedFireTimeNumBullets { get; set; }
        [Group("Uncharacterized", "Fire Timing")]
        public int fireTimeInterpolationType { get; set; }
        [Group("Uncharacterized", "Ammo Generation")]
        public int generateAmmo { get; set; }
        [Group("Uncharacterized", "Ammo Generation")]
        public int ammoPerShot { get; set; }
        [Group("Uncharacterized", "Ammo Generation")]
        public int explodeCount { get; set; }
        [Group("Uncharacterized", "Ammo Generation")]
        public int batteryDischargeRate { get; set; }
        [Group("Uncharacterized", "Ammo Generation")]
        public int extendedBattery { get; set; }
        [Group("Uncharacterized", "Unknown Integers")]
        public int iU_079 { get; set; }
        [Group("Uncharacterized", "Unknown Integers")]
        public int iU_080 { get; set; }
        [Group("Uncharacterized", "Rattle and Crosshair")]
        public int rattleSoundType { get; set; }
        [Group("Uncharacterized", "Rattle and Crosshair")]
        public bool adsShouldShowCrosshair { get; set; }
        [Group("Uncharacterized", "Rattle and Crosshair")]
        public bool adsCrosshairShouldScale { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool turretADSEnabled { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool knifeAttachTagLeft { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool knifeAlwaysAttached { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool meleeOverrideValues { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool riotShieldEnableDamage { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool allowPrimaryWeaponPickup { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool sharedAmmo { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool lockonSupported { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool requireLockonToFire { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool isAirburstWeapon { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool bigExplosion { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool noAdsWhenMagEmpty { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool avoidDropCleanup { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool inheritsPerks { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool crosshairColorChange { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool rifleBullet { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool armorPiercing { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool boltAction { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool aimDownSight { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool canHoldBreath { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool meleeOnly { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool bU_085 { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool bU_086 { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool canVariableZoom { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool rechamberWhileAds { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool bulletExplosiveDamage { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool cookOffHold { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool useBattery { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool reticleSpin45 { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool clipOnly { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool noAmmoPickup { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool disableSwitchToWhenEmpty { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool suppressAmmoReserveDisplay { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool motionTracker { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool markableViewmodel { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool noDualWield { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool flipKillIcon { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool actionSlotShowAmmo { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool noPartialReload { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool segmentedReload { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool multipleReload { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool blocksProne { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool silenced { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool isRollingGrenade { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool projExplosionEffectForceNormalUp { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool projExplosionEffectInheritParentDirection { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool projImpactExplode { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool projTrajectoryEvents { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool projWhizByEnabled { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool stickToPlayers { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool stickToVehicles { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool stickToTurrets { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool thrownSideways { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool hasDetonatorEmptyThrow { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool hasDetonatorDoubleTap { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool disableFiring { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool timedDetonation { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool noCrumpleMissile { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool fuseLitAfterImpact { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool rotate { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool holdButtonToThrow { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool freezeMovementWhenFiring { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool thermalScope { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool thermalToggle { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool outlineEnemies { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool altModeSameWeapon { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool turretBarrelSpinEnabled { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool missileConeSoundEnabled { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool missileConeSoundPitchshiftEnabled { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool missileConeSoundCrossfadeEnabled { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool offhandHoldIsCancelable { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool doNotAllowAttachmentsToOverrideSpread { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool useFastReloadAnims { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool dualMagReloadSupported { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool reloadStopsAlt { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool useScopeDrift { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool alwaysShatterGlassOnImpact { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool oldWeapon { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool raiseToHold { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool notifyOnPlayerImpact { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool decreasingKick { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool counterSilencer { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool projSuppressedByEMP { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool projDisabledByEMP { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool autosimDisableVariableRate { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool projPlayTrailEffectForOwnerOnly { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool projPlayBeaconEffectForOwnerOnly { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool projKillTrailEffectOnDeath { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool projKillBeaconEffectOnDeath { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool reticleDetonateHide { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool cloaked { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool adsHideWeapon { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool adsHideHands { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool bU_108 { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool adsSceneBlur { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool usesSniperScope { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool hasTransientModels { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool bU_112 { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool bU_113 { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool bU_114 { get; set; }
        [Group("Uncharacterized", "Miscellaneous Flags")]
        public bool bU_115 { get; set; }
        [Group("Uncharacterized", "ADS DOF")]
        public float adsDofPhysicalFstop { get; set; }
        [Group("Uncharacterized", "ADS DOF")]
        public float adsDofPhysicalFocusDistance { get; set; }
        [Group("Uncharacterized", "AutoSim")]
        public float autosimSpeedScale { get; set; }
        [Group("Uncharacterized", "Reactive Motion")]
        public float reactiveMotionRadiusScale { get; set; }
        [Group("Uncharacterized", "Reactive Motion")]
        public float reactiveMotionFrequencyScale { get; set; }
        [Group("Uncharacterized", "Reactive Motion")]
        public float reactiveMotionAmplitudeScale { get; set; }
        [Group("Uncharacterized", "Reactive Motion")]
        public float reactiveMotionFalloff { get; set; }
        [Group("Uncharacterized", "Reactive Motion")]
        public float reactiveMotionLifetime { get; set; }
        [Group("Uncharacterized", "Unknown Float Array")]
        public List<float> fU_3604 { get; set; }

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

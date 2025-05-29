using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public class WeaponJson
    {
        [Group("General")]
        public object baseAsset { get; set; }

        [Group("General")]
        public object szinternalName { get; set; }

        [Group("General")]
        public object szDisplayName { get; set; }

        [Group("General")]
        public object szAltWeaponName { get; set; }


        // Models group
        [Group("Models")]
        public List<object> gunModel { get; set; }

        [Group("Models")]
        public List<object> worldModel { get; set; }

        [Group("Models")]
        public List<object> reticleViewModels { get; set; }

        [Group("Models")]
        public object handModel { get; set; }

        [Group("Models")]
        public object persistentArmXModel { get; set; }

        [Group("Models")]
        public object worldClipModel { get; set; }

        [Group("Models")]
        public object rocketModel { get; set; }

        [Group("Models")]
        public object knifeModel { get; set; }

        [Group("Models")]
        public object worldKnifeModel { get; set; }


        // Animations group, subgroup "RightHanded"
        [Group("Animations", "RightHanded")]
        public Dictionary<string, object> szXAnimsRightHanded { get; set; }

        // Animations group, subgroup "LeftHanded"
        [Group("Animations", "LeftHanded")]
        public Dictionary<string, object> szXAnimsLeftHanded { get; set; }

        // Animations group, subgroup "General"
        [Group("Animations", "General")]
        public Dictionary<string, object> szXAnims { get; set; }


        [Group("Attachments")]
        public List<object> attachments { get; set; }


        [Group("Sound Notetracks")]
        public List<object> notetrackSoundMapKeys { get; set; }

        [Group("Sound Notetracks")]
        public List<object> notetrackSoundMapValues { get; set; }

        [Group("Sound Notetracks")]
        public List<object> notetrackRumbleMapKeys { get; set; }

        [Group("Sound Notetracks")]
        public List<object> notetrackRumbleMapValues { get; set; }

        [Group("Sound Notetracks")]
        public List<object> notetrackFXMapKeys { get; set; }

        [Group("Sound Notetracks")]
        public List<object> notetrackFXMapValues { get; set; }

        [Group("Sound Notetracks")]
        public List<object> notetrackFXMapTagValues { get; set; }

        [Group("Sound Notetracks")]
        public List<object> notetrackUnknownKeys { get; set; }

        [Group("Sound Notetracks")]
        public List<object> notetrackUnknown { get; set; }

        [Group("Sound Notetracks")]
        public List<object> notetrackUnknownValues { get; set; }

        // FX group, subgroup "Effects"
        [Group("FX")]
        public object viewFlashEffect { get; set; }

        [Group("FX")]
        public object worldFlashEffect { get; set; }

        [Group("FX")]
        public object viewBodyFlashEffect { get; set; }

        [Group("FX")]
        public object viewFlashADSEffect { get; set; }

        [Group("FX")]
        public object viewBodyFlashADSEffect { get; set; }

        [Group("FX")]
        public object signatureViewFlashEffect { get; set; }

        [Group("FX")]
        public object signatureViewBodyFlashEffect { get; set; }

        [Group("FX")]
        public object signatureWorldFlashEffect { get; set; }

        [Group("FX")]
        public object signatureViewFlashADSEffect { get; set; }

        [Group("FX")]
        public object signatureViewBodyFlashADSEffect { get; set; }

        [Group("FX")]
        public object meleeHitEffect { get; set; }

        [Group("FX")]
        public object meleeMissEffect { get; set; }

        [Group("FX")]
        public object viewMagEjectEffect { get; set; }

        [Group("FX")]
        public object viewShellEjectEffect { get; set; }

        [Group("FX")]
        public object worldShellEjectEffect { get; set; }

        [Group("FX")]
        public object viewLastShotEjectEffect { get; set; }

        [Group("FX")]
        public object worldLastShotEjectEffect { get; set; }


        [Group("Tags")]
        public List<object> hideTags { get; set; }


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
        public object physCollmap { get; set; }

        [Group("Physics")]
        public object physPreset { get; set; }

        [Group("Position and Rotation", "Stand")]
        public List<object> standMove { get; set; }

        [Group("Position and Rotation", "Stand")]
        public List<object> standRot { get; set; }

        [Group("Position and Rotation", "Strafe")]
        public List<object> strafeMove { get; set; }

        [Group("Position and Rotation", "Strafe")]
        public List<object> strafeRot { get; set; }

        [Group("Position and Rotation", "Ducked")]
        public List<object> duckedOfs { get; set; }

        [Group("Position and Rotation", "Ducked")]
        public List<object> duckedMove { get; set; }

        [Group("Position and Rotation", "Ducked")]
        public List<object> duckedRot { get; set; }

        [Group("Position and Rotation", "Prone")]
        public List<object> proneOfs { get; set; }

        [Group("Position and Rotation", "Prone")]
        public List<object> proneMove { get; set; }

        [Group("Position and Rotation", "Prone")]
        public List<object> proneRot { get; set; }


        [Group("Misc")]
        public object posMoveRate { get; set; }

        [Group("Misc")]
        public object posProneMoveRate { get; set; }

        [Group("Misc")]
        public object standMoveMinSpeed { get; set; }

        [Group("Misc")]
        public object duckedMoveMinSpeed { get; set; }

        [Group("Misc")]
        public object proneMoveMinSpeed { get; set; }

        [Group("Misc")]
        public object posRotRate { get; set; }

        [Group("Misc")]
        public object posProneRotRate { get; set; }


        [Group("Icons")]
        public object hudIcon { get; set; }

        [Group("Icons")]
        public object hudIconRatio { get; set; }

        [Group("Icons")]
        public object pickupIconRatio { get; set; }

        [Group("Icons")]
        public object ammoCounterIconRatio { get; set; }

        [Group("Icons")]
        public object ammoCounterClip { get; set; }

        [Group("Icons")]
        public object pickupIcon { get; set; }


        [Group("Icons")]
        public object minimapIconFriendly { get; set; }

        [Group("Icons")]
        public object minimapIconEnemy { get; set; }

        [Group("Icons")]
        public object minimapIconNeutral { get; set; }

        [Group("Icons")]
        public object ammoCounterIcon { get; set; }


        [Group("Ammo")]
        public object szAmmoName { get; set; }

        [Group("Ammo")]
        public object szClipName { get; set; }

        [Group("Ammo")]
        public object szSharedAmmoCapName { get; set; }

        [Group("Ammo")]
        public object ammoDropStockMin { get; set; }

        [Group("Ammo")]
        public object ammoDropStockMax { get; set; }

        [Group("Ammo")]
        public object ammoDropClipPercentMin { get; set; }

        [Group("Ammo")]
        public object ammoDropClipPercentMax { get; set; }

        [Group("Weapon Stats")]
        public object clipSize { get; set; }

        [Group("Weapon Stats")]
        public object startAmmo { get; set; }

        [Group("Weapon Stats")]
        public object maxAmmo { get; set; }

        [Group("Weapon Stats")]
        public object minAmmoReq { get; set; }

        [Group("Weapon Stats")]
        public object shotCount { get; set; }

        [Group("Weapon Stats")]
        public object sharedAmmoCap { get; set; }

        [Group("Weapon Stats")]
        public object damage { get; set; }

        [Group("Weapon Stats")]
        public object playerDamage { get; set; }

        [Group("Weapon Stats")]
        public object meleeDamage { get; set; }

        [Group("Weapon Stats")]
        public object damageType { get; set; }

        [Group("Weapon Stats")]
        public object autoAimRange { get; set; }

        [Group("Weapon Stats")]
        public object aimAssistRangeAds { get; set; }

        [Group("Weapon Stats")]
        public object aimAssistRange { get; set; }

        [Group("Weapon Stats")]
        public object aimPadding { get; set; }

        [Group("Weapon Stats")]
        public object enemyCrosshairRange { get; set; }

        [Group("Weapon Stats")]
        public object moveSpeedScale { get; set; }

        [Group("Weapon Stats")]
        public object adsMoveSpeedScale { get; set; }

        [Group("Weapon Stats")]
        public object sprobjectDurationScale { get; set; }

        [Group("Weapon Stats")]
        public object adsZoomFov { get; set; }

        [Group("Weapon Stats")]
        public object adsZoomInFrac { get; set; }

        [Group("Weapon Stats")]
        public object adsZoomOutFrac { get; set; }

        [Group("Weapon Stats")]
        public object adsSceneBlurStrength { get; set; }

        [Group("Weapon Stats")]
        public object adsSceneBlurPhysicalScale { get; set; }

        [Group("Weapon Stats")]
        public object adsBobFactor { get; set; }

        [Group("Weapon Stats")]
        public object adsViewBobMult { get; set; }

        [Group("Weapon Stats")]
        public object fireType { get; set; }

        [Group("Weapon Stats")]
        public object fireBarrels { get; set; }

        [Group("Weapon Stats")]
        public object adsFireMode { get; set; }

        [Group("Weapon Stats")]
        public object burstFireCooldown { get; set; }

        [Group("Weapon Stats")]
        public object weapType { get; set; }

        [Group("Weapon Stats")]
        public object weapClass { get; set; }

        [Group("Weapon Stats")]
        public object penetrateType { get; set; }

        [Group("Weapon Stats")]
        public object penetrateDepth { get; set; }

        [Group("Weapon Stats")]
        public object impactType { get; set; }

        [Group("Weapon Stats")]
        public object inventoryType { get; set; }

        [Group("Weapon Stats")]
        public object greebleType { get; set; }

        [Group("Weapon Stats")]
        public object autoReloadType { get; set; }

        [Group("Weapon Stats")]
        public object autoHolsterType { get; set; }

        [Group("Weapon Stats")]
        public object offhandClass { get; set; }

        [Group("Weapon Stats")]
        public object stance { get; set; }

        [Group("Weapon Stats")]
        public object reticleCenterSize { get; set; }

        [Group("Weapon Stats")]
        public object reticleSideSize { get; set; }

        [Group("Weapon Stats")]
        public object reticleMinOfs { get; set; }

        [Group("Weapon Stats")]
        public object activeReticleType { get; set; }

        [Group("Spread", "Min")]
        public object hipSpreadStandMin { get; set; }

        [Group("Spread", "Min")]
        public object hipSpreadDuckedMin { get; set; }

        [Group("Spread", "Min")]
        public object hipSpreadProneMin { get; set; }

        [Group("Spread", "Max")]
        public object hipSpreadStandMax { get; set; }

        [Group("Spread", "Max")]
        public object hipSpreadSprobjectMax { get; set; }

        [Group("Spread", "Max")]
        public object hipSpreadSlideMax { get; set; }

        [Group("Spread", "Max")]
        public object hipSpreadDuckedMax { get; set; }

        [Group("Spread", "Max")]
        public object hipSpreadProneMax { get; set; }


        [Group("Spread", "Decay")]
        public object hipSpreadDecayRate { get; set; }

        [Group("Spread", "Decay")]
        public object hipSpreadFireAdd { get; set; }

        [Group("Spread", "Decay")]
        public object hipSpreadTurnAdd { get; set; }

        [Group("Spread", "Decay")]
        public object hipSpreadMoveAdd { get; set; }

        [Group("Spread", "Decay")]
        public object hipSpreadDuckedDecay { get; set; }

        [Group("Spread", "Decay")]
        public object hipSpreadProneDecay { get; set; }

        [Group("Sway", "Base")]
        public object swayMaxAngleSteadyAim { get; set; }

        [Group("Sway", "Base")]
        public object swayMaxAngle { get; set; }

        [Group("Sway", "Base")]
        public object swayLerpSpeed { get; set; }

        [Group("Sway", "Base")]
        public object swayPitchScale { get; set; }

        [Group("Sway", "Base")]
        public object swayYawScale { get; set; }

        [Group("Sway", "Base")]
        public object swayVertScale { get; set; }

        [Group("Sway", "Base")]
        public object swayHorizScale { get; set; }

        [Group("Sway", "Base")]
        public object swayShellShockScale { get; set; }

        [Group("Sway", "ADS")]
        public object adsSwayMaxAngle { get; set; }

        [Group("Sway", "ADS")]
        public object adsSwayLerpSpeed { get; set; }

        [Group("Sway", "ADS")]
        public object adsSwayPitchScale { get; set; }

        [Group("Sway", "ADS")]
        public object adsSwayYawScale { get; set; }

        [Group("Sway", "ADS")]
        public object adsSwayHorizScale { get; set; }

        [Group("Sway", "ADS")]
        public object adsSwayVertScale { get; set; }

        // Continue adding all other fields with similar Group/SubGroup pattern...
        [Group("Uncharacterized", "Base")]
        public object szScript { get; set; }

        [Group("Uncharacterized", "Base")]
        public object szAdsrBaseSetting { get; set; }

        [Group("Uncharacterized", "Base")]
        public object szUseHobjectobject { get; set; }

        [Group("Uncharacterized", "Base")]
        public object dropHobjectobject { get; set; }

        [Group("Uncharacterized", "World")]
        public object lobWorldModelName { get; set; }

        [Group("Uncharacterized", "Rumble")]
        public object fireRumble { get; set; }

        [Group("Uncharacterized", "Rumble")]
        public object fireMedRumble { get; set; }

        [Group("Uncharacterized", "Rumble")]
        public object fireHighRumble { get; set; }

        [Group("Uncharacterized", "Rumble")]
        public object meleeImpactRumble { get; set; }

        [Group("Uncharacterized", "Damage")]
        public List<object> locationDamageMultipliers { get; set; }

        [Group("Uncharacterized", "Sounds")]
        public object bounceSound { get; set; }

        [Group("Uncharacterized", "Sounds")]
        public object rollingSound { get; set; }

        [Group("Uncharacterized", "Ads")]
        public object adsViewErrorMin { get; set; }

        [Group("Uncharacterized", "Ads")]
        public object adsViewErrorMax { get; set; }

        [Group("Uncharacterized", "Ads")]
        public object adsFireAnimFrac { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object dualWieldViewModelOffset { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object scopeDriftDelay { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object scopeDriftLerpobjectime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object scopeDriftSteadyTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object scopeDriftLerpOutTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object scopeDriftSteadyFactor { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object scopeDriftUnsteadyFactor { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object explosionRadius { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object explosionRadiusMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object explosionInnerDamage { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object explosionOuterDamage { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object damageConeAngle { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object bulletExplDmgMult { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object bulletExplRadiusMult { get; set; }

        [Group("Uncharacterized", "Other")]
        public object bobVerticalFactor { get; set; }

        [Group("Uncharacterized", "Other")]
        public object bobHorizontalFactor { get; set; }

        [Group("Uncharacterized", "Other")]
        public object bobViewVerticalFactor { get; set; }

        [Group("Uncharacterized", "Other")]
        public object bobViewHorizontalFactor { get; set; }

        [Group("Uncharacterized", "Other")]
        public object stationaryZoomFov { get; set; }

        [Group("Uncharacterized", "Other")]
        public object stationaryZoomDelay { get; set; }

        [Group("Uncharacterized", "Other")]
        public object stationaryZoomLerpobjectime { get; set; }

        [Group("Uncharacterized", "Other")]
        public object stationaryZoomLerpOutTime { get; set; }

        [Group("Uncharacterized", "Other")]
        public object adsDofStart { get; set; }

        [Group("Uncharacterized", "Other")]
        public object adsDofEnd { get; set; }

        [Group("Uncharacterized", "Other")]
        public object reticleCenter { get; set; }

        [Group("Uncharacterized", "Other")]
        public object reticleSide { get; set; }

        [Group("Uncharacterized", "Other")]
        public object tracerType { get; set; }

        [Group("Uncharacterized", "Other")]
        public object signatureTracerType { get; set; }

        [Group("Uncharacterized", "Other")]
        public object laserType { get; set; }

        [Group("Uncharacterized", "Other")]
        public object stowOffsetModel { get; set; }

        [Group("Uncharacterized", "Other")]
        public object killIcon { get; set; }

        [Group("Uncharacterized", "Other")]
        public object killIconRatio { get; set; }

        [Group("Uncharacterized", "Other")]
        public object dpadIcon { get; set; }

        [Group("Uncharacterized", "Other")]
        public object dpadIconRatio { get; set; }

        [Group("Uncharacterized", "Other")]
        public object hudProximityWarningIcon { get; set; }

        [Group("Uncharacterized", "Other")]
        public object fireAnimLength { get; set; }

        [Group("Uncharacterized", "Other")]
        public object fireAnimLengthAkimbo { get; set; }

        [Group("Uncharacterized", "Other")]
        public object inspectAnimTime { get; set; }

        [Group("Uncharacterized", "Other")]
        public object reloadAmmoAdd { get; set; }

        [Group("Uncharacterized", "Other")]
        public object reloadStartAdd { get; set; }

        [Group("Uncharacterized", "Other")]
        public object missileConeSoundAlias { get; set; }

        [Group("Uncharacterized", "Other")]
        public object missileConeSoundAliasAtBase { get; set; }

        [Group("Uncharacterized", "Other")]
        public object stowTag { get; set; }

        [Group("Uncharacterized", "Other")]
        public object altWeapon { get; set; }

        [Group("Uncharacterized", "Other")]
        public object playerAnimType { get; set; }

        [Group("Uncharacterized", "Other")]
        public object hipReticleSidePos { get; set; }

        [Group("Uncharacterized", "Other")]
        public object adsIdleAmount { get; set; }

        [Group("Uncharacterized", "Other")]
        public object adsIdleSpeed { get; set; }

        [Group("Uncharacterized", "Other")]
        public object hipIdleSpeed { get; set; }

        [Group("Uncharacterized", "Other")]
        public object idleCrouchFactor { get; set; }

        [Group("Uncharacterized", "Other")]
        public object stickiness { get; set; }

        [Group("Uncharacterized", "Other")]
        public object lowAmmoWarningThreshold { get; set; }

        [Group("Uncharacterized", "Other")]
        public object ricochetChance { get; set; }

        [Group("Uncharacterized", "Other")]
        public object riotShieldHealth { get; set; }

        [Group("Uncharacterized", "Other")]
        public object riotShieldDamageMult { get; set; }

        [Group("Uncharacterized", "Other")]
        public List<object> parallelBounce { get; set; }

        [Group("Uncharacterized", "Other")]
        public List<object> perpendicularBounce { get; set; }

        [Group("Uncharacterized", "Other")]
        public object idleProneFactor { get; set; }

        [Group("Uncharacterized", "Other")]
        public object fightDist { get; set; }

        [Group("Uncharacterized", "Other")]
        public object maxDist { get; set; }

        [Group("Uncharacterized", "Other")]
        public object leftArc { get; set; }

        [Group("Uncharacterized", "Other")]
        public object rightArc { get; set; }

        [Group("Uncharacterized", "Other")]
        public object topArc { get; set; }

        [Group("Uncharacterized", "Other")]
        public object bottomArc { get; set; }

        [Group("Uncharacterized", "Other")]
        public object accuracy { get; set; }

        [Group("Uncharacterized", "Other")]
        public object aiSpread { get; set; }

        [Group("Uncharacterized", "Other")]
        public object playerSpread { get; set; }

        [Group("Uncharacterized", "Other")]
        public List<object> mobjecturnSpeed { get; set; }

        [Group("Uncharacterized", "Other")]
        public List<object> maxTurnSpeed { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object gunMaxPitch { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object gunMaxYaw { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsIdleLerpStartTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsIdleLerpTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsTransobjectime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsTransInFromSprobjectTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsTransOutTime { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsAimPitch { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsCrosshairInFrac { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsCrosshairOutFrac { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsGunKickReducedKickBullets { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsGunKickReducedKickPercent { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsGunKickPitchMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsGunKickPitchMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsGunKickYawMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsGunKickYawMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsGunKickMagMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsGunKickAccel { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsGunKickSpeedMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsGunKickSpeedDecay { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsGunKickStaticDecay { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsViewKickPitchMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsViewKickPitchMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsViewKickYawMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsViewKickYawMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsViewKickMagMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsViewKickCenterSpeed { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsViewScatterMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsViewScatterMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object adsSpread { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipGunKickReducedKickBullets { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipGunKickPitchMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipGunKickPitchMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipGunKickYawMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipGunKickYawMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipGunKickMagMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipGunKickAccel { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipGunKickSpeedMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipGunKickSpeedDecay { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipGunKickStaticDecay { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipViewKickPitchMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipViewKickPitchMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipViewKickYawMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipViewKickYawMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipViewKickMagMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipViewKickCenterSpeed { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipViewScatterMin { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object hipViewScatterMax { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object viewKickScale { get; set; }

        [Group("Uncharacterized", "Weapon")]
        public object positionReloadTransTime { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projectileName { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projectileModel { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projExplosionEffect { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projDudEffect { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projExplosionSound { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projDudSound { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projTrailEffect { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projBeaconEffect { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projIgnitionEffect { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projIgnitionSound { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projectileSpeed { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projectileSpeedUp { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projectileSpeedForward { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projectileActivateDist { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projLifetime { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object timeToAccelerate { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projectileCurvature { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projExplosion { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public List<object> projectileColor { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object guidedMissileType { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object maxSteeringAccel { get; set; }

        [Group("Uncharacterized", "Projectile")]
        public object projIgnitionDelay { get; set; }

        [Group("Uncharacterized", "Turret")]
        public object turrentOverheatSound { get; set; }

        [Group("Uncharacterized", "Turret")]
        public object turrentOverheatEffect { get; set; }

        [Group("Uncharacterized", "Turret")]
        public object turrentBarrelSpinRumble { get; set; }

        [Group("Uncharacterized", "Turret")]
        public object turrentBarrelSpinMaxSnd { get; set; }

        [Group("Uncharacterized", "Turret")]
        public List<object> turrentBarrelSpinUpSnd { get; set; }

        [Group("Uncharacterized", "Turret")]
        public List<object> turrentBarrelSpinDownSnd { get; set; }

        [Group("Uncharacterized", "View Jitter")]
        public object pitchConvergenceTime { get; set; }
        [Group("Uncharacterized", "View Jitter")]
        public object yawConvergenceTime { get; set; }
        [Group("Uncharacterized", "View Jitter")]
        public object suppressTime { get; set; }
        [Group("Uncharacterized", "View Jitter")]
        public object playerPositionDist { get; set; }
        [Group("Uncharacterized", "View Jitter")]
        public object horizViewJitter { get; set; }
        [Group("Uncharacterized", "View Jitter")]
        public object vertViewJitter { get; set; }
        [Group("Uncharacterized", "Scan")]
        public object scanSpeed { get; set; }
        [Group("Uncharacterized", "Scan")]
        public object scanAccel { get; set; }
        [Group("Uncharacterized", "Scan")]
        public object scanPauseTime { get; set; }
        [Group("Uncharacterized", "Damage")]
        public object minDamage { get; set; }
        [Group("Uncharacterized", "Damage")]
        public object midDamage { get; set; }
        [Group("Uncharacterized", "Damage")]
        public object minPlayerDamage { get; set; }
        [Group("Uncharacterized", "Damage")]
        public object midPlayerDamage { get; set; }
        [Group("Uncharacterized", "Damage")]
        public object maxDamageRange { get; set; }
        [Group("Uncharacterized", "Damage")]
        public object minDamageRange { get; set; }
        [Group("Uncharacterized", "Signature Damage")]
        public object signatureAmmoInClip { get; set; }
        [Group("Uncharacterized", "Signature Damage")]
        public object signatureDamage { get; set; }
        [Group("Uncharacterized", "Signature Damage")]
        public object signatureMidDamage { get; set; }
        [Group("Uncharacterized", "Signature Damage")]
        public object signatureMinDamage { get; set; }
        [Group("Uncharacterized", "Signature Damage")]
        public object signatureMaxDamageRange { get; set; }
        [Group("Uncharacterized", "Signature Damage")]
        public object signatureMinDamageRange { get; set; }
        [Group("Uncharacterized", "Destabilization")]
        public object destabilizationRateTime { get; set; }
        [Group("Uncharacterized", "Destabilization")]
        public object destabilizationCurvatureMax { get; set; }
        [Group("Uncharacterized", "Destabilization")]
        public object destabilizeDistance { get; set; }
        [Group("Uncharacterized", "Turret Zoom")]
        public object turretADSTime { get; set; }
        [Group("Uncharacterized", "Turret Zoom")]
        public object turretFov { get; set; }
        [Group("Uncharacterized", "Turret Zoom")]
        public object turretFovADS { get; set; }
        [Group("Uncharacterized", "Turret Zoom")]
        public object turretScopeZoomRate { get; set; }
        [Group("Uncharacterized", "Turret Zoom")]
        public object turretScopeZoomMin { get; set; }
        [Group("Uncharacterized", "Turret Zoom")]
        public object turretScopeZoomMax { get; set; }
        [Group("Uncharacterized", "Overheat")]
        public object overheatUpRate { get; set; }
        [Group("Uncharacterized", "Overheat")]
        public object overheatDownRate { get; set; }
        [Group("Uncharacterized", "Overheat")]
        public object overheatCooldownRate { get; set; }
        [Group("Uncharacterized", "Overheat")]
        public object overheatPenalty { get; set; }
        [Group("Uncharacterized", "Turret Barrel")]
        public object turretBarrelSpinSpeed { get; set; }
        [Group("Uncharacterized", "Turret Barrel")]
        public object turretBarrelSpinUpTime { get; set; }
        [Group("Uncharacterized", "Turret Barrel")]
        public object turretBarrelSpinDownTime { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundRadiusAtTop { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundRadiusAtBase { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundHeight { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundOriginOffset { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundVolumescaleAtCore { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundVolumescaleAtEdge { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundVolumescaleCoreSize { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundPitchAtTop { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundPitchAtBottom { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundPitchTopSize { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundPitchBottomSize { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundCrossfadeTopSize { get; set; }
        [Group("Uncharacterized", "Missile Cone Sound")]
        public object missileConeSoundCrossfadeBottomSize { get; set; }
        [Group("Uncharacterized", "Auto Melee")]
        public object aim_automelee_lerp { get; set; }
        [Group("Uncharacterized", "Auto Melee")]
        public object aim_automelee_range { get; set; }
        [Group("Uncharacterized", "Auto Melee")]
        public object aim_automelee_region_height { get; set; }
        [Group("Uncharacterized", "Auto Melee")]
        public object aim_automelee_region_width { get; set; }
        [Group("Uncharacterized", "Player Melee")]
        public object player_meleeHeight { get; set; }
        [Group("Uncharacterized", "Player Melee")]
        public object player_meleeRange { get; set; }
        [Group("Uncharacterized", "Player Melee")]
        public object player_meleeWidth { get; set; }
        [Group("Uncharacterized", "Fire Timing")]
        public object changedFireTime { get; set; }
        [Group("Uncharacterized", "Fire Timing")]
        public object changedFireTimeNumBullets { get; set; }
        [Group("Uncharacterized", "Fire Timing")]
        public object fireTimeobjecterpolationType { get; set; }
        [Group("Uncharacterized", "Ammo Generation")]
        public object generateAmmo { get; set; }
        [Group("Uncharacterized", "Ammo Generation")]
        public object ammoPerShot { get; set; }
        [Group("Uncharacterized", "Ammo Generation")]
        public object explodeCount { get; set; }
        [Group("Uncharacterized", "Ammo Generation")]
        public object batteryDischargeRate { get; set; }
        [Group("Uncharacterized", "Ammo Generation")]
        public object extendedBattery { get; set; }
        [Group("Uncharacterized", "Unknown objectegers")]
        public object iU_079 { get; set; }
        [Group("Uncharacterized", "Unknown objectegers")]
        public object iU_080 { get; set; }
        [Group("Uncharacterized", "Rattle and Crosshair")]
        public object rattleSoundType { get; set; }
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
        public object adsSceneBlur { get; set; }
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
        public object adsDofPhysicalFstop { get; set; }
        [Group("Uncharacterized", "ADS DOF")]
        public object adsDofPhysicalFocusDistance { get; set; }
        [Group("Uncharacterized", "AutoSim")]
        public object autosimSpeedScale { get; set; }
        [Group("Uncharacterized", "Reactive Motion")]
        public object reactiveMotionRadiusScale { get; set; }
        [Group("Uncharacterized", "Reactive Motion")]
        public object reactiveMotionFrequencyScale { get; set; }
        [Group("Uncharacterized", "Reactive Motion")]
        public object reactiveMotionAmplitudeScale { get; set; }
        [Group("Uncharacterized", "Reactive Motion")]
        public object reactiveMotionFalloff { get; set; }
        [Group("Uncharacterized", "Reactive Motion")]
        public object reactiveMotionLifetime { get; set; }
        [Group("Uncharacterized", "Unknown object Array")]
        public List<object> fU_3604 { get; set; }

        // Nested classes for complex properties:
        public class Sounds
        {
            [Group("Sounds", "Pickup")]
            public object pickupSound { get; set; }

            [Group("Sounds", "Pickup")]
            public object pickupSoundPlayer { get; set; }

            [Group("Sounds", "Pickup")]
            public object ammoPickupSound { get; set; }

            [Group("Sounds", "Pickup")]
            public object ammoPickupSoundPlayer { get; set; }

            [Group("Sounds", "Projectile")]
            public object projectileSound { get; set; }

            [Group("Sounds", "Pullback")]
            public object pullbackSound { get; set; }

            [Group("Sounds", "Pullback")]
            public object pullbackSoundPlayer { get; set; }

            [Group("Sounds", "Pullback")]
            public object pullbackSoundQuick { get; set; }

            [Group("Sounds", "Pullback")]
            public object pullbackSoundQuickPlayer { get; set; }

            [Group("Sounds", "Fire")]
            public object fireSound { get; set; }

            [Group("Sounds", "Fire")]
            public object fireSoundPlayer { get; set; }

            [Group("Sounds", "Fire")]
            public object fireSoundPlayerAkimbo { get; set; }

            [Group("Sounds", "Fire")]
            public object fireMedSound { get; set; }

            [Group("Sounds", "Fire")]
            public object fireMedSoundPlayer { get; set; }

            [Group("Sounds", "Fire")]
            public object fireHighSound { get; set; }

            [Group("Sounds", "Fire")]
            public object fireHighSoundPlayer { get; set; }

            [Group("Sounds", "FireLoop")]
            public object fireLoopSound { get; set; }

            [Group("Sounds", "FireLoop")]
            public object fireLoopSoundPlayer { get; set; }

            [Group("Sounds", "FireLoop")]
            public object fireMedLoopSound { get; set; }

            [Group("Sounds", "FireLoop")]
            public object fireMedLoopSoundPlayer { get; set; }

            [Group("Sounds", "FireLoop")]
            public object fireHighLoopSound { get; set; }

            [Group("Sounds", "FireLoop")]
            public object fireHighLoopSoundPlayer { get; set; }

            [Group("Sounds", "FireLoopEndPoobject")]
            public object fireLoopEndPoobjectSound { get; set; }

            [Group("Sounds", "FireLoopEndPoobject")]
            public object fireLoopEndPoobjectSoundPlayer { get; set; }

            [Group("Sounds", "FireStop")]
            public object fireStopSound { get; set; }

            [Group("Sounds", "FireStop")]
            public object fireStopSoundPlayer { get; set; }

            [Group("Sounds", "FireStop")]
            public object fireMedStopSound { get; set; }

            [Group("Sounds", "FireStop")]
            public object fireMedStopSoundPlayer { get; set; }

            [Group("Sounds", "FireStop")]
            public object fireHighStopSound { get; set; }

            [Group("Sounds", "FireStop")]
            public object fireHighStopSoundPlayer { get; set; }

            [Group("Sounds", "FireLast")]
            public object fireLastSound { get; set; }

            [Group("Sounds", "FireLast")]
            public object fireLastSoundPlayer { get; set; }

            [Group("Sounds", "FireFirst")]
            public object fireFirstSound { get; set; }

            [Group("Sounds", "FireFirst")]
            public object fireFirstSoundPlayer { get; set; }

            [Group("Sounds", "FireCustom")]
            public object fireCustomSound { get; set; }

            [Group("Sounds", "FireCustom")]
            public object fireCustomSoundPlayer { get; set; }

            [Group("Sounds", "EmptyFire")]
            public object emptyFireSound { get; set; }

            [Group("Sounds", "EmptyFire")]
            public object emptyFireSoundPlayer { get; set; }

            [Group("Sounds", "ADS")]
            public object adsRequiredFireSoundPlayer { get; set; }

            [Group("Sounds", "Melee")]
            public object meleeSwipeSound { get; set; }

            [Group("Sounds", "Melee")]
            public object meleeSwipeSoundPlayer { get; set; }

            [Group("Sounds", "Melee")]
            public object meleeHitSound { get; set; }

            [Group("Sounds", "Melee")]
            public object meleeHitSoundPlayer { get; set; }

            [Group("Sounds", "Melee")]
            public object meleeMissSound { get; set; }

            [Group("Sounds", "Melee")]
            public object meleeMissSoundPlayer { get; set; }

            [Group("Sounds", "Rechamber")]
            public object rechamberSound { get; set; }

            [Group("Sounds", "Rechamber")]
            public object rechamberSoundPlayer { get; set; }

            [Group("Sounds", "Reload")]
            public object reloadSound { get; set; }

            [Group("Sounds", "Reload")]
            public object reloadSoundPlayer { get; set; }

            [Group("Sounds", "Reload")]
            public object reloadEmptySound { get; set; }

            [Group("Sounds", "Reload")]
            public object reloadEmptySoundPlayer { get; set; }

            [Group("Sounds", "Reload")]
            public object reloadStartSound { get; set; }

            [Group("Sounds", "Reload")]
            public object reloadStartSoundPlayer { get; set; }

            [Group("Sounds", "Reload")]
            public object reloadEndSound { get; set; }

            [Group("Sounds", "Reload")]
            public object reloadEndSoundPlayer { get; set; }

            [Group("Sounds", "Detonate")]
            public object detonateSound { get; set; }

            [Group("Sounds", "Detonate")]
            public object detonateSoundPlayer { get; set; }

            [Group("Sounds", "NightVision")]
            public object nightVisionWearSound { get; set; }

            [Group("Sounds", "NightVision")]
            public object nightVisionWearSoundPlayer { get; set; }

            [Group("Sounds", "NightVision")]
            public object nightVisionRemoveSound { get; set; }

            [Group("Sounds", "NightVision")]
            public object nightVisionRemoveSoundPlayer { get; set; }

            [Group("Sounds", "Raise")]
            public object raiseSound { get; set; }

            [Group("Sounds", "Raise")]
            public object raiseSoundPlayer { get; set; }

            [Group("Sounds", "Raise")]
            public object firstRaiseSound { get; set; }

            [Group("Sounds", "Raise")]
            public object firstRaiseSoundPlayer { get; set; }

            [Group("Sounds", "AltSwitch")]
            public object altSwitchSound { get; set; }

            [Group("Sounds", "AltSwitch")]
            public object altSwitchSoundPlayer { get; set; }

            [Group("Sounds", "Putaway")]
            public object putawaySound { get; set; }

            [Group("Sounds", "Putaway")]
            public object putawaySoundPlayer { get; set; }

            [Group("Sounds", "Misc")]
            public object scanSound { get; set; }

            [Group("Sounds", "Misc")]
            public object changeVariableZoomSound { get; set; }

            [Group("Sounds", "ADS")]
            public object adsUpSound { get; set; }

            [Group("Sounds", "ADS")]
            public object adsDownSound { get; set; }

            [Group("Sounds", "ADS")]
            public object adsCrosshairEnemySound { get; set; }
        }

        public class Overlay
        {
            [Group("Overlay")]
            public object shader { get; set; }

            [Group("Overlay")]
            public object shaderLowRes { get; set; }

            [Group("Overlay")]
            public object shaderEMP { get; set; }

            [Group("Overlay")]
            public object shaderEMPLowRes { get; set; }

            [Group("Overlay")]
            public object reticle { get; set; }

            [Group("Overlay")]
            public object width { get; set; }

            [Group("Overlay")]
            public object height { get; set; }

            [Group("Overlay")]
            public object widthSplitscreen { get; set; }

            [Group("Overlay")]
            public object heightSplitscreen { get; set; }
        }

        public class AccuracyGraph
        {
            [Group("Accuracy Graph")]
            public List<object> accuracyGraphName { get; set; }
        }

        public class StateTimers
        {
            [Group("State Timers", "Fuse")]
            public object aiFuseTime { get; set; }
            public object fuseTime { get; set; }

            [Group("State Timers", "Raise/Drop")]
            public object altDropTime { get; set; }
            public object altRaiseTime { get; set; }
            public object dropTime { get; set; }
            public object raiseTime { get; set; }
            public object quickDropTime { get; set; }
            public object quickRaiseTime { get; set; }
            public object emptyDropTime { get; set; }
            public object emptyRaiseTime { get; set; }

            [Group("State Timers", "Fire")]
            public object fireTime { get; set; }
            public object fireDelay { get; set; }
            public object holdFireTime { get; set; }

            [Group("State Timers", "Melee")]
            public object meleeTime { get; set; }
            public object meleeDelay { get; set; }
            public object meleeChargeTime { get; set; }
            public object meleeChargeDelay { get; set; }

            [Group("State Timers", "NVG")]
            public object nightVisionRemoveTime { get; set; }
            public object nightVisionWearTime { get; set; }
            public object nightVisionRemoveTimeFadeInStart { get; set; }
            public object nightVisionWearTimeFadeOutEnd { get; set; }
            public object nightVisionRemoveTimePowerDown { get; set; }
            public object nightVisionWearTimePowerUp { get; set; }

            [Group("State Timers", "Reload")]
            public object reloadTime { get; set; }
            public object reloadAddTime { get; set; }
            public object reloadEndTime { get; set; }
            public object reloadStartTime { get; set; }
            public object reloadShowRocketTime { get; set; }

            [Group("State Timers", "Movement")]
            public object sprobjectobjectime { get; set; }
            public object sprobjectLoopTime { get; set; }
            public object sprobjectOutTime { get; set; }
            public object slideobjectime { get; set; }
            public object slideLoopTime { get; set; }
            public object slideOutTime { get; set; }

            [Group("State Timers", "Other")]
            public bool bHoldFullPrime { get; set; }
            public object breachRaiseTime { get; set; }
            public object dodgeTime { get; set; }
            public object landDipTime { get; set; }
            public object stunnedTimeBegin { get; set; }
            public object stunnedTimeEnd { get; set; }
            public object stunnedTimeLoop { get; set; }
            // Add more reorganized entries if desired...
        }

    }
}

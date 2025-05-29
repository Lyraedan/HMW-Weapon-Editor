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

        [Group("Animations")]
        public Dictionary<string, object> szXAnimsRightHanded { get; set; }

        [Group("Animations")]
        public Dictionary<string, object> szXAnimsLeftHanded { get; set; }

        [Group("Animations")]
        public Dictionary<string, object> szXAnims { get; set; }

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

        [Group("Models")]
        public string worldKnifeModel { get; set; }

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

        // Additional properties can be grouped similarly...
    }
}

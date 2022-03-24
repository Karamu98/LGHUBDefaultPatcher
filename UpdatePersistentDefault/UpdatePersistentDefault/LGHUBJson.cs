using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LGHUB
{
    public partial class LGHUBData
    {
        [JsonProperty("/devices/g502_hero/persistent_data")]
        public DevicesG502HeroPersistentData DevicesG502HeroPersistentData { get; set; }

        [JsonProperty("analytics")]
        public Analytics Analytics { get; set; }

        [JsonProperty("applications")]
        public Applications Applications { get; set; }

        [JsonProperty("arx_control_authentication")]
        public ArxControlAuthentication ArxControlAuthentication { get; set; }

        [JsonProperty("arx_control_service_guid")]
        public string ArxControlServiceGuid { get; set; }

        [JsonProperty("autostart")]
        public bool Autostart { get; set; }

        [JsonProperty("blue_voice_advanced_controls_enabled")]
        public bool BlueVoiceAdvancedControlsEnabled { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("cards")]
        public Cards Cards { get; set; }

        [JsonProperty("crash_reporting")]
        public CrashReporting CrashReporting { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("devices/known")]
        public DevicesKnown DevicesKnown { get; set; }

        [JsonProperty("installed_integrations")]
        public string[] InstalledIntegrations { get; set; }

        [JsonProperty("integration_manager_settings")]
        public IntegrationManagerSettings IntegrationManagerSettings { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("lighting_effects/20a6c607-38bd-4b6d-b72c-280c04320825")]
        public LightingEffects20A6C60738Bd4B6DB72C280C04320825 LightingEffects20A6C60738Bd4B6DB72C280C04320825 { get; set; }

        [JsonProperty("lighting_prefabs")]
        public LightingPrefabs LightingPrefabs { get; set; }

        [JsonProperty("lighting_sleep")]
        public bool LightingSleep { get; set; }

        [JsonProperty("lock_notifications_enabled")]
        public bool LockNotificationsEnabled { get; set; }

        [JsonProperty("low_battery_notifications_enabled")]
        public bool LowBatteryNotificationsEnabled { get; set; }

        [JsonProperty("migration_shown")]
        public bool MigrationShown { get; set; }

        [JsonProperty("mouse_buttons_swapped")]
        public bool MouseButtonsSwapped { get; set; }

        [JsonProperty("non_interactive_prompted")]
        public object[] NonInteractivePrompted { get; set; }

        [JsonProperty("notifications_enabled")]
        public bool NotificationsEnabled { get; set; }

        [JsonProperty("onboarding_shown")]
        public bool OnboardingShown { get; set; }

        [JsonProperty("persistent")]
        public ArxControlAuthentication Persistent { get; set; }

        [JsonProperty("persistent_features")]
        public PersistentFeatures PersistentFeatures { get; set; }

        [JsonProperty("profiles")]
        public Profiles Profiles { get; set; }

        [JsonProperty("release_notes_build_id")]
        public long ReleaseNotesBuildId { get; set; }

        [JsonProperty("seen_coach_marks")]
        public string[] SeenCoachMarks { get; set; }

        [JsonProperty("settings_transferred")]
        public bool SettingsTransferred { get; set; }
    }

    public partial class Analytics
    {
        [JsonProperty("hostId")]
        public string HostId { get; set; }

        [JsonProperty("pendingUserPrompt")]
        public ArxControlAuthentication PendingUserPrompt { get; set; }

        [JsonProperty("versionNumber")]
        public string VersionNumber { get; set; }
    }

    public partial class ArxControlAuthentication
    {
    }

    public partial class Applications
    {
        [JsonProperty("applications")]
        public Application[] ApplicationsApplications { get; set; }
    }

    public partial class Application
    {
        [JsonProperty("applicationFolder", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationFolder { get; set; }

        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }

        [JsonProperty("applicationPath", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationPath { get; set; }

        [JsonProperty("categoryColors", NullValueHandling = NullValueHandling.Ignore)]
        public CategoryColor[] CategoryColors { get; set; }

        [JsonProperty("commands", NullValueHandling = NullValueHandling.Ignore)]
        public Command[] Commands { get; set; }

        [JsonProperty("databaseId", NullValueHandling = NullValueHandling.Ignore)]
        public string? DatabaseId { get; set; }

        [JsonProperty("isInstalled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsInstalled { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("posterUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri PosterUrl { get; set; }

        [JsonProperty("profileUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ProfileUrl { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public long? Version { get; set; }

        [JsonProperty("lastRunTime", NullValueHandling = NullValueHandling.Ignore)]
        public string LastRunTime { get; set; }

        [JsonProperty("isCustom", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsCustom { get; set; }

        [JsonProperty("posterPath", NullValueHandling = NullValueHandling.Ignore)]
        public string PosterPath { get; set; }
    }

    public partial class CategoryColor
    {
        [JsonProperty("hex")]
        public string Hex { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }

    public partial class Command
    {
        [JsonProperty("cardId")]
        public string CardId { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Cards
    {
        [JsonProperty("cards")]
        public Card[] CardsCards { get; set; }
    }

    public partial class Card
    {
        [JsonProperty("attribute")]
        public string Attribute { get; set; }

        [JsonProperty("equalizer", NullValueHandling = NullValueHandling.Ignore)]
        public Equalizer Equalizer { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("readOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReadOnly { get; set; }

        [JsonProperty("applicationId", NullValueHandling = NullValueHandling.Ignore)]
        public string? ApplicationId { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        [JsonProperty("macro", NullValueHandling = NullValueHandling.Ignore)]
        public Macro Macro { get; set; }

        [JsonProperty("profileId", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProfileId { get; set; }

        [JsonProperty("firmwareLightingSettings", NullValueHandling = NullValueHandling.Ignore)]
        public FirmwareLightingSettings FirmwareLightingSettings { get; set; }

        [JsonProperty("proEqualizer", NullValueHandling = NullValueHandling.Ignore)]
        public ProEqualizer ProEqualizer { get; set; }

        [JsonProperty("videoSettings", NullValueHandling = NullValueHandling.Ignore)]
        public VideoSettings VideoSettings { get; set; }

        [JsonProperty("cameraSettings", NullValueHandling = NullValueHandling.Ignore)]
        public CameraSettings CameraSettings { get; set; }

        [JsonProperty("syncLightingSettings", NullValueHandling = NullValueHandling.Ignore)]
        public SyncLightingSettings SyncLightingSettings { get; set; }

        [JsonProperty("mouseSettings", NullValueHandling = NullValueHandling.Ignore)]
        public MouseSettings MouseSettings { get; set; }
    }

    public partial class CameraSettings
    {
        [JsonProperty("audioMode")]
        public string AudioMode { get; set; }

        [JsonProperty("exposure")]
        public Exposure Exposure { get; set; }

        [JsonProperty("focus")]
        public Exposure Focus { get; set; }

        [JsonProperty("fov")]
        public long Fov { get; set; }

        [JsonProperty("hdr")]
        public bool Hdr { get; set; }

        [JsonProperty("iris")]
        public Iris Iris { get; set; }

        [JsonProperty("pan")]
        public Iris Pan { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("roll")]
        public Iris Roll { get; set; }

        [JsonProperty("tilt")]
        public Iris Tilt { get; set; }

        [JsonProperty("zoom")]
        public Exposure Zoom { get; set; }
    }

    public partial class Exposure
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; set; }
    }

    public partial class Iris
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }
    }

    public partial class Equalizer
    {
        [JsonProperty("advanced")]
        public double[] Advanced { get; set; }

        [JsonProperty("deviceType")]
        public string DeviceType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("simple")]
        public long[] Simple { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class FirmwareLightingSettings
    {
        [JsonProperty("effects")]
        public Effect[] Effects { get; set; }
    }

    public partial class Effect
    {
        [JsonProperty("fixedParams", NullValueHandling = NullValueHandling.Ignore)]
        public FixedParams FixedParams { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("zoneType")]
        public string ZoneType { get; set; }

        [JsonProperty("cycleParams", NullValueHandling = NullValueHandling.Ignore)]
        public CycleParams CycleParams { get; set; }
    }

    public partial class CycleParams
    {
        [JsonProperty("intensity")]
        public long Intensity { get; set; }

        [JsonProperty("periodInMs")]
        public long PeriodInMs { get; set; }
    }

    public partial class FixedParams
    {
        [JsonProperty("color")]
        public Color Color { get; set; }
    }

    public partial class Color
    {
        [JsonProperty("rgba")]
        public Rgba Rgba { get; set; }
    }

    public partial class Rgba
    {
        [JsonProperty("alpha")]
        public long Alpha { get; set; }

        [JsonProperty("blue")]
        public long Blue { get; set; }

        [JsonProperty("green")]
        public double Green { get; set; }
    }

    public partial class Macro
    {
        [JsonProperty("actionName", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionName { get; set; }

        [JsonProperty("keystroke", NullValueHandling = NullValueHandling.Ignore)]
        public Keystroke Keystroke { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("action", NullValueHandling = NullValueHandling.Ignore)]
        public Action Action { get; set; }

        [JsonProperty("onboardable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Onboardable { get; set; }

        [JsonProperty("sequence", NullValueHandling = NullValueHandling.Ignore)]
        public Sequence Sequence { get; set; }
    }

    public partial class Action
    {
        [JsonProperty("actionId")]
        public string ActionId { get; set; }

        [JsonProperty("erroneousParameters", NullValueHandling = NullValueHandling.Ignore)]
        public ErroneousParameters ErroneousParameters { get; set; }

        [JsonProperty("integrationId")]
        public string IntegrationId { get; set; }

        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public Parameters Parameters { get; set; }
    }

    public partial class ErroneousParameters
    {
        [JsonProperty("app_selection")]
        public string AppSelection { get; set; }
    }

    public partial class Parameters
    {
        [JsonProperty("app_selection")]
        public string AppSelection { get; set; }

        [JsonProperty("command_selection")]
        public string CommandSelection { get; set; }
    }

    public partial class Keystroke
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public long? Code { get; set; }

        [JsonProperty("modifiers", NullValueHandling = NullValueHandling.Ignore)]
        public long[] Modifiers { get; set; }
    }

    public partial class Sequence
    {
        [JsonProperty("defaultDelay")]
        public long DefaultDelay { get; set; }

        [JsonProperty("heldSequence")]
        public ArxControlAuthentication HeldSequence { get; set; }

        [JsonProperty("pressSequence")]
        public ArxControlAuthentication PressSequence { get; set; }

        [JsonProperty("releaseSequence")]
        public ArxControlAuthentication ReleaseSequence { get; set; }

        [JsonProperty("simpleSequence")]
        public SimpleSequence SimpleSequence { get; set; }

        [JsonProperty("toggleSequence")]
        public ArxControlAuthentication ToggleSequence { get; set; }

        [JsonProperty("useDefaultDelay")]
        public bool UseDefaultDelay { get; set; }

        [JsonProperty("useSimpleActions")]
        public bool UseSimpleActions { get; set; }
    }

    public partial class SimpleSequence
    {
        [JsonProperty("components")]
        public Component[] Components { get; set; }
    }

    public partial class Component
    {
        [JsonProperty("keyboard", NullValueHandling = NullValueHandling.Ignore)]
        public Keyboard Keyboard { get; set; }

        [JsonProperty("delay", NullValueHandling = NullValueHandling.Ignore)]
        public Delay Delay { get; set; }
    }

    public partial class Delay
    {
        [JsonProperty("durationMs")]
        public long DurationMs { get; set; }
    }

    public partial class Keyboard
    {
        [JsonProperty("displayName")]
        public long DisplayName { get; set; }

        [JsonProperty("hidUsage")]
        public long HidUsage { get; set; }

        [JsonProperty("isDown", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsDown { get; set; }
    }

    public partial class MouseSettings
    {
        [JsonProperty("dpiTable")]
        public DpiTable DpiTable { get; set; }

        [JsonProperty("reportRate")]
        public ReportRate ReportRate { get; set; }
    }

    public partial class DpiTable
    {
        [JsonProperty("activeDpi")]
        public long ActiveDpi { get; set; }

        [JsonProperty("defaultDpi")]
        public long DefaultDpi { get; set; }

        [JsonProperty("levels")]
        public long[] Levels { get; set; }

        [JsonProperty("shiftDpi")]
        public long ShiftDpi { get; set; }
    }

    public partial class ReportRate
    {
        [JsonProperty("value")]
        public long Value { get; set; }
    }

    public partial class ProEqualizer
    {
        [JsonProperty("bands")]
        public long[] Bands { get; set; }

        [JsonProperty("deviceType", NullValueHandling = NullValueHandling.Ignore)]
        public string? DeviceType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
        public string Tag { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class SyncLightingSettings
    {
        [JsonProperty("devices")]
        public Devices Devices { get; set; }

        [JsonProperty("effects")]
        public Effect[] Effects { get; set; }
    }

    public partial class Devices
    {
        [JsonProperty("g502hero")]
        public string G502Hero { get; set; }

        [JsonProperty("g513")]
        public string G513 { get; set; }
    }

    public partial class VideoSettings
    {
        [JsonProperty("antiFlicker")]
        public long AntiFlicker { get; set; }

        [JsonProperty("brightness")]
        public Exposure Brightness { get; set; }

        [JsonProperty("color")]
        public Iris Color { get; set; }

        [JsonProperty("contrast")]
        public Exposure Contrast { get; set; }

        [JsonProperty("gain")]
        public Exposure Gain { get; set; }

        [JsonProperty("gamma")]
        public Iris Gamma { get; set; }

        [JsonProperty("hue")]
        public Exposure Hue { get; set; }

        [JsonProperty("saturation")]
        public Exposure Saturation { get; set; }

        [JsonProperty("sharpness")]
        public Exposure Sharpness { get; set; }

        [JsonProperty("whiteBalance")]
        public Exposure WhiteBalance { get; set; }
    }

    public partial class CrashReporting
    {
        [JsonProperty("userPrompted")]
        public bool UserPrompted { get; set; }

        [JsonProperty("versionNumber")]
        public string VersionNumber { get; set; }
    }

    public partial class DevicesG502HeroPersistentData
    {
        [JsonProperty("onboardMode")]
        public ArxControlAuthentication OnboardMode { get; set; }
    }

    public partial class DevicesKnown
    {
        [JsonProperty("knownList")]
        public KnownList[] KnownList { get; set; }
    }

    public partial class KnownList
    {
        [JsonProperty("modelId")]
        public string ModelId { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("serialNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string SerialNumber { get; set; }
    }

    public partial class IntegrationManagerSettings
    {
        [JsonProperty("allowLedSdk")]
        public bool AllowLedSdk { get; set; }
    }

    public partial class LightingEffects20A6C60738Bd4B6DB72C280C04320825
    {
        [JsonProperty("deviceSupport")]
        public string[] DeviceSupport { get; set; }

        [JsonProperty("fixedInfo")]
        public FixedInfo FixedInfo { get; set; }
    }

    public partial class FixedInfo
    {
        [JsonProperty("lightingSlots")]
        public LightingSlots LightingSlots { get; set; }
    }

    public partial class LightingSlots
    {
        [JsonProperty("infoMap")]
        public InfoMap InfoMap { get; set; }
    }

    public partial class InfoMap
    {
        [JsonProperty("PERKEY_INDICATOR")]
        public Perkey PerkeyIndicator { get; set; }

        [JsonProperty("PERKEY_KEYBOARD")]
        public Perkey PerkeyKeyboard { get; set; }
    }

    public partial class Perkey
    {
        [JsonProperty("perKeyMap")]
        public PerKeyMap PerKeyMap { get; set; }
    }

    public partial class PerKeyMap
    {
        [JsonProperty("colorCodeMap")]
        public Dictionary<string, ColorCodeMap> ColorCodeMap { get; set; }
    }

    public partial class ColorCodeMap
    {
        [JsonProperty("hex")]
        public string Hex { get; set; }
    }

    public partial class LightingPrefabs
    {
        [JsonProperty("list")]
        public List[] List { get; set; }
    }

    public partial class List
    {
        [JsonProperty("deviceSupport")]
        public string[] DeviceSupport { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class PersistentFeatures
    {
        [JsonProperty("assignments")]
        public Assignment[] Assignments { get; set; }

        [JsonProperty("features")]
        public Feature[] Features { get; set; }
    }

    public partial class Assignment
    {
        [JsonProperty("cardId")]
        public string CardId { get; set; }

        [JsonProperty("slotId")]
        public string SlotId { get; set; }
    }

    public partial class Feature
    {
        [JsonProperty("configuringSlots")]
        public string[] ConfiguringSlots { get; set; }

        [JsonProperty("devicePrefix")]
        public string DevicePrefix { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Profiles
    {
        [JsonProperty("profiles")]
        public Profile[] ProfilesProfiles { get; set; }
    }

    public partial class Profile
    {
        [JsonProperty("activeForApplication", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ActiveForApplication { get; set; }

        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }

        [JsonProperty("assignments")]
        public Assignment[] Assignments { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("publishing", NullValueHandling = NullValueHandling.Ignore)]
        public Publishing Publishing { get; set; }

        [JsonProperty("syncLightingCard", NullValueHandling = NullValueHandling.Ignore)]
        public string? SyncLightingCard { get; set; }
    }

    public partial class Publishing
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("deviceModelIds", NullValueHandling = NullValueHandling.Ignore)]
        public string[] DeviceModelIds { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public string Metadata { get; set; }
    }
}

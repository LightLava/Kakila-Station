using Robust.Shared.Prototypes;

namespace Content.Shared.Aquila.Settings;

[Prototype]
public sealed partial class AQSettingPrototype : IPrototype
{
    [IdDataField]
    public string ID { get; private set; } = string.Empty;

    /// <summary>
    /// Имя сеттинга
    /// </summary>
    [DataField(required: true)]
    public LocId Name = string.Empty;
}
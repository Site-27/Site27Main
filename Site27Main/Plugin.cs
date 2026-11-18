using Exiled.API.Features;
using Exiled.CreditTags;
using Exiled.CustomItems.API.Features;
using Exiled.Events.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site27Main;

public class Plugin : Plugin<Config>
{
    public override string Name => "Site-27 Main";
    public override string Author => "Axeras & Site-27 Development Team";
    public override Version Version => new Version(1, 0, 0);
    public static Plugin Instance;
    private EventHandlers Events { get; set; }

    public override void OnEnabled()
    {
        Instance = this;
        Events = new EventHandlers();
        Scp096.Enraging += Events.OnEnraging;
        Scp096.CalmingDown += Events.OnCalmingDown;
        Scp096.RemovingTarget += Events.OnRemovingTarget;
        CustomItem.RegisterItems();
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Instance = null;
        Scp096.Enraging -= Events.OnEnraging;
        Scp096.CalmingDown -= Events.OnCalmingDown;
        Scp096.RemovingTarget -= Events.OnRemovingTarget;
        CustomItem.UnregisterItems();
        base.OnDisabled();
    }

}

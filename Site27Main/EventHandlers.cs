using System.Runtime.Remoting.Messaging;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp096;
using Exiled.API.Features;
using PlayerRoles;
using MEC;
using System.Linq;

namespace Site27Main;

public class EventHandlers
{
    //all of the following stuff is currently Only for shyguytoggle. this may or may not become a mess if we ever add more stuff that needs event handlers

    public static bool PermaAngerEnabled { get; set; } = false;

    public void OnEnraging(EnragingEventArgs ev)
    {
        if (PermaAngerEnabled)
            ev.InitialDuration = 999f;
    }

    public void OnCalmingDown(CalmingDownEventArgs ev)
    {
        if (PermaAngerEnabled && ev.Scp096.Targets != null && ev.Scp096.Targets.Count != 0)
            ev.IsAllowed = false;
        else
            ev.IsAllowed = true;
    }

    public void OnRemovingTarget(RemovingTargetEventArgs ev)
    {
        Timing.CallDelayed(Timing.WaitForOneFrame, delegate
        {
            if (!ev.Scp096.TargetsTracker.Targets.Any() && PermaAngerEnabled)
            {
                ev.Scp096.Calm();
            }
        });
    }
}
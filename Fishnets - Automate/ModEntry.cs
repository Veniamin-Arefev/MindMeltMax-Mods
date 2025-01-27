﻿using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishnets.Automate
{
    internal class ModEntry : Mod
    {
        internal static int FishnetId;

        public override void Entry(IModHelper helper)
        {
            if (Helper.ModRegistry.IsLoaded("MindMeltMax.Fishnets") && Helper.ModRegistry.IsLoaded("Pathoschild.Automate"))
            {
                Helper.Events.GameLoop.GameLaunched += (s, e) =>
                {
                    var api = Helper.ModRegistry.GetApi<IAutomateApi>("Pathoschild.Automate");
                    if (api is not null)
                    {
                        api.AddFactory(new FishNetFactory());
                        Monitor.Log("Successfully registered fishnets to automate");
                    }
                    else Monitor.Log("Failed to register fishnets to automate, api couldn't be accessed", LogLevel.Error);
                    var api2 = Helper.ModRegistry.GetApi<IFishnetApi>("MindMeltMax.Fishnets");
                    if (api2 is not null)
                    {
                        FishnetId = api2.GetId();
                        Monitor.Log($"Successfully obtained fishnet id, (id: {FishnetId})");
                    }
                    else Monitor.Log("Failed to obtain fishnet id, api couldn't be accessed", LogLevel.Error);
                };
            }
            else Monitor.Log("A requirement was not loaded, mod will not be loaded", LogLevel.Error);
        }
    }
}

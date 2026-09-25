using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("Monument Blocker Remover", "insoulglobal", "0.1.0")]
    [Description("Deletes Facepunch monument blockers (Breach and Clear, Sept 2026) on wipe")]
    public class MonumentBlockerRemover : RustPlugin
    {
        private void OnServerInitialized(bool warmup)
        {
            Puts(RemoveAll());
        }

        private string RemoveAll()
        {
            // Snapshot list: Kill mutates serverEntities mid-enumeration.
            var blockers = new List<MonumentBlocker>();
            foreach (BaseNetworkable entity in BaseNetworkable.serverEntities)
            {
                if (entity is MonumentBlocker)
                {
                    blockers.Add((MonumentBlocker)entity);
                }
            }

            foreach (MonumentBlocker blocker in blockers)
            {
                blocker.Kill(BaseNetworkable.DestroyMode.None);
            }

            return blockers.Count > 0
                ? $"Removed {blockers.Count} monument blocker(s)"
                : "No monument blockers present";
        }
    }
}

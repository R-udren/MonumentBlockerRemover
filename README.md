# Monument Blocker Remover

Oxide plugin for Rust. Deletes all **monument blockers** (Facepunch "Breach and Clear" update, 2026-09-03) when the server finishes initializing, so red keycard puzzle rooms at top-tier monuments open like before the update.

## Features

- Removes every `MonumentBlocker` entity on server start - both the high-HP barricades and the weak melee-destroyable props
- Wipe-scoped by design: removal is saved with the map, so it runs once per wipe. Fresh wipe respawns blockers only for them to be removed again at boot
- Targets the `MonumentBlocker` entity class, not prefab names - new blocker prefabs Facepunch adds in future updates are removed too, no plugin update required
- Zero configuration, zero commands, zero permissions

## Installation

Copy `MonumentBlockerRemover.cs` into your framework's plugin folder:

- **Oxide/uMod**: `oxide/plugins/`
- **Carbon**: `carbon/plugins/`

The plugin compiles and loads automatically on both frameworks (verified on Oxide v2.0.7726 and Carbon 2.0.259.0).

## Notes for server owners

- After boot, check the Oxide log for `Removed N monument blocker(s)` to confirm
- Facepunch's built-in `printmonumentblocker` console command (run as a player) dumps any blockers that remain
- Unloading the plugin does not respawn already-removed blockers - Facepunch despawns them permanently for the wipe once destroyed. Remove the plugin before a wipe if you want blockers on the next map

## License

[MIT](LICENSE)

# Monument Blocker Remover

Oxide plugin for Rust. Deletes all **monument blockers** (Facepunch "Breach and Clear" update, 2026-09-03) when the server finishes initializing, so red keycard puzzle rooms at top-tier monuments open like before the update.

## Features

- Removes every `MonumentBlocker` entity on server start - both the high-HP barricades and the weak melee-destroyable props
- Wipe-scoped by design: removal is saved with the map, so it runs once per wipe. Fresh wipe respawns blockers only for them to be removed again at boot
- Targets the `MonumentBlocker` entity class, not prefab names - new blocker prefabs Facepunch adds in future updates are removed too, no plugin update required
- Zero configuration, zero commands, zero permissions

## Installation

Copy `MonumentBlockerRemover.cs` into your server's `oxide/plugins/` folder. Oxide compiles and loads it automatically.

## Configuration

None. The plugin has a single behavior and nothing worth tuning.

## Commands

None.

## Permissions

None. The plugin runs server-side on startup and never interacts with players.

## Notes for server owners

- After boot, check the Oxide log for `Removed N monument blocker(s)` to confirm
- Facepunch's built-in `printmonumentblocker` console command (run as a player) dumps any blockers that remain
- Unloading the plugin does not respawn already-removed blockers - Facepunch despawns them permanently for the wipe once destroyed. Remove the plugin before a wipe if you want blockers on the next map

## Technical details

- `MonumentBlocker` is a `StagedResourceEntity` that spawns with map generation and is serialized into the save file; it never respawns mid-wipe once destroyed
- Entities are snapshotted into a list before killing, since `Kill` mutates `BaseNetworkable.serverEntities` during enumeration
- Verified against Rust build 25454815 (September 2026), Oxide v2.0.7726

## License

[MIT](LICENSE)

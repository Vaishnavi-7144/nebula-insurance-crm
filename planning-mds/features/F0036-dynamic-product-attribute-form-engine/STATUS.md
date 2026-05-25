# F0036: Form Engine and Form-State Preservation Status

**Overall Status:** Phase A draft pending approval
**Created:** 2026-05-25
**Last Updated:** 2026-05-25
**Priority:** High

> Folder slug remains `F0036-dynamic-product-attribute-form-engine` for link stability; the feature title was broadened on 2026-05-25 (see scope revision below).

## Origin

F0036 was created after a review of the archived F0035 found that its form-state preservation layer is wired to zero forms. Root-cause analysis traced this to ADR-021 drift: ADR-021 (Accepted, 2026-05-06) specified a React Hook Form + AJV + widget-registry engine for F0034's `DynamicAttributePanel`, but F0034 shipped a hardcoded Cyber panel with none of it, and `react-hook-form`/`ajv` were never added as dependencies. F0036 realizes the ADR-021 engine for LOB product attributes (Cyber first), and — per the 2026-05-25 scope revision — also migrates the hand-rolled CRUD forms to RHF and registers them with F0035, fully closing F0035 finding #1.

**Scope decisions (operator, 2026-05-25):**
- Engine depth: **Full ADR-021 engine** (RHF + AJV + schema-driven widget registry), not RHF-adoption-only.
- Form coverage (initial): LOB product attributes only.
- **Form coverage (revised 2026-05-25):** **Product attributes + the hand-rolled CRUD forms.** Operator asked to fold the remaining gap fix into F0036 so finding #1 is fully closed. CRUD forms get RHF + F0035 preservation but **not** the AJV/widget-registry schema engine (they are fixed-shape). Organized as two workstreams (A: product-attribute engine; B: CRUD form migration + preservation).

## Planning Checklist

- [x] Feature registered in trackers (REGISTRY, ROADMAP) (2026-05-25)
- [x] Minimal PRD created (2026-05-25)
- [ ] PRD enriched / Phase A clarification gate resolved
- [ ] Product stories defined and colocated (S0001–S0006 proposed in PRD)
- [ ] Phase A user approval (A1)
- [ ] Architecture review (Phase B) — reconcile/extend ADR-021; decide on F0035-integration ADR
- [ ] Security review scoped
- [ ] Implementation plan approved (feature-assembly-plan.md, owned by feature action Step 0)

## Story Checklist (proposed)

| Story | Title | Status |
|-------|-------|--------|
| F0036-S0001 | Adopt RHF + AJV dependencies and engine skeleton + widget-registry contract | [ ] Not started |
| F0036-S0002 | MVP widget vocabulary with theme + a11y coverage | [ ] Not started |
| F0036-S0003 | Schema-driven rendering + AJV client validation with backend parity (Cyber) | [ ] Not started |
| F0036-S0004 | Pin-during-edit binding to (productVersionId, stage) | [ ] Not started |
| F0036-S0005 | Replace hardcoded Cyber DynamicAttributePanel (five-screen regression) | [ ] Not started |
| F0036-S0006 | Wire product-attribute form into F0035 dirty-form registry + restore | [ ] Not started |
| F0036-S0007 | Shared preservation registration helper + migrate CRUD forms to RHF (Workstream B) | [ ] Not started |
| F0036-S0008 | Register migrated CRUD forms with F0035 + restore; close S0003 Contact Edit scenario | [ ] Not started |

## Known Current-State Anchors (verified 2026-05-25)

- `experience/package.json` has no `react-hook-form`, `ajv`, `ajv-formats`, or `ajv-errors`.
- `experience/src/features/lob-attributes/components/DynamicAttributePanel.tsx` is a hardcoded Cyber panel (controlled `value`/`onChange`/`errors`, lifted state); `useCyberSchemaBundle` is used only for a status string.
- Consuming screens: `CreateSubmissionPage`, `CreatePolicyPage`, `PolicyDetailPage`, `RenewalDetailPage`, `SubmissionDetailPage`.
- Backend contracts available: `LobSchemaBundle` entity, `planning-mds/schemas/lob-schema-bundle.schema.json`, Cyber `cyber/1.0.0` bundle (F0034).
- F0035 integration surface: `experience/src/features/session-continuity/` — `useSessionRestorableForm`, `dirtyFormRegistry`, `consumeFormSnapshot` (currently unused by any form).

## Out of Scope

- Putting CRUD forms through the AJV/widget-registry schema engine (they are fixed-shape; RHF for field state only).
- Heavy widgets beyond the ADR-021 MVP vocabulary.
- New LOBs beyond Cyber; backend registry/entity/schema changes.
- Non-mutation/filter-only forms with no in-flight state worth preserving (confirmed at Phase A form inventory).

## Tracker Sync Checklist

- [x] `planning-mds/features/REGISTRY.md` — F0036 added; Next Available bumped to F0037
- [x] `planning-mds/features/ROADMAP.md` — F0036 added to `Now`
- [ ] `planning-mds/features/STORY-INDEX.md` — regenerate when stories are colocated (G2)
- [ ] `planning-mds/BLUEPRINT.md` — add F0036 under Platform Foundation when approved

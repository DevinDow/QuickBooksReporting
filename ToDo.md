# ToDo

- horizontal scrolling of ListBoxes
- generate Reports
- read multiple years' CSV files

## Design Decisions

### Mapping Company Names
- currently fills lstMappedNames then calls fillUnmappedNames() & fillLineItems()
- Theoretically a second Mapping CSV could be loaded on top of the first.  Do we need a way to clear the current mappings?

## Mapping Items
- 
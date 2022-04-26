# Search

Reference: https://developer.spotify.com/documentation/web-api/reference/#/operations/search

Query:
- q (string)
- type (array of strings)
e.g. "track,artist"
- include_external (string)
- limit (int)
- market (string)
- offset (integer)

### Response
- tracks (object)
- artists (object)
- albums (object)
- playlists (object)
- shows (object)
- episodes (object)

Object schema:
- href (string)
- items (array of type of object above)
- limit (integer)
- next (string)
- offset (integer)
- previous (string)
- total (integer)

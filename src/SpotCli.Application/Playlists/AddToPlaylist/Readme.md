﻿# Add to Playlist

Reference: https://developer.spotify.com/documentation/web-api/reference/#/operations/add-tracks-to-playlist

Params:
- playlist_id

Query:
- position (integer)
- uris (string; comma delimited) *preferred to pass via body

Body:
- uris (array of strings)
- position (integer)
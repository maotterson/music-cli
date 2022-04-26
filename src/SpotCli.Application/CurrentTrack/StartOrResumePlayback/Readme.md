# Start or Resume Playback

Reference: https://developer.spotify.com/documentation/web-api/reference/#/operations/start-a-users-playback

Query:
- device_id (string)

Body:
- context_uri (string)
- uris (array of strings)
- offset (additionalproperties object)
- position_ms (integer)
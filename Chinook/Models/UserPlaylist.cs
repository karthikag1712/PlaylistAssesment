﻿using System.ComponentModel.DataAnnotations;

namespace Chinook.Models;

public class UserPlaylist
{
    public string UserId { get; set; }
    public long PlaylistId { get; set; }
    public ChinookUser User { get; set; }
    public Playlist Playlist { get; set; }
    public long TrackId { get; set; }
    public Track Track { get; set; }
}

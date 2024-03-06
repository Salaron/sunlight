using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[Table("live_setting_m")]
public partial class LiveSettingM
{
    [Key]
    [Column("live_setting_id")]
    public int LiveSettingId { get; set; }

    [Column("live_track_id")]
    public int LiveTrackId { get; set; }

    [Column("difficulty")]
    public int Difficulty { get; set; }

    [Column("stage_level")]
    public int StageLevel { get; set; }

    [Column("attribute_icon_id")]
    public int AttributeIconId { get; set; }

    [Required]
    [Column("live_icon_asset")]
    public string LiveIconAsset { get; set; }

    [Column("live_icon_asset_en")]
    public string LiveIconAssetEn { get; set; }

    [Column("asset_movie_id")]
    public int? AssetMovieId { get; set; }

    [Column("asset_background_id")]
    public int AssetBackgroundId { get; set; }

    [Required]
    [Column("notes_setting_asset")]
    public string NotesSettingAsset { get; set; }

    [Column("notes_setting_asset_en")]
    public string NotesSettingAssetEn { get; set; }

    [Column("c_rank_score")]
    public int CRankScore { get; set; }

    [Column("b_rank_score")]
    public int BRankScore { get; set; }

    [Column("a_rank_score")]
    public int ARankScore { get; set; }

    [Column("s_rank_score")]
    public int SRankScore { get; set; }

    [Column("c_rank_combo")]
    public int CRankCombo { get; set; }

    [Column("b_rank_combo")]
    public int BRankCombo { get; set; }

    [Column("a_rank_combo")]
    public int ARankCombo { get; set; }

    [Column("s_rank_combo")]
    public int SRankCombo { get; set; }

    [Column("ac_flag")]
    public int AcFlag { get; set; }

    [Column("swing_flag")]
    public int SwingFlag { get; set; }

    [Column("lane_count")]
    public int LaneCount { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}

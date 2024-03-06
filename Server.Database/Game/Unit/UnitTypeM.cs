using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_type_m")]
public partial class UnitTypeM
{
    [Key]
    [Column("unit_type_id")]
    public int UnitTypeId { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Column("name_en")]
    public string NameEn { get; set; }

    [Required]
    [Column("speaker_name")]
    public string SpeakerName { get; set; }

    [Column("speaker_name_en")]
    public string SpeakerNameEn { get; set; }

    [Column("asset_background_id")]
    public int? AssetBackgroundId { get; set; }

    [Column("image_button_asset")]
    public string ImageButtonAsset { get; set; }

    [Column("image_button_asset_en")]
    public string ImageButtonAssetEn { get; set; }

    [Required]
    [Column("background_color")]
    public string BackgroundColor { get; set; }

    [Column("background_color_en")]
    public string BackgroundColorEn { get; set; }

    [Column("name_image_asset")]
    public string NameImageAsset { get; set; }

    [Column("name_image_asset_en")]
    public string NameImageAssetEn { get; set; }

    [Column("album_series_name_image_asset")]
    public string AlbumSeriesNameImageAsset { get; set; }

    [Column("album_series_name_image_asset_en")]
    public string AlbumSeriesNameImageAssetEn { get; set; }

    [Column("skit_icon_asset")]
    public string SkitIconAsset { get; set; }

    [Column("named_skit_icon_asset")]
    public string NamedSkitIconAsset { get; set; }

    [Column("named_skit_icon_asset_en")]
    public string NamedSkitIconAssetEn { get; set; }

    [Column("name_plate_icon_asset")]
    public string NamePlateIconAsset { get; set; }

    [Required]
    [Column("age")]
    public string Age { get; set; }

    [Column("age_en")]
    public string AgeEn { get; set; }

    [Column("birthday")]
    public string Birthday { get; set; }

    [Column("birthday_en")]
    public string BirthdayEn { get; set; }

    [Column("school")]
    public string School { get; set; }

    [Column("school_en")]
    public string SchoolEn { get; set; }

    [Column("hobby")]
    public string Hobby { get; set; }

    [Column("hobby_en")]
    public string HobbyEn { get; set; }

    [Column("blood_type")]
    public string BloodType { get; set; }

    [Column("blood_type_en")]
    public string BloodTypeEn { get; set; }

    [Column("height")]
    public string Height { get; set; }

    [Column("height_en")]
    public string HeightEn { get; set; }

    [Column("three_size")]
    public string ThreeSize { get; set; }

    [Column("three_size_en")]
    public string ThreeSizeEn { get; set; }

    [Column("member_category")]
    public int MemberCategory { get; set; }

    [Column("cv")]
    public string Cv { get; set; }

    [Column("cv_en")]
    public string CvEn { get; set; }

    [Column("original_attribute_id")]
    public int? OriginalAttributeId { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
